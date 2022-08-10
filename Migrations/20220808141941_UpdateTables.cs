using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace csharp_boolflix.Migrations
{
    public partial class UpdateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_PaymentMethods_PaymentId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_PaymentId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Subscriptions");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Registered",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registered_PaymentId",
                table: "Registered",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registered_PaymentMethods_PaymentId",
                table: "Registered",
                column: "PaymentId",
                principalTable: "PaymentMethods",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registered_PaymentMethods_PaymentId",
                table: "Registered");

            migrationBuilder.DropIndex(
                name: "IX_Registered_PaymentId",
                table: "Registered");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Registered");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Subscriptions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_PaymentId",
                table: "Subscriptions",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_PaymentMethods_PaymentId",
                table: "Subscriptions",
                column: "PaymentId",
                principalTable: "PaymentMethods",
                principalColumn: "Id");
        }
    }
}
