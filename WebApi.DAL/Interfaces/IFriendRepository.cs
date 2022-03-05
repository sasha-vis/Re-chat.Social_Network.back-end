namespace WebApi.DAL.Interfaces
{
    public interface IFriendRepository<T> where T : class
    {
        List<T> FriendsByUser(string userName);
        List<T> RequareFriendsByUser(string userName);
        List<T> GetAllFriendsByUser(string userName);
        void ResponseToRequareFriendsByUser(T friend);
        void DeleteFriend(T friend);
        public void Create(T friend);


    }
}
