namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLikes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Post", "ApplicationUserId");
            AddForeignKey("dbo.Post", "ApplicationUserId", "dbo.ApplicationUser", "Id", cascadeDelete: true);
            DropColumn("dbo.Post", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "Author", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Post", "ApplicationUserId", "dbo.ApplicationUser");
            DropIndex("dbo.Post", new[] { "ApplicationUserId" });
            DropColumn("dbo.Post", "ApplicationUserId");
        }
    }
}
