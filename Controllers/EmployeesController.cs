using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OASIS.Data;
using OASIS.Models;
using OASIS.Utilities;
using OASIS.ViewModels;

namespace OASIS.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _applicationContext;
        private readonly OasisContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;

        public EmployeesController(ApplicationDbContext applicationContext, OasisContext context, UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _applicationContext = applicationContext;
            _context = context;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        // GET: Employees
        [Authorize(Policy = "EmployeeViewPolicy")]
        public async Task<IActionResult> Index(string QuickSearchName, string SearchName, string SearchEmail, int? RoleID,
            string actionButton, int? page, int? pageSizeID, string sortDirection = "asc", string sortField = "Employee")
        {
            var employee = from p in _context.Employees
                           .Include(p => p.Role)
                           select p;

            ViewData["RoleID"] = new SelectList(_context
                 .Roles
                 .OrderBy(c => c.Name), "ID", "Name");

            ViewData["Filtering"] = "";

            CookieHelper.CookieSet(HttpContext, "CustomersURL", "", -1);


            if (RoleID.HasValue)
            {
                employee = employee.Where(p => p.RoleID == RoleID);
                ViewData["Filtering"] = " show";
            }

            if (String.IsNullOrEmpty(SearchName))
            {
                if (!String.IsNullOrEmpty(QuickSearchName))
                {
                    employee = employee.Where(p => p.LastName.ToUpper().Contains(QuickSearchName.ToUpper())
                                            || p.FirstName.ToUpper().Contains(QuickSearchName.ToUpper()));
                }

            }


            if (!String.IsNullOrEmpty(SearchEmail))
            {
                employee = employee.Where(p => p.Email.ToUpper().Contains(SearchEmail.ToUpper()));
                ViewData["Filtering"] = "show";
            }


            if (!String.IsNullOrEmpty(SearchName))
            {
                employee = employee.Where(p => p.LastName.ToUpper().Contains(SearchName.ToUpper())
                                        || p.FirstName.ToUpper().Contains(SearchName.ToUpper()));
                ViewData["Filtering"] = "show";
            }

            if (!String.IsNullOrEmpty(actionButton))
            {
                if (actionButton != "Filter")
                {
                    if (actionButton == sortField)
                    {
                        sortDirection = sortDirection == "asc" ? "desc" : "asc";
                    }
                    sortField = actionButton;
                }
            }

            if (sortField == "Employee")
            {
                if (sortDirection == "asc")
                {
                    employee = employee
                       .OrderBy(p => p.LastName)
                       .ThenBy(p => p.FirstName);
                }
                else
                {
                    employee = employee
                        .OrderByDescending(p => p.LastName)
                        .ThenByDescending(p => p.FirstName);
                }
            }

            else //Sorting by Patient Name
            {
                if (sortDirection == "asc")
                {
                    employee = employee
                        .OrderBy(p => p.Role.Name);
                }
                else
                {
                    employee = employee
                        .OrderByDescending(p => p.Role.Name);
                }
            }
            //Set sort for next time
            ViewData["sortField"] = sortField;
            ViewData["sortDirection"] = sortDirection;


            //For Paging
            int pageSize;
            if (pageSizeID.HasValue)
            {
                //Value selected from DDL so use and save it to Cookie
                pageSize = pageSizeID.GetValueOrDefault();
                CookieHelper.CookieSet(HttpContext, "pageSizeValue", pageSize.ToString(), 30);
            }
            else
            {
                //Not selected so see if it is in Cookie
                pageSize = Convert.ToInt32(HttpContext.Request.Cookies["pageSizeValue"]);
            }
            pageSize = (pageSize == 0) ? 5 : pageSize;
            ViewData["pageSizeID"] =
                new SelectList(new[] { "3", "5", "10", "20", "30", "40", "50", "100", "500" }, pageSize.ToString());
            var pagedData = await PaginatedList<Employee>.CreateAsync(employee.AsNoTracking(), page ?? 1, pageSize);

            return View(pagedData);


        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.Role)
                .FirstOrDefaultAsync(m => m.ID == id);

            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Employees");
            ViewData["Bids"] = _context.Bids.Where(p => p.DesignerID == id);
            ViewData["ProjectName"] = _context.Bids.Where(p => p.DesignerID == id).Select(p => p.Project).Distinct(); ;

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        [Authorize(Policy = "EmployeeCreatePolicy")]
        public IActionResult Create(int? roleID)
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Employees");
            Employee employee = new Employee();

            if (roleID != null)
            {
                //save the roleID
                TempData["RoleID"] = roleID;
            }
            else
            {
                TempData["RoleID"] = 0;

            }

            PopulateDropDownLists(employee);
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "EmployeeCreatePolicy")]

        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,MiddleName,AddressLineOne,AddressLineTwo,ApartmentNumber,City,Province,Country,Phone,Email,RoleID,IsUser")] Employee employee, int fromRoleID)
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Employees");

            if (fromRoleID != 0)
            {
                //set the tempdata again for post back after error
                TempData["RoleID"] = fromRoleID;

                employee.RoleID = fromRoleID;
            }
            else
            {
                //set the tempdata again for post back after error
                TempData["RoleID"] = 0;
            }



            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(employee);

                    if (employee.IsUser)
                    {
                        try
                        {
                            employee.UserName = employee.SetUserName;
                            UpdateUserAccount(employee);
                        }
                        catch
                        {
                            ModelState.AddModelError("", "Employee User Account Could not be created");
                        }
                    }

                    await _context.SaveChangesAsync();

                    //return RedirectToAction(nameof(Index));
                  
                    return RedirectToAction("Details", new { employee.ID });

                }

            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: Employees.Email"))
                {
                    ModelState.AddModelError("Email", "Unable to save changes.You cannot have same email address as another employee .");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            PopulateDropDownLists(employee);
            return View(employee);
        }

        // GET: Employees/Edit/5
        [Authorize(Policy = "EmployeeEditPolicy")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Employees");


            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            PopulateDropDownLists(employee);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "EmployeeEditPolicy")]

        public async Task<IActionResult> Edit(int id, Byte[] RowVersion)
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Employees");

            var employeeToUpdate = _context.Employees.SingleOrDefault(p => p.ID == id);

            if (employeeToUpdate == null)
            {
                return NotFound();
            }
            _context.Entry(employeeToUpdate).Property("RowVersion").OriginalValue = RowVersion;
            if (await TryUpdateModelAsync<Employee>(employeeToUpdate, "", p => p.FirstName, p => p.LastName, p => p.MiddleName, p =>
                 p.AddressLineOne, p => p.AddressLineTwo, p => p.Province, p => p.Country, p => p.City, p => p.Phone, p => p.Email, p => p.RoleID, p => p.Password, p => p.IsUser))
            {
                try
                {
                    UpdateUserAccount(employeeToUpdate);
                    await _context.SaveChangesAsync();

                    //return RedirectToAction(nameof(Index));
                    return RedirectToAction("Details", new { employeeToUpdate.ID });


                }
                catch (DbUpdateConcurrencyException ex)// Added for concurrency
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Employee)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError("",
                            "Unable to save changes. The Role was deleted by another user.");
                    }
                    else
                    {
                        var databaseValues = (Employee)databaseEntry.ToObject();
                        if (databaseValues.FirstName != clientValues.FirstName)
                            ModelState.AddModelError("FirstName", "Current value: "
                                + databaseValues.FirstName);
                        if (databaseValues.LastName != clientValues.LastName)
                            ModelState.AddModelError("LastName", "Current value: "
                                + databaseValues.LastName);
                        if (databaseValues.MiddleName != clientValues.LastName)
                            ModelState.AddModelError("MiddleName", "Current value: "
                                + databaseValues.MiddleName);
                        if (databaseValues.AddressLineOne != clientValues.AddressLineOne)
                            ModelState.AddModelError("AddressLineOne", "Current value: "
                                + databaseValues.AddressLineOne);
                        if (databaseValues.AddressLineTwo != clientValues.AddressLineTwo)
                            ModelState.AddModelError("AddressLineTwo", "Current value: "
                                + databaseValues.AddressLineTwo);
                        if (databaseValues.City != clientValues.City)
                            ModelState.AddModelError("City", "Current value: "
                                + databaseValues.City);
                        if (databaseValues.Province != clientValues.Province)
                            ModelState.AddModelError("Province", "Current value: "
                                + databaseValues.Province);
                        if (databaseValues.Country != clientValues.Country)
                            ModelState.AddModelError("Country", "Current value: "
                                + databaseValues.Country);
                        if (databaseValues.Phone != clientValues.Phone)
                            ModelState.AddModelError("Phone", "Current value: "
                                + databaseValues.Phone);
                        if (databaseValues.Email != clientValues.Email)
                            ModelState.AddModelError("Email", "Current value: "
                                + databaseValues.Email);
                        if (databaseValues.RoleID != clientValues.RoleID)
                        {
                            Role databaseRole = await _context.Roles.SingleOrDefaultAsync(i => i.ID == databaseValues.RoleID);
                            ModelState.AddModelError("RoleID", $"Current value: {databaseRole?.Name}");
                        }


                        ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                                + "was modified by another user after you received your values. The "
                                + "edit operation was canceled and the current values in the database "
                                + "have been displayed. If you still want to save your version of this record, click "
                                + "the Save button again. Otherwise click the 'Back to List' hyperlink.");
                        employeeToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                        ModelState.Remove("RowVersion");
                    }
                }
                catch (DbUpdateException dex)
                {
                    if (dex.GetBaseException().Message.Contains("UNIQUE constraint failed: Employees.Email"))
                    {
                        ModelState.AddModelError("Email", "Unable to save changes.You cannot have same email address as another employee .");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    }
                } 


            }
            PopulateDropDownLists(employeeToUpdate);
            return View(employeeToUpdate);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Employees");


            var employee = await _context.Employees
                .Include(e => e.Role)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Employees");

            try
            {
                var employee = await _context.Employees.FindAsync(id);
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return Redirect(ViewData["returnURL"].ToString());

            }
            catch (DbUpdateException dex)
            {
                if (dex.GetBaseException().Message.Contains("FOREIGN KEY constraint failed"))
                {
                    ModelState.AddModelError("", "Unable to Delete Employee. You cannot delete an employees assigned to a team.");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }

        // Order Role drop down list by name
        private void PopulateDropDownLists(Employee employee = null)
        {
            var dQuery = from d in _context.Roles
                         orderby d.Name
                         select d;
            ViewData["RoleID"] = new SelectList(dQuery, "ID", "Name", employee?.RoleID);
        }

        private async void UpdateUserAccount(Employee employee)
        {
            if (employee.IsUser)
            {
                // check if user exist in db
                if (_userManager.FindByEmailAsync(employee.Email).Result == null && _userManager.FindByNameAsync(employee.UserName).Result == null)
                {
                    try
                    {
                        // Create a new user
                        IdentityUser user = new IdentityUser
                        {
                            UserName = employee.UserName,
                            Email = employee.Email
                        };

                        await _userManager.CreateAsync(user, "password");

                        var msg = new EmailMessage()
                        {
                            ToAddress = user.Email,
                            Subject = "Set up user account for OASIS",
                            Content = "<p> Congragulation You have been invited to set up an account with OASIS.</P>" +
                                  "<p>Follow the link given below to get started</p>" +
                                  "<a>http://oasis-analytics.azurewebsites.net/</a>" +
                                  $"<p>UserName : {user.UserName}</p>" +
                                  $"<p>Password : password </p>"
                        };

                        await _emailSender.SendEmailAsync(msg.ToAddress, msg.Subject, msg.Content);
                    }
                    catch
                    {
                        ModelState.AddModelError("IsUser", "User Creation Failed");
                    }


                }
                else
                {
                    try
                    {
                        // Update user password
                        IdentityUser user = await _userManager.FindByEmailAsync(employee.Email);

                        // update user password
                        var passResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                        await _userManager.ResetPasswordAsync(user, passResetToken, employee.Password);
                        await _userManager.UpdateAsync(user);

                        _applicationContext.SaveChanges();
                    }
                    catch
                    {
                        ModelState.AddModelError("Password", "User Updation Failed");
                    }


                }
            }


        }

    

    }
}
