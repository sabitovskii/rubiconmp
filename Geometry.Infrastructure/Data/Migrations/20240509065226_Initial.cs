using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Geometry.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rectangles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    A_X = table.Column<double>(type: "double precision", nullable: false),
                    A_Y = table.Column<double>(type: "double precision", nullable: false),
                    B_X = table.Column<double>(type: "double precision", nullable: false),
                    B_Y = table.Column<double>(type: "double precision", nullable: false),
                    C_X = table.Column<double>(type: "double precision", nullable: false),
                    C_Y = table.Column<double>(type: "double precision", nullable: false),
                    D_X = table.Column<double>(type: "double precision", nullable: false),
                    D_Y = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectangles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start_X = table.Column<double>(type: "double precision", nullable: false),
                    Start_Y = table.Column<double>(type: "double precision", nullable: false),
                    End_X = table.Column<double>(type: "double precision", nullable: false),
                    End_Y = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rectangles");

            migrationBuilder.DropTable(
                name: "Segments");
        }
    }
}
