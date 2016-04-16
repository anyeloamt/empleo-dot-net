namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCompanyPropertiesFromJobOpportunityTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobOpportunities", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.JobOpportunities", new[] { "UserProfileId" });
            DropColumn("dbo.JobOpportunities", "CompanyName");
            DropColumn("dbo.JobOpportunities", "CompanyUrl");
            DropColumn("dbo.JobOpportunities", "CompanyEmail");
            DropColumn("dbo.JobOpportunities", "CompanyLogoUrl");
            DropColumn("dbo.JobOpportunities", "UserProfileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOpportunities", "UserProfileId", c => c.Int());
            AddColumn("dbo.JobOpportunities", "CompanyLogoUrl", c => c.String());
            AddColumn("dbo.JobOpportunities", "CompanyEmail", c => c.String(nullable: false));
            AddColumn("dbo.JobOpportunities", "CompanyUrl", c => c.String());
            AddColumn("dbo.JobOpportunities", "CompanyName", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.JobOpportunities", "UserProfileId");
            AddForeignKey("dbo.JobOpportunities", "UserProfileId", "dbo.UserProfiles", "Id");

            SqlFile(@"..\..\SqlScripts\empleado - rollback move company info from JobOpportunity to Company table.sql");
        }
    }
}
