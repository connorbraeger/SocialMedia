namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPostKeyName : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Post");
            DropColumn("dbo.Post", "Id");
            AddColumn("dbo.Post", "PostId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Post", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Post");
            DropColumn("dbo.Post", "PostId");
            AddPrimaryKey("dbo.Post", "Id");
        }
    }
}
