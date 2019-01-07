using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPA_Tracker.Models.SchoolViewModels
{
    public class AssignedEventData
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public bool Assigned { get; set; }
    }
}
