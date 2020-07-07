using Microsoft.EntityFrameworkCore.Migrations;

namespace LogSystem.Entities.Migrations
{
    public partial class logccompanyserviceid9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyServices",
                table: "CompanyServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyServices",
                table: "CompanyServices",
                column: "CompanyServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyServices_CompanyId",
                table: "CompanyServices",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyServices",
                table: "CompanyServices");

            migrationBuilder.DropIndex(
                name: "IX_CompanyServices_CompanyId",
                table: "CompanyServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyServices",
                table: "CompanyServices",
                columns: new[] { "CompanyId", "ServiceId" });
        }
    }
}
