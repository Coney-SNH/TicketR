using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage= "Please enter a first name")]
        [MinLength(2, ErrorMessage= "Please enter a longer first name")]
        [Display(Name="First Name")]
        public string FirstName {get;set;}

        [Required(ErrorMessage= "Please enter a last name")]
        [MinLength(2, ErrorMessage= "Please enter a longer last name")]
        [Display(Name="Last Name")]
        public string LastName {get;set;}

        [Required(ErrorMessage= "Please enter an Email address")]
        [EmailAddress]
        [Display(Name= "Email")]
        public string Email {get;set;}

        [Required(ErrorMessage="Please enter the access code your employer gave you")]
        // [MinLength(8, ErrorMessage="The code your employer gave you is 8 characters long")]
        // [MaxLength(8, ErrorMessage="The code your employer gave you is 8 characters long")]
        [Display(Name="Employer Code")]
        public string AccessLevel {get;set;}

        [Required(ErrorMessage= "Please enter a Password")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Your password is too short. Make a better Password.")]
        [Display(Name= "Password")]
        [RegularExpression(pattern: @"^(?=(.*\d){2})(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\d]).{8,}$", ErrorMessage="Your password must contain two numbers. at least one upper case letter and one lower case letter. and at least one unique character.")]
        public string Password {get;set;}

        [NotMapped]
        [Compare("Password", ErrorMessage="Passwords must match")]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        public string ConfirmPassword {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<Event> EventsMade {get;set;}

        public List<Patron> PatronsAdded {get;set;}

        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}