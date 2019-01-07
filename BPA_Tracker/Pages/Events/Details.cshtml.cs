using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BPA_Tracker.Models;

namespace BPA_Tracker.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly BPA_Tracker.Models.BPA_TrackerContext _context;

        public DetailsModel(BPA_Tracker.Models.BPA_TrackerContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.SingleOrDefaultAsync(m => m.EventID == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
