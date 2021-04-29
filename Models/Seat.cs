using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Models
{
    public class Seat
    {
        [Key]
        public int SeatId {get;set;}
        public string SeatNumber {get;set;}
        public string SeatStatus {get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<SeriesSeatPatronRel> PatronInSeries {get;set;}
    }
}