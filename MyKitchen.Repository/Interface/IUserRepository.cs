using MyKitchen.Model;

namespace MyKitchen.Repository.Interface
{
    public interface IUserRepository
    {
        User Create(User user);
        User Retrieve(int id);
        List<User> RetrieveAll();
        User Update(User user);
        void Delete(int id);

        User DoLogin(string username, string password);
    }
}
