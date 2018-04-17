namespace VidlyAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenders : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO Genders (Id, Name) VALUES (0, 'Male');
                INSERT INTO Genders (Id, Name) VALUES (1, 'Female');
                INSERT INTO Genders (Id, Name) VALUES (2, 'Other');
            ");
        }
        
        public override void Down()
        {
        }
    }
}
