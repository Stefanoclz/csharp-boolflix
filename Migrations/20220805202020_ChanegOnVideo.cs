using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_boolflix.Migrations
{
    public partial class ChanegOnVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Playlists_PlaylistId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_PlaylistId",
                table: "Profiles");

            migrationBuilder.AlterColumn<int>(
                name: "PlaylistId",
                table: "Profiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PlaylistId",
                table: "Profiles",
                column: "PlaylistId",
                unique: true,
                filter: "[PlaylistId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Playlists_PlaylistId",
                table: "Profiles",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Playlists_PlaylistId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_PlaylistId",
                table: "Profiles");

            migrationBuilder.AlterColumn<int>(
                name: "PlaylistId",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PlaylistId",
                table: "Profiles",
                column: "PlaylistId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Playlists_PlaylistId",
                table: "Profiles",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
