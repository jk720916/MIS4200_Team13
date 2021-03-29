using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit;

namespace MIS4200_Team13.Models
{
    public class profileData
    {
        public Guid ID { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "A last name is required")]
        public string lastName { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "A first name is required")]
        public string firstName { get; set; }
        [Display(Name = "Full Name")]
        public string fullName
        {
            get
            {
                return lastName + ", " + firstName;
            }
        }
        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "A business unit is required")]
        public string businessUnit { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "A title is required")]
        public string title { get; set; }

        [Display(Name = "Date Hired")]
        [Required(ErrorMessage = "Date hired is required")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime dateHired { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required ie:555-555-5555")]
       [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string phoneNumber { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required ie: username@domain.com")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public ICollection<award> award { get; set; }
        
    }
    
  
}