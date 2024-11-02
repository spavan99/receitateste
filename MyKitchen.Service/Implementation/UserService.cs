using MyKitchen.Model;
using MyKitchen.Repository.Interface;
using MyKitchen.Service.Interface;

namespace MyKitchen.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository _repository)
        {
            this._repository = _repository;
        }

        public User Create(User user)
        {
            return _repository.Create(user);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public User DoLogin(string username, string password)
        {
            return _repository.DoLogin(username, password);
        }

        public User Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<User> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public User Update(User user)
        {
            return _repository.Update(user);
        }
    }
}
