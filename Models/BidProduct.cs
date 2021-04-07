using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OASIS.Models
{
    public class BidProduct
    {
        //PK?FK
        public int BidID { get; set; }
        public Bid Bid { get; set; }

        [Required(ErrorMessage = "You must enter a quantity.")]
        [Range(0, 9999999, ErrorMessage = "Invalid Quantity.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "You must select a product type.")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
