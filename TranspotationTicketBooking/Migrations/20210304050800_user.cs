using Microsoft.EntityFrameworkCore.Migrations;

namespace TranspotationTicketBooking.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "1a0afdb8-989e-4ca7-b20a-c756ae0227a1");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5ab95b39-20fe-465d-aa0a-a2b6dc3ff0b0");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "85d83924-2194-4aa4-99b1-743b01dc19e4");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "a3a93e90-4822-438a-9e42-87b262bc9a00");

            migrationBuilder.CreateTable(
                name: "UserRegistrationModel",
                columns: table => new
                {
                    NIC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverNo = table.Column<int>(type: "int", nullable: false),
                    CondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondNo = table.Column<int>(type: "int", nullable: false),
                    MaxSeats = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegistrationModel", x => x.NIC);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c6a8fdb-fab0-4602-aafb-41081c09a977", "1eb2bfa1-201f-49f8-8e1d-b3afe40c3cc7", "Visitor", "VISITOR" },
                    { "ed8be351-ca0b-4aa6-a94b-8038c10ae852", "d27dd7cc-b7f5-43f1-96c8-db772b473453", "Passenger", "PASSENGER" },
                    { "1106b34d-0d4a-427c-8e87-9a36a6859ee8", "557375f0-6f24-4e7b-96bd-4db0b7edb29a", "BusController", "BUSCONTROLLER" },
                    { "8198715f-7462-408e-8421-9128478cf855", "276bc038-652c-46e7-9158-72479c7628cd", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRegistrationModel");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "1106b34d-0d4a-427c-8e87-9a36a6859ee8");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "8198715f-7462-408e-8421-9128478cf855");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "8c6a8fdb-fab0-4602-aafb-41081c09a977");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "ed8be351-ca0b-4aa6-a94b-8038c10ae852");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a0afdb8-989e-4ca7-b20a-c756ae0227a1", "5d7abc9a-3211-4d65-bccc-09b6f3906c4b", "Visitor", "VISITOR" },
                    { "85d83924-2194-4aa4-99b1-743b01dc19e4", "e9678022-3c3c-43ef-b72b-caf6407c19f8", "Passenger", "PASSENGER" },
                    { "5ab95b39-20fe-465d-aa0a-a2b6dc3ff0b0", "c8e0d413-26b9-4c96-82ab-0eb91cd80079", "BusController", "BUSCONTROLLER" },
                    { "a3a93e90-4822-438a-9e42-87b262bc9a00", "464f7e96-f515-4449-a8d5-9a96ccb484f4", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
