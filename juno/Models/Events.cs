using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace juno.Models
{
    public class Events
    {
        [Key] // Mark EventId as the primary key
        public int EventId { get; set; }

        public string Clubname { get; set; }
        public string Eventname { get; set; }
        public string Location { get; set; }
        public int MaximumCapacity { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
    }
}