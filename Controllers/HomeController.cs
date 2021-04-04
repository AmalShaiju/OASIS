using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OASIS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OASIS.Data;
using Microsoft.AspNetCore.Identity;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using OASIS.ViewModels;

namespace OASIS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _applicationContext;
        private readonly OasisContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ApplicationDbContext applicationContext, OasisContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _applicationContext = applicationContext;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {
            DashBoardVM dashVm = new DashBoardVM();

            try
            {
                // get signed in user profile and employee profie 

                var user = await _userManager.GetUserAsync(User);
                var employeeProfile = await _context.Employees.FirstOrDefaultAsync(p => p.UserName == user.UserName);

                if (User.IsInRole("Designer"))
                {
                    dashVm = DesignerDashView(employeeProfile);
                }


            }
            catch
            {

            }



            return View(dashVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public DashBoardVM DesignerDashView(Employee employeeProfile)
        {
            DashBoardVM dashvm = new DashBoardVM();

            // get all projects made by the logged in designer
            var projectsUserWorkedOn =
            _context.Projects
            .Include(project => project.Customer)
            .Include(p => p.Bids).ThenInclude(p => p.Approval)
            .Where(project => project.Bids.Where(bid => bid.DesignerID == employeeProfile.ID).Any()).OrderBy(project => project.Name);

            dashvm.Projects = projectsUserWorkedOn.ToList();




            // get all bids which was approved by both the client and NBD
            var approvals =
                _context.Bids.Where(p => p.DesignerID == employeeProfile.ID)
                .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID);
            dashvm.ApprovedBids = approvals.ToList();

            // get all bids which was approved by either the client and NBD
            var disApprovals =
                _context.Bids.Where(p => p.DesignerID == employeeProfile.ID)
                .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID || p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID);
            dashvm.DisApprovedBids = disApprovals.ToList();

            // get all bids that reuires approval
            var reqApprovals =
              _context.Bids.Where(p => p.DesignerID == employeeProfile.ID)
              .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID
              || p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID
              );


            dashvm.ReqApprovalBids = reqApprovals.ToList();


            // get all bids grouped by bid status
            foreach (var status in _context.BidStatuses)
            {
                // bids might be null
                try
                {
                    BidBidStatusVM bidBidStatus = new BidBidStatusVM
                    {
                        BidStatusName = status.Name,
                        BidStatusID = status.ID,
                        Bids = _context.Bids.Where(p => p.BidStatusID == status.ID).Where(p => p.DesignerID == employeeProfile.ID).ToList()
                    };
                    dashvm.BidBidStatusVMs.Add(bidBidStatus);

                }
                catch
                {

                }
            }

            try
            {
                // all projects with start date after today's date
                var startApproch = _context.Projects
                    .Where(p => p.Bids.Where(p => p.IsFinal == true && p.EstBidStartDate > DateTime.Today).Any())
                    .Where(project => project.Bids.Where(bid => bid.DesignerID == employeeProfile.ID).Any());

                // get all bids grouped by projcet
                foreach (var project in startApproch)
                {
                    ProjectBidDateVM s = new ProjectBidDateVM();
                    s.ProjectName = project.Name;
                    s.ProjectID = project.ID;

                    foreach (var bid in project.Bids.Where(p => p.DesignerID == employeeProfile.ID))
                    {
                        s.ApprovedBidDate = bid.EstBidStartDate;
                        dashvm.StartApprochBids.Add(s);
                    }
                }

                // all projects with End date after today's date
                var endApproch = _context.Projects
                      .Where(p => p.Bids
                      .Where(p => p.IsFinal == true && p.EstBidEndDate > DateTime.Today).Any())
                      .Where(project => project.Bids.Where(bid => bid.DesignerID == employeeProfile.ID).Any());

                // get all bids grouped by projcet
                foreach (var project in endApproch)
                {
                    ProjectBidDateVM s = new ProjectBidDateVM();
                    s.ProjectName = project.Name;
                    s.ProjectID = project.ID;

                    foreach (var bid in project.Bids.Where(p => p.DesignerID == employeeProfile.ID))
                    {
                        s.ApprovedBidDate = bid.EstBidEndDate;
                        dashvm.EndApprochBids.Add(s);
                    }
                }

            }
            catch
            {

            }

            return (dashvm);
        }

        [HttpGet]
        public async Task<JsonResult> DashFilter(string userName, string ApprovalStatus, int? BidStatusID, int? ProjectID)
        {

            try
            {
                var statusID = 0;

                var employeeProfile = await _context.Employees.FirstOrDefaultAsync(p => p.UserName == userName);

                var bidsUserWorkedOn =
                    _context.Bids.Where(p => p.DesignerID == employeeProfile.ID);


                if (ApprovalStatus != null)
                {
                    if (ApprovalStatus == "Approved")
                    {
                        bidsUserWorkedOn = bidsUserWorkedOn
                        .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID 
                        && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID);


                    }
                    else if (ApprovalStatus == "Disapproved")
                    {
                        bidsUserWorkedOn = bidsUserWorkedOn
                              .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID 
                              || p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID);

                    }
                    else
                    {
                        bidsUserWorkedOn = bidsUserWorkedOn
                           .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID 
                           && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID
                          || p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID 
                          && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID
                          );
                    }


                }

                if (BidStatusID != null)
                {
                    bidsUserWorkedOn = bidsUserWorkedOn.Where(p => p.BidStatusID == BidStatusID);
                }

                if (ProjectID != null)
                {
                    bidsUserWorkedOn = bidsUserWorkedOn.Where(p => p.ProjectID == ProjectID);

                }

                if(!(bidsUserWorkedOn.Count() < 1))
                {
                    var successReturnVal = new { success = true, msg = $"Filter Success!", objects = bidsUserWorkedOn };

                    return Json(successReturnVal);
                }
                else
                {
                    var successReturnVal = new { success = false, msg = $"No Bids Matching the Filter" };

                    return Json(successReturnVal);
                }

             
            }
            catch
            {

            }

            var FailureReturnVal = new { success = false, msg = $"Filter Failed!" };

            return Json(FailureReturnVal);

        }

    }
}
