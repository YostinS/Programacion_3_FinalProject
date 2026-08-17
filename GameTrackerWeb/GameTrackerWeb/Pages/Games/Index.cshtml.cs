using Microsoft.AspNetCore.Mvc.RazorPages;
using GameTrackerWeb.Data;
using GameTrackerWeb.Models;

namespace GameTrackerWeb.Pages.Games
{
    public class IndexModel : PageModel
    {
        public List<Game> Games { get; set; }

        public void OnGet()
        {
            Games = GameStore.Games;
        }
    }
}