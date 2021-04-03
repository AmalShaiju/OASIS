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
            try
            {
                // get signed in user profile and employee profie 

                var user = await _userManager.GetUserAsync(User);
                var employeeProfile = await _context.Employees.FirstOrDefaultAsync(p => p.UserName == user.UserName);
                DashBoardVM dashvm = new DashBoardVM();


                if (User.IsInRole("Designer"))
                {
                    var projects =
                    _context.Projects
                    .Include(project => project.Customer)
                    .Include(project => project.Bids).ThenInclude(p => p.BidStatus)
                    .Include(p => p.Bids).ThenInclude(p => p.Approval).ThenInclude(p => p.ApprovalStatuses)
                    .Where(project => project.Bids.Where(bid => bid.DesignerID == employeeProfile.ID).Any()).OrderBy(project => project.Name);
                    dashvm.Projects = projects.ToList();

                    var approvals =
                        _context.Bids.Where(p => p.DesignerID == employeeProfile.ID)
                        .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID && (p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Approved").ID));
                    dashvm.ApprovedBids = approvals.ToList();

                    var disApprovals =
                        _context.Bids.Where(p => p.DesignerID == employeeProfile.ID)
                        .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID || (p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "Disapproved").ID));
                    dashvm.DisApprovedBids = disApprovals.ToList();

                    var reqApprovals =
                      _context.Bids.Where(p => p.DesignerID == employeeProfile.ID)
                      .Where(p => p.Approval.ClientStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID || (p.Approval.DesignerStatusID == _context.ApprovalStatuses.SingleOrDefault(p => p.Name == "RequiresApproval").ID));
                    dashvm.ReqApprovalBids = reqApprovals.ToList();


                    foreach (var status in _context.BidStatuses)
                    {
                        try
                        {
                            BidBidStatusVM bidBidStatus = new BidBidStatusVM
                            {
                                BidStatusName = status.Name,
                                Bids = _context.Bids.Where(p => p.BidStatusID == status.ID).ToList()
                            };
                            dashvm.BidBidStatusVMs.Add(bidBidStatus);

                        }
                        catch
                        {

                        }



                    }

                    return View(projects);
                }
            }
            catch
            {

            }



            return View();
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
    }
}
