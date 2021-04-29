using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ticketr.Models
{
    public class SeriesSeatPatronRel
    {
        [Key]
        public int SeriesSeatPatronId {get;set;}

        public int SeriesId{get;set;}
        public int SeatId{get;set;}
        public int PatronId {get;set;}
        public Series Series {get;set;}
        public Seat Seat {get;set;}
        public Patron Patron {get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}