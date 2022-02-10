using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractInvoice.Model.Entities
{
    public class Work
    {
        public long Id { get; set; }

        public long ProjectId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedById { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedById { get; set; }

        public int HoursWorked { get; set; }

        public DateTime DateWorked { get; set; }

    }
}