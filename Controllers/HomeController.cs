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
        public async Task<JsonResult> DashFilter(string ApprovalStatus, int? BidStatusID, int? ProjectID)
        {

            try
            {
                var user = await _userManager.GetUserAsync(User);
                var employeeProfile = await _context.Employees.FirstOrDefaultAsync(p => p.UserName == user.UserName);

                var projectsUserWorkedOn =
                  _context.Projects
                  .Include(project => project.Customer)
                  .Include(p => p.Bids).ThenInclude(p => p.Approval)
                  .Where(project => project.Bids.Where(bid => bid.DesignerID == employeeProfile.ID).Any());



                if (ApprovalStatus != null)
                {
                    if (ApprovalStatus == "Approved")
                    {
                        projectsUserWorkedOn =  projectsUserWorkedOn.Where(p => p.Bids.Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID
                        && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID).Any());

                    }
                    else if (ApprovalStatus == "Disapproved")
                    {
                        projectsUserWorkedOn = projectsUserWorkedOn.Where(p => p.Bids.Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID
                        || p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID).Any());

                    }
                    else
                    {
                        projectsUserWorkedOn = projectsUserWorkedOn.Where(p => p.Bids.Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID &&
                        p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID
                        || p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID &&
                        p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID).Any()
                        );
                    }


                }

                if (BidStatusID != null)
                {
                    var statusID = _context.ApprovalStatuses.SingleOrDefaultAsync(p => p.Name == ApprovalStatus).Id;
                    projectsUserWorkedOn = projectsUserWorkedOn.Where(p => p.Bids.Where(p => p.BidStatusID == statusID).Any());
                }

                if (ProjectID != null)
                {
                    projectsUserWorkedOn = projectsUserWorkedOn.Where(p => p.ID == ProjectID);
                }

                 var successReturnVal = new { success = true, msg = $"Filter Success!", objects = projectsUserWorkedOn };

                return Json(successReturnVal);
            }
            catch
            {
                
            }

            var FailureReturnVal = new { success = true, msg = $"Filter Failed!" };

            return Json(FailureReturnVal);

        }
       
    }
}
