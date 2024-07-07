using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityApi.Migrations
{
    public partial class gdkgdgv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQualifications_Universities_UniversityId",
                table: "UserQualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQualifications_Users_UserId",
                table: "UserQualifications");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserQualifications",
                newName: "UserProfileId");

            migrationBuilder.RenameColumn(
                name: "UserQualificationId",
                table: "UserQualifications",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserQualifications_UserId",
                table: "UserQualifications",
                newName: "IX_UserQualifications_UserProfileId");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "UserQualifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Institution",
                table: "UserQualifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_UserId",
                table: "UserProfiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQualifications_Universities_UniversityId",
                table: "UserQualifications",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQualifications_UserProfiles_UserProfileId",
                table: "UserQualifications",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQualifications_Universities_UniversityId",
                table: "UserQualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_UserQualifications_UserProfiles_UserProfileId",
                table: "UserQualifications");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Institution",
                table: "UserQualifications");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "UserQualifications",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserQualifications",
                newName: "UserQualificationId");

            migrationBuilder.RenameIndex(
                name: "IX_UserQualifications_UserProfileId",
                table: "UserQualifications",
                newName: "IX_UserQualifications_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UniversityId",
                table: "UserQualifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQualifications_Universities_UniversityId",
                table: "UserQualifications",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "UniversityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserQualifications_Users_UserId",
                table: "UserQualifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
