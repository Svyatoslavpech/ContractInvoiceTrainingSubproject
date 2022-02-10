using ContractInvoice.Data.Contexts;
using ContractInvoice.Model.Contracts;
using ContractInvoice.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class WorkRepository : GenericRepository<Work>, IWorkRepository
    {
        public WorkRepository(ContractInvoiceDbContext context) : base(context)
        {
        }

    }
}