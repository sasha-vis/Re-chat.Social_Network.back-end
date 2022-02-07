namespace WebApi.DAL.Interfaces
{
    public interface IUserRepository<T> where T : class
    {
        public IEnumerable<T> GetList();
        //public T GetItem(int id);
        //public void Create(T item);
        //public void Edit(T item);
        //public void Delete(int Id);
    }
}