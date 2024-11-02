using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyKitchen.Model;
using MyKitchen.Service.Interface;
using System.Text.Json;

namespace MyKitchen.WebApp.Pages.Users
{
    public class RegisterModel : PageModel
    {
        private readonly IUserService _service;

        public User User { get; set; }

        public RegisterModel(IUserService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            GetSession();
        }

        private void GetSession()
        {
            string userJSON = HttpContext.Session.GetString("user");
            if (null != userJSON)
            {
                User = JsonSerializer.Deserialize<User>(userJSON);
            }
        }

        public IActionResult OnPost()
        {
            User user = new User();
            user.Username = Convert.ToString(Request.Form["username"]);
            user.Password = Convert.ToString(Request.Form["password"]);
            user.Name = Convert.ToString(Request.Form["name"]);
            user.Email = Convert.ToString(Request.Form["email"]);
            _service.Create(user);

            return Redirect("/users/login");
        }
    }
}
