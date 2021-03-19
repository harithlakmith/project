using Microsoft.EntityFrameworkCore.Migrations;

namespace TranspotationTicketBooking.Migrations
{
    public partial class user1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "b7ff0b9d-71b6-4abc-a94f-66d1cd51fc68", "9e17bc6e-78f4-42a0-aea8-7d3041c9eb75", "Visitor", "VISITOR" },
                    { "f24be4a5-a363-4b0d-83f8-5c60d3305796", "7bffab89-0107-4f37-9687-96b0609c0f50", "Passenger", "PASSENGER" },
                    { "7c43532b-cd3d-4e36-afb3-b97b543a43b3", "713b1555-f10b-4a0d-8d9d-b4407e12d7a9", "BusController", "BUSCONTROLLER" },
                    { "dbc9515d-2186-47a2-ba05-e7b06875e0f5", "f242d85b-eba9-462c-9edf-44f782146b3d", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7c43532b-cd3d-4e36-afb3-b97b543a43b3");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "b7ff0b9d-71b6-4abc-a94f-66d1cd51fc68");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "dbc9515d-2186-47a2-ba05-e7b06875e0f5");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f24be4a5-a363-4b0d-83f8-5c60d3305796");

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
    }
}
