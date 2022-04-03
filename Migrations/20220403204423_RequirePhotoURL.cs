using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Solution.Migrations
{
    public partial class RequirePhotoURL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnimalPhotoURL",
                table: "Animals",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1,
                column: "AnimalPhotoURL",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTsuPg3g3nAvGkX3pJKCxVT92YlipcQW87tMQ&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2,
                column: "AnimalPhotoURL",
                value: "https://dogsbestlife.com/wp-content/uploads/2020/05/Beagle-scaled.jpeg");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3,
                column: "AnimalPhotoURL",
                value: "https://www.akc.org/wp-content/uploads/2017/11/Standard-Schnauzer-standing-outdoors.jpg");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4,
                column: "AnimalPhotoURL",
                value: "https://images.ctfassets.net/sfnkq8lmu5d7/1j5LJ5cIY1gfqE90AxvD6V/11c51d0709478c75d9a6716d92b28c08/2021_0714_national_mutt_day.jpg?w=1000&h=750&fl=progressive&q=80&fm=jpg");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5,
                column: "AnimalPhotoURL",
                value: "https://highlandcanine.com/wp-content/uploads/2021/03/pomeranian-running-and-happy.jpg");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 6,
                column: "AnimalPhotoURL",
                value: "https://s36537.pcdn.co/wp-content/uploads/2017/11/Mackerel-Tabby-cat.jpg.optimal.jpg");

            migrationBuilder.UpdateData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 7,
                column: "AnimalPhotoURL",
                value: "https://cat-world.com/wp-content/uploads/2016/09/all-about-calico-cats.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalPhotoURL",
                table: "Animals");
        }
    }
}
