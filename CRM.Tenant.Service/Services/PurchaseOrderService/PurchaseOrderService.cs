using Crm.Tenant.Data.Models.PurchaseOrder;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update.UpdatePurchaseOrderFields;

namespace CRM.Tenant.Service.Services.PurchaseOrderService
{
    public class PurchaseOrderService
    {
        PurchaseOrderFieldsService _purchaseOrderFields;
        PurchaseOrderItemsService _purchaseOrderItems;
        PurchaseOrderTermsService _purchaseOrderTerms;

        public PurchaseOrderService(PurchaseOrderFieldsService purchaseOrderFields,
        PurchaseOrderItemsService purchaseOrderItems, PurchaseOrderTermsService purchaseOrderTerms)
        {
            _purchaseOrderFields = purchaseOrderFields;
            _purchaseOrderItems = purchaseOrderItems;
            _purchaseOrderTerms = purchaseOrderTerms;
        }
        private (int currentYear, int financialYearStart, int financialYearEnd) GetFinancialYearInfo()
        {
            int currentYear = DateTime.Now.Year;
            int financialYearStart = DateTime.Now.Month < 4 ? currentYear - 1 : currentYear;
            int financialYearEnd = financialYearStart + 1;

            return (currentYear, financialYearStart, financialYearEnd);
        }

        private async Task<int> GetCurrentFinancialYearPurchaseOrderCount()
        {
            var (_, financialYearStart, financialYearEnd) = GetFinancialYearInfo();

            // Get all purchase orders created in the current financial year
            var allPurchaseOrders = await _purchaseOrderFields.ReadAsync();

            return allPurchaseOrders.Count(q =>
                q.AddedOn >= new DateTime(financialYearStart, 4, 1) &&
                q.AddedOn < new DateTime(financialYearEnd, 4, 1));
        }

        private string GeneratePurchaseOrderId(int sequenceNumber)
        {
            var (_, financialYearStart, financialYearEnd) = GetFinancialYearInfo();
            return $"ATF/PO/{financialYearStart % 100}-{financialYearEnd % 100}/{sequenceNumber}";
        }

        public async Task<object> Create(CreatePurchaseOrderRequest request)
        {
            // Get count before creating to get the sequence number
            int currentCount = await GetCurrentFinancialYearPurchaseOrderCount();

            PurchaseOrderFieldsModel? purchaseOrderFields = await _purchaseOrderFields.CreateAsync(request.purchaseOrderFields);
            List<PurchaseOrderItemModel> purchaseOrderItems = new List<PurchaseOrderItemModel>();

            if (purchaseOrderFields != null && purchaseOrderFields.Id != null)
            {
                // Generate ID with count + 1 (since we're adding a new one)
                purchaseOrderFields.PurchaseOrderId = GeneratePurchaseOrderId(currentCount + 1);

                foreach (var item in request.purchaseOrderItems)
                {
                    item.PurchaseOrderId = purchaseOrderFields.Id;
                    PurchaseOrderItemModel? savedItem = await _purchaseOrderItems.CreateAsync(item);
                    if (savedItem != null)
                    {
                        purchaseOrderItems.Add(savedItem);
                    }
                }

                UpdatePurchaseOrderFieldsRequest updReq = new UpdatePurchaseOrderFieldsRequest
                {
                    Id = purchaseOrderFields.Id,
                    PurchaseOrderId = purchaseOrderFields.PurchaseOrderId,
                    AddedOn = DateTime.Now,
                    Discount = request.purchaseOrderFields.Discount,
                    DiscountType = request.purchaseOrderFields.DiscountType,
                    GrandTotal = request.purchaseOrderFields.GrandTotal,
                    GstAmount = request.purchaseOrderFields.GstAmount,
                    GstPercent = request.purchaseOrderFields.GstPercent,
                    ModifiedOn = DateTime.Now,
                    NetTotal = request.purchaseOrderFields.NetTotal,
                    OtherCharges = request.purchaseOrderFields.OtherCharges,
                    PurchaseOrderAssignedToId = request.purchaseOrderFields.PurchaseOrderAssignedToId,
                    PurchaseOrderAttentionId = request.purchaseOrderFields.PurchaseOrderAttentionId,
                    PurchaseOrderDate = request.purchaseOrderFields.PurchaseOrderDate,
                    PurchaseOrderMadeById = request.purchaseOrderFields.PurchaseOrderMadeById,
                    PurchaseOrderVendorId = request.purchaseOrderFields.PurchaseOrderVendorId
                };
                await _purchaseOrderFields.UpdateAsync(updReq);

                request.purchaseOrderTerms.PurchaseOrderId = purchaseOrderFields.Id;
                PurchaseOrderTermsModel? purchaseOrderTerms = await _purchaseOrderTerms.CreateAsync(request.purchaseOrderTerms);
                return new
                {
                    purchaseOrderFields.PurchaseOrderId
                };
            }
            return new { Message = "Failed to create purchase order." };
        }

