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
    public class CreateModel : EventNamePageModel  // Changed from PageModel
    {
        private readonly BPA_Tracker.Models.BPA_TrackerContext _context;

        public CreateModel(BPA_Tracker.Models.BPA_TrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //LINE BELOW IS NEW
            PopulateEventsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //LINSE BELOW IS NEW*********************************************
            var emptyCourse = new Student();

            if (await TryUpdateModelAsync<Student>(
                 emptyCourse,
                 "student",   // Prefix for form value.
                 s => s.StudentID, s => s.LastName, s => s.FirstName, s => s.StudentPhone, s => s.StudentEmail, s => s.ParentName, s => s.ParentPhone, s => s.ParentEmail))
            {
                _context.Student.Add(emptyCourse);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateEventsDropDownList(_context, emptyCourse.StudentID);
            return Page();

            //************************************LINES ABOVE IS NEW

            //_context.Student.Add(Student);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
        }
    }
}