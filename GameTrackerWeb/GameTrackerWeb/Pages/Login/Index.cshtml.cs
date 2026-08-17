using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameTrackerWeb.Pages.Login
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            if (Username == "admin" &&
                Password == "123456")
            {
                return RedirectToPage("/Games/Index");
            }

            ErrorMessage =
                "Invalid credentials";

            return Page();
        }
    }
}