using CRM.Admin.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;
        public EmailController(EmailService emailService) 
        {
            _emailService = emailService;
        }

        /*[HttpPost("generate-otp")]
        public async Task<IActionResult> GenerateOtp([FromBody] OtpRequest request)
        {
            var otp = GenerateOtp();
            otpStore[request.Email] = otp;
            await SendOtpEmail(request.Email, otp);
            return Ok(new { message = "OTP sent to your email." });
        }*/


    }
}
