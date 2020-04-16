using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkateShop.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accessory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bearing",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bearing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostDate = table.Column<DateTime>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Size = table.Column<float>(nullable: false),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GripTape",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GripTape", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Truck",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Type = table.Column<float>(nullable: false),
                    Size = table.Column<float>(nullable: false),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Truck", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wheel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(nullable: true),
                    Size = table.Column<float>(nullable: false),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wheel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Complete",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeckId = table.Column<int>(nullable: true),
                    BearingId = table.Column<int>(nullable: true),
                    GripTapeId = table.Column<int>(nullable: true),
                    TruckId = table.Column<int>(nullable: true),
                    WheelId = table.Column<int>(nullable: true),
                    AccessoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complete_Accessory_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complete_Bearing_BearingId",
                        column: x => x.BearingId,
                        principalTable: "Bearing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complete_Deck_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Deck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complete_GripTape_GripTapeId",
                        column: x => x.GripTapeId,
                        principalTable: "GripTape",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complete_Truck_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Truck",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Complete_Wheel_WheelId",
                        column: x => x.WheelId,
                        principalTable: "Wheel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Complete_AccessoryId",
                table: "Complete",
                column: "AccessoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Complete_BearingId",
                table: "Complete",
                column: "BearingId");

            migrationBuilder.CreateIndex(
                name: "IX_Complete_DeckId",
                table: "Complete",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Complete_GripTapeId",
                table: "Complete",
                column: "GripTapeId");

            migrationBuilder.CreateIndex(
                name: "IX_Complete_TruckId",
                table: "Complete",
                column: "TruckId");

            migrationBuilder.CreateIndex(
                name: "IX_Complete_WheelId",
                table: "Complete",
                column: "WheelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Complete");

            migrationBuilder.DropTable(
                name: "Accessory");

            migrationBuilder.DropTable(
                name: "Bearing");

            migrationBuilder.DropTable(
                name: "Deck");

            migrationBuilder.DropTable(
                name: "GripTape");

            migrationBuilder.DropTable(
                name: "Truck");

            migrationBuilder.DropTable(
                name: "Wheel");
        }
    }
}
