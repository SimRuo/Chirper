using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chirper.Models
{
    public class Chirp
    {
        public int Id { get; set; } // Primary key
        public required string Content { get; set; } // Tweet text
        public required string Author { get; set; } // Username or user ID
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Default to current time
        public int Likes { get; set; } = 0; // Default likes to zero

        // Parameterless constructor
        public Chirp() { }
    }
}
