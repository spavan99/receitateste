using MyKitchen.Model;

namespace MyKitchen.Repository.Interface
{
    public interface ICategoryRepository
    {
        Category Create(Category category);
        Category Retrieve(int id);
        List<Category> RetrieveAll();
        Category Update(Category category);
        void Delete(int id);
    }
}
