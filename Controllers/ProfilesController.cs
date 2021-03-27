using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OASIS.Data;
using OASIS.Models;
using OASIS.Utilities;
using OASIS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly OasisContext _context;
        private readonly UserManager<IdentityUser> _userManager;
  

        public ProfilesController(OasisContext context, UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Profiles/Details/5
        public async Task<IActionResult> Details(string userName)
        {
            if (userName == null)
            {
                return NotFound();
            }

            Employee employee = _context.Employees
                .FirstOrDefault(p => p.UserName == userName);

            ProfileVM userProfile = CreateProfile(employee);

            return View("Index", userProfile);

        }

        // GET: Profiles/Edit/5
        public async Task<IActionResult> Edit(string userName)
        {
            if (userName == null)
            {
                return NotFound();
            }

            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Employees");

            Employee employee = _context.Employees
               .FirstOrDefault(p => p.UserName == userName);


            if (employee == null)
            {
                return NotFound();
            }

            return View(CreateProfile(employee));
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string userName, Byte[] RowVersion)
        {
            ViewData["returnURL"] = MaintainURL.ReturnURL(HttpContext, "Employees");

            var employeeToUpdate = _context.Employees.SingleOrDefault(p => p.UserName == userName);

            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            _context.Entry(employeeToUpdate).Property("RowVersion").OriginalValue = RowVersion;
            if (await TryUpdateModelAsync<Employee>(employeeToUpdate, "", p => p.FirstName, p => p.LastName, p => p.MiddleName, p =>
                p.Phone, p => p.Email, p => p.RoleID, p => p.Password))
            {
                try
                {
                    // set new user name if first and last name changed changed
                    employeeToUpdate.UserName = employeeToUpdate.SetUserName;
                    UpdateUserAccount(employeeToUpdate);
                    await _context.SaveChangesAsync();

                    //return RedirectToAction(nameof(Index));
                    return RedirectToAction("Index", new { employeeToUpdate.UserName });


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
                        if (databaseValues.Phone != clientValues.Phone)
                            ModelState.AddModelError("Phone", "Current value: "
                                + databaseValues.Phone);
                        if (databaseValues.Email != clientValues.Email)
                            ModelState.AddModelError("Email", "Current value: "
                                + databaseValues.Email);
                     
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


            return View(CreateProfile(employeeToUpdate));
        }


        public ProfileVM CreateProfile(Employee emp)
        {

            ProfileVM UserProfile = new ProfileVM
            {
                FirstName = emp.FirstName,
                MiddleName = emp.MiddleName,
                LastName = emp.LastName,
                Phone = emp.Phone,
                Email = emp.Email,
                UserName = emp.UserName,
                Password = emp.Password

            };

            return UserProfile;
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
                        // Update user Credimentals
                        IdentityUser user = await _userManager.FindByEmailAsync(employee.Email);
                        user.UserName = employee.UserName;
                        await _userManager.UpdateAsync(user);

                        // update user password
                        var passResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                        await _userManager.ResetPasswordAsync(user, passResetToken, employee.Password);
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
