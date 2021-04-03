using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OASIS.Models;

namespace OASIS.ViewModels
{
    public class DashBoardVM
    {
        public DashBoardVM()
        {
            this.ApprovedBids = new List<Bid>();
            this.DisApprovedBids = new List<Bid>();
            this.ReqApprovalBids = new List<Bid>();
            this.Projects = new List<Project>();
            this.BidBidStatusVMs = new List<BidBidStatusVM>();
        }

       public List<Project> Projects { get; set; }
       public List<Bid> ApprovedBids { get; set; }
       public List<Bid> DisApprovedBids { get; set; }
       public List<Bid> ReqApprovalBids { get; set; }
       public List<BidBidStatusVM> BidBidStatusVMs { get; set; }

    }
}
