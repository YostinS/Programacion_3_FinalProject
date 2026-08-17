using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GameTrackerWeb.Data;
using GameTrackerWeb.Models;

namespace GameTrackerWeb.Pages.Games
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Game Game { get; set; }

        public IActionResult OnGet(int id)
        {
            Game = GameStore.Games
                .FirstOrDefault(x => x.Id == id);

            if (Game == null)
                return RedirectToPage("Index");

            return Page();
        }

        public IActionResult OnPost()
        {
            GameStore.Games.RemoveAll(x => x.Id == Game.Id);

            return RedirectToPage("Index");
        }
    }
}