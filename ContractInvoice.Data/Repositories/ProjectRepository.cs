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
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ContractInvoiceDbContext context) : base(context)
        {
        }
    }
}
