using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BPA_Tracker.Models;

namespace BPA_Tracker.Pages.Students
{

    public class EditModel : StudentEventsPageModel
    {
        private readonly BPA_Tracker.Models.BPA_TrackerContext _context;

        public EditModel(BPA_Tracker.Models.BPA_TrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student
                .Include(i => i.AssignEvents)
                    .ThenInclude(i => i.Event)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.StudentID == id);

            if (Student == null)
            {
                return NotFound();
            }

            PopulateAssignedEventData(_context, Student);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedEvents)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studentToUpdate = await _context.Student
                .Include(i => i.AssignEvents)
                    .ThenInclude(i => i.Event)
                .FirstOrDefaultAsync(m => m.StudentID == id);

            if (await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "Student",
                i => i.FirstName, i => i.LastName,
                i => i.ParentEmail, i => i.ParentName,
                i => i.ParentPhone, i => i.StudentPhone,
                i => i.StudentEmail))
            {
                //               if (String.IsNullOrWhiteSpace(
                //                   studentToUpdate.AssignEvents?.))
                //               {
                //                   studentToUpdate.AssignEvents?.Location))
                //= null;
                //               }
                UpdateStudentEvents(_context, selectedEvents, studentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateStudentEvents(_context, selectedEvents, studentToUpdate);
            PopulateAssignedEventData(_context, studentToUpdate);
            return Page();
        }
    }
    //public class EditModel : PageModel
    //{
    //    private readonly BPA_Tracker.Models.BPA_TrackerContext _context;

    //    public EditModel(BPA_Tracker.Models.BPA_TrackerContext context)
    //    {
    //        _context = context;
    //    }

    //    [BindProperty]
    //    public Student Student { get; set; }

    //    public async Task<IActionResult> OnGetAsync(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        Student = await _context.Student.SingleOrDefaultAsync(m => m.StudentID == id);

    //        if (Student == null)
    //        {
    //            return NotFound();
    //        }
    //        return Page();
    //    }

    //    public async Task<IActionResult> OnPostAsync()
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return Page();
    //        }

    //        _context.Attach(Student).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!StudentExists(Student.StudentID))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return RedirectToPage("./Index");
    //    }

    //    private bool StudentExists(int id)
    //    {
    //        return _context.Student.Any(e => e.StudentID == id);
    //    }
    //}
}