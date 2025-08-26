using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PostDraft.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Link", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "linkedIn", new DateTime(2025, 8, 25, 12, 51, 51, 915, DateTimeKind.Utc).AddTicks(4767), "Description", "https://www.linkedin.com/u/TaofeekAbdulazeez", "How to optimize linkedIn profile", new DateTime(2025, 8, 25, 12, 51, 51, 915, DateTimeKind.Utc).AddTicks(5176) },
                    { 2, "youtube", new DateTime(2025, 8, 25, 12, 51, 51, 915, DateTimeKind.Utc).AddTicks(6368), "Description", "https://youtube.com/TaofeekAbdulazeez", "How to monetize your skills", new DateTime(2025, 8, 25, 12, 51, 51, 915, DateTimeKind.Utc).AddTicks(6369) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
