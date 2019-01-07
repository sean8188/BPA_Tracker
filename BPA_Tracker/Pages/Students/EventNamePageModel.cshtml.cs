using BPA_Tracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BPA_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BPA_Tracker.Pages.Students
{
    public class EventNamePageModel : PageModel
    {
        public SelectList EventNameSL { get; set; }

        public void PopulateEventsDropDownList(BPA_TrackerContext _context,
            object selectedEvent = null)
        {
            var EventsQuery = from d in _context.Event 
                              orderby d.EventName  // Sort by name.
                              select d;

            EventNameSL = new SelectList(EventsQuery.AsNoTracking(),
                        "EventID", "EventName", selectedEvent);
        }
    }
}
//The preceding code creates a SelectList to contain the list of Event names. If selectedEvent is specified, that Event is selected in the SelectList.
//The Create and Edit page model classes will derive from EventNamePageModel.