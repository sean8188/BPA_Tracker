using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BPA_Tracker.Models;

namespace BPA_Tracker.Pages.Students
{
    public class CreateModel : StudentEventsPageModel // Changed from PageModel
    {
        private readonly BPA_Tracker.Models.BPA_TrackerContext _context;

        public CreateModel(BPA_Tracker.Models.BPA_TrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //LINE BELOW IS NEW

            var student = new Student();
            student.AssignEvents = new List<AssignEvent>();

            PopulateAssignedEventData(_context, student);
            //PopulateEventsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var newStudent = new Student();
            if (selectedCourses != null)
            {
                newStudent.AssignEvents = new List<AssignEvent>();
                foreach (var course in selectedCourses)
                {
                    var coursetoadd = new AssignEvent
                    {
                        EventID = int.Parse(course)
                    };
                    newStudent.AssignEvents.Add(coursetoadd);
                }
            }

            if (await TryUpdateModelAsync<Student>(
                newStudent,
                "Student",
                i => i.FirstName, i => i.LastName,
                i => i.StudentPhone, i => i.StudentEmail,
                i => i.ParentName, i => i.ParentPhone,
                i => i.ParentEmail))
            {
                _context.Student.Add(newStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedEventData(_context, newStudent);
            return Page();
        }
    }
}