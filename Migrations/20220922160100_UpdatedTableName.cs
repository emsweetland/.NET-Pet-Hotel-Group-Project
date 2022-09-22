using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class UpdatedTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PetOwners",
                table: "PetOwners");

            migrationBuilder.RenameTable(
                name: "PetOwners",
                newName: "PetOwner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetOwner",
                table: "PetOwner",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PetOwner",
                table: "PetOwner");

            migrationBuilder.RenameTable(
                name: "PetOwner",
                newName: "PetOwners");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetOwners",
                table: "PetOwners",
                column: "id");
        }
    }
}
