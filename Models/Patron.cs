using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Models
{
    public class Patron
    {
        [Key]
        public int PatronId {get;set;}

        [Required(ErrorMessage="We require patrons first name")]
        [Display(Name="First Name")]
        [MinLength(2, ErrorMessage="Please enter a longer name")]
        public string FirstName {get;set;}

        [Required(ErrorMessage="We require patrons last name")]
        [Display(Name="Last Name")]
        [MinLength(2, ErrorMessage="Please enter a longer name")]
        public string LastName {get;set;}

        [Required(ErrorMessage="We require patrons address")]
        [Display(Name="Address")]
        [MinLength(3, ErrorMessage="Address should be longer")]
        public string Address {get;set;}

        [Required(ErrorMessage="Phone number required. (###)###-#### format")]
        [Display(Name="Phone Number")]
        [RegularExpression(pattern: @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$", ErrorMessage="(###)###-#### format")]
        // [Phone]
        // [MinLength(12, ErrorMessage="+#(###)###-#### format")]
        // [MaxLength(20, ErrorMessage="+#(###)###-#### ext ### format")]
        public string PhoneNumber {get;set;} //String? It does use () and - characters

        [Required(ErrorMessage="What type of phone number is this?")]
        public string PhoneNumberType {get;set;} //Home - Work - Cell

        [Display(Name="Email")]
        public string Email {get;set;}

        [Required(ErrorMessage="We require the patrons date of birth")]
        [Display(Name="Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth {get;set;}

        // [Phone]
        [Display(Name="Fax Number")]
        // [RegularExpression(pattern: @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$", ErrorMessage="(###)###-#### format")]
        public string FaxNumber {get;set;}

        [Display(Name="Website")]
        public string Website {get;set;}

        [Display(Name="Subscription Module")]
        public string SubscriptionModule {get;set;}

        [Display(Name="Military?")]
        public bool IsMilitary {get;set;}

        [Display(Name="Student?")]
        public bool IsStudent {get;set;}

        // public decimal TotalDonations {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public int UserId {get;set;}
        public User User {get;set;}

        public List<PatronSeriesRel> SeriesSeen {get;set;}

        public List<Donation> DonationsMade {get;set;}

        public List<PurchasedTicket> TicketsPurchased {get;set;}

        public List<SeriesSeatPatronRel> SeatInSeries {get;set;}
    }
}