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

        [Required(ErrorMessage="Please enter a donation amount")]
        [Display(Name="Donation Amount")]
        public decimal DonationAmount {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public int PatronId {get;set;}

        public Patron Patron {get;set;}
    }
}