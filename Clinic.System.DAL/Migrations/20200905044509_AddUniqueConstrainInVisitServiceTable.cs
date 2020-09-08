using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.System.DAL.Migrations
{
    public partial class AddUniqueConstrainInVisitServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceVisits",
                table: "ServiceVisits");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ServiceVisits",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceVisits",
                table: "ServiceVisits",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceVisits_DoctorId_ServiceId_VisitId",
                table: "ServiceVisits",
                columns: new[] { "DoctorId", "ServiceId", "VisitId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceVisits",
                table: "ServiceVisits");

            migrationBuilder.DropIndex(
                name: "IX_ServiceVisits_DoctorId_ServiceId_VisitId",
                table: "ServiceVisits");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ServiceVisits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceVisits",
                table: "ServiceVisits",
                columns: new[] { "DoctorId", "ServiceId", "VisitId" });
        }
    }
}
