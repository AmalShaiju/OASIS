﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace OASIS.Models
{
    public class Customer : Auditable
    {
        public int ID { get; set; }

        [Display(Name = "Customer")]
        public string FullName
        {
            get
            {
                return FirstName
                    + (string.IsNullOrEmpty(MiddleName) ? " " :
                    (" " + (char?)MiddleName[0] + ". ").ToUpper())
                    + LastName;
            }
        }

        [Display(Name = "Customer")]
        public string FormalName
        {
            get
            {
                return LastName + ", " + FirstName
                    + (string.IsNullOrEmpty(MiddleName) ? "" :
                        (" " + (char?)MiddleName[0] + ".").ToUpper());
            }
        }

        [Required(ErrorMessage = "You cannot leave the client name blank.")]
        [Display(Name="Organization Name")]
        //Name of the client or organization
        public string OrgName { get; set; }

        //Person of contact First, last and Middle
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        [StringLength(50, ErrorMessage = "Middle name cannot be more than 50 characters long.")]
        public string MiddleName { get; set; }

        // person of contact position
        [Display(Name = "Position Name")]
        [Required(ErrorMessage = "You cannot leave the postion Name blank.")]
        [StringLength(50, ErrorMessage = "Position name cannot be more than 30 characters long.")]
        public string Position { get; set; }

        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "You cannot leave the Address Line blank.")]
        [StringLength(50, ErrorMessage = "Address Line 1 cannot be more than 50 characters long.")]
        public string AddressLineOne { get; set; }

        //Optional
        [Display(Name = "Address Line 2")]
        [StringLength(100, ErrorMessage = "Address Line 1 cannot be more than 100 characters long.")]
        public string AddressLineTwo { get; set; }

        //Optional
        [Display(Name = "Apartment/Suite Number")]
        [StringLength(100, ErrorMessage = "Apartment/Suite Number cannot be more than 100 characters long.")]
        public string ApartmentNumber{ get; set; }

        [Required(ErrorMessage = "You cannot leave the City blank.")]
        [StringLength(100, ErrorMessage = "Address Line 1 cannot be more than 100 characters long.")]
        public string City { get; set; }

        [Required(ErrorMessage = "You cannot leave the Province blank.")]
        [StringLength(100, ErrorMessage = "Province cannot be more than 100 characters long.")]
        public string Province { get; set; }

        [Required(ErrorMessage = "You cannot leave the Country blank.")]
        [StringLength(100, ErrorMessage = "Country cannot be more than 100 characters long.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 Phone { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
