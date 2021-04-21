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
    public class OAScriptSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OasisContext(
                serviceProvider.GetRequiredService<DbContextOptions<OasisContext>>()))
            {
                Random random = new Random();
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
                string[] cityName = new string[] { "Riyadh", "Damman", "Jedda", "Tabouk", "Makka", "Maddena", "Haiel" };
                string[] stateName = new string[] { "Qassem State", "North State", "East State", "South State", "West State" };
                string[] zipCode = new string[] { "28889", "96459", "35748", "15005", "99625", "71465" };

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
                        Name = "Botanist",
                        LabourCostPerHr = Convert.ToDecimal(50.0),
                        LabourPricePerHr = Convert.ToDecimal(75.0)
                    },
                    new Role
                    {
                        Name = "Sales Associate",
                        LabourCostPerHr = Convert.ToDecimal(50.0),
                        LabourPricePerHr = Convert.ToDecimal(75.0)
                    },
                    new Role
                    {
                        Name = "Management",
                        LabourCostPerHr = Convert.ToDecimal(100.0),
                        LabourPricePerHr = Convert.ToDecimal(175.0)
                    },
                     new Role
                     {
                         Name = "Production Worker",
                         LabourCostPerHr = Convert.ToDecimal(20.0),
                         LabourPricePerHr = Convert.ToDecimal(55.0)
                     }
                );
                    context.SaveChanges();
                }

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(
                    new Employee
                    {
                        FirstName = "Keri",
                        LastName = "Yamaguchi",
                        AddressLineOne = streetNumber[random.Next(streetNumber.Count())] + " " + streetName[random.Next(streetName.Count())],
                        City = cityName[random.Next(cityName.Count())],
                        Province = stateName[random.Next(stateName.Count())],
                        Country = countryList[random.Next(countryList.Count())],
                        Phone = 1234567890,
                        Email = "Keri@outlook.com",
                        IsUser = true,
                        RoleID = context.Roles.FirstOrDefault(p => p.Name == "Management").ID
                    },
                      new Employee
                      {
                          FirstName = "Stan",
                          LastName = "Fenton",
                          AddressLineOne = streetNumber[random.Next(streetNumber.Count())] + " " + streetName[random.Next(streetName.Count())],
                          City = cityName[random.Next(cityName.Count())],
                          Province = stateName[random.Next(stateName.Count())],
                          Country = countryList[random.Next(countryList.Count())],
                          Phone = 1234567890,
                          Email = "Stan@outlook.com",
                          IsUser = true,
                          RoleID = context.Roles.FirstOrDefault(p => p.Name == "Management").ID
                      },
                       new Employee
                       {
                           FirstName = "Cheryl",
                           LastName = "Poy",
                           AddressLineOne = streetNumber[random.Next(streetNumber.Count())] + " " + streetName[random.Next(streetName.Count())],
                           City = cityName[random.Next(cityName.Count())],
                           Province = stateName[random.Next(stateName.Count())],
                           Country = countryList[random.Next(countryList.Count())],
                           Phone = 1234567890,
                           Email = "Cheryl@outlook.com",
                           IsUser = true,
                           RoleID = context.Roles.FirstOrDefault(p => p.Name == "Management").ID
                       },
                        new Employee
                        {
                            FirstName = "Sue",
                            LastName = "Kaufman",
                            AddressLineOne = streetNumber[random.Next(streetNumber.Count())] + " " + streetName[random.Next(streetName.Count())],
                            City = cityName[random.Next(cityName.Count())],
                            Province = stateName[random.Next(stateName.Count())],
                            Country = countryList[random.Next(countryList.Count())],
                            Phone = 1234567890,
                            Email = "Sue@outlook.com",
                            IsUser = true,
                            RoleID = context.Roles.FirstOrDefault(p => p.Name == "Management").ID
                        },
                        new Employee
                        {
                            FirstName = "Bob",
                            LastName = "Reinhardt",
                            AddressLineOne = streetNumber[random.Next(streetNumber.Count())] + " " + streetName[random.Next(streetName.Count())],
                            City = cityName[random.Next(cityName.Count())],
                            Province = stateName[random.Next(stateName.Count())],
                            Country = countryList[random.Next(countryList.Count())],
                            Phone = 1234567890,
                            Email = "Bob@outlook.com",
                            IsUser = true,
                            RoleID = context.Roles.FirstOrDefault(p => p.Name == "Sales Associate").ID
                        },
                        new Employee
                        {
                            FirstName = "Tamara",
                            LastName = "Bakken",
                            AddressLineOne = streetNumber[random.Next(streetNumber.Count())] + " " + streetName[random.Next(streetName.Count())],
                            City = cityName[random.Next(cityName.Count())],
                            Province = stateName[random.Next(stateName.Count())],
                            Country = countryList[random.Next(countryList.Count())],
                            Phone = 1234567890,
                            Email = "Tamara@outlook.com",
                            IsUser = true,
                            RoleID = context.Roles.FirstOrDefault(p => p.Name == "Designer").ID
                        },
                         new Employee
                         {
                             FirstName = "Monica",
                             LastName = "goce",
                             AddressLineOne = streetNumber[random.Next(streetNumber.Count())] + " " + streetName[random.Next(streetName.Count())],
                             City = cityName[random.Next(cityName.Count())],
                             Province = stateName[random.Next(stateName.Count())],
                             Country = countryList[random.Next(countryList.Count())],
                             Phone = 1234567890,
                             Email = "Monica@outlook.com",
                             RoleID = context.Roles.FirstOrDefault(p => p.Name == "Production Worker").ID
                         },
                        new Employee
                        {
                            FirstName = "Bert",
                            LastName = "Swenson ",
                            AddressLineOne = streetNumber[random.Next(streetNumber.Count())] + " " + streetName[random.Next(streetName.Count())],
                            City = cityName[random.Next(cityName.Count())],
                            Province = stateName[random.Next(stateName.Count())],
                            Country = countryList[random.Next(countryList.Count())],
                            Phone = 1234567890,
                            Email = "Bert@outlook.com",
                            RoleID = context.Roles.FirstOrDefault(p => p.Name == "Production Worker").ID
                        },
                        new Employee
                        {
                            FirstName = "Connie",
                            LastName = "Nguyen",
                            AddressLineOne = streetNumber[random.Next(streetNumber.Count())] + " " + streetName[random.Next(streetName.Count())],
                            City = cityName[random.Next(cityName.Count())],
                            Province = stateName[random.Next(stateName.Count())],
                            Country = countryList[random.Next(countryList.Count())],
                            Phone = 1234567890,
                            IsUser = true,
                            Email = "Connie@outlook.com",
                            RoleID = context.Roles.FirstOrDefault(p => p.Name == "Botanist").ID
                        });

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
                        context.SaveChanges();

                    }

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
                             Code = "Areca",
                             Description = "arecastum coco",
                             size = "15 gal",
                             Price = 458.00,
                             ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Plant Inventory").ID

                         },
                            new Product
                            {
                                Code = "Cary",
                                Description = "caryota mitius",
                                size = "15 gal",
                                Price = 154.00,
                                ProductTypeID = context.ProductTypes.SingleOrDefault(p => p.Name == "Plant Inventory").ID

                            },
                            new Product
                            {
                                Code = "Margi",
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
            }
        }
    }
}
