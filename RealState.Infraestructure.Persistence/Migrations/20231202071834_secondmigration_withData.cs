using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RealState.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration_withData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Improvements",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "IsDeleted", "LastModified", "LastModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "es una habitación", false, null, null, "Habitación" },
                    { 2, null, null, "es una Cocina", false, null, null, "Cocina" }
                });

            migrationBuilder.InsertData(
                table: "PropertiesTypes",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "IsDeleted", "LastModified", "LastModifiedBy", "Name" },
                values: new object[] { 1, null, null, "es una grasa", false, null, null, "Apartamento" });

            migrationBuilder.InsertData(
                table: "SaleTypes",
                columns: new[] { "Id", "Created", "CreatedBy", "Description", "IsDeleted", "LastModified", "LastModifiedBy", "Name" },
                values: new object[] { 1, null, null, "se paga en un determinado tiempo", false, null, null, "Alquiler" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Improvements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PropertiesTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SaleTypes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
