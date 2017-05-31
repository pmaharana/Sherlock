namespace Sherlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedcomments : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Comments", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AddColumn("dbo.Comments", "LandmarkId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "LandmarkId");
            AddForeignKey("dbo.Comments", "LandmarkId", "dbo.Landmarks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "LandmarkId", "dbo.Landmarks");
            DropIndex("dbo.Comments", new[] { "LandmarkId" });
            DropColumn("dbo.Comments", "LandmarkId");
            RenameIndex(table: "dbo.Comments", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Comments", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
