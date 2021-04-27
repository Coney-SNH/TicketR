using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketr.Models
{
    [NotMapped]
    public class LogUser
    {
        [Required(ErrorMessage="Please enter your email")]
        [EmailAddress]
        [Display(Name="Email")]
        public string LoginEmail {get;set;}

        [Required(ErrorMessage="Please enter your password")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be longer than 8 characters")]
        [Display(Name="Password")]
        public string LoginPassword {get;set;}
    }
}