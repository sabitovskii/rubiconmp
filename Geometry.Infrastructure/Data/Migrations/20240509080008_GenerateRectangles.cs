using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Geometry.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class GenerateRectangles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Random random = new Random();
            double edgeMaxLength = 50;
            double edgeMinLength = 1;
            int maxRectangleCount = 20;
            for (int i = 0; i < maxRectangleCount; i++)
            {
                double A_X = GenerateRandom(random, -300, 300);
                double A_Y = GenerateRandom(random, -300, 300);
                double B_X = GenerateRandom(random, edgeMinLength, edgeMaxLength) + A_X;
                double B_Y = GenerateRandom(random, edgeMinLength, edgeMaxLength) + A_Y;

                double slope_AB = (A_Y - B_Y) / (A_X - B_X);

                double slope_CD = (-1 / slope_AB);

                double C_X = GenerateRandom(random, edgeMinLength, edgeMaxLength) + B_X;
                double C_Y = Math.Round(slope_CD * (C_X - B_X) + B_Y, 2);
                double D_X = C_X - (B_X - A_X);
                double D_Y = Math.Round(C_Y - (B_Y - A_Y), 2);

                migrationBuilder.Sql($"INSERT INTO public.\"Rectangles\" " +
                    $"(\"A_X\", \"A_Y\", \"B_X\", \"B_Y\", \"C_X\", \"C_Y\", \"D_X\", \"D_Y\") " +
                    $"VALUES ({A_X}, {A_Y}, {B_X}, {B_Y}, {C_X}, {C_Y}, {D_X}, {D_Y})");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM public.\"Rectangles\"");
        }

        private double GenerateRandom(Random random, double min, double max)
        {
            var result = random.NextDouble() * (max - min) + min;
            return Math.Round(result, 2);
        }
    }
}
