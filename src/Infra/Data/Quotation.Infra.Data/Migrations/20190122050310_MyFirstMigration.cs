using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quotation.Infra.Data.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Quotation");

            migrationBuilder.CreateTable(
                name: "CorrelationPair",
                schema: "Quotation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<Guid>(nullable: false),
                    BaseCurrencyId = table.Column<int>(nullable: false),
                    QuoteCurrencyId = table.Column<int>(nullable: false),
                    Coefficient = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeleatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrelationPair", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "Quotation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 15, nullable: false),
                    IsoCode = table.Column<string>(maxLength: 3, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrelationPair",
                schema: "Quotation");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "Quotation");
        }
    }
}
