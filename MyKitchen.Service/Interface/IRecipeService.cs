using MyKitchen.Model;

namespace MyKitchen.Service.Interface
{
    public interface IRecipeService
    {
        Recipe Create(Recipe recipe);
        Recipe Retrieve(int id);
        List<Recipe> RetrieveAll();
        Recipe Update(Recipe recipe);
        void Delete(int id);
    }
}
