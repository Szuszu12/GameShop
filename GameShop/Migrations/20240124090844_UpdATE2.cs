using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameShop.Migrations
{
    /// <inheritdoc />
    public partial class UpdATE2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Producers_ProducerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_CategoryId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ProducerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ProducerId",
                table: "Games");
        }

        /// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.AddColumn<int>(
        //        name: "CategoryId",
        //        table: "Games",
        //        type: "int",
        //        nullable: false,
        //        defaultValue: 0);

        //    migrationBuilder.AddColumn<int>(
        //        name: "ProducerId",
        //        table: "Games",
        //        type: "int",
        //        nullable: false,
        //        defaultValue: 0);

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Games_CategoryId",
        //        table: "Games",
        //        column: "CategoryId");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Games_ProducerId",
        //        table: "Games",
        //        column: "ProducerId");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Games_Categories_CategoryId",
        //        table: "Games",
        //        column: "CategoryId",
        //        principalTable: "Categories",
        //        principalColumn: "Id",
        //        onDelete: ReferentialAction.Cascade);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_Games_Producers_ProducerId",
        //        table: "Games",
        //        column: "ProducerId",
        //        principalTable: "Producers",
        //        principalColumn: "Id",
        //        onDelete: ReferentialAction.Cascade);
        //}
    }
}
