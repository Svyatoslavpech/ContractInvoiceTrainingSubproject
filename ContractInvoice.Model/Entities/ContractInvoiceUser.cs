using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractInvoice.Model.Entities
{
    public class ContractInvoiceUser : IdentityUser
    {
        public string NameContractInvoiceUser { get; set; }

        public int PhoneContractInvoiceUser { get; set; }

        public string AdressContractInvoiceUser { get; set; }
    }

}