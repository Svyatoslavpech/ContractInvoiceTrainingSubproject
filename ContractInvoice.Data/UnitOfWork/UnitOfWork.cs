using ContractInvoice.Data.Contexts;
using ContractInvoice.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContractInvoiceDbContext context;
        public UnitOfWork(ContractInvoiceDbContext context)
        {
            this.context = context;

            Work = new WorkRepository(this.context);

            Project = new ProjectRepository(this.context);

            ContractInvoiceUser = new ContractInvoiceUserRepository(this.context);
        }
        public IWorkRepository Work { get; private set; }

        public IProjectRepository Project { get; private set; }

        public IContractInvoiceUserRepository ContractInvoiceUser { get; private set; }

        public int Complete()
        {
            return this.context.SaveChanges();
        }
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}