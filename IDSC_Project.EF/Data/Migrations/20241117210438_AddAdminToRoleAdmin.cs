using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDSC_Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminToRoleAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUserRoles] (UserId, RoleId) SELECT '2c29a9ca-dc31-4c31-bfad-6a50c4d3de3a', Id FROM [dbo].[AspNetRoles]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId = '2c29a9ca-dc31-4c31-bfad-6a50c4d3de3a'");
        }
    }
}
