using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyKitchen.Model;
using MyKitchen.Service.Interface;
using System.Text.Json;

namespace MyKitchen.WebApp.Pages.Categories
{
    public class UpdateModel : PageModel
    {
        private readonly ICategoryService _service;

        public UpdateModel(ICategoryService service)
        {
            _service = service;
        }

        public Category Category { get; set; }

        public void OnGet(int id)
        {
            GetSession();
            Category = _service.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            GetSession();
            Category category = new Category();
            category.Id = Convert.ToInt32(Request.Form["id"]);
            category.Name = Convert.ToString(Request.Form["name"]);
            
            _service.Update(category);
            return Redirect("/categories/retrieveall");
        }

        public User User { get; set; }
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
