namespace DBLab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveQuantities : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DishIngredients", "Quantity");
            DropColumn("dbo.OrderedDishes", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderedDishes", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.DishIngredients", "Quantity", c => c.Int(nullable: false));
        }
    }
}
