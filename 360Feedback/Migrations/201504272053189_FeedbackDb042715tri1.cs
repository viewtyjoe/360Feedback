namespace _360Feedback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackDb042715tri1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Completed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Completed");
        }
    }
}
