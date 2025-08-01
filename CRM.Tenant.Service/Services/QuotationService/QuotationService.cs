﻿using Crm.Tenant.Data.Models.Quotation;
using CRM.Tenant.Service.Models.Requests.Quotation.Delete;
using CRM.Tenant.Service.Models.Requests.Quotation;
using CRM.Tenant.Service.Models.Requests.Quotation.Update;
using CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationFields;

namespace CRM.Tenant.Service.Services.QuotationService
{
    public class QuotationService
    {
        QuotationFieldsService _quotationFields;
        QuotationItemsService _quotationItems;
        QuotationTermsService _quotationTerms;

        public QuotationService(QuotationFieldsService quotationFields,
        QuotationItemsService quotationItems, QuotationTermsService quotationTerms)
        {
            _quotationFields = quotationFields;
            _quotationItems = quotationItems;
            _quotationTerms = quotationTerms;
        }

        private (int currentYear, int financialYearStart, int financialYearEnd) GetFinancialYearInfo()
        {
            int currentYear = DateTime.Now.Year;
            int financialYearStart = DateTime.Now.Month < 4 ? currentYear - 1 : currentYear;
            int financialYearEnd = financialYearStart + 1;

            return (currentYear, financialYearStart, financialYearEnd);
        }

        private async Task<int> GetCurrentFinancialYearQuotationCount()
        {
            var (_, financialYearStart, financialYearEnd) = GetFinancialYearInfo();

            // Get all quotations created in the current financial year
            var allQuotations = await _quotationFields.ReadAsync();

            return allQuotations.Count(q =>
                q.QuotationDate >= new DateTime(financialYearStart, 4, 1) &&
                q.QuotationDate < new DateTime(financialYearEnd, 4, 1));
        }

        private string GenerateQuotationId(int quotationId)
        {
            var (_, financialYearStart, financialYearEnd) = GetFinancialYearInfo();
            return $"ATF/{financialYearStart % 100}-{financialYearEnd % 100}/{quotationId}";
        }

        public async Task<object> Create(CreateQuotationRequest request)
        {
            // Get count before creating to get the sequence number
            int currentCount = await GetCurrentFinancialYearQuotationCount();

            QuotationFieldsModel? quotationFields = await _quotationFields.CreateAsync(request.quotationFields);
            List<QuotationItemModel> quotationItems = new List<QuotationItemModel>();

            if (quotationFields != null && quotationFields.Id != null)
            {
                quotationFields.QuotationId = GenerateQuotationId(currentCount + 1);

                foreach (var item in request.quotationItems)
                {
                    item.QuotationId = quotationFields.Id;
                    QuotationItemModel? savedItem = await _quotationItems.CreateAsync(item);
                    if (savedItem != null)
                    {
                        quotationItems.Add(savedItem);
                    }
                }

                UpdateQuotationFieldsRequest updReq = new UpdateQuotationFieldsRequest
                {
                    Id = quotationFields.Id,
                    QuotationId = quotationFields.QuotationId,
                    AddedOn = DateTime.Now,
                    Discount = request.quotationFields.Discount,
                    DiscountType = request.quotationFields.DiscountType,
                    GrandTotal = request.quotationFields.GrandTotal,
                    GstAmount = request.quotationFields.GstAmount,
                    GstPercent = request.quotationFields.GstPercent,
                    ModifiedOn = DateTime.Now,
                    NetTotal = request.quotationFields.NetTotal,
                    OtherCharges = request.quotationFields.OtherCharges,
                    QuotationAssignedToId = request.quotationFields.QuotationAssignedToId,
                    QuotationAttentionId = request.quotationFields.QuotationAttentionId,
                    QuotationCompanyId = request.quotationFields.QuotationCompanyId,
                    QuotationDate = request.quotationFields.QuotationDate,
                    QuotationFollowUpDate = request.quotationFields.QuotationFollowUpDate,
                    QuotationImportance = request.quotationFields.QuotationImportance,
                    QuotationMadeById = request.quotationFields.QuotationMadeById,
                    QuotationPriority = request.quotationFields.QuotationPriority,
                    QuotationStage = request.quotationFields.QuotationStage,
                    Reference = request.quotationFields.Reference,
                    IsGstRemoved = request.quotationFields.IsGstRemoved,
                    IsRoundOff = request.quotationFields.IsRoundOff
                };
                await _quotationFields.UpdateAsync(updReq);

                request.quotationTerms.QuotationId = quotationFields.Id;
                QuotationTermsModel? quotationTerms = await _quotationTerms.CreateAsync(request.quotationTerms);
                return new
                {
                    quotationFields.Id,
                    quotationFields.QuotationId
                };
            }
            return new { Message = "Failed to create quotation." };
        }

