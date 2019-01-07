using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BPA_Tracker.Models
{

    public class AssignStudent
    {
        public int AssignStudentID { get; set; }
        //The AssignEventID property is the primary key.
        //This entity uses the classnameID pattern instead of ID like the Student entity.
        //Typically developers choose one pattern and use it throughout the data model.
        //In a later tutorial, using ID without classname is shown to make it easier to implement inheritance in the data model.
        public int InstructorID { get; set; }

        public int StudentID { get; set; }
        //The StudentID property is a foreign key, and the corresponding navigation property is Student. 
        //An Enrollment entity is associated with one Student entity, so the property contains a single Student entity. 
        //The Student entity differs from the Student.AssignEvents navigation property(IN THE STUDENTS CLASS), which contains multiple entities.
        //NAVIGATION PROPERTIES

        public Instructor Instructor { get; set; }
        public Student Student { get; set; }
    }

    /*
     * 
EF Core interprets a property as a foreign key if it's named <navigation property name><primary key property name>. 
For example,StudentID for the Student navigation property, since the Student entity's primary key is ID. 

Foreign key properties can also be named <primary key property name>. 
For example, CourseID since the Course entity's primary key is CourseID.
     * 
     */
}
