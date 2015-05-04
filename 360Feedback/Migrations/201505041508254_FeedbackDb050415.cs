namespace _360Feedback.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedbackDb050415 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Responses", "StudentFor_Email", "dbo.Students");
            DropForeignKey("dbo.Responses", "StudentFrom_Email", "dbo.Students");
            DropIndex("dbo.Responses", new[] { "StudentFor_Email" });
            DropIndex("dbo.Responses", new[] { "StudentFrom_Email" });
            RenameColumn(table: "dbo.Responses", name: "StudentFor_Email", newName: "StudentFor_StudentId");
            RenameColumn(table: "dbo.Responses", name: "StudentFrom_Email", newName: "StudentFrom_StudentId");
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.Students", "StudentId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Responses", "StudentFor_StudentId", c => c.Int());
            AlterColumn("dbo.Responses", "StudentFrom_StudentId", c => c.Int());
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Students", "StudentId");
            CreateIndex("dbo.Responses", "StudentFor_StudentId");
            CreateIndex("dbo.Responses", "StudentFrom_StudentId");
            AddForeignKey("dbo.Responses", "StudentFor_StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.Responses", "StudentFrom_StudentId", "dbo.Students", "StudentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responses", "StudentFrom_StudentId", "dbo.Students");
            DropForeignKey("dbo.Responses", "StudentFor_StudentId", "dbo.Students");
            DropIndex("dbo.Responses", new[] { "StudentFrom_StudentId" });
            DropIndex("dbo.Responses", new[] { "StudentFor_StudentId" });
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Responses", "StudentFrom_StudentId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Responses", "StudentFor_StudentId", c => c.String(maxLength: 128));
            DropColumn("dbo.Students", "StudentId");
            AddPrimaryKey("dbo.Students", "Email");
            RenameColumn(table: "dbo.Responses", name: "StudentFrom_StudentId", newName: "StudentFrom_Email");
            RenameColumn(table: "dbo.Responses", name: "StudentFor_StudentId", newName: "StudentFor_Email");
            CreateIndex("dbo.Responses", "StudentFrom_Email");
            CreateIndex("dbo.Responses", "StudentFor_Email");
            AddForeignKey("dbo.Responses", "StudentFrom_StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.Responses", "StudentFor_StudentId", "dbo.Students", "StudentId");
        }
    }
}
