using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Biography { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? ProfilePictureUrl { get; set; }

        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }
    }
}
