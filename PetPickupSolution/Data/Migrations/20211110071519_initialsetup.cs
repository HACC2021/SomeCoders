using Microsoft.EntityFrameworkCore.Migrations;

namespace PetPickupSolution.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetPickupModel",
                columns: table => new
                {
                    PetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetMicroChipID = table.Column<int>(type: "int", nullable: false),
                    PetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetPickupModel", x => x.PetID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetPickupModel");
        }
    }
}
