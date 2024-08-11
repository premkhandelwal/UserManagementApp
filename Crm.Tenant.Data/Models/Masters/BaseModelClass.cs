using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Tenant.Data.Models.Masters
{
    public class BaseModelClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public DateTime? AddedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
