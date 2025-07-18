using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sacramentMeetingPlanner.Data;
using sacramentMeetingPlanner.Models;

namespace sacramentMeetingPlanner.Pages.SacramentPlanner.Speakers
{
    public class DeleteModel : PageModel
    {
        private readonly sacramentMeetingPlanner.Data.sacramentMeetingPlannerContext _context;

        public DeleteModel(sacramentMeetingPlanner.Data.sacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Speaker Speaker { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speakers.FirstOrDefaultAsync(m => m.Id == id);

            if (speaker is not null)
            {
                Speaker = speaker;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speaker = await _context.Speakers.FindAsync(id);
            if (speaker != null)
            {
                Speaker = speaker;
                _context.Speakers.Remove(Speaker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
