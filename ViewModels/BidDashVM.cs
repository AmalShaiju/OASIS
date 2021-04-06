using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.ViewModels
{
    public class BidDashVM
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProjectName { get; set; }
        public double EstAmount { get; set; }
    }
}
