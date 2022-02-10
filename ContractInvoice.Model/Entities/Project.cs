using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractInvoice.Model.Entities
{
    public class Project
    {
        public long Id { get; set; }

        public string Business { get; set; }

        public long NameProject { get; set; }

        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        public int HoursWorked { get; set; }

        public DateTime DateWorked { get; set; }
    }
}
