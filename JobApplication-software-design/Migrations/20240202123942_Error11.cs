using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplication_software_design.Migrations
{
    /// <inheritdoc />
    public partial class Error11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_ApplicationStatuses_StatusId",
                table: "JobApplications");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "JobApplications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_ApplicationStatuses_StatusId",
                table: "JobApplications",
                column: "StatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_ApplicationStatuses_StatusId",
                table: "JobApplications");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "JobApplications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_ApplicationStatuses_StatusId",
                table: "JobApplications",
                column: "StatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
