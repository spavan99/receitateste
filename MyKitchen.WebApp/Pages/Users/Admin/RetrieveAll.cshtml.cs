using Microsoft.AspNetCore.Mvc.RazorPages;
using MyKitchen.Model;
using MyKitchen.Service.Interface;
using System.Text.Json;

namespace MyKitchen.WebApp.Pages.Users.Admin
{
    public class RetrieveAllModel : PageModel
    {

        private readonly IUserService _service;
        public User User { get; set; }
        public List<User> Users { get; set; }   

        public RetrieveAllModel(IUserService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            GetSession();
            Users = _service.RetrieveAll();
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
