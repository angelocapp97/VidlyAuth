using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyAuth.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        [Display(Name = "Customer Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter customer's surname.")]
        [StringLength(255)]
        [Display(Name = "Customer Surname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please select a membership type.")]
        [Display(Name = "Select Membership Type")]
        public byte MembershipTypeId { get; set; }
        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage = "Please select a gender.")]
        [Display(Name = "Select Gender")]
        public byte GenderId { get; set; }
        public Gender Gender { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required(ErrorMessage = "Please enter customer's birthday")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date format.")]
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime Birthdate { get; set; }
    }
}