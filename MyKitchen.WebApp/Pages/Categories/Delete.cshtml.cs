using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyKitchen.Model;
using MyKitchen.Service.Interface;
using System.Text.Json;

namespace MyKitchen.WebApp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryService _service;

        public DeleteModel(ICategoryService service)
        {
            _service = service;
        }

        
        public IActionResult OnGet(int id)
        {
            GetSession();
            _service.Delete(id);
            return Redirect("/Categories/RetrieveAll");
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
