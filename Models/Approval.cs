using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.Models
{
    public class Approval
    {
        public int ID { get; set; }

        [Display(Name = "Notes")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
        public int ClientStatusID { get; set; }
        public virtual ApprovalStatus ClientStatus { get; set; }
        public int DesignerStatusID { get; set; }
        public virtual ApprovalStatus DesignerStatus { get; set; }
        public ICollection<ApprovalStatus> ApprovalStatuses { get; set; }
        public int BidID { get; set; }
        public Bid Bid { get; set; }

        public int BidID { get; set; }
        public Bid Bid { get; set; }

    }
}
