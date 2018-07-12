using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models.Validations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Type of Membership")]
        public byte MembershipTypeId { get; set; }
        
        [Display(Name = "Date of Birth (dd/mm/yyyy)")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; } // '?'means Not required
    }
}