        public async Task<object> Update(UpdatePurchaseOrderRequest request)
        {
            if (request.purchaseOrderFields.PurchaseOrderId == "" && request.purchaseOrderFields.Id != null)
            {
                // For existing POs, we'll keep their original sequence number
                var existingPo = _purchaseOrderFields.GetById((int)request.purchaseOrderFields.Id);
                if (existingPo != null && existingPo.PurchaseOrderId != null)
                {
                    request.purchaseOrderFields.PurchaseOrderId = existingPo.PurchaseOrderId;
                }
                else
                {
                    // If for some reason PO doesn't have an ID, generate a new one
                    int currentCount = await GetCurrentFinancialYearPurchaseOrderCount();
                    request.purchaseOrderFields.PurchaseOrderId = GeneratePurchaseOrderId(currentCount + 1);
                }
            }

            PurchaseOrderFieldsModel? purchaseOrderFields = await _purchaseOrderFields.UpdateAsync(request.purchaseOrderFields);
            List<PurchaseOrderItemModel> purchaseOrderItems = new List<PurchaseOrderItemModel>();

            if (purchaseOrderFields != null && purchaseOrderFields.Id != null)
            {
                foreach (var item in request.purchaseOrderItems)
                {
                    item.PurchaseOrderId = purchaseOrderFields.Id;
                    PurchaseOrderItemModel? savedItem = item.Id == null
                        ? await _purchaseOrderItems.CreateAsync(item)
                        : await _purchaseOrderItems.UpdateAsync(item);

                    if (savedItem != null)
                    {
                        purchaseOrderItems.Add(savedItem);
                    }
                }

                request.purchaseOrderTerms.PurchaseOrderId = purchaseOrderFields.Id;
                PurchaseOrderTermsModel? purchaseOrderTerms = await _purchaseOrderTerms.UpdateAsync(request.purchaseOrderTerms);

                return new
                {
                    purchaseOrderFields.PurchaseOrderId
                };
            }
            return new { Message = "Failed to update purchase order." };
        }

        public async Task<object> Delete(DeletePurchaseOrderRequest request)
        {
            if (request.purchaseOrderFields == null)
            {
                return new { Message = "Purchase order fields cannot be null." };
            }
            PurchaseOrderFieldsModel? purchaseOrderFields = await _purchaseOrderFields.UpdateAsync(request.purchaseOrderFields);

            if (purchaseOrderFields == null || purchaseOrderFields.Id == null)
            {
                return new { Message = "Failed to delete purchase order fields." };
            }

            // Soft delete PurchaseOrderItems
            if (request.purchaseOrderItems != null && request.purchaseOrderItems.Any())
            {
                foreach (var item in request.purchaseOrderItems)
                {
                    await _purchaseOrderItems.UpdateAsync(item);
                }
            }

            // Soft delete PurchaseOrderTerms
            if (request.purchaseOrderTerms != null)
            {
                await _purchaseOrderTerms.UpdateAsync(request.purchaseOrderTerms);
            }

            return new { Message = "Purchase order deleted successfully." };
        }

