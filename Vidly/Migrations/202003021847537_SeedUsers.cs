namespace UDemyVidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd2ef2362-c275-4f7c-9975-98ca99b5c96d', N'guest@vidly.com', 0, N'AIVqG/vt7uwzxjOMzC9QsUi3aqZqudknGniPBed1zikJqGj+SwizgiVIfoNrTOHPEQ==', N'26cf8ac6-1c7f-477e-a1c3-7b40361d77dd', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e13d16fa-519d-452b-9ede-2f1e7ee45b6a', N'admin@vidly.com', 0, N'ABqYLOWfFop5gZ99RtBYwbFFVQNQamoGIc0XhwJNmtuz0yM8mzdG/VpLvt/0gGyVpQ==', N'fc81ca80-4b75-40e9-922a-bf4d85063c30', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3f27f56f-d138-4ecf-98f9-4f37d24b66d3', N'CanManageMovies')                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e13d16fa-519d-452b-9ede-2f1e7ee45b6a', N'3f27f56f-d138-4ecf-98f9-4f37d24b66d3')
                ");
        }


        public override void Down()
        {
        }
    }
}
