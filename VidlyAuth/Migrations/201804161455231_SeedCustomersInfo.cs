namespace VidlyAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCustomersInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        MembershipTypeId = c.Byte(nullable: false),
                        IsSubscribedToNewsletter = c.Boolean(nullable: false),
                        Birthdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypes", t => t.MembershipTypeId, cascadeDelete: true)
                .Index(t => t.MembershipTypeId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                        MembershipTypeGroupId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MembershipTypeGroups", t => t.MembershipTypeGroupId, cascadeDelete: true)
                .Index(t => t.MembershipTypeGroupId);
            
            CreateTable(
                "dbo.MembershipTypeGroups",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropForeignKey("dbo.MembershipTypes", "MembershipTypeGroupId", "dbo.MembershipTypeGroups");
            DropIndex("dbo.MembershipTypes", new[] { "MembershipTypeGroupId" });
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropTable("dbo.MembershipTypeGroups");
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
        }
    }
}
