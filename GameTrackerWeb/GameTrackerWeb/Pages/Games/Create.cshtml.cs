using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GameTrackerWeb.Models;
using GameTrackerWeb.Data;

namespace GameTrackerWeb.Pages.Games
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Game Game { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Game.Id = GameStore.Games.Count + 1;

            GameStore.Games.Add(Game);

            return RedirectToPage("Index");
        }
    }
}