using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyKitchen.Model;
using MyKitchen.Service.Interface;
using System.Text.Json;

namespace MyKitchen.WebApp.Pages.Users
{
    public class LoginModel : PageModel
    {

        private readonly IUserService _service;

        public LoginModel(IUserService service)
        {
            _service = service;
        }

        public User User { get; set; }

        public void OnGet()
        {
            GetSession();
        }

        public IActionResult OnPost()
        {
            string username = Convert.ToString(Request.Form["username"]);
            string password = Convert.ToString(Request.Form["password"]);

            User user = _service.DoLogin(username, password);
            SetSessionUser(user);
            return Redirect("/");
        }

        private void SetSessionUser(User user)
        {
            string jsonString = JsonSerializer.Serialize(user);
            HttpContext.Session.SetString("user", jsonString);
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
