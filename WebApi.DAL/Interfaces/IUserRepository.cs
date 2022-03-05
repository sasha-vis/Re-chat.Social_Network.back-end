namespace WebApi.DAL.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        public IEnumerable<T> GetList();
        public T GetItem(string userName);
    }
}