using Final.Models.Entity;
using System.Data.Entity;

namespace Final.Models
{
    public class VMElanDbContext : DbContext
    {
        public VMElanDbContext()
            : base("cstring")
        {

        }
        public DbSet<Agents> Agents { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<HomeInfo> HomeInfos { get; set; }
        public DbSet<HomeProperty> HomeProperties { get; set; }
        public DbSet<SaleType> SaleTypes { get; set; }
        public DbSet<SiteInfo> SiteInfos { get; set; }
        public DbSet<SiteServices> SiteServices { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ErrorHistory> ErrorHistories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PlanImage> PlanImages { get; set; }
        public DbSet<HomeToProperty> HomeToProperties { get; set; }
        public DbSet<Rewiev> Rewievs { get; set; }

    }
}