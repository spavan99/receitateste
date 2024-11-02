using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyKitchen.Model;
using MyKitchen.Service.Interface;
using System.Text.Json;

namespace MyKitchen.WebApp.Pages.Recipes
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;

        public RetrieveAllModel(IRecipeService recipeService, ICategoryService categoryService)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
        }

        public List<Recipe> Recipes { get; set; }
        public List<Category> Categories { get; set; }
        public Recipe Recipe { get; set; }
        public User User { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        public void OnGet()
        {
            GetSession();
            Recipes = _recipeService.RetrieveAll();
            Categories = _categoryService.RetrieveAll();
        }

        public IActionResult OnPost()
        {
            GetSession();
            Recipe recipe = new Recipe();
            recipe.Name = Convert.ToString(Request.Form["name"]);
            recipe.Description = Convert.ToString(Request.Form["description"]);
            recipe.Owner = User;
            recipe.Category = new Category() { Id = Convert.ToInt32(Request.Form["category"]) };
            recipe.Image = "";

            var file = Image.FileName;
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                Image.CopyToAsync(fileStream);
            }

            return Redirect("/recipes/retrieveall");
        }

        private void GetSession()
        {
            string userJSON = HttpContext.Session.GetString("user");
            if (null != userJSON)
            {
                User = JsonSerializer.Deserialize<User>(userJSON);
            }
        }
    }
}