        public async Task<object> Update(UpdateQuotationRequest request)
        {
            QuotationFieldsModel? quotationFields = await _quotationFields.UpdateAsync(request.quotationFields);
            List<QuotationItemModel> quotationItems = new List<QuotationItemModel>();

            if (quotationFields != null && quotationFields.Id != null)
            {
                foreach (var item in request.quotationItems)
                {
                    item.QuotationId = quotationFields.Id;
                    QuotationItemModel? savedItem = item.Id == null
                        ? await _quotationItems.CreateAsync(item)
                        : await _quotationItems.UpdateAsync(item);

                    if (savedItem != null)
                    {
                        quotationItems.Add(savedItem);
                    }
                }

                request.quotationTerms.QuotationId = quotationFields.Id;
                QuotationTermsModel? quotationTerms = await _quotationTerms.UpdateAsync(request.quotationTerms);

                return new
                {
                    quotationFields.QuotationId
                };
            }
            return new { Message = "Failed to update quotation." };
        }

        public async Task<object> Delete(DeleteQuotationRequest request)
        {
            if (request.quotationFields == null)
            {
                return new { Message = "Quotation fields cannot be null." };
            }
            QuotationFieldsModel? quotationFields = await _quotationFields.UpdateAsync(request.quotationFields);

            if (quotationFields == null || quotationFields.Id == null)
            {
                return new { Message = "Failed to delete quotation fields." };
            }

            // Soft delete QuotationItems
            if (request.quotationItems != null && request.quotationItems.Any())
            {
                foreach (var item in request.quotationItems)
                {
                    await _quotationItems.UpdateAsync(item);
                }
            }

            // Soft delete QuotationTerms
            if (request.quotationTerms != null)
            {
                await _quotationTerms.UpdateAsync(request.quotationTerms);
            }

            return new { Message = "Quotation deleted successfully." };
        }

        public async Task<List<QuotationModel>> Get()
        {
            List<QuotationModel> result = new List<QuotationModel>();
           List<QuotationFieldsModel> quotationFields = await _quotationFields.ReadAsync();
           List<QuotationItemModel> quotationItems = await _quotationItems.ReadAsync();
           List<QuotationTermsModel> quotationTerms = await _quotationTerms.ReadAsync();
            foreach (var quotation in quotationFields)
            {
                int? id = quotation.Id;
                if (id != null)
                {
                   List<QuotationItemModel> qItems = quotationItems.Where(item => item.QuotationId == id).ToList();
                    QuotationTermsModel? qTerms = quotationTerms.Where((item) => item.QuotationId == id).FirstOrDefault();
                    result.Add(new QuotationModel() { 
                        quotationFields = quotation,
                        quotationItems = qItems,
                        quotationTerms = qTerms ?? new QuotationTermsModel()
                    
                    });
                }
            }
            return result;
        }

        public async Task<QuotationModel?> GetQuotationById(int id) 
        {
            QuotationModel result = new QuotationModel();

            QuotationFieldsModel? quotation =  _quotationFields.GetById(id);
            List<QuotationItemModel> quotationItems = await _quotationItems.ReadAsync();
            List<QuotationTermsModel> quotationTerms = await _quotationTerms.ReadAsync();
            if (quotation != null)
            {
                int? qId = quotation.Id;
                if (qId != null)
                {
                    List<QuotationItemModel> qItems = quotationItems.Where(item => item.QuotationId == qId).ToList();
                    QuotationTermsModel? qTerms = quotationTerms.Where(item => item.QuotationId == qId).FirstOrDefault();
                    return new QuotationModel()
                    {
                        quotationFields = quotation,
                        quotationItems = qItems,
                        quotationTerms = qTerms ?? new QuotationTermsModel()
                    };
                }
            }
                
            
            return null;
        }

        public async Task<List<QuotationModel>> GetQuotationsForUser(int userId)
        {
            List<QuotationModel> result = new List<QuotationModel>();

            // Fetch all relevant data
            List<QuotationFieldsModel> quotationFields = await _quotationFields.ReadAsync();
            List<QuotationItemModel> quotationItems = await _quotationItems.ReadAsync();
            List<QuotationTermsModel> quotationTerms = await _quotationTerms.ReadAsync();

            // Filter quotations where userId matches the creator or assignee
            var userQuotations = quotationFields
                .Where(q => q.QuotationAssignedToId == userId || q.QuotationMadeById == userId);

            foreach (var quotation in userQuotations)
            {
                int? id = quotation.Id;
                if (id != null)
                {
                    List<QuotationItemModel> qItems = quotationItems.Where(item => item.QuotationId == id).ToList();
                    QuotationTermsModel? qTerms = quotationTerms.Where(item => item.QuotationId == id).FirstOrDefault();
                    result.Add(new QuotationModel()
                    {
                        quotationFields = quotation,
                        quotationItems = qItems,
                        quotationTerms = qTerms ?? new QuotationTermsModel()
                    });
                }
            }

            return result;
        }


    }
}
