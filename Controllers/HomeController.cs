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
            ViewData["UserRole"] = "NotAssigned";
            DashBoardVM dashVm = new DashBoardVM();

            try
            {
                // get signed in user profile and employee profie 
                var user = await _userManager.GetUserAsync(User);
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "UserRoles");
                }

                var employeeProfile = await _context.Employees.FirstOrDefaultAsync(p => p.UserName == user.UserName);
                ViewData["EmployeeID"] = employeeProfile.ID;

                if (User.IsInRole("Designer"))
                {
                    dashVm = DesignerDashView(employeeProfile);
                    ViewData["UserRole"] = "Designer";

                }
                else if (User.IsInRole("Sales"))
                {
                    dashVm = SalesDashVM(employeeProfile);
                    ViewData["UserRole"] = "Sales";

                }
                else
                {
                    dashVm = ManagementDashVM(employeeProfile);
                    ViewData["UserRole"] = "Management";

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
              || p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID
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
                        if (bid.IsFinal)
                        {
                            s.ApprovedBidDate = bid.EstBidStartDate;
                            dashvm.StartApprochBids.Add(s);
                        }
                       
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
                        if (bid.IsFinal)
                        {
                            s.ApprovedBidDate = bid.EstBidEndDate;
                            dashvm.EndApprochBids.Add(s);
                        }
                    }
                }

            }
            catch
            {

            }

            return (dashvm);
        }

        public DashBoardVM SalesDashVM(Employee employeeProfile)
        {
            DashBoardVM dashvm = new DashBoardVM();

            // get all projects made by the logged in designer
            var projectsUserWorkedOn =
                _context.Projects
                .Include(project => project.Customer)
                .Where(project => project.Bids.Where(bid => bid.SalesAsscociateID == employeeProfile.ID).Any());

            dashvm.Projects = projectsUserWorkedOn.ToList();

            return dashvm;

        }

        public DashBoardVM ManagementDashVM(Employee employeeProfile)
        {
            DashBoardVM dashvm = new DashBoardVM();

            var ReqApprovalBids = _context.Bids
                .Include(p => p.Approval)
                .Include(p => p.Project)
                .ThenInclude(p => p.Customer)
                  .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID
              || p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID
              || p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID
              );

            dashvm.ReqApprovalBids = ReqApprovalBids.OrderBy(p => p.DateCreated).ToList();

            // get all bids which was approved by both the client and NBD
            var approvals =
                _context.Bids
                .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID);

            dashvm.ApprovedBids = approvals.ToList();


            // get all bids which was approved by either the client and NBD
            var disApprovals =
                _context.Bids
                .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID || p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID);


            dashvm.DisApprovedBids = disApprovals.ToList();




            // get all bids grouped by bid status
            foreach (var status in _context.BidStatuses)
            {
                // bids might be null
                BidBidStatusVM bidBidStatus = new BidBidStatusVM();
                try
                {


                    bidBidStatus.BidStatusName = status.Name;
                    bidBidStatus.BidStatusID = status.ID;
                    bidBidStatus.BidsCount = _context.Bids.Where(p => p.BidStatusID == status.ID).Count();

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
                    .Where(p => p.Bids.Where(p => p.IsFinal == true && p.EstBidStartDate > DateTime.Today).Any());


                // get all bids grouped by projcet
                foreach (var project in startApproch)
                {
                    ProjectBidDateVM s = new ProjectBidDateVM();
                    s.ProjectName = project.Name;
                    s.ProjectID = project.ID;

                    // should only have one approved but some cases may have more than one 
                    foreach (var bid in project.Bids)
                    {
                        if (bid.IsFinal)
                        {
                            s.ApprovedBidDate = bid.EstBidStartDate;
                            dashvm.StartApprochBids.Add(s);
                        }
                       
                    }
                }

                // all projects with End date after today's date
                var endApproch = _context.Projects
                      .Where(p => p.Bids
                      .Where(p => p.IsFinal == true && p.EstBidEndDate > DateTime.Today).Any());


                // get all bids grouped by projcet
                foreach (var project in endApproch)
                {
                    ProjectBidDateVM s = new ProjectBidDateVM();
                    s.ProjectName = project.Name;
                    s.ProjectID = project.ID;

                    foreach (var bid in project.Bids)
                    {
                        if (bid.IsFinal)
                        {
                            s.ApprovedBidDate = bid.EstBidEndDate;
                            dashvm.EndApprochBids.Add(s);
                        }
                       
                    }
                }

            }
            catch
            {

            }



            return dashvm;
        }

        [HttpGet]
        public async Task<JsonResult> DashFilter(string ApprovalStatus, int? BidStatusID, int? ProjectID, DateTime? FromDate, DateTime? ToDate)
        {

            try
            {
                var statusID = 0;

                var user = await _userManager.GetUserAsync(User);
                var employeeProfile = await _context.Employees.FirstOrDefaultAsync(p => p.UserName == user.UserName);

                var bidsUserWorkedOn =
                     _context.Bids
                     .Include(p => p.Project).Select(p => p);

                if (!await _userManager.IsInRoleAsync(user, "Management"))
                {
                    bidsUserWorkedOn =
                    _context.Bids
                    .Include(p => p.Project)
                    .Where(p => p.DesignerID == employeeProfile.ID);
                }




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
                    var failureReturnVal = new { success = false, msg = $"No Bids Matching the Filter" };

                    return Json(failureReturnVal);
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

            // get all bids
            var bidsUserWorkedOn =
              _context.Bids
             .Include(p => p.Project).Select(p => p);

            // filter using the designer
            if (!(User.IsInRole("Management")))
            {
                bidsUserWorkedOn =
               _context.Bids
                .Include(p => p.Project)
               .Where(p => p.DesignerID == employeeProfile.ID);
            }

            // filter dates
            if (FromDate.HasValue)
            {
                bidsUserWorkedOn = bidsUserWorkedOn.Where(p => p.DateCreated >= FromDate);
            }

            if (ToDate.HasValue)
            {
                bidsUserWorkedOn = bidsUserWorkedOn.Where(p => p.DateCreated <= ToDate);
            }

            // return err msg if no bids
            if (bidsUserWorkedOn.Count() == 0)
            {
                var FailurereturnVal = new { success = false, msg = $"No Bids Matching the filter" };
                return Json(FailurereturnVal);
            }


            // get all bids which was approved by both the client and NBD
            var approvals =
             _context.Bids.Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID);

            if (!User.IsInRole("Management"))
            {
                approvals = approvals.Where(p => p.DesignerID == employeeProfile.ID);
            }


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
                _context.Bids
                .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID || p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID);

            if (!User.IsInRole("Management"))
            {
                disApprovals =  disApprovals.Where(p => p.DesignerID == employeeProfile.ID);
            }


            if (FromDate.HasValue)
            {
                disApprovals = disApprovals.Where(p => p.DateCreated >= FromDate);
            }

            if (ToDate.HasValue)
            {
                disApprovals = disApprovals.Where(p => p.DateCreated <= ToDate);

            }


            // get all bids that reuires approval
            var reqApprovals =
              _context.Bids
              .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID
              || p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID
              || p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID && p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID
              );

            if (!User.IsInRole("Management"))
            {
                reqApprovals =  reqApprovals.Where(p => p.DesignerID == employeeProfile.ID);
            }


            if (FromDate.HasValue)
            {
                reqApprovals = reqApprovals.Where(p => p.DateCreated >= FromDate);
            }

            if (ToDate.HasValue)
            {
                reqApprovals = reqApprovals.Where(p => p.DateCreated <= ToDate);

            }

            List<BidBidStatusVM> bidsByStatus = new List<BidBidStatusVM>();

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
                    .Where(p => p.Bids.Where(p => p.IsFinal == true && p.EstBidStartDate > DateTime.Today).Any());

                if (!User.IsInRole("Management"))
                {
                    startApproch =  startApproch.Where(project => project.Bids.Where(bid => bid.DesignerID == employeeProfile.ID).Any());
                }


                if (FromDate.HasValue)
                {
                    startApproch = startApproch.Where(p => p.Bids.Where(p => p.DateCreated >= FromDate).Any());
                }

                if (ToDate.HasValue)
                {
                    startApproch = startApproch.Where(p => p.Bids.Where(p => p.DateCreated <= ToDate).Any());
                }





                List<ProjectBidDateVM> StartProjectByDate = new List<ProjectBidDateVM>();
                // get all bids grouped by projcet
                foreach (var project in startApproch)
                {
                    try
                    {
                        ProjectBidDateVM s = new ProjectBidDateVM();
                        s.ProjectName = project.Name;
                        s.ProjectID = project.ID;

                        foreach (var bid in project.Bids.Where(p => p.DesignerID == employeeProfile.ID))
                        {
                            if (bid.IsFinal)
                            {
                                s.ApprovedBidDate = bid.EstBidStartDate;
                                StartProjectByDate.Add(s);
                            }

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
                      .Where(p => p.IsFinal == true && p.EstBidEndDate > DateTime.Today).Any());


                if (!User.IsInRole("Management"))
                {
                    endApproch = endApproch.Where(project => project.Bids.Where(bid => bid.DesignerID == employeeProfile.ID).Any());
                }

                if (FromDate.HasValue)
                {
                    endApproch = startApproch.Where(p => p.Bids.Where(p => p.DateCreated >= FromDate).Any());
                }

                if (ToDate.HasValue)
                {
                    endApproch = startApproch.Where(p => p.Bids.Where(p => p.DateCreated <= ToDate).Any());
                }





                List<ProjectBidDateVM> EndProjectByDate = new List<ProjectBidDateVM>();
                // get all bids grouped by projcet
                foreach (var project in endApproch)
                {
                    try
                    {
                        ProjectBidDateVM s = new ProjectBidDateVM();
                        s.ProjectName = project.Name;
                        s.ProjectID = project.ID;

                        foreach (var bid in project.Bids.Where(p => p.DesignerID == employeeProfile.ID))
                        {
                            if (bid.IsFinal)
                            {
                                s.ApprovedBidDate = bid.EstBidEndDate;
                                EndProjectByDate.Add(s);
                            }
                                
                        }
                    }
                    catch
                    {

                    }

                }


                //var withDateReturn = new { success = true, msg = $"Filter Success!" ,  Bids = bidsUserWorkedOn, Approvals = approvals.Count(), disapprovals = disApprovals.Count(),  RequireApproval = reqApprovals.Count(), StartDateApproch = ApprochProjectByDate, EndDateApproch = EndProjectByDate };
                var withDateReturn = new
                {
                    success = true,
                    msg = "Filter Success!",
                    approvalsCount = approvals.Count(),
                    disapprovalsCount = disApprovals.Count(),
                    reqapprovalsCount = reqApprovals.Count(),
                    bidStatusByBids = bidsByStatus.OrderBy(p => p.BidStatusName),
                    endApprochBids = EndProjectByDate.OrderBy(p => p.ProjectName),
                    startApprochBids = StartProjectByDate.OrderBy(p => p.ProjectName),
                    bids = bidsUserWorkedOn.OrderBy(p => p.DateCreated).Select(p => new BidDashVM { ID = p.ID, DateCreated = p.DateCreated, EstAmount = p.EstAmount, ProjectName = p.Project.Name })




                };
                return Json(withDateReturn);


            }
            catch
            {

            }

            var withoutDateReturn = new { success = true, msg = $"Filter Success!", bids = bidsUserWorkedOn.Select(p => new BidDashVM { ID = p.ID, DateCreated = p.DateCreated, EstAmount = p.EstAmount }) };
            return Json(withoutDateReturn);

        }

        [HttpGet]
        public async Task<JsonResult> ShowCustomer(int Id)
        {
            try
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(p => p.ID == Id);

                var successResult = new { success = true, msg = $"Successfully customer found!", customer = customer };
                return Json(successResult);
            }
            catch
            {

            }


            var failureResult = new { success = false, msg = $"Failed to find customer!" };
            return Json(failureResult);



        }

        [HttpGet]
        public async Task<JsonResult> PreviewBid(int Id)
        {
            try
            {
                var bid = await _context.Bids.Include(p => p.Approval).SingleOrDefaultAsync(p => p.ID == Id);
                bid.Approval.ClientStatus = _context.ApprovalStatuses.SingleOrDefault(p => p.ID == bid.Approval.ClientStatusID);
                bid.Approval.DesignerStatus = _context.ApprovalStatuses.SingleOrDefault(p => p.ID == bid.Approval.DesignerStatusID);

                List<BidProductDetails> bidProducts = _context.BidProducts.Where(p => p.BidID == Id)
                    .Select(p => new BidProductDetails
                    {
                        Code = _context.Products.SingleOrDefault(s => s.ID == p.ProductID).Code,
                        Size = _context.Products.SingleOrDefault(s => s.ID == p.ProductID).size,
                        Description = _context.Products.SingleOrDefault(s => s.ID == p.ProductID).Description,
                        Price = _context.Products.SingleOrDefault(s => s.ID == p.ProductID).Price,
                        Quantity = p.Quantity,
                        Total = p.Quantity * (double)_context.Products.SingleOrDefault(s => s.ID == p.ProductID).Price,
                    }).ToList();



                List<BidLabourDetails> bidLabours = _context.BidLabours.Where(p => p.BidID == Id)
                    .Select(p => new BidLabourDetails
                    {
                        Hours = p.Hours,
                        Name = _context.Roles.SingleOrDefault(r => r.ID == p.RoleID).Name,
                        Price = (double)_context.Roles.SingleOrDefault(r => r.ID == p.RoleID).LabourPricePerHr,
                        Total = (double)_context.Roles.SingleOrDefault(r => r.ID == p.RoleID).LabourPricePerHr * p.Hours,
                    }).ToList();

                var returnVal = new { success = true, msg = $"Successfully found bid", bid = bid, bidProducts = bidProducts, bidLabours = bidLabours };
                return Json(returnVal);
            }
            catch
            {
                var returnVal = new { success = false, msg = $"Something went wrong" };
                return Json(returnVal);
            }


        }

        public async Task<ActionResult> UpdateApproval(int bidId, string approvalStatusName, string approvalType)
        {
            try
            {
                var ApprovalToUpdate = await _context.Approvals.SingleOrDefaultAsync(p => p.BidID == bidId);

                if (approvalType == "client")
                {
                    ApprovalToUpdate.ClientStatusID = _context.ApprovalStatuses.SingleOrDefault(p => p.Name == approvalStatusName).ID;
                    _context.Update(ApprovalToUpdate);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                else
                {
                    ApprovalToUpdate.DesignerStatusID = _context.ApprovalStatuses.SingleOrDefault(p => p.Name == approvalStatusName).ID;
                    _context.Update(ApprovalToUpdate);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }


            }
            catch
            {
                return RedirectToAction("Index");
            }




        }
    }
}
