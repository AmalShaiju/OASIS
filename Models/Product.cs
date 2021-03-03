using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.Models
{
    public class Product : Auditable
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "You cannot leave the Code blank.")]
        [MinLength(4, ErrorMessage = "The Code must be at least 4 characters long.")]
        [MaxLength(8, ErrorMessage = "The Code cannot be more than 8 characters long")]
        public string Code { get; set; }

        [Required(ErrorMessage = "You cannot leave the description blank.")]
        [MinLength(4, ErrorMessage = "The description must be at least 4 characters long.")]
        [MaxLength(50, ErrorMessage = "The description cannot be more than 50 characters long")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You cannot leave the size blank.")]
        [MinLength(4, ErrorMessage = "The description must be at least 4 characters long.")]
        [MaxLength(15, ErrorMessage = "The description cannot be more than 15 characters long")]
        public string size { get; set; }

        [Required(ErrorMessage = "You must enter the price.")]
        [DataType(DataType.Currency)]
        [Range(0, 9999999.99, ErrorMessage = "Invalid price.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "You must select a product type.")]
        public int ProductTypeID { get; set; }
        public ProductType ProductType { get; set; }

    }
}
