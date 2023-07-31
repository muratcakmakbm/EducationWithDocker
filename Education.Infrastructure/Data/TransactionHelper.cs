using Education.Domain;
using System;
using System.Transactions;

namespace Education.Infrastructure.Data
{

    public class TransactionHelper : ITransactionHelper
        {
            private TransactionScope _transaction;

            public TransactionHelper()
            {

            }

            public void BeginTransaction()
            {
                if (_transaction == null)
                {
                    _transaction = new TransactionScope(TransactionScopeOption.Required,
                        new TransactionOptions()
                        {
                            IsolationLevel = IsolationLevel.ReadCommitted,
                            Timeout = new TimeSpan(0, 5, 0)
                        });
                    _disposed = false;
                }
                else
                {
                    throw new Exception("Error.ThereIsAlreadyTransaction");
                }
            }

            public void Complete()
            {
                if (_transaction == null)
                    throw new Exception("Error.TransactionIsNull");

                _transaction.Complete();
            }

            bool _disposed = false;
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        _transaction?.Dispose();
                        _transaction = null;
                    }
                }
                _disposed = true;
            }
        }

    
}
