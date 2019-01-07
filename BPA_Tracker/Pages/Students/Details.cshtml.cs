using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BPA_Tracker.Models;

namespace BPA_Tracker.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly BPA_Tracker.Models.BPA_TrackerContext _context;

        public DetailsModel(BPA_Tracker.Models.BPA_TrackerContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Student = await _context.Student.SingleOrDefaultAsync(m => m.StudentID == id);
            Student = await _context.Student
                    .Include(s => s.AssignEvents)
                        .ThenInclude(e => e.Event)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.StudentID == id);
            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
