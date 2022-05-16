namespace DBLab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRedundunt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DishIngredients", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.DishIngredients", "IngridientId", "dbo.Ingredients");
            DropForeignKey("dbo.OrderedDishes", "DishId", "dbo.Dishes");
            DropForeignKey("dbo.OrderedDishes", "OrderId", "dbo.Orders");
            DropIndex("dbo.DishIngredients", new[] { "DishId" });
            DropIndex("dbo.DishIngredients", new[] { "IngridientId" });
            DropIndex("dbo.OrderedDishes", new[] { "OrderId" });
            DropIndex("dbo.OrderedDishes", new[] { "DishId" });
            DropTable("dbo.DishIngredients");
            DropTable("dbo.OrderedDishes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderedDishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        DishId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DishIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DishId = c.Int(nullable: false),
                        IngridientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OrderedDishes", "DishId");
            CreateIndex("dbo.OrderedDishes", "OrderId");
            CreateIndex("dbo.DishIngredients", "IngridientId");
            CreateIndex("dbo.DishIngredients", "DishId");
            AddForeignKey("dbo.OrderedDishes", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderedDishes", "DishId", "dbo.Dishes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DishIngredients", "IngridientId", "dbo.Ingredients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DishIngredients", "DishId", "dbo.Dishes", "Id", cascadeDelete: true);
        }
    }
}
