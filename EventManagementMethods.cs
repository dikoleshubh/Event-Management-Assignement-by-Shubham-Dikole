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

            string name;
            do
            {
                Console.Write("Enter Event Name (required) : ");
                name = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Event Name cannot be empty. Please enter a valid name.");
                }

            } while (string.IsNullOrEmpty(name));

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

            if (ConfirmSave())
            {
                var newEvent = eventManager.CreateEvent(name, description, date, location);
                Console.WriteLine("Event created successfully!");
                Console.WriteLine(newEvent);
            }
            else
            {
                Console.WriteLine("Save operation canceled.");
                return;
            }

        }

        public void ListEvents(EventManager eventManager)
        {
            Console.Write("Enter sorting option (date, name or leave blank or type 'back' to return to menu ): ");
            string sortBy = Console.ReadLine();
            if (BackToMenu(sortBy)) return;
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
            Console.Write("Enter keyword to search(or type 'back' to return to menu): ");
            string keyword = Console.ReadLine();
            if (BackToMenu(keyword)) return;

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


        public void GetEvent(EventManager eventManager)
        {
            while (true)
            {
                Console.Write("Enter the Event ID to view (or type 'back' to return to menu): ");
                string input = Console.ReadLine();
                if (BackToMenu(input)) return;
                if (int.TryParse(input, out int id))
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
        }

        public void DeleteEvent(EventManager eventManager)
        {
            while (true)
            {
                Console.Write("Enter the Event ID to delete (or type 'back' to return to menu): ");
                string input = Console.ReadLine();
                if (BackToMenu(input)) return;
                if (int.TryParse(input, out int id))
                {
                    Console.Write("Do you really want to delete (Y/N)?: ");
                    if (ConfirmSave())
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
                        Console.WriteLine("Delete operation canceled.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid Event ID.");
                }
            }
        }

        public void UpdateEvent(EventManager eventManager)
        {
            while (true)
            {
                Console.Write("Enter the Event ID to update (or type 'back' to return to menu): ");
                string input = Console.ReadLine();
                if (BackToMenu(input)) return;

                if (int.TryParse(input, out int id))
                {
                    EventManagementEntity evnt = eventManager.GetEvent(id);

                    if (evnt != null)
                    {

                        Console.Write("\nEnter new Event Name (leave empty to keep current): ");
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
                        Console.Write("\nEnter new Date (yyyy-MM-dd) (leave empty to keep current): ");
                        string dateInput = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(dateInput))
                        {
                            if (DateTime.TryParse(dateInput, out DateTime parsedDate))
                            {
                                date = parsedDate;
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid date format. Keeping the current date.");
                                date = evnt.Date;
                            }
                        }

                        Console.Write("\nEnter new Location (leave empty to keep current): ");
                        string location = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(location))
                        {
                            location = evnt.Location;
                        }
                        if (!ConfirmSave())
                        {
                            return;
                        }
                        bool updated = eventManager.UpdateEvent(id, name, description, date, location);
                        if (updated)
                        {
                            Console.WriteLine("Event updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nFailed to update event. Please try again.");
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
        private bool BackToMenu(string input)
        {
            return input.Trim().ToLower() == "back";
        }

        private bool ConfirmSave()
        {
            while (true)
            {
                Console.Write("Do you want to confirm you selection? (yes/no): ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "yes")
                {
                    return true;
                }
                else if (input == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please type 'yes' or 'no'.");
                }
            }
        }
    }
}
