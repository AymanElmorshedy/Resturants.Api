using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resturants.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyResturantAndUserWithNewRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Resturants",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");
            migrationBuilder.Sql("UPDATE Resturants SET OwnerId = '7126ff74-fef8-4c4a-b1ac-af5edf10afc9'");

            migrationBuilder.CreateIndex(
                name: "IX_Resturants_OwnerId",
                table: "Resturants",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resturants_AspNetUsers_OwnerId",
                table: "Resturants",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resturants_AspNetUsers_OwnerId",
                table: "Resturants");

            migrationBuilder.DropIndex(
                name: "IX_Resturants_OwnerId",
                table: "Resturants");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Resturants");
        }
    }
}
