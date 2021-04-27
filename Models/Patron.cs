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

        public string FirstName {get;set;}

        public string LastName {get;set;}

        public string Address {get;set;}

        public string PhoneNumber {get;set;} //String? It does use () and - characters

        public string PhoneNumberType {get;set;} //Home - Work - Cell

        public string Email {get;set;}

        public string FaxNumber {get;set;}

        public string Website {get;set;}

        public string SubscriptionModule {get;set;}

        public bool IsMilitary {get;set;}

        public bool IsStudent {get;set;}

        public decimal TotalDonations {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public int UserId {get;set;}
        public User User {get;set;}

        public List<PatronSeriesRel> SeriesSeen {get;set;}

        public List<Donation> DonationsMade {get;set;}
    }
}