using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUT24_JohanHansson_Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_PersonInterests_PersonInterestPersonId_PersonInterestInterestId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_PersonInterestPersonId_PersonInterestInterestId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "PersonInterestInterestId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "PersonInterestPersonId",
                table: "Links");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId_InterestId",
                table: "Links",
                columns: new[] { "PersonId", "InterestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Links_PersonInterests_PersonId_InterestId",
                table: "Links",
                columns: new[] { "PersonId", "InterestId" },
                principalTable: "PersonInterests",
                principalColumns: new[] { "PersonId", "InterestId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_PersonInterests_PersonId_InterestId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_PersonId_InterestId",
                table: "Links");

            migrationBuilder.AddColumn<int>(
                name: "PersonInterestInterestId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonInterestPersonId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonInterestPersonId_PersonInterestInterestId",
                table: "Links",
                columns: new[] { "PersonInterestPersonId", "PersonInterestInterestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Links_PersonInterests_PersonInterestPersonId_PersonInterestInterestId",
                table: "Links",
                columns: new[] { "PersonInterestPersonId", "PersonInterestInterestId" },
                principalTable: "PersonInterests",
                principalColumns: new[] { "PersonId", "InterestId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
