using MyKitchen.Model;
using MyKitchen.Repository.Interface;
using MyKitchen.Service.Interface;
using System.Collections.Generic;

namespace MyKitchen.Service.Implementation
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _repository;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;

        public RecipeService(IRecipeRepository repository, IUserService userService, ICategoryService categoryService)
        {
            _repository = repository;
            _userService = userService;
            _categoryService = categoryService;
        }

        public Recipe Create(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Recipe Retrieve(int id)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> RetrieveAll()
        {
            List<Recipe> recipes = _repository.RetrieveAll();
            foreach (Recipe recipe in recipes)
            {
                recipe.Owner = _userService.Retrieve(recipe.Owner.Id);
                recipe.Category = _categoryService.Retrieve(recipe.Category.Id);
                recipe.Difficulty.Name = "Easy";
            }
            return recipes;
        }

        public Recipe Update(Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
