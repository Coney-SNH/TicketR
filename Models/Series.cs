using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Models
{
    public class Series
    {
        [Key]
        public int SeriesId {get;set;}
        
        [NotMapped]
        [Required(ErrorMessage= "Input your company code for this event")]
        [MinLength(4, ErrorMessage="Should at least be 4 characters long.")]
        [Display(Name="Related Event Code")]
        public string RelatedEventCode {get;set;}

        [Required(ErrorMessage="Enter the name of this particular series")]
        [MinLength(3, ErrorMessage="Series name must be longer.")]
        [Display(Name="Series Name")]
        public string SeriesName {get;set;}

        [Required(ErrorMessage="Please set the day of the series")]
        [Display(Name="Series Date")]
        [DataType(DataType.Date)]
        public DateTime SeriesDate {get;set;}

        [Required(ErrorMessage="Please set the time of the series")]
        [Display(Name="Series Time")]
        [DataType(DataType.Time)]
        public DateTime SeriesTime {get;set;}

        public DateTime CombinedTime {get;set;} = DateTime.Now;

        [Required(ErrorMessage="Please enter the name of the venue")]
        [Display(Name="Venue")]
        public string SeriesVenue {get;set;}
        //Make a dropdown menu for the venues?

        // public string PriceModel {get;set;} // prefilled? neccessary? Yes. Need to specify between monday show prices and saturday night show prices.

        [Required(ErrorMessage="What is the price of a ticket for this series?")]
        [Display(Name="Ticket Price")]
        public decimal TicketPrice {get;set;}

        [Required(ErrorMessage="How many tickets are available for this series?")]
        [Display(Name="Tickets Available")]
        public int TicketsAvailable {get;set;}

        [Display(Name="Tickets Sold")]
        public int TicketsSold {get;set;} = 0;

        [Display(Name="Base Price")]
        public decimal BasePrice {get;set;} = 0;

        [Display(Name="Total Discounts")]
        public decimal TotalDiscounts {get;set;} = 0;

        [Display(Name="Net Sales")]
        public decimal NetSales {get;set;} = 0;

        // public string[] AvailableSeats {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public int UserId {get;set;}
        public User User {get;set;}

        public int EventId {get;set;}
        public Event Event {get;set;}

        public List<PatronSeriesRel> PatronsWatched {get;set;}

        public List<SeriesSeatPatronRel> PatronsInSeats {get;set;}
    }
}


// SHOULD venues be their own models?
// if (SeriesVener == "Issaquah")
// {
//     string [] GSeats = [A3, B4, etc]
//     string [] ASeats = [these seats]
//     string [] BSeats = [these last seats]
// }
// else if (SeriesVender == "Everett")
//{
//     these are the gold, A, B seats
// }
//else -- Error code