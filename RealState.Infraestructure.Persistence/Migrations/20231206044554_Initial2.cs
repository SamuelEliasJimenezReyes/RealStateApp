using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealState.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProperties_Properties_PropertyId",
                table: "FavoriteProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyTypes_PropertyTypeId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "PropertyImprovents");

            migrationBuilder.DropTable(
                name: "PropertyTypes");

            migrationBuilder.RenameColumn(
                name: "PropertyTypeId",
                table: "Properties",
                newName: "PropertiesTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_PropertyTypeId",
                table: "Properties",
                newName: "IX_Properties_PropertiesTypeId");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "FavoriteProperties",
                newName: "PropertiesId");

            migrationBuilder.CreateTable(
                name: "PropertiesImprovents",
                columns: table => new
                {
                    PropertiesId = table.Column<int>(type: "int", nullable: false),
                    ImproventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesImprovents", x => new { x.PropertiesId, x.ImproventId });
                    table.ForeignKey(
                        name: "FK_PropertiesImprovents_Improvements_ImproventId",
                        column: x => x.ImproventId,
                        principalTable: "Improvements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertiesImprovents_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertiesTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertiesTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesImprovents_ImproventId",
                table: "PropertiesImprovents",
                column: "ImproventId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProperties_Properties_PropertiesId",
                table: "FavoriteProperties",
                column: "PropertiesId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertiesTypes_PropertiesTypeId",
                table: "Properties",
                column: "PropertiesTypeId",
                principalTable: "PropertiesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteProperties_Properties_PropertiesId",
                table: "FavoriteProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertiesTypes_PropertiesTypeId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "PropertiesImprovents");

            migrationBuilder.DropTable(
                name: "PropertiesTypes");

            migrationBuilder.RenameColumn(
                name: "PropertiesTypeId",
                table: "Properties",
                newName: "PropertyTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_PropertiesTypeId",
                table: "Properties",
                newName: "IX_Properties_PropertyTypeId");

            migrationBuilder.RenameColumn(
                name: "PropertiesId",
                table: "FavoriteProperties",
                newName: "PropertyId");

            migrationBuilder.CreateTable(
                name: "PropertyImprovents",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    ImproventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyImprovents", x => new { x.PropertyId, x.ImproventId });
                    table.ForeignKey(
                        name: "FK_PropertyImprovents_Improvements_ImproventId",
                        column: x => x.ImproventId,
                        principalTable: "Improvements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyImprovents_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropertyImprovents_ImproventId",
                table: "PropertyImprovents",
                column: "ImproventId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteProperties_Properties_PropertyId",
                table: "FavoriteProperties",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyTypes_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId",
                principalTable: "PropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
