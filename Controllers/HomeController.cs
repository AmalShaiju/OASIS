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
                ViewData["EmployeeID"] = employeeProfile.ID;

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
                .Where(project => project.Bids.Where(bid => bid.DesignerID == employeeProfile.ID).Any());


            dashvm.Projects = projectsUserWorkedOn.OrderBy(p => p.Name).ToList();




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
                BidBidStatusVM bidBidStatus = new BidBidStatusVM();
                try
                {


                    bidBidStatus.BidStatusName = status.Name;
                    bidBidStatus.BidStatusID = status.ID;
                    bidBidStatus.BidsCount = _context.Bids.Where(p => p.BidStatusID == status.ID)
                    .Where(p => p.DesignerID == employeeProfile.ID).Count();

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
        public async Task<JsonResult> DashFilter(string userName, string ApprovalStatus, int? BidStatusID, int? ProjectID, DateTime? FromDate, DateTime? ToDate)
        {

            try
            {
                var statusID = 0;


                var employeeProfile = await _context.Employees.FirstOrDefaultAsync(p => p.UserName == userName);

                var bidsUserWorkedOn =
                  _context.Bids
                  .Include(p => p.Project)
                  .Where(p => p.DesignerID == employeeProfile.ID);

                if (FromDate.HasValue)
                {
                    bidsUserWorkedOn = bidsUserWorkedOn.Where(p => p.DateCreated >= FromDate);
                }

                if (ToDate.HasValue)
                {

                    bidsUserWorkedOn = bidsUserWorkedOn.Where(p => p.DateCreated <= ToDate);

                }

                if(bidsUserWorkedOn.Count() == 0)
                {
                    var FailurereturnVal = new { success = false, msg = $"No Bids Matching the filter" };
                    return Json(FailurereturnVal);
                }



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

                if (!(bidsUserWorkedOn.Count() < 1))
                {
                    var successReturnVal = new { success = true, msg = $"Filter Success!", objects = bidsUserWorkedOn.Select(p => new BidDashVM { ID = p.ID, DateCreated = p.DateCreated, EstAmount = p.EstAmount, ProjectName = p.Project.Name }) };

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

        [HttpGet]
        public async Task<JsonResult> DateFilter(string userName, DateTime? FromDate, DateTime? ToDate)
        {


            var employeeProfile = await _context.Employees.FirstOrDefaultAsync(p => p.UserName == userName);

            var bidsUserWorkedOn =
              _context.Bids
              .Include(p => p.Project)
              .Where(p => p.DesignerID == employeeProfile.ID);

            if (FromDate.HasValue)
            {
                bidsUserWorkedOn = bidsUserWorkedOn.Where(p => p.DateCreated >= FromDate);
            }

            if (ToDate.HasValue)
            {
                bidsUserWorkedOn = bidsUserWorkedOn.Where(p => p.DateCreated <= ToDate);
            }

            if (bidsUserWorkedOn.Count() == 0)
            {
                var FailurereturnVal = new { success = false, msg = $"No Bids Matching the filter" };
                return Json(FailurereturnVal);
            }


            // get all bids which was approved by both the client and NBD
            var approvals =
                _context.Bids.Where(p => p.DesignerID == employeeProfile.ID)
                .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID);

            if (FromDate.HasValue)
            {
                approvals = approvals.Where(p => p.DateCreated >= FromDate);
            }

            if (ToDate.HasValue)
            {
                approvals = approvals.Where(p => p.DateCreated <= ToDate);

            }



            // get all bids which was approved by either the client and NBD
            var disApprovals =
                _context.Bids.Where(p => p.DesignerID == employeeProfile.ID)
                .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID || p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID);

            if (FromDate.HasValue)
            {
                disApprovals =  disApprovals.Where(p => p.DateCreated >= FromDate);
            }

            if (ToDate.HasValue)
            {
                disApprovals = disApprovals.Where(p => p.DateCreated <= ToDate);

            }


            // get all bids that reuires approval
            var reqApprovals =
              _context.Bids.Where(p => p.DesignerID == employeeProfile.ID)
              .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID
              || p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID
              );

            if (FromDate.HasValue)
            {
                reqApprovals  =  reqApprovals.Where(p => p.DateCreated >= FromDate);
            }

            if (ToDate.HasValue)
            {
                reqApprovals = reqApprovals.Where(p => p.DateCreated <= ToDate);

            }

            List <BidBidStatusVM> bidsByStatus = new List<BidBidStatusVM>();

            // get all bids grouped by bid status
            foreach (var status in _context.BidStatuses)
            {
                // bids might be null
                BidBidStatusVM bidBidStatus = new BidBidStatusVM();
                try
                {
                    bidBidStatus.BidStatusName = status.Name;
                    bidBidStatus.BidStatusID = status.ID;
                    bidBidStatus.BidsCount = bidsUserWorkedOn.Where(p => p.BidStatusID == status.ID).Count();
                    bidsByStatus.Add(bidBidStatus);
                   
                }
                catch
                {

                }
            }

            try
            {
                // all projects with start date after today's date
                var startApproch = _context.Projects
                    .Include(p => p.Bids)
                    .Where(p => p.Bids.Where(p => p.IsFinal == true && p.EstBidStartDate > DateTime.Today).Any())
                    .Where(project => project.Bids.Where(bid => bid.DesignerID == employeeProfile.ID).Any());

              


                List<ProjectBidDateVM> StartProjectByDate = new List<ProjectBidDateVM>();
                // get all bids grouped by projcet
                foreach (var project in startApproch)
                {
                    try
                    {
                        ProjectBidDateVM s = new ProjectBidDateVM();
                        s.ProjectName = project.Name;
                        s.ProjectID = project.ID;

                        var tempBids = project.Bids.Where(p => p.DesignerID == employeeProfile.ID);

                        if (FromDate.HasValue)
                        {
                            tempBids = tempBids.Where(p => p.DateCreated >= FromDate);
                        }

                        if (ToDate.HasValue)
                        {
                            tempBids = tempBids.Where(p => p.DateCreated <= ToDate);

                        }

                        foreach (var bid in tempBids)
                        {
                            s.ApprovedBidDate = bid.EstBidStartDate;
                            StartProjectByDate.Add(s);
                        }
                    }
                    catch
                    {

                    }
                   
                }

                // all projects with End date after today's date
                var endApproch = _context.Projects
                     .Include(p => p.Bids)
                      .Where(p => p.Bids
                      .Where(p => p.IsFinal == true && p.EstBidEndDate > DateTime.Today).Any())
                      .Where(project => project.Bids.Where(bid => bid.DesignerID == employeeProfile.ID).Any());


               

                List<ProjectBidDateVM> EndProjectByDate = new List<ProjectBidDateVM>();
                // get all bids grouped by projcet
                foreach (var project in endApproch)
                {
                    try
                    {
                        ProjectBidDateVM s = new ProjectBidDateVM();
                        s.ProjectName = project.Name;
                        s.ProjectID = project.ID;

                        var tempBids = project.Bids.Where(p => p.DesignerID == employeeProfile.ID);

                        if (FromDate.HasValue)
                        {
                            tempBids = tempBids.Where(p => p.DateCreated >= FromDate);
                        }

                        if (ToDate.HasValue)
                        {
                            tempBids = tempBids.Where(p => p.DateCreated <= ToDate);


                        }

                        foreach (var bid in tempBids)
                        {
                            s.ApprovedBidDate = bid.EstBidEndDate;
                            EndProjectByDate.Add(s);
                        }
                    }
                    catch
                    {

                    }
                   
                }


                //var withDateReturn = new { success = true, msg = $"Filter Success!" ,  Bids = bidsUserWorkedOn, Approvals = approvals.Count(), disapprovals = disApprovals.Count(),  RequireApproval = reqApprovals.Count(), StartDateApproch = ApprochProjectByDate, EndDateApproch = EndProjectByDate };
                var withDateReturn = new { success = true, msg = "Filter Success!",
                    approvalsCount = approvals.Count(),
                    disapprovalsCount = disApprovals.Count(),
                    reqapprovalsCount = reqApprovals.Count(),
                    bidStatusByBids = bidsByStatus.OrderBy(p => p.BidStatusName),
                    endApprochBids = EndProjectByDate.OrderBy(p => p.ProjectName),
                    startApprochBids = StartProjectByDate.OrderBy(p => p.ProjectName),
                    bids = bidsUserWorkedOn.Select(p => new BidDashVM { ID = p.ID, DateCreated = p.DateCreated, EstAmount = p.EstAmount, ProjectName = p.Project.Name })




                };
                return Json(withDateReturn);


            }
            catch
            {

            }

            var withoutDateReturn = new { success = true, msg = $"Filter Success!", bids= bidsUserWorkedOn.Select(p => new BidDashVM { ID = p.ID, DateCreated = p.DateCreated, EstAmount = p.EstAmount })};
            return Json(withoutDateReturn);

        }
    }
}
