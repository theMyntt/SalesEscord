using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesEscord.Migrations
{
    /// <inheritdoc />
    public partial class SalesTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_SALES",
                columns: table => new
                {
                    ID_SALE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TX_PRODUCT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_FINAL_PRICE = table.Column<double>(type: "float", nullable: false),
                    TX_DATE_OF_SALE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SALES", x => x.ID_SALE);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_SALES");
        }
    }
}
