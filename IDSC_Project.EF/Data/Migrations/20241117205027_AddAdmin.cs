using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDSC_Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'2c29a9ca-dc31-4c31-bfad-6a50c4d3de3a', N'SuperAdmin@IDSC.com', N'SUPERADMIN@IDSC.COM', N'SuperAdmin@IDSC.com', N'SUPERADMIN@IDSC.COM', 1, N'AQAAAAIAAYagAAAAEBrD4+H0G01xwIBc/WYpeQB/KCHFpZ3636mTG1shnjR2e7cAINnOsEtBH2+qOSuc8A==', N'BU5F4HVGSCZUYKWBUUHAKYJGSBSZVTIY', N'fdc806f6-7828-46de-b6cc-5e662cc94327', NULL, 0, 0, NULL, 1, 0)\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM  [dbo].[AspNetUsers] WHERE [Email] = 'SuperAdmin@IDSC.com'");
        }
    }
}
