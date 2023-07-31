using Education.Domain;

namespace Education.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private EducationDbContext context;
        public UnitOfWork(EducationDbContext context)
        {
            this.context = context;
            EducationGroup = new EducationGroupRepository(context);
            TransactionHelper = new TransactionHelper();
        }

        public IEducationGroupRepository EducationGroup
        {
            get;
            private set;
        }
        public ITransactionHelper TransactionHelper
        {
            get;
            private set;
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public int SaveChangesAsync()
        {
            return context.SaveChanges();
        }


    }
}
