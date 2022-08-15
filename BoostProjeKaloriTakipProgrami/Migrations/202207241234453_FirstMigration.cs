namespace BoostProjeKaloriTakipProgrami.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Calories = c.Double(nullable: false),
                        Description = c.String(),
                        Meal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.Meal_Id)
                .Index(t => t.Meal_Id);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        TotalCalories = c.Double(nullable: false),
                        FoodId = c.Int(nullable: false),
                        UserDetail_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserDetails", t => t.UserDetail_Id)
                .Index(t => t.UserDetail_Id);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInfos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfos", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.Meals", "UserDetail_Id", "dbo.UserDetails");
            DropForeignKey("dbo.Foods", "Meal_Id", "dbo.Meals");
            DropIndex("dbo.UserInfos", new[] { "UserId" });
            DropIndex("dbo.UserDetails", new[] { "UserId" });
            DropIndex("dbo.Meals", new[] { "UserDetail_Id" });
            DropIndex("dbo.Foods", new[] { "Meal_Id" });
            DropTable("dbo.UserInfos");
            DropTable("dbo.Users");
            DropTable("dbo.UserDetails");
            DropTable("dbo.Meals");
            DropTable("dbo.Foods");
        }
    }
}
