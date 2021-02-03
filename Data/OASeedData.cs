using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OASIS.Models;

namespace OASIS.Data
{
    public class OASeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new OasisContext(
                serviceProvider.GetRequiredService<DbContextOptions<OasisContext>>()))
            {
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                     new Role
                     {
                         Name = "Designer",
                         LabourCostPerHr = Convert.ToDecimal(40.0),
                         LabourPricePerHr = Convert.ToDecimal(65.0)
                     },

                     new Role
                     {
                         Name = "Production Worker",
                         LabourCostPerHr = Convert.ToDecimal(18.0),
                         LabourPricePerHr = Convert.ToDecimal(30.0)
                     },
                     new Role
                     {
                         Name = "Equipment Operator",
                         LabourCostPerHr = Convert.ToDecimal(45.0),
                         LabourPricePerHr = Convert.ToDecimal(65.0)
                     },
                     new Role
                     {
                         Name = "Botanist",
                         LabourCostPerHr = Convert.ToDecimal(50.0),
                         LabourPricePerHr = Convert.ToDecimal(75.0)
                     }
                );
                    context.SaveChanges();
                }

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(
                    new Employee
                    {
                        FirstName = "Amal",
                        MiddleName = "E",
                        LastName = "Shaiju",
                        AddressLineOne = "586 First Ave",
                        City = "Welland",
                        Province = "Ontario",
                        Country = "Canada",
                        Phone = 9055551212,
                        Email = "Ashaiju1@outlook.com",
                        RoleID = context.Roles.FirstOrDefault(d => d.Name == "Designer").ID
                    },
                    new Employee
                    {
                        FirstName = "Jesline",

                        LastName = "Stanly",
                        AddressLineOne = "596",
                        AddressLineTwo = "First Ave",
                        ApartmentNumber = "Flat 96",
                        City = "Welland",
                        Province = "Ontario",
                        Country = "Canada",
                        Phone = 9055551213,
                        Email = "Jstanly1@outlook.com",
                        RoleID = context.Roles.FirstOrDefault(d => d.Name == "Production Worker").ID
                    },
                    new Employee
                    {
                        FirstName = "Val",
                        LastName = "Garaskky",
                        AddressLineOne = "598 First Ave",
                        City = "Welland",
                        Province = "Ontario",
                        Country = "Canada",
                        Phone = 9055551215,
                        Email = "val1@outlook.com",
                        RoleID = context.Roles.FirstOrDefault(d => d.Name == "Equipment Operator").ID
                    },
                    new Employee
                    {
                        FirstName = "Yasmeen",
                        LastName = "Faager",
                        AddressLineOne = "590 First Ave",
                        City = "Welland",
                        Province = "Ontario",
                        Country = "Canada",
                        Phone = 9055554213,
                        Email = "Yasmmen1@outlook.com",
                        RoleID = context.Roles.FirstOrDefault(d => d.Name == "Botanist").ID
                    },
                    new Employee
                    {
                        FirstName = "Rufaro",
                        LastName = "Gonsalaz",
                        AddressLineOne = "580 First Ave",
                        City = "Welland",
                        Province = "Ontario",
                        Country = "Canada",
                        Phone = 9255554213,
                        Email = "Rgonz1@outlook.com",
                        RoleID = context.Roles.FirstOrDefault(d => d.Name == "Botanist").ID
                    });
                    context.SaveChanges();
                }


                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                    new Customer
                    {
                        OrgName = "Wonderboy Media",
                        FirstName = "Amal",
                        MiddleName = "E",
                        LastName = "Shaiju",
                        Position = "CEO",
                        AddressLineOne = "586 First Ave",
                        City = "Welland",
                        Province = "Ontario",
                        Country = "Canada",
                        Phone = 9055551212,
                        Email = "Ashaiju1@outlook.com",
                    },
                    new Customer
                    {
                        OrgName = "Weiner Media",
                        FirstName = "Jesline",
                        LastName = "Stanly",
                        Position = "CTO",
                        AddressLineOne = "596",
                        AddressLineTwo = "First Ave",
                        ApartmentNumber = "Flat 96",
                        City = "Welland",
                        Province = "Ontario",
                        Country = "Canada",
                        Phone = 9055551213,
                        Email = "Jstanly1@outlook.com",
                    },
                    new Customer
                    {
                        OrgName = "VAl Media",
                        FirstName = "Val",
                        LastName = "Garaskky",
                        Position = "Manager",
                        AddressLineOne = "598 First Ave",
                        City = "Welland",
                        Province = "Ontario",
                        Country = "Canada",
                        Phone = 9055551215,
                        Email = "val1@outlook.com",
                    },
                    new Customer
                    {
                        OrgName = "Yasmeen Designers",
                        FirstName = "Yasmeen",
                        LastName = "Faager",
                        Position = "CFO",
                        AddressLineOne = "590 First Ave",
                        City = "Welland",
                        Province = "Ontario",
                        Country = "Canada",
                        Phone = 9055554213,
                        Email = "Yasmmen1@outlook.com",
                    },
                    new Customer
                    {
                        OrgName = "Rufaro Media",
                        FirstName = "Rufaro",
                        Position = "CKO",
                        LastName = "Gonsalaz",
                        AddressLineOne = "580 First Ave",
                        City = "Welland",
                        Province = "Ontario",
                        Country = "Canada",
                        Phone = 9255554213,
                        Email = "Rgonz1@outlook.com",
                    });
                    context.SaveChanges();
                }


                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(
                    new Project
                    {
                        Name = "Alpha",
                        SiteAddressLineOne = "586 First Ave",
                        City = "Welland",
                        Province = "Ontario",
                        Country = "Canada",
                        CustomerID = context.Customers.FirstOrDefault(d => d.FirstName == "Amal").ID
                    },
                    new Project
                    {
                        Name = "Beta",
                        SiteAddressLineOne = "586",
                        SiteAddressLineTwo = "First Ave",
                        City = "Welland",
                        Province = "Ontario",
                        Country = "Canada",
                        CustomerID = context.Customers.FirstOrDefault(d => d.FirstName == "Jesline").ID
                    },
                     new Project
                     {
                         Name = "Mall",
                         SiteAddressLineOne = "586 First Ave",
                         City = "Welland",
                         Province = "Ontario",
                         Country = "Canada",
                         CustomerID = context.Customers.FirstOrDefault(d => d.FirstName == "Yasmeen").ID
                     },
                     new Project
                     {
                         Name = "Seaway Mall",
                         SiteAddressLineOne = "586 First Ave",
                         City = "Welland",
                         Province = "Ontario",
                         Country = "Canada",
                         CustomerID = context.Customers.FirstOrDefault(d => d.FirstName == "Val").ID
                     },
                      new Project
                      {
                          Name = "Start up",
                          SiteAddressLineOne = "586 First Ave",
                          City = "Welland",
                          Province = "Ontario",
                          Country = "Canada",
                          CustomerID = context.Customers.FirstOrDefault(d => d.FirstName == "Rufaro").ID
                      }, new Project
                      {
                          Name = "Walmart",
                          SiteAddressLineOne = "786 First Ave",
                          City = "Niagara",
                          Province = "Ontario",
                          Country = "Canada",
                          CustomerID = context.Customers.FirstOrDefault(d => d.FirstName == "Amal").ID
                      },
                        new Project
                        {
                            Name = "BestBuy",
                            SiteAddressLineOne = "5096 First Ave",
                            City = "Hamilton",
                            Province = "Ontario",
                            Country = "Canada",
                            CustomerID = context.Customers.FirstOrDefault(d => d.FirstName == "Jesline").ID
                        },
                         new Project
                         {
                             Name = "Staples",
                             SiteAddressLineOne = "596 First Ave",
                             City = "St Chatehrines",
                             Province = "Ontario",
                             Country = "Canada",
                             CustomerID = context.Customers.FirstOrDefault(d => d.FirstName == "Val").ID
                         },
                          new Project
                          {
                              Name = "Burger King",
                              SiteAddressLineOne = "176 First Ave",
                              City = "Toronto",
                              Province = "Ontario",
                              Country = "Canada",
                              CustomerID = context.Customers.FirstOrDefault(d => d.FirstName == "Yasmeen").ID
                          },
                           new Project
                           {
                               Name = "Tim Hortons",
                               SiteAddressLineOne = "586 First Ave",
                               City = "Welland",
                               Province = "Ontario",
                               Country = "Canada",
                               CustomerID = context.Customers.FirstOrDefault(d => d.FirstName == "Rufaro").ID
                           },
                            new Project
                            {
                                Name = "A&W Canada",
                                SiteAddressLineOne = "586 First Ave",
                                City = "Welland",
                                Province = "Ontario",
                                Country = "Canada",
                                CustomerID = context.Customers.FirstOrDefault(d => d.FirstName == "Amal").ID
                            }
                      );
                    context.SaveChanges();
                }

            }
        }
    }
}
