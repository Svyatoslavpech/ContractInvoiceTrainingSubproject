using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractInvoice.Data.Contexts;
using ContractInvoice.Model.Contracts;
using ContractInvoice.Model.Entities;

namespace Data.Repositories
{
    public class ContractInvoiceUserRepository : GenericRepository<ContractInvoiceUser>, IContractInvoiceUserRepository
    {
        public ContractInvoiceUserRepository(ContractInvoiceDbContext context) : base(context)
        {
        }
    }
}
