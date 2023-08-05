using Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_Investor_Id", x => x.Id)
            );

            migrationBuilder.CreateTable(
                name: "Builder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    About = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false),
                    Cnpj = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    Segment = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    FoundationDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: DateTime.Now),
                },
                constraints: table => table.PrimaryKey("PK_Builder_Id", x => x.Id)
            );

            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInvestor = table.Column<long>(type: "BIGINT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_Investor_IdInvestor",
                        column: x => x.IdInvestor,
                        principalTable: "Investor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Enterprise",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBuilder = table.Column<long>(type: "BIGINT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Value = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    ProfitabilityPerYear = table.Column<short>(type: "SMALLINT", nullable: false),
                    TermInMonths = table.Column<int>(type: "INT", nullable: false),
                    PaymentType = table.Column<PaymentType>(type: "VARCHAR(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprise_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enterprise_Builder_IdBuilder",
                        column: x => x.IdBuilder,
                        principalTable: "Builder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateTable(
                name: "Contribution",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInvestor = table.Column<long>(type: "BIGINT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(180)", maxLength: 180, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contribution_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contribution_Investor_IdInvestor",
                        column: x => x.IdInvestor,
                        principalTable: "Investor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_EContribution_Builder_IdBuilder",
                        column: x => x.IdInvestor,
                        principalTable: "Builder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Contribution");
            migrationBuilder.DropTable(name: "Enterprise");
            migrationBuilder.DropTable(name: "Wallet");
            migrationBuilder.DropTable(name: "Builder");
            migrationBuilder.DropTable(name: "Investor");
        }
    }
}
