namespace VidlyAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO MembershipTypes (Id, Name, SignupFee, DurationInMonths, DiscountRate, MembershipTypeGroupId) 
                    VALUES (1, 'Pay as You Go', 0, 0, 0, 0);

                INSERT INTO MembershipTypes (Id, Name, SignupFee, DurationInMonths, DiscountRate, MembershipTypeGroupId) 
                    VALUES (2, 'Monthly', 30, 1, 10, 1);

                INSERT INTO MembershipTypes (Id, Name, SignupFee, DurationInMonths, DiscountRate, MembershipTypeGroupId) 
                    VALUES (3, 'Quarterly', 90, 3, 15, 1);

                INSERT INTO MembershipTypes (Id, Name, SignupFee, DurationInMonths, DiscountRate, MembershipTypeGroupId) 
                    VALUES (4, 'Annual', 300, 12, 20, 1);
                ");
        }
        
        public override void Down()
        {
        }
    }
}
