namespace LandOfStartups.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        pageID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.pageID);
            
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        informationID = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        page_pageID = c.Int(),
                    })
                .PrimaryKey(t => t.informationID)
                .ForeignKey("dbo.Pages", t => t.page_pageID)
                .Index(t => t.page_pageID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        questionID = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        page_pageID = c.Int(),
                    })
                .PrimaryKey(t => t.questionID)
                .ForeignKey("dbo.Pages", t => t.page_pageID)
                .Index(t => t.page_pageID);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        answerID = c.Int(nullable: false, identity: true),
                        text = c.String(),
                        question_questionID = c.Int(),
                        startup_startupID = c.Int(),
                    })
                .PrimaryKey(t => t.answerID)
                .ForeignKey("dbo.Questions", t => t.question_questionID)
                .ForeignKey("dbo.Startups", t => t.startup_startupID)
                .Index(t => t.question_questionID)
                .Index(t => t.startup_startupID);
            
            CreateTable(
                "dbo.Startups",
                c => new
                    {
                        startupID = c.Int(nullable: false, identity: true),
                        userID = c.Int(nullable: false),
                        name = c.String(),
                        link = c.String(),
                    })
                .PrimaryKey(t => t.startupID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Answers", new[] { "startup_startupID" });
            DropIndex("dbo.Answers", new[] { "question_questionID" });
            DropIndex("dbo.Questions", new[] { "page_pageID" });
            DropIndex("dbo.Information", new[] { "page_pageID" });
            DropForeignKey("dbo.Answers", "startup_startupID", "dbo.Startups");
            DropForeignKey("dbo.Answers", "question_questionID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "page_pageID", "dbo.Pages");
            DropForeignKey("dbo.Information", "page_pageID", "dbo.Pages");
            DropTable("dbo.Startups");
            DropTable("dbo.Answers");
            DropTable("dbo.Questions");
            DropTable("dbo.Information");
            DropTable("dbo.Pages");
        }
    }
}
