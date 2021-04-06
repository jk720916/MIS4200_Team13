using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        private string roles1;

        public string Getroles()
        {
            return roles1;
        }

        public void Setroles(string value)
        {
            roles1 = value;
        }

        //public enum roles
        //{enter roles here 8-16 in book}
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

        public enum title1
        {
            admin = 0,
            employee = 1,

        }
        //added employee to enum
        // trying to add dropdown to profile creation 
        [ForeignKey("recognizer")]
        public ICollection<award> awardsGiven { get; set; }

        [ForeignKey("recognized")]
        public ICollection<award> awardsReceived { get; set; }
        public title1 title { get; internal set; }
        public ICollection<Scoreboard> Scoreboard { get; set; }
    }


}