using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Solution.Migrations
{
    public partial class AddAnimalPhotoURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnimalPhotoURL",
                table: "Animals",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalPhotoURL",
                table: "Animals");
        }
    }
}
