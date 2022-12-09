using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace examback.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalHistory_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Birthday", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("76d4dab5-9b77-4d97-8ef1-ea1380a405b1"), new DateTime(2002, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taras", "Shevchenko" },
                    { new Guid("98b66e0f-0396-401a-8d72-d7d36d25be50"), new DateTime(1994, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stepan", "Bandera" },
                    { new Guid("d6b09813-f15d-419f-8747-10c304258091"), new DateTime(2003, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykhailo", "Vovkanych" },
                    { new Guid("e9ced0b5-f079-4094-83a7-90347f211423"), new DateTime(1982, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesia", "Ukrainka" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalHistory_PatientId",
                table: "MedicalHistory",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
