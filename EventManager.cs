using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Event_Management_Assignement___Shubham_Dikole
{
    public class EventManager
    {
        private readonly Dictionary<int, EventManagementEntity> events = new();
        private int nextId = 1;
        private const string DataFilePath = "events.json";


        public EventManager()
        {
            LoadEventsFromFile();
            if (events.Count > 0)
            {
                nextId = events.Keys.Max() + 1;
            }
        }

        public EventManagementEntity CreateEvent(string name, string description, DateTime date, string location)
        {
            var newEvent = new EventManagementEntity(nextId++, name, description, date, location);
            events.Add(newEvent.Id, newEvent);
            SaveEventsToFile();
            return newEvent;
        }

        public bool DeleteEvent(int id)
        {
            if (events.Remove(id))
            {
                SaveEventsToFile();
                return true;
            }
            return false;
        }

        public EventManagementEntity GetEvent(int id)
        {
            events.TryGetValue(id, out EventManagementEntity evnt);
            return evnt;
        }

        public List<EventManagementEntity> ListEvents(string sortBy)
        {
            var sortedEvents = events.Values.ToList();

            if (sortBy == "date")
            {
                sortedEvents = sortedEvents?.OrderBy(e => e.Date).ToList();
            }
            else if (sortBy == "name")
            {
                sortedEvents = sortedEvents?.OrderBy(e => e.Name).ToList();
            }

            return sortedEvents;
        }

        public List<EventManagementEntity> SearchEvents(string keyword)
        {
            return events.Values
                .Where(e => (e.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                             e.Description.Contains(keyword, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        public bool UpdateEvent(int id, string name, string description, DateTime? date, string location)
        {
            if (events.TryGetValue(id, out EventManagementEntity evnt))
            {
                if (!string.IsNullOrEmpty(name)) evnt.Name = name;
                if (!string.IsNullOrEmpty(description)) evnt.Description = description;
                if (date.HasValue) evnt.Date = date.Value;
                if (!string.IsNullOrEmpty(location)) evnt.Location = location;

                SaveEventsToFile();
                return true;
            }
            return false;
        }

        private void SaveEventsToFile()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(events.Values, options);
                File.WriteAllText(DataFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving events to file: {ex.Message}");
            }
        }

        private void LoadEventsFromFile()
        {
            try
            {
                if (File.Exists(DataFilePath))
                {
                    var json = File.ReadAllText(DataFilePath);
                    var loadedEvents = JsonSerializer.Deserialize<List<EventManagementEntity>>(json);
                    if (loadedEvents != null)
                    {
                        foreach (var evnt in loadedEvents)
                        {
                            events.Add(evnt.Id, evnt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading events from file: {ex.Message}");
            }
        }
    }
}
