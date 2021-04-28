using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Models
{
    public class Event
    {
        [Key]
        public int EventId {get;set;}

        [Required(ErrorMessage= "Input your company code for this event")]
        [MinLength(4, ErrorMessage="Should at least be 4 characters long.")]
        [Display(Name="Event Code")]
        public string EventCode {get;set;} //string so that they can use letters to organize if they want 

        [Required(ErrorMessage="Please input the name of the series")]
        [MinLength(2, ErrorMessage="The name of the event should be longer")]
        [Display(Name="Event Name")]
        public string EventName {get;set;}

        [Required(ErrorMessage="Please input the price map you want to use for the event.")]
        [MinLength(3, ErrorMessage="The price map is not correct")]
        [Display(Name="Price Map")]
        public string PriceMap {get;set;} //For simplicity's sake, we can say High (for high profit shows), Normal (for normal profit shows), or Low (for new shows. low profit)
        //Use a select option

        [Required(ErrorMessage="Input the start date of the event")]
        [DataType(DataType.Date)]
        [Display(Name="Start Date")]
        public DateTime StartDate {get;set;}

        [Required(ErrorMessage="Input the end date of the event")]
        [DataType(DataType.Date)]
        [Display(Name="End Date")]
        public DateTime EndDate {get;set;}

        // public string Director {get;set;}

        // public string Playwright {get;set;}

        // public string StarActorOne {get;set;}
        
        // public string StarActorTwo {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //Who created this event
        public int UserId {get;set;}
        public User CreatedBy {get;set;}

        public List<Series> SeriesForEvent {get;set;}
    }
}