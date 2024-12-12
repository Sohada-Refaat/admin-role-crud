using AdminRole.Models;

namespace AdminRole.SQLUnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        AdminRoleContext _dbContext;
        public UnitOfWork(AdminRoleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
