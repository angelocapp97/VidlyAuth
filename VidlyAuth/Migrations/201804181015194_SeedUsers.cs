namespace VidlyAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Birthdate]) VALUES (N'1de114dd-687a-4035-a4b6-aaef90395fe5', N'angelocapp97@gmail.com', 0, N'ANFJh7PVMRR5qjvOyoQB6uqZiSwGzzRIQQ2TcByk5DATKrBwo0gpY8bvrq0Av9z7hg==', N'dea84cc0-e43c-4d03-832a-5ab152914165', NULL, 0, 0, NULL, 1, 0, N'angelocapp97', N'Angelo', N'Cappelletti', N'1997-04-02 00:00:00')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [Birthdate]) VALUES (N'9aaaf06a-3a76-4e29-8ee5-417d667d2234', N'admin@vidly.com', 0, N'AHpT/Uh+GUifscEpAZEQG6wmMD7UDmYZOkMneQotAoUdfw95dmY7ZhLGLLpnq/tFOA==', N'4470ab10-c88e-4104-8842-982991f91ce9', NULL, 0, 0, NULL, 1, 0, N'admin', N'Admin', N'Admin', N'2018-04-18 00:00:00')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ea1bd3b5-d784-46fe-86e3-ce44482243ad', N'CanManageCustomers')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9aaaf06a-3a76-4e29-8ee5-417d667d2234', N'ea1bd3b5-d784-46fe-86e3-ce44482243ad')
");
        }
        
        public override void Down()
        {
        }
    }
}
