using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Models
{
    public class PatronSeriesRel
    {
        [Key]
        public int PatronSeriesId {get;set;}

        public int PatronId {get;set;}

        public int SeriesId {get;set;}

        public Patron Patron {get;set;}

        public Series Series {get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}