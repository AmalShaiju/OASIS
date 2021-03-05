using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.Models
{
    public class ProductType : Auditable
    {

        public int ID { get; set; }

        [Display(Name = "Product Type Name")]
        [Required(ErrorMessage = "You cannot leave the Product type name blank.")]
        [StringLength(50, ErrorMessage = "Project Name cannot be more than 20 characters long.")]
        
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
