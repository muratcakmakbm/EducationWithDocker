using System;

namespace Education.Domain
{
    public interface ITransactionHelper : ITransactionalDispose
    {

    }

    public interface ITransactionalDispose : IDisposable
    {
        void BeginTransaction();
        void Complete();

    }
}
