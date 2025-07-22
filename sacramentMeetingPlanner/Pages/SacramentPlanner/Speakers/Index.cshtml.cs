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
    public class IndexModel : PageModel
    {
        private readonly sacramentMeetingPlanner.Data.sacramentMeetingPlannerContext _context;

        public IndexModel(sacramentMeetingPlanner.Data.sacramentMeetingPlannerContext context)
        {
            _context = context;
        }

        public IList<Speaker> Speakers { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Speakers = await _context.Speakers
                .Include(s => s.Meeting).ToListAsync();
        }
    }
}
