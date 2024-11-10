using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_Assignement___Shubham_Dikole
{
    public class EventManagementEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }

        public EventManagementEntity(int id, string name, string description, DateTime date, string location)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
            Location = location;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Date: {Date:yyyy-MM-dd}, Location: {Location}";
        }

        public string DetailedInfo()
        {
            return $"Event Details:\nName: {Name}\nDescription: {Description}\nDate: {Date:yyyy-MM-dd}\nLocation: {Location}";
        }
    }
}
