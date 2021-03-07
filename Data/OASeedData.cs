using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OASIS.Models;
using System.Threading;

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
                string[] approvalStatus = new string[] { "Approved", "Disapproved", "RequiresApproval" };
                string[] bidStatus = new string[] { "In Progress", "Stoped Due To Weather", "Completed", "Not Started", "Waiting approval", "Design stage", "Approved by client", "Approved by NBD", "Needs revision", };
                string[] productTypes = new string[] { "Plant Inventory", "Pottery Inventory", "Materials Inventory" };
                string[] _firstName = new string[] { "Adam", "Alex", "Aaron", "Ben", "Carl", "Dan", "David", "Edward", "Fred", "Frank", "George", "Hal", "Hank", "Ike", "John", "Jack", "Joe", "Larry", "Monte", "Matthew", "Mark", "Nathan", "Otto", "Paul", "Peter", "Roger", "Roger", "Steve", "Thomas", "Tim", "Ty", "Victor", "Walter" };
                string[] _lastName = new string[] { "Anderson", "Ashwoon", "Aikin", "Bateman", "Bongard", "Bowers", "Boyd", "Cannon", "Cast", "Deitz", "Dewalt", "Ebner", "Frick", "Hancock", "Haworth", "Hesch", "Hoffman", "Kassing", "Knutson", "Lawless", "Lawicki", "Mccord", "McCormack", "Miller", "Myers", "Nugent", "Ortiz", "Orwig", "Ory", "Paiser", "Pak", "Pettigrew", "Quinn", "Quizoz", "Ramachandran", "Resnick", "Sagar", "Schickowski", "Schiebel", "Sellon", "Severson", "Shaffer", "Solberg", "Soloman", "Sonderling", "Soukup", "Soulis", "Stahl", "Sweeney", "Tandy", "Trebil", "Trusela", "Trussel", "Turco", "Uddin", "Uflan", "Ulrich", "Upson", "Vader", "Vail", "Valente", "Van Zandt", "Vanderpoel", "Ventotla", "Vogal", "Wagle", "Wagner", "Wakefield", "Weinstein", "Weiss", "Woo", "Yang", "Yates", "Yocum", "Zeaser", "Zeller", "Ziegler", "Bauer", "Baxster", "Casal", "Cataldi", "Caswell", "Celedon", "Chambers", "Chapman", "Christensen", "Darnell", "Davidson", "Davis", "DeLorenzo", "Dinkins", "Doran", "Dugelman", "Dugan", "Duffman", "Eastman", "Ferro", "Ferry", "Fletcher", "Fietzer", "Hylan", "Hydinger", "Illingsworth", "Ingram", "Irwin", "Jagtap", "Jenson", "Johnson", "Johnsen", "Jones", "Jurgenson", "Kalleg", "Kaskel", "Keller", "Leisinger", "LePage", "Lewis", "Linde", "Lulloff", "Maki", "Martin", "McGinnis", "Mills", "Moody", "Moore", "Napier", "Nelson", "Norquist", "Nuttle", "Olson", "Ostrander", "Reamer", "Reardon", "Reyes", "Rice", "Ripka", "Roberts", "Rogers", "Root", "Sandstrom", "Sawyer", "Schlicht", "Schmitt", "Schwager", "Schutz", "Schuster", "Tapia", "Thompson", "Tiernan", "Tisler" };
                string[] countryList = new string[] { "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antarctica", "Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas (the)", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia (Plurinational State of)", "Bonaire, Sint Eustatius and Saba", "Bosnia and Herzegovina", "Botswana", "Bouvet Island", "Brazil", "British Indian Ocean Territory (the)", "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Cabo Verde", "Cambodia", "Cameroon", "Canada", "Cayman Islands (the)", "Central African Republic (the)", "Chad", "Chile", "China", "Christmas Island", "Cocos (Keeling) Islands (the)", "Colombia", "Comoros (the)", "Congo (the Democratic Republic of the)", "Congo (the)", "Cook Islands (the)", "Costa Rica", "Croatia", "Cuba", "Curaçao", "Cyprus", "Czechia", "Côte d'Ivoire", "Denmark", "Djibouti", "Dominica", "Dominican Republic (the)", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Eswatini", "Ethiopia", "Falkland Islands (the) [Malvinas]", "Faroe Islands (the)", "Fiji", "Finland", "France", "French Guiana", "French Polynesia", "French Southern Territories (the)", "Gabon", "Gambia (the)", "Georgia", "Germany", "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guernsey", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Heard Island and McDonald Islands", "Holy See (the)", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran (Islamic Republic of)", "Iraq", "Ireland", "Isle of Man", "Israel", "Italy", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea (the Democratic People's Republic of)", "Korea (the Republic of)", "Kuwait", "Kyrgyzstan", "Lao People's Democratic Republic (the)", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macao", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands (the)", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico", "Micronesia (Federated States of)", "Moldova (the Republic of)", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Myanmar", "Namibia", "Nauru", "Nepal", "Netherlands (the)", "New Caledonia", "New Zealand", "Nicaragua", "Niger (the)", "Nigeria", "Niue", "Norfolk Island", "Northern Mariana Islands (the)", "Norway", "Oman", "Pakistan", "Palau", "Palestine, State of", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines (the)", "Pitcairn", "Poland", "Portugal", "Puerto Rico", "Qatar", "Republic of North Macedonia", "Romania", "Russian Federation (the)", "Rwanda", "Réunion", "Saint Barthélemy", "Saint Helena, Ascension and Tristan da Cunha", "Saint Kitts and Nevis", "Saint Lucia", "Saint Martin (French part)", "Saint Pierre and Miquelon", "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Sint Maarten (Dutch part)", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Georgia and the South Sandwich Islands", "South Sudan", "Spain", "Sri Lanka", "Sudan (the)", "Suriname", "Svalbard and Jan Mayen", "Sweden", "Switzerland", "Syrian Arab Republic", "Taiwan", "Tajikistan", "Tanzania, United Republic of", "Thailand", "Timor-Leste", "Togo", "Tokelau", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands (the)", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates (the)", "United Kingdom of Great Britain and Northern Ireland (the)", "United States Minor Outlying Islands (the)", "United States of America (the)", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela (Bolivarian Republic of)", "Viet Nam", "Virgin Islands (British)", "Virgin Islands (U.S.)", "Wallis and Futuna", "Western Sahara", "Yemen", "Zambia", "Zimbabwe", "Åland Islands" };
                string[] streetNumber = new string[] { "25489", "87459", "35478", "15975", "95125", "78965" };
                string[] CompanyName = new string[] { "Media", "Inc", "Builders", "Shop", "Demolishers", "Styles" };
                string[] position = new string[] { "CEO", "Manager", "Employee", "Supervisor", "CTO" };

                string[] streetName = new string[] { "A street", "B street", "C street", "D street", "E street", "F street" };
                ;
                string[] cityName = new string[] { "Riyadh", "Damman", "Jedda", "Tabouk", "Makka", "Maddena", "Haiel" };

                string[] stateName = new string[] { "Qassem State", "North State", "East State", "South State", "West State" };

                string[] zipCode = new string[] { "28889", "96459", "35748", "15005", "99625", "71465" };

                //bool Checkarrray(List<string> list, string s)
                //{
                //    if (list.Contains(s))
                //        return true;
                //    return false;
                //}


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


                int[] roleID = context.Roles.Select(p => p.ID).ToArray();


                if (!context.Employees.Any())
                {
                    for (int i = 0; i < 25; i++)
                    {

                        var a = new Employee()
                        {
                            FirstName = _firstName[random.Next(_firstName.Count())],
                            MiddleName = _firstName[random.Next(_firstName.Count())],
                            LastName = _lastName[random.Next(_lastName.Count())],
                            AddressLineOne = streetNumber[random.Next(streetNumber.Count())] + streetName[random.Next(streetName.Count())],
                            City = cityName[random.Next(cityName.Count())],
                            Province = stateName[random.Next(stateName.Count())],
                            Country = countryList[random.Next(countryList.Count())],
                            Phone = 1234567890,
                            Email = _firstName[random.Next(_firstName.Count())] + _lastName[random.Next(_lastName.Count())] + "@outlook.com",
                            RoleID = roleID[random.Next(roleID.Count())]
                        };

                        try
                        {
                            context.Add(a);
                            context.SaveChanges();
                        }
                        catch
                        {

                        }
                    }

                }

                //if (!context.Customers.Any())
                //{
                //    for (int i = 0; i < 50; i++)
                //    {

                //        var a = new Customer()
                //        {
                //            FirstName = _firstName[random.Next(_firstName.Count())],
                //            MiddleName = _firstName[random.Next(_firstName.Count())],
                //            LastName = _lastName[random.Next(_lastName.Count())],
                //            AddressLineOne = streetNumber[random.Next(streetNumber.Count())] + " " + streetName[random.Next(streetName.Count())],
                //            City = cityName[random.Next(cityName.Count())],
                //            Province = stateName[random.Next(stateName.Count())],
                //            Country = countryList[random.Next(countryList.Count())],
                //            Phone = 1234567890,
                //            Email = _firstName[random.Next(_firstName.Count())] + _lastName[random.Next(_lastName.Count())] + "@outlook.com",
                //            OrgName = _firstName[random.Next(_firstName.Count())] + " " + CompanyName[random.Next(CompanyName.Count())],
                //            Position = position[random.Next(position.Count())]
                //        };

                //        try
                //        {
                //            context.Add(a);
                //            context.SaveChanges();
                //        }
                //        catch
                //        {
                //            //do nothing
                //        }
                //    }

                //}



                //int[] CustomerIDs = context.Customers.Select(p => p.ID).ToArray();
                ////if (!context.Projects.Any())
                ////{
                ////    List<string> projectName = new List<string>();

                ////    foreach (int i in CustomerIDs)
                ////    {

                ////        var project = _firstName[random.Next(_firstName.Count())] + "Project";

                ////        while (Checkarrray(projectName, project))
                ////        {
                ////            project = _lastName[random.Next(_lastName.Count())] + "Project";

                ////        }

                ////        projectName.Add(project);

                ////        try { 
                ////        context.Projects.Add(
                ////           new Project
                ////           {
                ////               Name = project,
                ////               SiteAddressLineOne = "586 First Ave",
                ////               City = "Welland",
                ////               Province = "Ontario",
                ////               Country = "Canada",
                ////               CustomerID = random.Next(CustomerIDs.Count())
                ////           });

                ////            context.SaveChangesAsync();
                ////        }
                ////        catch
                ////        {

                ////        }

                ////    }
                ////}

                ////if (!context.Projects.Any())
                ////{
                ////    List<string> projectName = new List<string>();
                ////    foreach (int i in CustomerIDs)
                ////    {
                ////        for (int j = 0; j < 5; j++)
                ////        {

                ////            var project = _firstName[random.Next(_firstName.Count())] + "Project";

                ////            while (Checkarrray(projectName, project))
                ////            {
                ////                project = _lastName[random.Next(_lastName.Count())] + "Project";

                ////            }

                ////            Project a = new Project()
                ////            {
                ////                Name = project,
                ////                SiteAddressLineOne = streetNumber[random.Next(streetNumber.Count())] + " " + streetName[random.Next(streetName.Count())],
                ////                City = cityName[random.Next(cityName.Count())],
                ////                Province = stateName[random.Next(stateName.Count())],
                ////                Country = countryList[random.Next(countryList.Count())],
                ////                CustomerID = i


                ////            };

                ////            try
                ////            {
                ////                context.Add(a);
                ////                context.SaveChanges();

                ////            }
                ////            catch
                ////            {
                ////                dod nothing repeat
                ////            }
                ////        }





                ////    }
                ////    context.SaveChanges();
                ////}



                //if (!context.Projects.Any())
                //{
                //    context.Projects.AddRange(
                //    new Project
                //    {
                //        Name = "Alpha",
                //        SiteAddressLineOne = "586 First Ave",
                //        City = "Welland",
                //        Province = "Ontario",
                //        Country = "Canada",
                //        CustomerID = random.Next(CustomerIDs.Count())
                //    },
                //    new Project
                //    {
                //        Name = "Beta",
                //        SiteAddressLineOne = "586",
                //        SiteAddressLineTwo = "First Ave",
                //        City = "Welland",
                //        Province = "Ontario",
                //        Country = "Canada",
                //        CustomerID = random.Next(CustomerIDs.Count())
                //    },
                //     new Project
                //     {
                //         Name = "Mall",
                //         SiteAddressLineOne = "586 First Ave",
                //         City = "Welland",
                //         Province = "Ontario",
                //         Country = "Canada",
                //         CustomerID = random.Next(CustomerIDs.Count())
                //     },
                //     new Project
                //     {
                //         Name = "Seaway Mall",
                //         SiteAddressLineOne = "586 First Ave",
                //         City = "Welland",
                //         Province = "Ontario",
                //         Country = "Canada",
                //         CustomerID = random.Next(CustomerIDs.Count())
                //     },
                //      new Project
                //      {
                //          Name = "Start up",
                //          SiteAddressLineOne = "586 First Ave",
                //          City = "Welland",
                //          Province = "Ontario",
                //          Country = "Canada",
                //          CustomerID = random.Next(CustomerIDs.Count())
                //      }, new Project
                //      {
                //          Name = "Walmart",
                //          SiteAddressLineOne = "786 First Ave",
                //          City = "Niagara",
                //          Province = "Ontario",
                //          Country = "Canada",
                //          CustomerID = random.Next(CustomerIDs.Count())
                //      },
                //        new Project
                //        {
                //            Name = "BestBuy",
                //            SiteAddressLineOne = "5096 First Ave",
                //            City = "Hamilton",
                //            Province = "Ontario",
                //            Country = "Canada",
                //            CustomerID = random.Next(CustomerIDs.Count())
                //        },
                //         new Project
                //         {
                //             Name = "Staples",
                //             SiteAddressLineOne = "596 First Ave",
                //             City = "St Chatehrines",
                //             Province = "Ontario",
                //             Country = "Canada",
                //             CustomerID = random.Next(CustomerIDs.Count())
                //         },
                //          new Project
                //          {
                //              Name = "Burger King",
                //              SiteAddressLineOne = "176 First Ave",
                //              City = "Toronto",
                //              Province = "Ontario",
                //              Country = "Canada",
                //              CustomerID = random.Next(CustomerIDs.Count())
                //          },
                //           new Project
                //           {
                //               Name = "Tim Hortons",
                //               SiteAddressLineOne = "586 First Ave",
                //               City = "Welland",
                //               Province = "Ontario",
                //               Country = "Canada",
                //               CustomerID = random.Next(CustomerIDs.Count())
                //           },
                //            new Project
                //            {
                //                Name = "A&W Canada",
                //                SiteAddressLineOne = "586 First Ave",
                //                City = "Welland",
                //                Province = "Ontario",
                //                Country = "Canada",
                //                CustomerID = random.Next(CustomerIDs.Count())
                //            }
                //      ); ;
                //    context.SaveChanges();
                //}


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





                if (!context.ApprovalStatuses.Any())
                {
                    foreach (string i in approvalStatus)
                    {
                        ApprovalStatus a = new ApprovalStatus()
                        {
                            Name = i
                        };
                        context.Add(a);
                    }
                    context.SaveChanges();

                }


                if (!context.ProductTypes.Any())
                {
                    foreach (string i in productTypes)
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
                          Code = "Cham",
                          Description = "Chamaedorea",
                          size = "15 Gal",
                          Price = 499.00,
                          ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Plant Inventory").ID

                      },
                       new Product
                       {
                           Code = "Cera",
                           Description = "Ceratozamia molongo",
                           size = "14 in",
                           Price = 400.00,
                           ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Plant Inventory").ID

                       },
                         new Product
                         {
                             Code = "areca",
                             Description = "arecastum coco",
                             size = "15 gal",
                             Price = 458.00,
                             ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Plant Inventory").ID

                         },
                            new Product
                            {
                                Code = "cary",
                                Description = "caryota mitius",
                                size = "15 gal",
                                Price = 154.00,
                                ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Plant Inventory").ID

                            },
                            new Product
                            {
                                Code = "margi",
                                Description = "marginata",
                                size = "2 gal",
                                Price = 75.00,
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
                           Code = "GP50",
                           Description = "Granite pot",
                           size = "50 Gal",
                           Price = 195.95,
                           ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Pottery Inventory").ID

                       },
                         new Product
                         {
                             Code = "TCF03",
                             Description = "t/c figurine-swan",
                             size = "",
                             Price = 45.00,
                             ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Pottery Inventory").ID

                         },
                          new Product
                          {
                              Code = "MBBB30",
                              Description = "Marble bird bath",
                              size = "30 in",
                              Price = 250.00,
                              ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Pottery Inventory").ID

                          },
                           new Product
                           {
                               Code = "GFN48",
                               Description = "Granite Fountain",
                               size = "48 in",
                               Price = 750.00,
                               ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Pottery Inventory").ID

                           },
                        new Product
                        {
                            Code = "CBRK5",
                            Description = "Decorative Cedar Bark",
                            size = "bag(5 cu Ft)",
                            Price = 15.95,
                            ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Materials Inventory").ID

                        },
                          new Product
                          {
                              Code = "CRGRN",
                              Description = "Crushed granite",
                              size = "Yard",
                              Price = 14.00,
                              ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Materials Inventory").ID

                          },
                           new Product
                           {
                               Code = "PGRV",
                               Description = "Pea gravel",
                               size = "Yard",
                               Price = 20.00,
                               ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Materials Inventory").ID

                           },
                           new Product
                           {
                               Code = "GRVI",
                               Description = "1 Gravel",
                               size = "Yard",
                               Price = 12.00,
                               ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Materials Inventory").ID

                           },
                           new Product
                           {
                               Code = "TSOIL",
                               Description = "Top soil",
                               size = "Yard",
                               Price = 20.00,
                               ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Materials Inventory").ID

                           },
                             new Product
                             {
                                 Code = "PBLKG",
                                 Description = "Patio block-gray",
                                 size = "each",
                                 Price = 0.84,
                                 ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Materials Inventory").ID

                             },
                              new Product
                              {
                                  Code = "PBLKR",
                                  Description = "Patio block-red",
                                  size = "each",
                                  Price = 0.84,
                                  ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Materials Inventory").ID

                              },


                    new Product
                    {
                        Code = "Arenga",
                        Description = "Arenga Pinnata",
                        size = "15 Gal",
                        Price = 516.00,
                        ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Plant Inventory").ID

                    });
                    context.SaveChanges();
                }

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
                int[] approvalStatusID = context.ApprovalStatuses.Select(p => p.ID).ToArray();
                int[] bidStatusID = context.BidStatuses.Select(p => p.ID).ToArray();
                int ProjectCount = projectID.Count();
                int designerCount = designerID.Count();
                int bidStatusCount = bidStatusID.Count();
                int salesAssociateCount = salesAssociateID.Count();

                if (!context.Bids.Any())
                {
                    foreach (int i in projectID)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            int range = 5 * 365; //5 years

                            Bid a = new Bid()
                            {
                                DateCreated = DateTime.Today.AddDays(random.Next(range)),
                                EstAmount = 0,
                                EstBidStartDate = DateTime.Today.AddDays(random.Next(range)),
                                EstBidEndDate = DateTime.Today.AddDays(random.Next(range)),
                                Comments = baconNotes[random.Next(5)],
                                DesignerID = designerID[random.Next(designerCount)],
                                SalesAsscociateID = salesAssociateID[random.Next(salesAssociateCount)],
                                ProjectID = projectID[random.Next(ProjectCount)],
                                BidStatusID = bidStatusID[random.Next(bidStatusCount)],


                            };


                            a.Approval.ClientStatusID = approvalStatusID[random.Next(approvalStatusID.Count())];
                            a.Approval.DesignerStatusID = approvalStatusID[random.Next(approvalStatusID.Count())];
                            try
                            {
                                context.Add(a);
                                context.SaveChanges();

                            }
                            catch
                            {
                                // dod nothing repeat
                            }
                        }

                    }
                    context.SaveChanges();
                }




                int[] bidID = context.Bids.Select(s => s.ID).ToArray();
                int[] productID = context.Products.Select(p => p.ID).ToArray();

                //Bid Products 
                if (!context.BidProducts.Any())
                {
                    // loop over bid

                    foreach (int i in bidID)
                    {
                        int breaker = random.Next(productID.Count());
                        // loop over products
                        foreach (var j in productID)
                        {
                            if (j == breaker)
                                break;
                            BidProduct bidProduct = new BidProduct()
                            {
                                BidID = i,
                                Quantity = random.Next(1, 100),
                                ProductID = j
                            };

                            try
                            {
                                context.Add(bidProduct);
                                context.SaveChanges();
                            }
                            catch
                            {
                                // do nothing
                            }
                        }
                    }
                }

                if (!context.BidLabours.Any())
                {
                    // loop over bid

                    foreach (int i in bidID)
                    {
                        int breaker = random.Next(productID.Count());

                        // loop over role
                        foreach (var j in roleID)
                        {
                            if (j == breaker)
                                break;

                            BidLabour bidLabour = new BidLabour()
                            {
                                BidID = i,
                                Hours = random.Next(1, 8),
                                RoleID = j
                            };

                            try
                            {
                                context.Add(bidLabour);
                                context.SaveChanges();
                            }
                            catch
                            {
                                // do nothing
                            }
                        }
                    }
                }


                Thread.Sleep(2000);
                //loop over bids 
                if (context.BidProducts.Any())
                {
                    var allBids = context.Bids.ToList();

                    //Loop over bids
                    foreach (var i in allBids)
                    {
                        var allBidProducts = context.BidProducts.Where(p => p.BidID == i.ID);
                        var allBidLabour = context.BidLabours.Where(p => p.BidID == i.ID);
                        double total = 0;

                        // loop over bid products
                        foreach (var j in allBidProducts)
                        {

                            // Add bid price * qnty to total
                            total += j.Product.Price * j.Quantity;
                        }

                        foreach (var j in allBidLabour)
                        {
                            total += (double)j.Role.LabourPricePerHr * j.Hours;
                        }

                        context.Bids.SingleOrDefault(p => p.ID == i.ID).EstAmount = total;

                        try
                        {
                            context.SaveChangesAsync();
                        }
                        catch
                        {
                            // do nothing
                        }

                    }

                }


            }


        }
    }

}