        public async Task<List<PurchaseOrderModel>> Get()
        {
            List<PurchaseOrderModel> result = new List<PurchaseOrderModel>();
            List<PurchaseOrderFieldsModel> purchaseOrderFields = await _purchaseOrderFields.ReadAsync();
            List<PurchaseOrderItemModel> purchaseOrderItems = await _purchaseOrderItems.ReadAsync();
            List<PurchaseOrderTermsModel> purchaseOrderTerms = await _purchaseOrderTerms.ReadAsync();
            foreach (var purchaseOrder in purchaseOrderFields)
            {
                int? id = purchaseOrder.Id;
                if (id != null)
                {
                    List<PurchaseOrderItemModel> qItems = purchaseOrderItems.Where(item => item.PurchaseOrderId == id).ToList();
                    PurchaseOrderTermsModel? qTerms = purchaseOrderTerms.Where((item) => item.PurchaseOrderId == id).FirstOrDefault();
                    result.Add(new PurchaseOrderModel()
                    {
                        purchaseOrderFields = purchaseOrder,
                        purchaseOrderItems = qItems,
                        purchaseOrderTerms = qTerms ?? new PurchaseOrderTermsModel()

                    });
                }
            }
            return result;
        }

        public async Task<PurchaseOrderModel?> GetPurchaseOrderById(int id)
        {
            PurchaseOrderModel result = new PurchaseOrderModel();

            PurchaseOrderFieldsModel? purchaseOrder = _purchaseOrderFields.GetById(id);
            List<PurchaseOrderItemModel> purchaseOrderItems = await _purchaseOrderItems.ReadAsync();
            List<PurchaseOrderTermsModel> purchaseOrderTerms = await _purchaseOrderTerms.ReadAsync();
            if (purchaseOrder != null)
            {
                int? qId = purchaseOrder.Id;
                if (qId != null)
                {
                    List<PurchaseOrderItemModel> qItems = purchaseOrderItems.Where(item => item.PurchaseOrderId == qId).ToList();
                    PurchaseOrderTermsModel? qTerms = purchaseOrderTerms.Where(item => item.PurchaseOrderId == qId).FirstOrDefault();
                    return new PurchaseOrderModel()
                    {
                        purchaseOrderFields = purchaseOrder,
                        purchaseOrderItems = qItems,
                        purchaseOrderTerms = qTerms ?? new PurchaseOrderTermsModel()
                    };
                }
            }


            return null;
        }

        public async Task<List<PurchaseOrderModel>> GetPurchaseOrdersForUser(int userId)
        {
            List<PurchaseOrderModel> result = new List<PurchaseOrderModel>();

            // Fetch all relevant data
            List<PurchaseOrderFieldsModel> purchaseOrderFields = await _purchaseOrderFields.ReadAsync();
            List<PurchaseOrderItemModel> purchaseOrderItems = await _purchaseOrderItems.ReadAsync();
            List<PurchaseOrderTermsModel> purchaseOrderTerms = await _purchaseOrderTerms.ReadAsync();

            // Filter purchaseOrders where userId matches the creator or assignee
            var userPurchaseOrders = purchaseOrderFields
                .Where(q => q.PurchaseOrderAssignedToId == userId || q.PurchaseOrderMadeById == userId);

            foreach (var purchaseOrder in userPurchaseOrders)
            {
                int? id = purchaseOrder.Id;
                if (id != null)
                {
                    List<PurchaseOrderItemModel> qItems = purchaseOrderItems.Where(item => item.PurchaseOrderId == id).ToList();
                    PurchaseOrderTermsModel? qTerms = purchaseOrderTerms.Where(item => item.PurchaseOrderId == id).FirstOrDefault();
                    result.Add(new PurchaseOrderModel()
                    {
                        purchaseOrderFields = purchaseOrder,
                        purchaseOrderItems = qItems,
                        purchaseOrderTerms = qTerms ?? new PurchaseOrderTermsModel()
                    });
                }
            }

            return result;
        }

        
    }
}
