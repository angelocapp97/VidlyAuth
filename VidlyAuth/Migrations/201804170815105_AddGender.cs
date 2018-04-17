namespace VidlyAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "GenderId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "GenderId");
            AddForeignKey("dbo.Customers", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "GenderId", "dbo.Genders");
            DropIndex("dbo.Customers", new[] { "GenderId" });
            DropColumn("dbo.Customers", "GenderId");
            DropTable("dbo.Genders");
        }
    }
}
