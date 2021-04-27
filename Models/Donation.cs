using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Models
{
    public class Donation
    {
        [Key]
        public int DonationId {get;set;}

        public decimal DonationAmount {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public int PatronId {get;set;}

        public Patron Patron {get;set;}
    }
}