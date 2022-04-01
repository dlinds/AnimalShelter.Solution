using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Solution.Migrations
{
    public partial class AddDateListedAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateListed",
                table: "Animals",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "AdoptionPrice", "Age", "Breed", "DateListed", "Gender", "GoodWithChildren", "GoodWithOtherAnimals", "Name", "Species" },
                values: new object[,]
                {
                    { 1, 500, 6, "Beagle", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", true, true, "Babby", "Dog" },
                    { 2, 800, 1, "Beagle", new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", false, true, "Billy", "Dog" },
                    { 3, 200, 9, "German Schnauzer", new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", true, false, "Ned", "Dog" },
                    { 4, 100, 2, "Mutt", new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", false, true, "Poppins", "Dog" },
                    { 5, 800, 0, "Pomeranian", new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", true, true, "Mr Scruffles", "Dog" },
                    { 6, 70, 15, "Tabby", new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", false, false, "Tabatha", "Cat" },
                    { 7, 300, 0, "Calico", new DateTime(2022, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", false, false, "Pepper", "Cat" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "DateListed",
                table: "Animals");
        }
    }
}
