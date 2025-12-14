using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deliveries_residents_ResidentId",
                table: "deliveries");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "residents",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "residents",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Address_ZipCode",
                table: "residents",
                newName: "address_zipcode");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "residents",
                newName: "address_street");

            migrationBuilder.RenameColumn(
                name: "Address_State",
                table: "residents",
                newName: "address_state");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "residents",
                newName: "address_city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "residents",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "deliveries",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "KeyWord",
                table: "deliveries",
                newName: "keyword");

            migrationBuilder.RenameColumn(
                name: "Carrier",
                table: "deliveries",
                newName: "carrier");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "deliveries",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TrackingCode",
                table: "deliveries",
                newName: "tracking_code");

            migrationBuilder.RenameColumn(
                name: "ResidentId",
                table: "deliveries",
                newName: "resident_id");

            migrationBuilder.RenameIndex(
                name: "IX_deliveries_ResidentId",
                table: "deliveries",
                newName: "IX_deliveries_resident_id");

            migrationBuilder.AddColumn<int>(
                name: "address_number",
                table: "residents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "fk_resident",
                table: "deliveries",
                column: "resident_id",
                principalTable: "residents",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_resident",
                table: "deliveries");

            migrationBuilder.DropColumn(
                name: "address_number",
                table: "residents");

            migrationBuilder.RenameColumn(
                name: "surname",
                table: "residents",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "residents",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "address_zipcode",
                table: "residents",
                newName: "Address_ZipCode");

            migrationBuilder.RenameColumn(
                name: "address_street",
                table: "residents",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "address_state",
                table: "residents",
                newName: "Address_State");

            migrationBuilder.RenameColumn(
                name: "address_city",
                table: "residents",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "residents",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "deliveries",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "keyword",
                table: "deliveries",
                newName: "KeyWord");

            migrationBuilder.RenameColumn(
                name: "carrier",
                table: "deliveries",
                newName: "Carrier");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "deliveries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tracking_code",
                table: "deliveries",
                newName: "TrackingCode");

            migrationBuilder.RenameColumn(
                name: "resident_id",
                table: "deliveries",
                newName: "ResidentId");

            migrationBuilder.RenameIndex(
                name: "IX_deliveries_resident_id",
                table: "deliveries",
                newName: "IX_deliveries_ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_deliveries_residents_ResidentId",
                table: "deliveries",
                column: "ResidentId",
                principalTable: "residents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
