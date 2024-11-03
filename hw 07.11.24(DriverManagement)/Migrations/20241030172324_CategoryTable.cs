using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DriversManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class CategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Drivers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehicleCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Mass = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_CategoryId",
                table: "Drivers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_VehicleCategory_CategoryId",
                table: "Drivers",
                column: "CategoryId",
                principalTable: "VehicleCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_VehicleCategory_CategoryId",
                table: "Drivers");

            migrationBuilder.DropTable(
                name: "VehicleCategory");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_CategoryId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Drivers");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Drivers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
