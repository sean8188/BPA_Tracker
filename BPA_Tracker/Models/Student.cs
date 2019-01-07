using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPA_Tracker.Models
{
    public class Student
    {

        //Listed below is the fields for the student in the database. 
        //      public int StudentID { get; set; } is the key to the student table
        public int StudentID { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string StudentPhone { get; set; }
        public string StudentEmail { get; set; }
        public string ParentName { get; set; }
        public string ParentPhone { get; set; }
        public string ParentEmail { get; set; }

        //The following property is a navigation property. Navigation properties link to other entities that are related to this entity. 
        //In this case, the property of a Student entity holds all of the Enrollment entities that are related to that Student. 
        //For example, if a Student row in the DB has two related Enrollment rows, the Enrollments navigation property contains those two Enrollment entities. 
        //A related Enrollment row is a row that contains that student's primary key value in the StudentID column. 
        //For example, suppose the student with ID=1 has two rows in the Enrollment table. The Enrollment table has two rows with StudentID = 1. 
        //StudentID is a foreign key in the Enrollment table that specifies the student in the Student table.
        public ICollection<AssignEvent> AssignEvents { get; set; }
        public Instructor Instructor { get; set; }


    }
}
