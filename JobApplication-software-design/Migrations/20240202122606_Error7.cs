using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplication_software_design.Migrations
{
    /// <inheritdoc />
    public partial class Error7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoverLetters_JobApplicationId",
                table: "CoverLetters");

            migrationBuilder.AlterColumn<int>(
                name: "JobApplicationId",
                table: "CoverLetters",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CoverLetters_JobApplicationId",
                table: "CoverLetters",
                column: "JobApplicationId",
                unique: true,
                filter: "[JobApplicationId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CoverLetters_JobApplicationId",
                table: "CoverLetters");

            migrationBuilder.AlterColumn<int>(
                name: "JobApplicationId",
                table: "CoverLetters",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoverLetters_JobApplicationId",
                table: "CoverLetters",
                column: "JobApplicationId",
                unique: true);
        }
    }
}
