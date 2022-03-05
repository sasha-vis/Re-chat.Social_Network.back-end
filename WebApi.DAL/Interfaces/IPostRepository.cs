namespace WebApi.DAL.Interfaces
{
    public interface IPostRepository<T> where T : class
    {
        public IEnumerable<T> GetList();
        public T GetItem(int id);
        public void Create(T item, string userName);
        public void Edit(T item);
        public void Delete(T item);
    }
}
