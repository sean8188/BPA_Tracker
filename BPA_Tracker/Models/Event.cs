using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPA_Tracker.Models
{
    public class Event
    {
        //The DatabaseGenerated attribute allows the app to specify the primary key rather than having the DB generate it.

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
   
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string DateTime { get; set; }
        public string Location { get; set; }

        //Navigation properties
        public ICollection<AssignEvent> AssignEvents { get; set; }

    }
}
