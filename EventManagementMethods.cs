using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_Assignement___Shubham_Dikole
{
    public class EventManagementMethods
    {
        public void CreateEvent(EventManager eventManager)
        {
            Console.Write("Enter Event Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Description (optional): ");
            string description = Console.ReadLine();

            DateTime date;
            while (true)
            {
                Console.Write("Enter Date (yyyy-MM-dd): ");
                string dateInput = Console.ReadLine();
                try
                {
                    date = DateTime.ParseExact(dateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-MM-dd).");
                }
            }

            Console.Write("Enter Location (optional): ");
            string location = Console.ReadLine();

            var newEvent = eventManager.CreateEvent(name, description, date, location);
            Console.WriteLine("Event created successfully!");
            Console.WriteLine(newEvent);
        }

        public void ListEvents(EventManager eventManager)
        {
            Console.Write("Enter sorting option (date, name or leave blank): ");
            string sortBy = Console.ReadLine();
            var events = eventManager.ListEvents(sortBy);

            if (events.Count == 0)
            {
                Console.WriteLine("No events available.");
            }
            else
            {
                foreach (var evnt in events)
                {
                    Console.WriteLine(evnt);
                }
            }
        }

      

        public void SearchEvents(EventManager eventManager)
        {
            Console.Write("Enter keyword to search: ");
            string keyword = Console.ReadLine();

            var events = eventManager.SearchEvents(keyword);

            if (events.Count == 0)
            {
                Console.WriteLine("No events found matching the keyword.");
            }
            else
            {
                foreach (var evnt in events)
                {
                    Console.WriteLine(evnt);
                }
            }
        }

        public DateTime? ParseDate(string input)
        {
            try
            {
                if (!string.IsNullOrEmpty(input) && DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format.");
            }
            return null;
        }

        public void GetEvent(EventManager eventManager)
        {
            Console.Write("Enter the Event ID to view: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                EventManagementEntity evnt = eventManager.GetEvent(id);
                if (evnt != null)
                {
                    Console.WriteLine(evnt.DetailedInfo());
                }
                else
                {
                    Console.WriteLine("Event not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Event ID.");
            }
        }

        public void DeleteEvent(EventManager eventManager)
        {
            Console.Write("Enter the Event ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                bool deleted = eventManager.DeleteEvent(id);
                if (deleted)
                {
                    Console.WriteLine("Event deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Event not found or could not be deleted.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Event ID.");
            }
        }

        public void UpdateEvent(EventManager eventManager)
        {
            Console.Write("Enter the Event ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                EventManagementEntity evnt = eventManager.GetEvent(id);
                if (evnt != null)
                {
                    Console.WriteLine("Leave fields blank to keep current values.");

                    Console.Write("Enter new Event Name (leave empty to keep current): ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        name = evnt.Name;
                    }

                    Console.Write("Enter new Description (leave empty to keep current): ");
                    string description = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(description))
                    {
                        description = evnt.Description;
                    }

                    DateTime? date = null;
                    Console.Write("Enter new Date (yyyy-MM-dd) or leave blank to keep current: ");
                    string dateInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(dateInput))
                    {
                        if (DateTime.TryParse(dateInput, out DateTime parsedDate))
                        {
                            date = parsedDate;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Keeping the current date.");
                            date = evnt.Date;
                        }
                    }

                    Console.Write("Enter new Location (leave empty to keep current): ");
                    string location = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(location))
                    {
                        location = evnt.Location;
                    }

                    bool updated = eventManager.UpdateEvent(id, name, description, date, location);
                    if (updated)
                    {
                        Console.WriteLine("Event updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to update event. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Event not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Event ID.");
            }
        }


    }
}
