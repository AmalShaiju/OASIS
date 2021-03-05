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
            Random random = new Random();

            string[] baconNotes = new string[] { "Bacon ipsum dolor amet meatball corned beef kevin, alcatra kielbasa biltong drumstick strip steak spare ribs swine. Pastrami shank swine leberkas bresaola, prosciutto frankfurter porchetta ham hock short ribs short loin andouille alcatra. Andouille shank meatball pig venison shankle ground round sausage kielbasa. Chicken pig meatloaf fatback leberkas venison tri-tip burgdoggen tail chuck sausage kevin shank biltong brisket.", "Sirloin shank t-bone capicola strip steak salami, hamburger kielbasa burgdoggen jerky swine andouille rump picanha. Sirloin porchetta ribeye fatback, meatball leberkas swine pancetta beef shoulder pastrami capicola salami chicken. Bacon cow corned beef pastrami venison biltong frankfurter short ribs chicken beef. Burgdoggen shank pig, ground round brisket tail beef ribs turkey spare ribs tenderloin shankle ham rump. Doner alcatra pork chop leberkas spare ribs hamburger t-bone. Boudin filet mignon bacon andouille, shankle pork t-bone landjaeger. Rump pork loin bresaola prosciutto pancetta venison, cow flank sirloin sausage.", "Porchetta pork belly swine filet mignon jowl turducken salami boudin pastrami jerky spare ribs short ribs sausage andouille. Turducken flank ribeye boudin corned beef burgdoggen. Prosciutto pancetta sirloin rump shankle ball tip filet mignon corned beef frankfurter biltong drumstick chicken swine bacon shank. Buffalo kevin andouille porchetta short ribs cow, ham hock pork belly drumstick pastrami capicola picanha venison.", "Picanha andouille salami, porchetta beef ribs t-bone drumstick. Frankfurter tail landjaeger, shank kevin pig drumstick beef bresaola cow. Corned beef pork belly tri-tip, ham drumstick hamburger swine spare ribs short loin cupim flank tongue beef filet mignon cow. Ham hock chicken turducken doner brisket. Strip steak cow beef, kielbasa leberkas swine tongue bacon burgdoggen beef ribs pork chop tenderloin.", "Kielbasa porchetta shoulder boudin, pork strip steak brisket prosciutto t-bone tail. Doner pork loin pork ribeye, drumstick brisket biltong boudin burgdoggen t-bone frankfurter. Flank burgdoggen doner, boudin porchetta andouille landjaeger ham hock capicola pork chop bacon. Landjaeger turducken ribeye leberkas pork loin corned beef. Corned beef turducken landjaeger pig bresaola t-bone bacon andouille meatball beef ribs doner. T-bone fatback cupim chuck beef ribs shank tail strip steak bacon." };

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
                     },
                      new Role
                      {
                          Name = "Sales Associate",
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
                    },
                     new Employee
                     {
                         FirstName = "Dave",
                         LastName = "Kendell",
                         AddressLineOne = "580 First Ave",
                         City = "Welland",
                         Province = "Ontario",
                         Country = "Canada",
                         Phone = 9255524213,
                         Email = "Dkendell1@outlook.com",
                         RoleID = context.Roles.FirstOrDefault(d => d.Name == "Sales Associate").ID
                     }
                    );
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


                string[] productTypes = new string[] { "Plant Inventory", "Pottery Inventory", "Materials Inventory"};
                if (!context.ProductTypes.Any())
                {
                   foreach( string i in productTypes)
                    {
                        ProductType a = new ProductType()
                        {
                            Name = i
                        };
                        context.Add(a);
                    }
                    context.SaveChanges();

                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                    new Product
                    {
                        Code = "Lacco",
                        Description = "Lacco Australasica",
                        size = "15 Gal",
                        Price = 450.00,
                        ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Plant Inventory").ID

                    },
                      new Product
                      {
                          Code = "TCP50",
                          Description = "t/c Pot",
                          size = "50 Gal",
                          Price = 110.95,
                          ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Pottery Inventory").ID

                      },
                        new Product
                        {
                            Code = "CBRK5",
                            Description = "Decorative Cedar Bark",
                            size = "bag(5 cu Ft)",
                            Price = 15.95,
                            ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Materials Inventory").ID

                        });
                    context.SaveChanges();
                }

                string[] bidStatus = new string[] { "Requires Approval", "Approved", "Disapproved" };
                if (!context.BidStatuses.Any())
                {
                    foreach (string i in bidStatus)
                    {
                        BidStatus a = new BidStatus()
                        {
                            Name = i
                        };
                        context.Add(a);
                    }
                    context.SaveChanges();
                }

                int[] projectID = context.Projects.Select(s => s.ID).ToArray();
                int[] designerID = context.Employees.Where(p => p.Role.Name == "Designer").Select(p => p.ID).ToArray();
                int[] salesAssociateID = context.Employees.Where(p => p.Role.Name == "Sales Associate").Select(p => p.ID).ToArray();
                int[] bidStatusID = context.BidStatuses.Select(p => p.ID).ToArray();
                int ProjectCount = projectID.Count();
                int designerCount = designerID.Count();
                int bidStatusCount = bidStatusID.Count();
                int salesAssociateCount = salesAssociateID.Count();

                if (!context.Bids.Any())
                {
                    foreach (int i in projectID)
                    {
                        Bid a = new Bid()
                        {
                            DateCreated = DateTime.Now,
                            EstAmount = random.Next(1000, 100000),
                            EstBidStartDate = DateTime.Today,
                            EstBidEndDate = DateTime.Today.AddDays(random.Next(5)),
                            Comments = baconNotes[random.Next(5)],
                            DesignerID = designerID[random.Next(designerCount)],
                            SalesAsscociateID = salesAssociateID[random.Next(salesAssociateCount)],
                            ProjectID = projectID[random.Next(ProjectCount)],
                            BidStatusID = bidStatusID[random.Next(bidStatusCount)],
                            

                        };
                        context.Bids.Add(a);

                    } 
                    context.SaveChanges();
                }

                int[] bidID = context.Bids.Select(s => s.ID).ToArray();
                int[] productID = context.Products.Select(p => p.ID).ToArray();
                if (!context.BidProducts.Any())
                {
                    foreach(int i in bidID)
                    {

                        BidProduct a = new BidProduct()
                        {
                            Quantity = random.Next(5,100),
                            BidID = bidID[random.Next(bidID.Count())],
                            ProductID = productID[random.Next(productID.Count())]
                        };
                        context.BidProducts.Add(a);

                    }
                    context.SaveChanges();
                }

                int[] roleID = context.Roles.Select(p => p.ID).ToArray();
                if (!context.BidLabours.Any())
                {
                    foreach (int i in bidID)
                    {

                        BidLabour a = new BidLabour()
                        {
                            Hours = random.Next(1, 8),
                            Description = baconNotes[random.Next(5)],
                            RoleID = roleID[random.Next(roleID.Count())],
                            BidID = bidID[random.Next(bidID.Count())]

                        };
                        context.BidLabours.Add(a);

                    }
                    context.SaveChanges();
                }
            }


        }
    }

}
