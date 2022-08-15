namespace BoostProjeKaloriTakipProgrami.Migrations
{
    using BoostProjeKaloriTakipProgrami.Classes;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BoostProjeKaloriTakipProgrami.Classes.UygulamaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BoostProjeKaloriTakipProgrami.Classes.UygulamaDbContext db)
        {
            if (!db.Users.Any())
            {
                SHA sha = new SHA();
                string password = sha.Sha256_Hash("123456789");

                db.Users.Add(new Classes.User()
                {
                    Email = "admin",
                    Password = password
                });
            }

            if (!db.Foods.Any())
            {
                db.Foods.Add(new Classes.Food()
                {
                    Name = "Banana",
                    Calories = 89d,
                    Description = "Fruit"
                });
                db.Foods.Add(new Classes.Food()
                {
                    Name = "Apple",
                    Calories = 52d,
                    Description = "Fruit"
                });
            }
        }
    }
}
