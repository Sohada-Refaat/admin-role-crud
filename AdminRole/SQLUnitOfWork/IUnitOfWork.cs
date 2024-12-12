namespace AdminRole.SQLUnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        void Dispose();
    }
}
