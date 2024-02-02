using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplication_software_design.Migrations
{
    /// <inheritdoc />
    public partial class Error15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationReviews_JobApplicationId",
                table: "ApplicationReviews");

            migrationBuilder.AlterColumn<int>(
                name: "JobApplicationId",
                table: "ApplicationReviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationReviews_JobApplicationId",
                table: "ApplicationReviews",
                column: "JobApplicationId",
                unique: true,
                filter: "[JobApplicationId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationReviews_JobApplicationId",
                table: "ApplicationReviews");

            migrationBuilder.AlterColumn<int>(
                name: "JobApplicationId",
                table: "ApplicationReviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationReviews_JobApplicationId",
                table: "ApplicationReviews",
                column: "JobApplicationId",
                unique: true);
        }
    }
}
