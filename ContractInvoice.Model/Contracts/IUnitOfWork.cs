using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractInvoice.Model.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IWorkRepository Work { get; }

        IProjectRepository Project { get; }

        IContractInvoiceUserRepository ContractInvoiceUser { get; }
        int Complete();

    }
}