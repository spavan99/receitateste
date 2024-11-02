using MyKitchen.Model;

namespace MyKitchen.Repository.Interface
{
    public interface IRecipeRepository
    {
        Recipe Create(Recipe recipe);
        Recipe Retrieve(int id);
        List<Recipe> RetrieveAll();
        Recipe Update(Recipe recipe);
        void Delete(int id);
    }
}
