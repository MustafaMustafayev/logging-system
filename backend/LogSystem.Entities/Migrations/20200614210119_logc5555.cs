using Microsoft.EntityFrameworkCore.Migrations;

namespace LogSystem.Entities.Migrations
{
    public partial class logc5555 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Services_ServiceId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestBodies_Requests_RequestId",
                table: "RequestBodies");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_CompanyServices_CompanyServiceId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Requests");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Services_ServiceId",
                table: "CompanyServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestBodies_Requests_RequestId",
                table: "RequestBodies",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_CompanyServices_CompanyServiceId",
                table: "Requests",
                column: "CompanyServiceId",
                principalTable: "CompanyServices",
                principalColumn: "CompanyServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Services_ServiceId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestBodies_Requests_RequestId",
                table: "RequestBodies");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_CompanyServices_CompanyServiceId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Test",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyServices_Services_ServiceId",
                table: "CompanyServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestBodies_Requests_RequestId",
                table: "RequestBodies",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_CompanyServices_CompanyServiceId",
                table: "Requests",
                column: "CompanyServiceId",
                principalTable: "CompanyServices",
                principalColumn: "CompanyServiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
