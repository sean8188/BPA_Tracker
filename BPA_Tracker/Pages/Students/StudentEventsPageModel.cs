using BPA_Tracker.Data;
using BPA_Tracker.Models;
using BPA_Tracker.Models.SchoolViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace BPA_Tracker.Pages.Students
{
    public class StudentEventsPageModel : PageModel
    {

        public List<AssignedEventData> AssignedEventDataList;

        public void PopulateAssignedEventData(BPA_TrackerContext context, Student Student)
        {
            var allEvents = context.Event;
            var StudentEvents = new HashSet<int>(
                Student.AssignEvents.Select(c => c.EventID));
            AssignedEventDataList = new List<AssignedEventData>();
            foreach (var Event in allEvents)
            {
                AssignedEventDataList.Add(new AssignedEventData
                {
                    EventID = Event.EventID,
                    EventName = Event.EventName,
                    Assigned = StudentEvents.Contains(Event.EventID)
                });
            }
        }

        public void UpdateStudentEvents(BPA_TrackerContext context,
            string[] selectedEvents, Student StudentToUpdate)
        {
            if (selectedEvents == null)
            {
                StudentToUpdate.AssignEvents = new List<AssignEvent>();
                return;
            }

            var selectedEventsHS = new HashSet<string>(selectedEvents);
            var StudentEvents = new HashSet<int>
                (StudentToUpdate.AssignEvents.Select(c => c.Event.EventID));
            foreach (var Event in context.Event)
            {
                if (selectedEventsHS.Contains(Event.EventID.ToString()))
                {
                    if (!StudentEvents.Contains(Event.EventID))
                    {
                        StudentToUpdate.AssignEvents.Add(
                            new AssignEvent
                            {
                                StudentID = StudentToUpdate.StudentID,
                                EventID = Event.EventID
                            });
                    }
                }
                else
                {
                    if (StudentEvents.Contains(Event.EventID))
                    {
                        AssignEvent EventToRemove
                            = StudentToUpdate
                                .AssignEvents
                                .SingleOrDefault(i => i.EventID == Event.EventID);
                        context.Remove(EventToRemove);
                    }
                }
            }
        }
    }
}