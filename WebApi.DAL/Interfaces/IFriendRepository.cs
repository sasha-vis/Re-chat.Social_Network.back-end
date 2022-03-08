namespace WebApi.DAL.Interfaces
{
    public interface IFriendRepository<T> where T : class
    {
        List<T> FriendsByUser(string userId);
        List<T> RequareFriendsByUser(string userId);
        List<T> GetAllFriendsByUser(string userName);
        void ResponseToRequareFriendsByUser(T friend);
        void DeleteFriend(T friend);
        public void Create(T friend);


    }
}
