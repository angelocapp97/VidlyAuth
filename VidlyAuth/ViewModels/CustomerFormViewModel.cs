using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyAuth.Models;

namespace VidlyAuth.ViewModels
{
    public class CustomerFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        [Display(Name = "Customer Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter customer's surname.")]
        [StringLength(255)]
        [Display(Name = "Customer Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please select a membership type.")]
        [Display(Name = "Select Membership Type")]
        public byte MembershipTypeId { get; set; }
        public List<SelectListItem> MembershipTypesListItems { get; set; }

        [Required(ErrorMessage = "Please select a gender.")]
        [Display(Name = "Select Gender")]
        public byte GenderId { get; set; }
        public IEnumerable<Gender> GendersListItems { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required(ErrorMessage = "Please enter your birthday")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date format.")]
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime Birthdate { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer" : "New Customer";
            }
        }

        public CustomerFormViewModel(List<MembershipType> membershipTypes, IEnumerable<Gender> genders)
        {
            Id = 0;
            Birthdate = DateTime.Now;

            GendersListItems = genders;

            PopulateMembershipTypes(membershipTypes);
        }

        public CustomerFormViewModel(Customer customer, List<MembershipType> membershipTypes, IEnumerable<Gender> genders)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            MembershipTypeId = customer.MembershipTypeId;

            GendersListItems = genders;

            PopulateMembershipTypes(membershipTypes);
        }

        private void PopulateMembershipTypes(List<MembershipType> membershipTypes)
        {
            MembershipTypesListItems = new List<SelectListItem>();

            List<MembershipType> listOfGroups = membershipTypes
                .GroupBy(g => new { g.MembershipTypeGroup.Id })
                .Select(g => g.First())
                .ToList();

            List<SelectListGroup> selectListGroup = new List<SelectListGroup>();
            foreach (MembershipType group in listOfGroups)
            {
                selectListGroup.Add(new SelectListGroup { Name = group.MembershipTypeGroup.Name });
            }


            foreach (MembershipType membershipType in membershipTypes)
            {
                MembershipTypesListItems.Add(new SelectListItem
                {
                    Value = membershipType.Id.ToString(),
                    Text = membershipType.Name,
                    Group = selectListGroup.Single(g => g.Name == membershipType.MembershipTypeGroup.Name)
                });
            }
        }
    }
}