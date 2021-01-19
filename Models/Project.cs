using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.Models
{
    public class Project
    {
        public int ID { get; set; }

        [Display(Name = "Project Name")]
        [Required(ErrorMessage = "You cannot leave the Project Name blank.")]
        [StringLength(20, ErrorMessage = "Project Name cannot be more than 20 characters long.")]
        public string Name { get; set; }

        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "You cannot leave the Address Line blank.")]
        [StringLength(50, ErrorMessage = "Address Line 1 cannot be more than 50 characters long.")]
        public string SiteAddressLineOne { get; set; }

        //Optional
        [Display(Name = "Address Line 2 (Optional)")]
        [StringLength(100, ErrorMessage = "Address Line 1 cannot be more than 100 characters long.")]
        public string SiteAddressLineTwo { get; set; }

        [Required(ErrorMessage = "You cannot leave the City blank.")]
        [StringLength(100, ErrorMessage = "Address Line 1 cannot be more than 100 characters long.")]
        public string City { get; set; }

        [Required(ErrorMessage = "You cannot leave the Province blank.")]
        [StringLength(100, ErrorMessage = "Province cannot be more than 100 characters long.")]
        public string Province { get; set; }

        [Required(ErrorMessage = "You cannot leave the Country blank.")]
        [StringLength(100, ErrorMessage = "Country cannot be more than 100 characters long.")]
        public string Country { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
