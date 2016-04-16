namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 150),
                        CompanyUrl = c.String(),
                        CompanyEmail = c.String(nullable: false),
                        CompanyLogoUrl = c.String(),
                        CompanyDescription = c.String(),
                        CompanyPhone = c.String(maxLength: 60),
                        CompanyVideoUrl = c.String(),
                        UserProfileId = c.Int(nullable: false),
                        FacebookProfile = c.String(),
                        TwitterProfile = c.String(),
                        LinkedInProfile = c.String(),
                        InstagramProfile = c.String(),
                        YoutubeProfile = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId);
            
            AddColumn("dbo.JobOpportunities", "CompanyId", c => c.Int());
            CreateIndex("dbo.JobOpportunities", "CompanyId");
            AddForeignKey("dbo.JobOpportunities", "CompanyId", "dbo.Companies", "CompanyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.JobOpportunities", "CompanyId", "dbo.Companies");
            DropIndex("dbo.JobOpportunities", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "UserProfileId" });
            DropColumn("dbo.JobOpportunities", "CompanyId");
            DropTable("dbo.Companies");
        }
    }
}
