namespace DBLab2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "Season_Id", "dbo.Seasons");
            DropIndex("dbo.Menus", new[] { "Season_Id" });
            RenameColumn(table: "dbo.Menus", name: "Season_Id", newName: "SeasonId");
            AlterColumn("dbo.Menus", "SeasonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Menus", "SeasonId");
            AddForeignKey("dbo.Menus", "SeasonId", "dbo.Seasons", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menus", "SeasonId", "dbo.Seasons");
            DropIndex("dbo.Menus", new[] { "SeasonId" });
            AlterColumn("dbo.Menus", "SeasonId", c => c.Int());
            RenameColumn(table: "dbo.Menus", name: "SeasonId", newName: "Season_Id");
            CreateIndex("dbo.Menus", "Season_Id");
            AddForeignKey("dbo.Menus", "Season_Id", "dbo.Seasons", "Id");
        }
    }
}
