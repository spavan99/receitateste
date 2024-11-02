using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyKitchen.Model;
using MyKitchen.Service.Interface;
using System.Text.Json;

namespace MyKitchen.WebApp.Pages.Categories
{
    public class RetrieveAllModel : PageModel
    {
        private readonly ICategoryService _service;

        public RetrieveAllModel(ICategoryService service)
        {
            _service = service;
        }

        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }

        public void OnGet()
        {
            GetSession();
            Categories = _service.RetrieveAll();
        }

        public IActionResult OnPost()
        {
            GetSession();
            Category category = new Category();
            category.Name = Convert.ToString(Request.Form["name"]);

            _service.Create(category);
            return Redirect("/categories/retrieveall");
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
