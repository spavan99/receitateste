using MyKitchen.Model;

namespace MyKitchen.Service.Interface
{
    public interface IUserService
    {
        User Create(User type);
        User Retrieve(int id);
        List<User> RetrieveAll();
        User Update(User type);
        void Delete(int id);

        User DoLogin(string username, string password);
    }
}
