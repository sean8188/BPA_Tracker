using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BPA_Tracker.Models.SchoolViewModels
{

    //Create a view model for the Student Index view
    //The students page shows data from three different tables.
    //A view model is created that includes the three entities representing the three tables.

    public class StudentIndexData
    {
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<AssignEvent> AssignEvents { get; set; }
    }
}