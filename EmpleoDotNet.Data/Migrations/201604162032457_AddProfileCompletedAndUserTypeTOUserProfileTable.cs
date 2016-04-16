namespace EmpleoDotNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileCompletedAndUserTypeToUserProfileTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "IsProfileCompleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserProfiles", "UserProfileType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "UserProfileType");
            DropColumn("dbo.UserProfiles", "IsProfileCompleted");
        }
    }
}
