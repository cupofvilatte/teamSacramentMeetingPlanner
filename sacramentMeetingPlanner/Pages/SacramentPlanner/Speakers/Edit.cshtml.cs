using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sacramentMeetingPlanner.Data;
using sacramentMeetingPlanner.Models;

namespace sacramentMeetingPlanner.Pages.SacramentPlanner.Speakers
{
    public class EditModel : PageModel
    {
        private readonly sacramentMeetingPlanner.Data.sacramentMeetingPlannerContext _context;

        public EditModel(sacramentMeetingPlanner.Data.sacramentMeetingPlannerContext context)
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

            var speaker =  await _context.Speakers.FirstOrDefaultAsync(m => m.Id == id);
            if (speaker == null)
            {
                return NotFound();
            }
            Speaker = speaker;
           ViewData["MeetingId"] = new SelectList(_context.Meeting, "Id", "Date");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Speaker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeakerExists(Speaker.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SpeakerExists(int id)
        {
            return _context.Speakers.Any(e => e.Id == id);
        }
    }
}
