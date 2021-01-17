using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.Models
{
    public class Role
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="You cannot leave the role name blank")]
        public string Name { get; set; }

        [Display(Name ="Labour Cost Per Hour")]
        [Required(ErrorMessage = "You cannot leave the role name blank")]
        public Decimal LabourCostPerHr { get; set; }

        [Display(Name = "Labour Price Per Hour")]
        [Required(ErrorMessage = "You cannot leave the role name blank")]
        public Decimal LabourPricePerHr { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
