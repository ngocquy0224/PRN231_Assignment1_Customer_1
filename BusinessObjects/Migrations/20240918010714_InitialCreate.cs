using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessObjects.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    Address = table.Column<string>(type: "text", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Username);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Username", "Address", "Birthday", "Fullname", "Gender", "Password" },
                values: new object[] { "qqq", "123 ABC Street, Hanoi", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pham Ngoc Quy", "Male", "B888" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Username", "Address", "Birthday", "Fullname", "Gender", "Password" },
                values: new object[] { "jdoe", "456 XYZ Avenue, Ho Chi Minh City", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", "Male", "J123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
