using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHotel.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangePetTypePropertyType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetTypes_TypeName",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_TypeName",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "Pets");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Pets");

            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "Pets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_TypeName",
                table: "Pets",
                column: "TypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetTypes_TypeName",
                table: "Pets",
                column: "TypeName",
                principalTable: "PetTypes",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
