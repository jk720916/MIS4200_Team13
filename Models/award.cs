using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIS4200_Team13.Models
{
    public class award
    {
        public int awardID { get; set; }
        [Display(Name = "Award")]
        [Required(ErrorMessage = "An award is required")]
        public CoreValue awards { get; set; }
        [Display(Name = "Recognizer")]
        [Required(ErrorMessage = "A recognizer is required")]
        public Guid recognizer { get; set; }
        [ForeignKey("recognizer")]
        public virtual profileData Recognizer { get; set; }
        [Display(Name = "Recognized")]
        [Required(ErrorMessage = "A recognized is required")]
        public Guid recognized { get; set; }
        [ForeignKey("recognized")]
        public virtual profileData Recognized { get; set; }
        [Display(Name = "Date")]
        [Required(ErrorMessage = "A date is required")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime recognitionDate { get; set; }

        //public Guid ID { get; set; }

        //public virtual profileData fullName { get; set; }


        public enum CoreValue
        {
            Stewardship = 1,
            Culture = 2,
            [Display(Name = "Delivery Excellence")]
            Delivery_Excellence = 3,
            Innovation = 4,
            [Display(Name = "Greater Good")]
            Greater_Good = 5,
            [Display(Name = "Integrity and Openness")]
            Integrity_and_openness = 6,
            [Display(Name = "Balanced Life")]
            Balanced_life = 7,

        }
        

    }
}