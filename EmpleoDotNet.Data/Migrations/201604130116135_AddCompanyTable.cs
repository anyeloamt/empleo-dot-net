using System.IO;

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
                        UserProfileId = c.Int(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId)
                .Index(t => t.UserProfileId);
            
            AddColumn("dbo.JobOpportunities", "CompanyId", c => c.Int());
            CreateIndex("dbo.JobOpportunities", "CompanyId");
            AddForeignKey("dbo.JobOpportunities", "CompanyId", "dbo.Companies", "CompanyId");
            
            // Copy company information from JobOpportunities to Companies table.
            SqlFile(@"..\..\SqlScripts\empleado - move company info from JobOpportunity to Company table.sql");
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
