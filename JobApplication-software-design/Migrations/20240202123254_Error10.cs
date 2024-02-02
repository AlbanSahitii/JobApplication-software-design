using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplication_software_design.Migrations
{
    /// <inheritdoc />
    public partial class Error10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Resumes_JobApplicationId",
                table: "Resumes");

            migrationBuilder.AlterColumn<int>(
                name: "JobApplicationId",
                table: "Resumes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_JobApplicationId",
                table: "Resumes",
                column: "JobApplicationId",
                unique: true,
                filter: "[JobApplicationId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Resumes_JobApplicationId",
                table: "Resumes");

            migrationBuilder.AlterColumn<int>(
                name: "JobApplicationId",
                table: "Resumes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_JobApplicationId",
                table: "Resumes",
                column: "JobApplicationId",
                unique: true);
        }
    }
}
