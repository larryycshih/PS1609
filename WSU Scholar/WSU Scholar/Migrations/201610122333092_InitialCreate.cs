namespace WSU_Scholar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        title = c.Int(),
                        fname = c.String(nullable: false, maxLength: 50),
                        lname = c.String(nullable: false, maxLength: 50),
                        schoolID = c.Int(nullable: false),
                        telephone = c.Int(nullable: false),
                        email = c.String(nullable: false),
                        mobile = c.Int(nullable: false),
                        university = c.String(),
                        campus = c.String(),
                        ResearchAuthor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Schools", t => t.schoolID, cascadeDelete: true)
                .ForeignKey("dbo.ResearchAuthors", t => t.ResearchAuthor_ID)
                .Index(t => t.schoolID)
                .Index(t => t.ResearchAuthor_ID);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        schoolName = c.String(nullable: false, maxLength: 50),
                        disciplineName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        researchID = c.Int(nullable: false),
                        ID = c.Int(nullable: false),
                        fileID = c.String(),
                    })
                .PrimaryKey(t => t.researchID)
                .ForeignKey("dbo.Researches", t => t.researchID)
                .Index(t => t.researchID);
            
            CreateTable(
                "dbo.Researches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        title = c.String(nullable: false),
                        schoolID = c.Int(nullable: false),
                        publishedDate = c.DateTime(nullable: false),
                        subject = c.String(),
                        grants = c.Decimal(nullable: false, precision: 18, scale: 2),
                        views = c.Int(nullable: false),
                        downloads = c.Int(nullable: false),
                        abstracts = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Schools", t => t.schoolID, cascadeDelete: true)
                .Index(t => t.schoolID);
            
            CreateTable(
                "dbo.ResearchAuthors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        researchID = c.Int(nullable: false),
                        authorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ResearchAuthorResearches",
                c => new
                    {
                        ResearchAuthor_ID = c.Int(nullable: false),
                        Research_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResearchAuthor_ID, t.Research_ID })
                .ForeignKey("dbo.ResearchAuthors", t => t.ResearchAuthor_ID, cascadeDelete: true)
                .ForeignKey("dbo.Researches", t => t.Research_ID, cascadeDelete: true)
                .Index(t => t.ResearchAuthor_ID)
                .Index(t => t.Research_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "researchID", "dbo.Researches");
            DropForeignKey("dbo.Researches", "schoolID", "dbo.Schools");
            DropForeignKey("dbo.ResearchAuthorResearches", "Research_ID", "dbo.Researches");
            DropForeignKey("dbo.ResearchAuthorResearches", "ResearchAuthor_ID", "dbo.ResearchAuthors");
            DropForeignKey("dbo.Authors", "ResearchAuthor_ID", "dbo.ResearchAuthors");
            DropForeignKey("dbo.Authors", "schoolID", "dbo.Schools");
            DropIndex("dbo.ResearchAuthorResearches", new[] { "Research_ID" });
            DropIndex("dbo.ResearchAuthorResearches", new[] { "ResearchAuthor_ID" });
            DropIndex("dbo.Researches", new[] { "schoolID" });
            DropIndex("dbo.Records", new[] { "researchID" });
            DropIndex("dbo.Authors", new[] { "ResearchAuthor_ID" });
            DropIndex("dbo.Authors", new[] { "schoolID" });
            DropTable("dbo.ResearchAuthorResearches");
            DropTable("dbo.ResearchAuthors");
            DropTable("dbo.Researches");
            DropTable("dbo.Records");
            DropTable("dbo.Schools");
            DropTable("dbo.Authors");
        }
    }
}
