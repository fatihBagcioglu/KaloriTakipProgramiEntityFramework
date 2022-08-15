using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostProjeKaloriTakipProgrami.Classes
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext() : base("name=ConnectionString")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
    }
}
