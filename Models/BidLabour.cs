using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OASIS.Models
{
    public class BidLabour
    {
        //PK?FK
        public int BidID { get; set; }
        public Bid Bid { get; set; }

        [Required(ErrorMessage = "You must enter the hours.")]
        [Range(0, 9999999, ErrorMessage = "Invalid Quantity.")]
        public double Hours { get; set; }

        [Required(ErrorMessage = "You must select a role.")]
        public int RoleID { get; set; }
        public Role Role { get; set; }


    }
}
