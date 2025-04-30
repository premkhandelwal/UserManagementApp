using Crm.Admin.Data;
using CRM.Admin.Data.Models;

namespace CRM.Admin.Service.Services
{
    public class OtpService
    {
        private readonly AdminDbContext _context;

        public OtpService(AdminDbContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateOtp(string email)
        {
            Random random = new Random();
            string otp =  random.Next(100000, 999999).ToString();
            DateTime expirationTime = DateTime.UtcNow.AddMinutes(5);
            OtpRecord otpRecord = new OtpRecord()
            {
                Email = email,
                ExpirationTime = expirationTime,
                OtpCode = otp,
                
            };
            _context.OtpRecords?.Add(otpRecord);   
            await _context.SaveChangesAsync();
            return otp;
        }

        public async Task<bool> ValidateOtp(string email, string otp)
        {
            OtpRecord? record = _context.OtpRecords?.FirstOrDefault(o => o.Email == email && o.OtpCode == otp && o.IsUsed == false && o.ExpirationTime > DateTime.UtcNow) ;
            if(record != null)
            {
                record.IsUsed = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task CleanupExpiredOtpsAsync()
        {
            var expiredOtps = _context.OtpRecords?.Where(o => o.ExpirationTime <= DateTime.UtcNow);
            if (expiredOtps != null && expiredOtps.Any())
            {
                _context.OtpRecords?.RemoveRange(expiredOtps);
                await _context.SaveChangesAsync();
            }
        }
    }
}
