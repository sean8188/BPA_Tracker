using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BPA_Tracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace BPA_Tracker.Pages.Events
{
    [Authorize]

    public class IndexModel : PageModel
    {
        private readonly BPA_Tracker.Models.BPA_TrackerContext _context;

        public IndexModel(BPA_Tracker.Models.BPA_TrackerContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Event.ToListAsync();
        }
    }
}
