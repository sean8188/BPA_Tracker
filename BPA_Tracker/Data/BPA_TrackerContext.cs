using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BPA_Tracker.Models;

namespace BPA_Tracker.Models
{
    public class BPA_TrackerContext : DbContext
    {
        public BPA_TrackerContext (DbContextOptions<BPA_TrackerContext> options)
            : base(options)
        {
        }

        public DbSet<BPA_Tracker.Models.Student> Student { get; set; }

        public DbSet<BPA_Tracker.Models.Event> Event { get; set; }
    }
}
