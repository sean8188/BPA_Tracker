using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BPA_Tracker.Models;
using BPA_Tracker.Models.SchoolViewModels;  // Add VM
using Microsoft.AspNetCore.Authorization;

namespace BPA_Tracker.Pages.Students
{
    [Authorize]
    
    public class IndexModel : PageModel
    {
        private readonly BPA_Tracker.Models.BPA_TrackerContext _context;

        public IndexModel(BPA_Tracker.Models.BPA_TrackerContext context)
        {
            _context = context;
        }

        //public IList<Student> Student { get;set; }
        public StudentIndexData Student { get; set; }
        public int StudentID { get; set; }
        public int EventID { get; set; }


        //Added search fields
        [BindProperty(SupportsGet = true)]

        public string SearchString { get; set; }


        public async Task OnGetAsync(int? id, int? EventID)
        {
            Student = new StudentIndexData();
            Student.Students = await _context.Student
                    .Include(s => s.AssignEvents)
                        .ThenInclude(i => i.Event)
                  .AsNoTracking()
                  .OrderBy(i => i.LastName)
                  .ToListAsync();
            /////////////////////////////////////////////////////
            //Added code for searching by last name.
            var SearchStudent = from m in _context.Student
                                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                Student.Students = SearchStudent.Where(s => s.LastName.Contains(SearchString));

            }

            /////////////////////////////////////////////////////


            if (id != null)
            {
                StudentID = id.Value;
                Student student = Student.Students.Where(
                    i => i.StudentID == id.Value).Single();
                Student.Events = student.AssignEvents.Select(s => s.Event);
            }

            if (EventID != null)
            {
                EventID = EventID.Value;
                Student.AssignEvents = Student.Events.Where(
                    x => x.EventID == EventID).Single().AssignEvents;
            }
        }
    }
}
