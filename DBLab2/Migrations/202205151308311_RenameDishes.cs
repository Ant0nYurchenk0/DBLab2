namespace DBLab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameDishes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "Order_Id", c => c.Int());
            CreateIndex("dbo.Dishes", "Order_Id");
            AddForeignKey("dbo.Dishes", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dishes", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Dishes", new[] { "Order_Id" });
            DropColumn("dbo.Dishes", "Order_Id");
        }
    }
}
