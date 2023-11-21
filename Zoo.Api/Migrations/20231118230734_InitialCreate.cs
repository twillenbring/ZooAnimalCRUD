using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoo.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZooAnimals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZooAnimals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ZooAnimals",
                columns: new[] { "Id", "Age", "Gender", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 4, "Female", "Mia", "Lion" },
                    { 2, 3, "Male", "Mason", "Jaguar" },
                    { 3, 2, "Male", "Henry", "Orangutan" },
                    { 4, 1, "Male", "Rae", "Bear" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZooAnimals");
        }
    }
}
