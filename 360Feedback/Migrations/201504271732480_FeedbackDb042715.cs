namespace _360Feedback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackDb042715 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Question_QuestionId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionId)
                .Index(t => t.Question_QuestionId);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        DescriptionId = c.Int(nullable: false, identity: true),
                        Position = c.Int(nullable: false),
                        Value = c.String(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.DescriptionId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                    })
                .PrimaryKey(t => t.QuestionId);
            
            CreateTable(
                "dbo.Responses",
                c => new
                    {
                        ResponseId = c.Int(nullable: false, identity: true),
                        ResponseValues = c.String(),
                        StudentFor_Email = c.String(maxLength: 128),
                        StudentFrom_Email = c.String(maxLength: 128),
                        Team_TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.ResponseId)
                .ForeignKey("dbo.Students", t => t.StudentFor_Email)
                .ForeignKey("dbo.Students", t => t.StudentFrom_Email)
                .ForeignKey("dbo.Teams", t => t.Team_TeamId)
                .Index(t => t.StudentFor_Email)
                .Index(t => t.StudentFrom_Email)
                .Index(t => t.Team_TeamId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Team_TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.Email)
                .ForeignKey("dbo.Teams", t => t.Team_TeamId)
                .Index(t => t.Team_TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responses", "Team_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Students", "Team_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Responses", "StudentFrom_Email", "dbo.Students");
            DropForeignKey("dbo.Responses", "StudentFor_Email", "dbo.Students");
            DropForeignKey("dbo.Categories", "Question_QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Descriptions", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Students", new[] { "Team_TeamId" });
            DropIndex("dbo.Responses", new[] { "Team_TeamId" });
            DropIndex("dbo.Responses", new[] { "StudentFrom_Email" });
            DropIndex("dbo.Responses", new[] { "StudentFor_Email" });
            DropIndex("dbo.Descriptions", new[] { "Category_CategoryId" });
            DropIndex("dbo.Categories", new[] { "Question_QuestionId" });
            DropTable("dbo.Teams");
            DropTable("dbo.Students");
            DropTable("dbo.Responses");
            DropTable("dbo.Questions");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Categories");
        }
    }
}
