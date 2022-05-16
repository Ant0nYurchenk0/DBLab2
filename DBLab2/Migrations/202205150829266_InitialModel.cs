namespace DBLab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Price = c.Int(nullable: false),
                        Description = c.String(maxLength: 100),
                        Ingredient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id)
                .Index(t => t.Ingredient_Id);
            
            CreateTable(
                "dbo.DishIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DishId = c.Int(nullable: false),
                        IngridientId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngridientId, cascadeDelete: true)
                .Index(t => t.DishId)
                .Index(t => t.IngridientId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(maxLength: 100),
                        Season_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seasons", t => t.Season_Id)
                .Index(t => t.Season_Id);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderedDishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        DishId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.DishId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOrdered = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuDishes",
                c => new
                    {
                        Menu_Id = c.Int(nullable: false),
                        Dish_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Menu_Id, t.Dish_Id })
                .ForeignKey("dbo.Menus", t => t.Menu_Id, cascadeDelete: true)
                .ForeignKey("dbo.Dishes", t => t.Dish_Id, cascadeDelete: true)
                .Index(t => t.Menu_Id)
                .Index(t => t.Dish_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedDishes", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderedDishes", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.Menus", "Season_Id", "dbo.Seasons");
            DropForeignKey("dbo.MenuDishes", "Dish_Id", "dbo.Dishes");
            DropForeignKey("dbo.MenuDishes", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.DishIngredients", "IngridientId", "dbo.Ingredients");
            DropForeignKey("dbo.Dishes", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.DishIngredients", "DishId", "dbo.Dishes");
            DropIndex("dbo.MenuDishes", new[] { "Dish_Id" });
            DropIndex("dbo.MenuDishes", new[] { "Menu_Id" });
            DropIndex("dbo.OrderedDishes", new[] { "DishId" });
            DropIndex("dbo.OrderedDishes", new[] { "OrderId" });
            DropIndex("dbo.Menus", new[] { "Season_Id" });
            DropIndex("dbo.DishIngredients", new[] { "IngridientId" });
            DropIndex("dbo.DishIngredients", new[] { "DishId" });
            DropIndex("dbo.Dishes", new[] { "Ingredient_Id" });
            DropTable("dbo.MenuDishes");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderedDishes");
            DropTable("dbo.Seasons");
            DropTable("dbo.Menus");
            DropTable("dbo.Ingredients");
            DropTable("dbo.DishIngredients");
            DropTable("dbo.Dishes");
        }
    }
}
