﻿using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Hsn.CreateHsn;
using FluentValidation;

namespace CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Hsn.DeleteHsn
{
    public class DeleteHsnValidationService : CreateHsnValidationService<DeleteHsnRequest>
    {
        public DeleteHsnValidationService()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.IsDeleted).NotEmpty().WithMessage("Is Deleted is required.");
        }
    }
}
