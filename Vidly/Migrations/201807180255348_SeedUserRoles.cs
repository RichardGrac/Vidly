namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUserRoles : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c48b17f-06dd-459d-baa7-fa5b1795bf12', N'admin@Vidly.com', 0, N'AGfZTRUvTDKJynAHmFj58Yc/p4tVd7+6SaMeKtC0fn9KPTiq3U1H+Q+fC5rlARchog==', N'a9878a3c-a7f5-439a-9181-f272b9d6189f', NULL, 0, 0, NULL, 1, 0, N'admin@Vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'21a5f276-9bb2-4e77-8267-671b1cea5ab3', N'guest@Vidly.com', 0, N'ABfPy+VMKeBhf++sz4gQljN6SakRrJudjfEDZeV6UwBHkFfHHyOwBQjeO+2yuxD16g==', N'0cd19433-cdd2-404a-8c6e-9cec574c1548', NULL, 0, 0, NULL, 1, 0, N'guest@Vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ca903312-a8c4-4597-bef1-eda0f2687a13', N'CanManageMoviesRole')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0c48b17f-06dd-459d-baa7-fa5b1795bf12', N'ca903312-a8c4-4597-bef1-eda0f2687a13')
");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
    }
}
