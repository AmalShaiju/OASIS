using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.Models
{
    public class BidLabour
    {
        //PK?FK
        public int BidID { get; set; }
        public Bid Bid { get; set; }

        [Display(Name = "Estimated Amount")]
        [Required(ErrorMessage = "You must enter the description.")]
        [StringLength(100, ErrorMessage = "Project Name cannot be more than 20 characters long.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "You must enter the hours.")]
        [Range(0, 9999999, ErrorMessage = "Invalid Quantity.")]
        public double Hours { get; set; }

        [Required(ErrorMessage = "You must select a role.")]

        public int RoleID { get; set; }
        public Role Role { get; set; }


    }
}
