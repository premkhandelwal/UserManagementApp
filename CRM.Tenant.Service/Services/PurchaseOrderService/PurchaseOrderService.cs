using Crm.Tenant.Data.Models.PurchaseOrder;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create;
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
        private string GenerateQuotationId(int quotationId)
        {
            int currentYear = DateTime.UtcNow.Year;
            int financialYearStart = DateTime.UtcNow.Month < 4 ? currentYear - 1 : currentYear;
            int financialYearEnd = financialYearStart + 1;

            return $"ATF/{financialYearStart % 100}-{financialYearEnd % 100}/{quotationId}";
        }

        public async Task<object> Create(CreatePurchaseOrderRequest request)
        {
            PurchaseOrderFieldsModel? purchaseOrderFields = await _purchaseOrderFields.CreateAsync(request.purchaseOrderFields);
            List<PurchaseOrderItemModel> purchaseOrderItems = new List<PurchaseOrderItemModel> { };
            if (purchaseOrderFields != null && purchaseOrderFields.Id != null)
            {
                purchaseOrderFields.PurchaseOrderId = GenerateQuotationId((int)purchaseOrderFields.Id);
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
                    AddedOn = DateTime.UtcNow,
                    Discount = request.purchaseOrderFields.Discount,
                    DiscountType = request.purchaseOrderFields.DiscountType,
                    GrandTotal = request.purchaseOrderFields.GrandTotal,
                    GstAmount = request.purchaseOrderFields.GstAmount,
                    GstPercent = request.purchaseOrderFields.GstPercent,
                    ModifiedOn = DateTime.UtcNow,
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
            PurchaseOrderFieldsModel? purchaseOrderFields = await _purchaseOrderFields.UpdateAsync(request.purchaseOrderFields);
            List<PurchaseOrderItemModel> purchaseOrderItems = new List<PurchaseOrderItemModel> { };
            if (purchaseOrderFields != null && purchaseOrderFields.Id != null)
            {
                purchaseOrderFields.PurchaseOrderId = GenerateQuotationId((int)purchaseOrderFields.Id);
                foreach (var item in request.purchaseOrderItems)
                {
                    item.PurchaseOrderId = purchaseOrderFields.Id;
                    PurchaseOrderItemModel? savedItem = null;
                    if (item.Id == null)
                    {
                        savedItem = await _purchaseOrderItems.CreateAsync(item);
                    }
                    else
                    {
                        savedItem = await _purchaseOrderItems.UpdateAsync(item);
                    }
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
