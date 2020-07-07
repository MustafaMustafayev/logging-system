using Microsoft.EntityFrameworkCore.Migrations;

namespace LogSystem.Entities.Migrations
{
    public partial class logc7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Services_ServiceId",
                table: "CompanyServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyServices",
                table: "CompanyServices");

            migrationBuilder.DropIndex(
                name: "IX_CompanyServices_CompanyId",
                table: "CompanyServices");

            migrationBuilder.DropColumn(
                name: "CompanyServiceId",
                table: "CompanyServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyServices",
                table: "CompanyServices",
                columns: new[] { "CompanyId", "ServiceId" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Companies_CompanyId",
                table: "CompanyServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyServices_Services_ServiceId",
                table: "CompanyServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyServices",
                table: "CompanyServices");

            migrationBuilder.AddColumn<int>(
                name: "CompanyServiceId",
                table: "CompanyServices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyServices",
                table: "CompanyServices",
                column: "CompanyServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServices_CompanyId",
                table: "CompanyServices",
                column: "CompanyId");

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
        }
    }
}
