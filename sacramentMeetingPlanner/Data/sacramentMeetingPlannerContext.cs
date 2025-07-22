using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sacramentMeetingPlanner.Models;

namespace sacramentMeetingPlanner.Data
{
    public class sacramentMeetingPlannerContext : DbContext
    {
        public sacramentMeetingPlannerContext(DbContextOptions<sacramentMeetingPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<sacramentMeetingPlanner.Models.Meeting> Meeting { get; set; } = default!;
        public DbSet<sacramentMeetingPlanner.Models.Speaker> Speakers { get; set; } = default!;
    }
}