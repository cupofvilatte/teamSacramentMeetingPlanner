using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sacramentMeetingPlanner.Data;
using sacramentMeetingPlanner.Models;

namespace sacramentMeetingPlanner.Pages.SacramentPlanner.Speakers
{
    public class CreateModel : PageModel
    {
        private readonly sacramentMeetingPlanner.Data.sacramentMeetingPlannerContext _context;

        public CreateModel(sacramentMeetingPlanner.Data.sacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? meetingId)
        {
            Speaker = new Speaker();

            if (meetingId != null && _context.Meeting.Any(m => m.Id == meetingId))
            {
                Speaker.MeetingId = meetingId.Value;
                ViewData["MeetingId"] = new SelectList(_context.Meeting.Where(m => m.Id == meetingId), "Id", "Date");
            }
            else
            {
                ViewData["MeetingId"] = new SelectList(_context.Meeting, "Id", "Date");
            }

            return Page();
        }

        [BindProperty]
        public Speaker Speaker { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Speakers.Add(Speaker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
