using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sacramentMeetingPlanner.Data;
using sacramentMeetingPlanner.Models;

namespace sacramentMeetingPlanner.Pages.SacramentPlanner
{
    public class PrintModel : PageModel
    {
        private readonly sacramentMeetingPlannerContext _context;

        public PrintModel(sacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        public Meeting Meeting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Meeting = await _context.Meeting
                .Include(m => m.Speakers)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Meeting == null)
                return NotFound();

            return Page();
        }
    }
}
