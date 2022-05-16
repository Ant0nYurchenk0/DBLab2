namespace DBLab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DishFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dishes", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.Dishes", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Dishes", new[] { "Ingredient_Id" });
            DropIndex("dbo.Dishes", new[] { "Order_Id" });
            CreateTable(
                "dbo.IngredientDishes",
                c => new
                    {
                        Ingredient_Id = c.Int(nullable: false),
                        Dish_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ingredient_Id, t.Dish_Id })
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Dishes", t => t.Dish_Id, cascadeDelete: true)
                .Index(t => t.Ingredient_Id)
                .Index(t => t.Dish_Id);
            
            CreateTable(
                "dbo.OrderDishes",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Dish_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Dish_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Dishes", t => t.Dish_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Dish_Id);
            
            DropColumn("dbo.Dishes", "Ingredient_Id");
            DropColumn("dbo.Dishes", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dishes", "Order_Id", c => c.Int());
            AddColumn("dbo.Dishes", "Ingredient_Id", c => c.Int());
            DropForeignKey("dbo.OrderDishes", "Dish_Id", "dbo.Dishes");
            DropForeignKey("dbo.OrderDishes", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.IngredientDishes", "Dish_Id", "dbo.Dishes");
            DropForeignKey("dbo.IngredientDishes", "Ingredient_Id", "dbo.Ingredients");
            DropIndex("dbo.OrderDishes", new[] { "Dish_Id" });
            DropIndex("dbo.OrderDishes", new[] { "Order_Id" });
            DropIndex("dbo.IngredientDishes", new[] { "Dish_Id" });
            DropIndex("dbo.IngredientDishes", new[] { "Ingredient_Id" });
            DropTable("dbo.OrderDishes");
            DropTable("dbo.IngredientDishes");
            CreateIndex("dbo.Dishes", "Order_Id");
            CreateIndex("dbo.Dishes", "Ingredient_Id");
            AddForeignKey("dbo.Dishes", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Dishes", "Ingredient_Id", "dbo.Ingredients", "Id");
        }
    }
}
