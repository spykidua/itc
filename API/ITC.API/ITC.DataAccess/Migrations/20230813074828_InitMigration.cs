using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ITC.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxBand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpperLimit = table.Column<int>(type: "int", nullable: true),
                    LowerLimit = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBand", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaxBand",
                columns: new[] { "Id", "LowerLimit", "Name", "Rate", "UpperLimit" },
                values: new object[,]
                {
                    { new Guid("63ebc360-2065-44a1-80a6-cafd42fba309"), 5000, "Band 2", 20, 20000 },
                    { new Guid("72c3a4c3-65f6-44b9-93db-f52a841d4eea"), 20000, "Band 3", 40, null },
                    { new Guid("dcb1ab88-d3c3-4022-bb75-cc9ef852202d"), 0, "Band 1", 0, 5000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxBand");
        }
    }
}
