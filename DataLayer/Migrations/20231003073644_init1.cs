using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrenIstasyonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IstasyonAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IstasyonAdresi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IstasyonKonumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrenIstasyonlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrenSeferler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrenKalkisIstasyonId = table.Column<int>(type: "int", nullable: false),
                    TrenVarisIstasyonId = table.Column<int>(type: "int", nullable: false),
                    KalısSaati = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VarisSaati = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrenSeferler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrenSeferler_TrenIstasyonlar_TrenKalkisIstasyonId",
                        column: x => x.TrenKalkisIstasyonId,
                        principalTable: "TrenIstasyonlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrenSeferler_TrenIstasyonlar_TrenVarisIstasyonId",
                        column: x => x.TrenVarisIstasyonId,
                        principalTable: "TrenIstasyonlar",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrenSeferler_TrenKalkisIstasyonId",
                table: "TrenSeferler",
                column: "TrenKalkisIstasyonId");

            migrationBuilder.CreateIndex(
                name: "IX_TrenSeferler_TrenVarisIstasyonId",
                table: "TrenSeferler",
                column: "TrenVarisIstasyonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "TrenSeferler");

            migrationBuilder.DropTable(
                name: "TrenIstasyonlar");
        }
    }
}
