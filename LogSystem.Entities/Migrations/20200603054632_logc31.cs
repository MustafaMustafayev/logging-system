using Microsoft.EntityFrameworkCore.Migrations;

namespace LogSystem.Entities.Migrations
{
    public partial class logc31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecretKey",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "CompanyServiceId",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CompanyServiceId",
                table: "Requests",
                column: "CompanyServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_CompanyServices_CompanyServiceId",
                table: "Requests",
                column: "CompanyServiceId",
                principalTable: "CompanyServices",
                principalColumn: "CompanyServiceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_CompanyServices_CompanyServiceId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_CompanyServiceId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CompanyServiceId",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "SecretKey",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
