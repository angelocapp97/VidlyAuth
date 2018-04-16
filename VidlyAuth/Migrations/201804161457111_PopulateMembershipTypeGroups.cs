namespace VidlyAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeGroups : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO MembershipTypeGroups (Id, Name) VALUES (0, 'For all users')
                INSERT INTO MembershipTypeGroups (Id, Name) VALUES (1, 'Only for Adults')"
            );
        }
        
        public override void Down()
        {
        }
    }
}
