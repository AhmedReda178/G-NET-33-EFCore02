using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventHub.Models
{
    public class Organizer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string? CompanyName { get; set; }

        public bool IsVerified { get; set; }

        public Profile Profile { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
