using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string? Note { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int AttendeeId { get; set; }
        public Attendee Attendee { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
