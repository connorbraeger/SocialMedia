namespace SocialMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLikesV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        LikeId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: true, maxLength: 128),
                        PostId = c.Int(nullable: true),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.LikeId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUserId, cascadeDelete: false)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: false)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropForeignKey("dbo.Like", "ApplicationUserId", "dbo.ApplicationUser");
            DropIndex("dbo.Like", new[] { "PostId" });
            DropIndex("dbo.Like", new[] { "ApplicationUserId" });
            DropTable("dbo.Like");
        }
    }
}
