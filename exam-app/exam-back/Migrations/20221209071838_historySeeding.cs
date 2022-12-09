using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace examback.Migrations
{
    /// <inheritdoc />
    public partial class historySeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("76d4dab5-9b77-4d97-8ef1-ea1380a405b1"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("98b66e0f-0396-401a-8d72-d7d36d25be50"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("d6b09813-f15d-419f-8747-10c304258091"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("e9ced0b5-f079-4094-83a7-90347f211423"));

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Birthday", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("2e11df19-8346-4823-9400-4381e6aa9c2d"), new DateTime(1982, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesia", "Ukrainka" },
                    { new Guid("9ac3971e-01c3-4515-a418-0c9a55be8488"), new DateTime(1994, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stepan", "Bandera" },
                    { new Guid("af5995b3-bfc5-4afe-b0de-658d1cb7992f"), new DateTime(2002, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taras", "Shevchenko" },
                    { new Guid("d7eecffe-2139-4953-915f-d6e7f97f72f1"), new DateTime(2003, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mykhailo", "Vovkanych" }
                });

            migrationBuilder.InsertData(
                table: "MedicalHistory",
                columns: new[] { "Id", "PatientId", "VisitTime" },
                values: new object[,]
                {
                    { new Guid("45f63b40-0685-4fd1-90c3-05c9c54b5596"), new Guid("af5995b3-bfc5-4afe-b0de-658d1cb7992f"), new DateTime(2022, 12, 6, 9, 18, 38, 561, DateTimeKind.Local).AddTicks(8441) },
                    { new Guid("b0454be4-3d90-41ec-a8db-2a8cc849e326"), new Guid("d7eecffe-2139-4953-915f-d6e7f97f72f1"), new DateTime(2022, 12, 4, 9, 18, 38, 561, DateTimeKind.Local).AddTicks(8391) },
                    { new Guid("d5880b44-00eb-4f88-a7d5-407ecb234bc4"), new Guid("d7eecffe-2139-4953-915f-d6e7f97f72f1"), new DateTime(2022, 12, 8, 9, 18, 38, 561, DateTimeKind.Local).AddTicks(8445) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MedicalHistory",
                keyColumn: "Id",
                keyValue: new Guid("45f63b40-0685-4fd1-90c3-05c9c54b5596"));

            migrationBuilder.DeleteData(
                table: "MedicalHistory",
                keyColumn: "Id",
                keyValue: new Guid("b0454be4-3d90-41ec-a8db-2a8cc849e326"));

            migrationBuilder.DeleteData(
                table: "MedicalHistory",
                keyColumn: "Id",
                keyValue: new Guid("d5880b44-00eb-4f88-a7d5-407ecb234bc4"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("2e11df19-8346-4823-9400-4381e6aa9c2d"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("9ac3971e-01c3-4515-a418-0c9a55be8488"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("af5995b3-bfc5-4afe-b0de-658d1cb7992f"));

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: new Guid("d7eecffe-2139-4953-915f-d6e7f97f72f1"));

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
        }
    }
}
