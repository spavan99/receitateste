using MyKitchen.Model;

namespace MyKitchen.Service.Interface
{
    public interface ICategoryService
    {
        Category Create(Category category);
        Category Retrieve(int id);
        List<Category> RetrieveAll();
        Category Update(Category category);
        void Delete(int id);
    }
}
