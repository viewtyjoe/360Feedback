namespace _360Feedback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _042715sex : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Team_TeamId", "dbo.Teams");
            DropIndex("dbo.Students", new[] { "Team_TeamId" });
            AlterColumn("dbo.Students", "Team_TeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "Team_TeamId");
            AddForeignKey("dbo.Students", "Team_TeamId", "dbo.Teams", "TeamId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Team_TeamId", "dbo.Teams");
            DropIndex("dbo.Students", new[] { "Team_TeamId" });
            AlterColumn("dbo.Students", "Team_TeamId", c => c.Int());
            CreateIndex("dbo.Students", "Team_TeamId");
            AddForeignKey("dbo.Students", "Team_TeamId", "dbo.Teams", "TeamId");
        }
    }
}
