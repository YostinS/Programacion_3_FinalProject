using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GameTrackerWeb.Data;
using GameTrackerWeb.Models;

namespace GameTrackerWeb.Pages.Games
{
    public class EditModel : PageModel
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
            var existingGame = GameStore.Games
                .FirstOrDefault(x => x.Id == Game.Id);

            existingGame.Name = Game.Name;
            existingGame.Status = Game.Status;

            return RedirectToPage("Index");
        }
    }
}