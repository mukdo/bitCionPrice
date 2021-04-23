using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BitcoinPrice.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EUR",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    symbol = table.Column<string>(nullable: true),
                    rate = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    rate_float = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EUR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GBP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    symbol = table.Column<string>(nullable: true),
                    rate = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    rate_float = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GBP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    updated = table.Column<string>(nullable: true),
                    updatedISO = table.Column<DateTime>(nullable: false),
                    updateduk = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USD",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    symbol = table.Column<string>(nullable: true),
                    rate = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    rate_float = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bpi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    USDId = table.Column<Guid>(nullable: true),
                    GBPId = table.Column<Guid>(nullable: true),
                    EURId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bpi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bpi_EUR_EURId",
                        column: x => x.EURId,
                        principalTable: "EUR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bpi_GBP_GBPId",
                        column: x => x.GBPId,
                        principalTable: "GBP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bpi_USD_USDId",
                        column: x => x.USDId,
                        principalTable: "USD",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BitCoinPrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    timeId = table.Column<Guid>(nullable: true),
                    disclaimer = table.Column<string>(nullable: true),
                    chartName = table.Column<string>(nullable: true),
                    bpiId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitCoinPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BitCoinPrice_Bpi_bpiId",
                        column: x => x.bpiId,
                        principalTable: "Bpi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BitCoinPrice_Time_timeId",
                        column: x => x.timeId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BitCoinPrice_bpiId",
                table: "BitCoinPrice",
                column: "bpiId");

            migrationBuilder.CreateIndex(
                name: "IX_BitCoinPrice_timeId",
                table: "BitCoinPrice",
                column: "timeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bpi_EURId",
                table: "Bpi",
                column: "EURId");

            migrationBuilder.CreateIndex(
                name: "IX_Bpi_GBPId",
                table: "Bpi",
                column: "GBPId");

            migrationBuilder.CreateIndex(
                name: "IX_Bpi_USDId",
                table: "Bpi",
                column: "USDId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BitCoinPrice");

            migrationBuilder.DropTable(
                name: "Bpi");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropTable(
                name: "EUR");

            migrationBuilder.DropTable(
                name: "GBP");

            migrationBuilder.DropTable(
                name: "USD");
        }
    }
}
