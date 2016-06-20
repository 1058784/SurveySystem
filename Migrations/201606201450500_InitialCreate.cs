namespace SurveySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RespondentID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Question", t => t.QuestionID, cascadeDelete: true)
                .ForeignKey("dbo.Respondent", t => t.RespondentID, cascadeDelete: true)
                .Index(t => t.RespondentID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SurveyID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        NoInSurvey = c.Int(nullable: false),
                        NullOrMultiAllowed = c.Boolean(),
                        MinRate = c.Int(),
                        RateStep = c.Int(),
                        MaxRate = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Survey", t => t.SurveyID, cascadeDelete: true)
                .Index(t => t.SurveyID);
            
            CreateTable(
                "dbo.Survey",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        fromDate = c.DateTime(nullable: false),
                        toDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Respondent",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 50),
                        LName = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        MStatus = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answer", "RespondentID", "dbo.Respondent");
            DropForeignKey("dbo.Question", "SurveyID", "dbo.Survey");
            DropForeignKey("dbo.Answer", "QuestionID", "dbo.Question");
            DropIndex("dbo.Question", new[] { "SurveyID" });
            DropIndex("dbo.Answer", new[] { "QuestionID" });
            DropIndex("dbo.Answer", new[] { "RespondentID" });
            DropTable("dbo.Respondent");
            DropTable("dbo.Survey");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
