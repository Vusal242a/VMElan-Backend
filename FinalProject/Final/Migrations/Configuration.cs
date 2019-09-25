namespace Final.Migrations
{
    using Final.Models.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Final.Models.VMElanDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Final.Models.VMElanDbContext context)
        {
            try
            {
                //// Categories
                //if (!context.Categories.Any())
                //{
                //    context.Categories.AddRange(new[]
                //{
                //        new Categories
                //        {
                //          Name = "Apartment",
                //          CreatedDate=DateTime.Now
                //        },
                //        new Categories
                //        {
                //          Name = "Villa",
                //          CreatedDate=DateTime.Now
                //        },
                //        new Categories
                //        {
                //          Name = "House",
                //          CreatedDate=DateTime.Now
                //        },
                //        new Categories
                //        {
                //          Name = "Building",
                //          CreatedDate=DateTime.Now
                //        }
                //    });
                //}

                //// Sale Types
                //if (!context.SaleTypes.Any())
                //{
                //    context.SaleTypes.AddRange(new[]
                //    {
                //        new SaleType
                //        {
                //          Name = "For Rent",
                //          CreatedDate = DateTime.Now
                //        },
                //        new SaleType
                //        {
                //          Name = "For Sale",
                //          CreatedDate = DateTime.Now
                //        },
                //    });
                //}

                //// Site Info
                //if (!context.SiteInfos.Any())
                //{
                //    context.SiteInfos.AddRange(new[]
                //{
                //        new SiteInfo
                //        {
                //          Logo = "",
                //          Email = "vusal242a@gmail.com",
                //          Phone = "(+994) 50 484 34 71",
                //          Description = "Lorem ipsum dolo sit azmet, consecter dipise consult elit. Maecenas mamus antesme non anean a dolor sample tempor nuncest erat.",
                //          Location = "Baku.Azerbaijan",
                //          WorkTime = "09:00 - 18:00",
                //          Facebook = "https://www.facebook.com/Vusal242a",
                //          Twitter = "https://twitter.com/Cool_Steel",
                //          LinkedIn = "https://www.linkedin.com/in/vusal-mahmudlu-617993186/",
                //          Instagram = "https://www.instagram.com/vusalmahmudlu/",
                //          Pinterest = "https://www.pinterest.com/vusal242a/",
                //          CreatedDate=DateTime.Now
                //        },
                //    });
                //}

                //// Site Services
                //if (!context.SiteServices.Any())
                //{
                //    context.SiteServices.AddRange(new[]
                //    {
                //    new SiteServices
                //    {
                //            Name = "Consultant Service",
                //            Description = "In Aenean purus, pretium sito amet sapien denim consectet sed urna placerat sodales magna leo.",
                //            CreatedDate = DateTime.Now
                //    },
                //    new SiteServices
                //    {
                //            Name = "Properties Management",
                //            Description = "In Aenean purus, pretium sito amet sapien denim consectet sed urna placerat sodales magna leo.",
                //            CreatedDate = DateTime.Now
                //    },
                //    new SiteServices
                //    {
                //            Name = "Renting and Selling",
                //            Description = "In Aenean purus, pretium sito amet sapien denim consectet sed urna placerat sodales magna leo.",
                //            CreatedDate = DateTime.Now
                //    },
                //    });
                //}

                //// Home Properties
                //if (!context.HomeProperties.Any())
                //{
                //    context.HomeProperties.AddRange(new[]
                //    {
                //        new HomeProperty
                //        {
                //          Name = "Air conditioning",
                //          CreatedDate = DateTime.Now
                //        },
                //        new HomeProperty
                //        {
                //          Name = "Telephone",
                //          CreatedDate = DateTime.Now
                //        },
                //        new HomeProperty
                //        {
                //          Name = "Laundry Room",
                //          CreatedDate = DateTime.Now
                //        },
                //        new HomeProperty
                //        {
                //          Name = "Central Heating",
                //          CreatedDate = DateTime.Now
                //        },
                //        new HomeProperty
                //        {
                //          Name = "Family Villa",
                //          CreatedDate = DateTime.Now
                //        },
                //        new HomeProperty
                //        {
                //          Name = "Metro Central",
                //          CreatedDate = DateTime.Now
                //        },
                //        new HomeProperty
                //        {
                //          Name = "City views",
                //          CreatedDate = DateTime.Now
                //        },
                //        new HomeProperty
                //        {
                //          Name = "Internet",
                //          CreatedDate = DateTime.Now
                //        },
                //        new HomeProperty
                //        {
                //          Name = "Electric Range",
                //          CreatedDate = DateTime.Now
                //        },
                //    });
                //}

                //// Agents
                //if (!context.Agents.Any())
                //{
                //    context.Agents.AddRange(new[]
                //{
                //        new Agents
                //        {
                //          Name = "Nicky Butt",
                //          Image = "",
                //          Vacation = "Researcher",
                //          Phone = "(+994)50 484 34 71",
                //          Email = "vusalim@code.edu.az",
                //          CreatedDate=DateTime.Now
                //        },
                //        new Agents
                //        {
                //          Name = "Tony Holland",
                //          Image = "",
                //          Vacation = "Real Estate Agent",
                //          Phone = "(+994)50 484 34 71",
                //          Email = "vusalim@code.edu.az",
                //          CreatedDate=DateTime.Now
                //        },
                //        new Agents
                //        {
                //          Name = "Sasha Gordon",
                //          Image = "",
                //          Vacation = "Researcher",
                //          Phone = "(+994)50 484 34 71",
                //          Email = "vusalim@code.edu.az",
                //          CreatedDate=DateTime.Now
                //        },
                //        new Agents
                //        {
                //          Name = "Gina Wesley",
                //          Image = "",
                //          Vacation = "Real Estate Agent",
                //          Phone = "(+994)50 484 34 71",
                //          Email = "vusalim@code.edu.az",
                //          CreatedDate=DateTime.Now
                //        },
                //    });
                //}

                //// Social Sites
                //if (!context.SocialSites.Any())
                //{
                //    context.SocialSites.AddRange(new[]
                //    {
                //        new SocialSites
                //        {
                //          Name = "Facebook",
                //          Logo = "",
                //          Link = "https://www.facebook.com",
                //          AgentsId = 1,
                //          CreatedDate = DateTime.Now
                //        },
                //        new SocialSites
                //        {
                //          Name = "Twitter",
                //          Logo = "",
                //          Link = "https://twitter.com",
                //          AgentsId = 1,
                //          CreatedDate = DateTime.Now
                //        },
                //        new SocialSites
                //        {
                //          Name = "Instagram",
                //          Logo = "",
                //          Link = "https://www.instagram.com",
                //          AgentsId = 1,
                //          CreatedDate = DateTime.Now
                //        },
                //    });
                //}

                // Home Infos
                //if (!context.HomeInfos.Any())
                //{
                //    context.HomeInfos.AddRange(new[]
                //    {
                //        new HomeInfo
                //        {
                //          Name = "305 North Palm Drive",
                //          Image = "",
                //          PlanImage = "",
                //          Price = "4.500.000",
                //          Location = "Beverly Hills, CA 90210",
                //          Square = "1500",
                //          Garage = 2,
                //          Bathroom = 8,
                //          Bedroom = 16,
                //          Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus egestas fermentum ornareste. Donec index lorem. Vestibulum aliquet odio, eget tempor libero. Cras congue cursus tincidunt. Nullam venenatis dui id orci egestas tincidunt id elit. Nullam ut vuputate justo. Integer lacnia pharetra pretium. Casan ante ipsum primis in faucibus orci luctus et ultrice.",
                //          CategoryId = 2,
                //          HomePropertyId = 1,
                //          SaleTypeId = 2,
                //          AgentsId = 4,
                //          CreatedDate = DateTime.Now,
                //        },
                //    });
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
