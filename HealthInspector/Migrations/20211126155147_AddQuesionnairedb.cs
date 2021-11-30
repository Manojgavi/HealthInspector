using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthInspector.Migrations
{
    public partial class AddQuesionnairedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question1",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Question2",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Question3",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Question4",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Question5",
                table: "Feedbacks");

            migrationBuilder.CreateTable(
                name: "Questionnaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Question1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question5 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaires", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questionnaires");

            migrationBuilder.AddColumn<string>(
                name: "Question1",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question2",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question3",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question4",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question5",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
