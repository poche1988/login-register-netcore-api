namespace Repository
{
    public interface IUnitOfWork
    {
        void CommitChanges();
    }
}
