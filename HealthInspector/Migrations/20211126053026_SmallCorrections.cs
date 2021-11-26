using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthInspector.Migrations
{
    public partial class SmallCorrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Localities",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Clinics",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Zipcode",
                table: "Localities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Localities",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clinics",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "Zipcode",
                table: "Localities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
