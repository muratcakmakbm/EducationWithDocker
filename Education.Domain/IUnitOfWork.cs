using System;

namespace Education.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IEducationGroupRepository EducationGroup
        {
            get;
        }
        int SaveChangesAsync();

        ITransactionHelper TransactionHelper
        {
            get;
        }
    }
}
