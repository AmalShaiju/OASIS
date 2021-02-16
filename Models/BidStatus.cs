using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.Models
{
    public class BidStatus
    {
        public int ID { get; set; }

        [Display(Name = "Estimated Amount")]
        [Required(ErrorMessage = "You must enter the estimated amount.")]
        public string Name { get; set; }

        public  ICollection<Bid> Bids { get; set; }
    }
}
