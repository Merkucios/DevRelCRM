using DevRelCRM.Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevRelCRM.WebAuth.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public CreateUserCommand Input { get; set; }
        public void OnGet()
        {

        }
    }
}
