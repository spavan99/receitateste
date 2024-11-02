using MyKitchen.Model;
using MyKitchen.Repository.Interface;
using MyKitchen.Service.Interface;

namespace MyKitchen.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public Category Create(Category category)
        {
            if (category.Name.Contains("eixe"))
            {
                throw new Exception("Com 'eixe' não pode!");
            }
            return _repository.Create(category);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Category Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Category> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Category Update(Category category)
        {
            return _repository.Update(category);
        }
    }
}
