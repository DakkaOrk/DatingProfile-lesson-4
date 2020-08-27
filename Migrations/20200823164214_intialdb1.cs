using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlindDating.Migrations
{
    public partial class intialdb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            return;
            migrationBuilder.CreateTable(
                name: "DatingProfile",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    First_Name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Last_Name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    Age = table.Column<int>(nullable: true),
                    Gender = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    Bio = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    UserAccountId = table.Column<string>(unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatingProfile", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Film_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Release_year = table.Column<string>(nullable: true),
                    Language_id = table.Column<byte>(nullable: false),
                    Original_language_id = table.Column<byte>(nullable: true),
                    Rental_duration = table.Column<byte>(nullable: false),
                    Rental_rate = table.Column<decimal>(nullable: false),
                    Length = table.Column<short>(nullable: true),
                    Replacement_cost = table.Column<decimal>(nullable: false),
                    Rating = table.Column<string>(nullable: true),
                    Special_features = table.Column<string>(nullable: true),
                    Last_update = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Film_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatingProfile");

            migrationBuilder.DropTable(
                name: "Film");
        }
    }
}
