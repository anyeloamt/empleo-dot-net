namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExtraPropertiesToCompanyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "CompanyDescription", c => c.String());
            AddColumn("dbo.Companies", "CompanyPhone", c => c.String(maxLength: 60));
            AddColumn("dbo.Companies", "CompanyVideoUrl", c => c.String());
            AddColumn("dbo.Companies", "FacebookProfile", c => c.String());
            AddColumn("dbo.Companies", "TwitterProfile", c => c.String());
            AddColumn("dbo.Companies", "LinkedInProfile", c => c.String());
            AddColumn("dbo.Companies", "InstagramProfile", c => c.String());
            AddColumn("dbo.Companies", "YoutubeProfile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "YoutubeProfile");
            DropColumn("dbo.Companies", "InstagramProfile");
            DropColumn("dbo.Companies", "LinkedInProfile");
            DropColumn("dbo.Companies", "TwitterProfile");
            DropColumn("dbo.Companies", "FacebookProfile");
            DropColumn("dbo.Companies", "CompanyVideoUrl");
            DropColumn("dbo.Companies", "CompanyPhone");
            DropColumn("dbo.Companies", "CompanyDescription");
        }
    }
}
