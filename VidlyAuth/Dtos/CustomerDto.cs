using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyAuth.Models;

namespace VidlyAuth.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }

        [Required]
        public byte GenderId { get; set; }
        public GenderDto Gender { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime Birthdate { get; set; }
    }
}