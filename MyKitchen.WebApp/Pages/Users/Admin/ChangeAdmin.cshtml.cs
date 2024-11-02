using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyKitchen.Model;
using MyKitchen.Service.Interface;
using System.Text.Json;

namespace MyKitchen.WebApp.Pages.Users.Admin
{
    public class ChangeAdminModel : PageModel
    {
        private readonly IUserService _service;
        public User User { get; set; }

        public ChangeAdminModel(IUserService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            GetSession();
            User userToUpdate = _service.Retrieve(id);
            userToUpdate.IsAdmin = !userToUpdate.IsAdmin;
            _service.Update(userToUpdate);
            return Redirect("/users/admin/retrieveall"); 

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
