using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            this.StartApprochBids = new List<ProjectBidDateVM>();
            this.EndApprochBids = new List<ProjectBidDateVM>();

            this.BidBidStatusVMs = new List<BidBidStatusVM>();
        }

        public List<Project> Projects { get; set; }
        public List<Bid> ApprovedBids { get; set; }
        public List<Bid> DisApprovedBids { get; set; }
        public List<Bid> ReqApprovalBids { get; set; }
        public List<ProjectBidDateVM> StartApprochBids { get; set; }
        public List<ProjectBidDateVM> EndApprochBids { get; set; }
        public List<BidBidStatusVM> BidBidStatusVMs { get; set; }

        public bool NoRole { get; set; }

    }
}
