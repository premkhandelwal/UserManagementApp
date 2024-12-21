using Crm.Api.Models.Quotation;
using Crm.Tenant.Data.Models.PurchaseOrder;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update;

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

        public async Task<int?> Create(CreatePurchaseOrderRequest request)
        {
            PurchaseOrderFieldsModel? purchaseOrderFields = await _purchaseOrderFields.CreateAsync(request.purchaseOrderFields);
            List<PurchaseOrderItemModel> purchaseOrderItems = new List<PurchaseOrderItemModel> { };
            if (purchaseOrderFields != null && purchaseOrderFields.Id != null)
            {
                foreach (var item in request.purchaseOrderItems)
                {
                    item.PurchaseOrderId = purchaseOrderFields.Id;
                    PurchaseOrderItemModel? savedItem = await _purchaseOrderItems.CreateAsync(item);
                    if (savedItem != null)
                    {
                        purchaseOrderItems.Add(savedItem);
                    }
                }
                request.purchaseOrderTerms.PurchaseOrderId = purchaseOrderFields.Id;
                PurchaseOrderTermsModel? purchaseOrderTerms = await _purchaseOrderTerms.CreateAsync(request.purchaseOrderTerms);
                return purchaseOrderFields.Id;
            }
            return -1;
        }

        public async Task<int> Update(UpdatePurchaseOrderRequest request)
        {
            PurchaseOrderFieldsModel? purchaseOrderFields = await _purchaseOrderFields.UpdateAsync(request.purchaseOrderFields);
            List<PurchaseOrderItemModel> purchaseOrderItems = new List<PurchaseOrderItemModel> { };
            if (purchaseOrderFields != null && purchaseOrderFields.Id != null)
            {
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
                return (int)purchaseOrderFields.Id;
            }
            return -1;
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
