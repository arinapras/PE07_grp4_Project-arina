using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PE07_grp4_Project.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5baf7aa0-5212-4883-9542-ea7610e8a44a", "AQAAAAIAAYagAAAAEGal7RpwAt/I09+OEmZ8NbYL52GFzgKj25yjV1EGIso0H4Tpxl8KqjpKKBorMi4b7w==", "ead94bfa-1fea-4f99-84bb-281a74e1635d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "968bc54a-dda1-416d-bf8a-80b68a88764a", "AQAAAAIAAYagAAAAEFQLmJ1ieolRZBoW4D6drNvZUykhMI/RaGwfQZlyjxGs0ezC/oB4f9xpTCb5BWnC2A==", "9ac90919-3936-471d-88a3-6d703dbb7590" });
        }
    }
}
