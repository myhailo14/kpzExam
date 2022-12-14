// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using exam_back.DB;

#nullable disable

namespace examback.Migrations
{
    [DbContext(typeof(DentistDbContext))]
    partial class DentistDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("exam_back.Models.MedicalHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VisitTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("MedicalHistory");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b0454be4-3d90-41ec-a8db-2a8cc849e326"),
                            PatientId = new Guid("d7eecffe-2139-4953-915f-d6e7f97f72f1"),
                            VisitTime = new DateTime(2022, 12, 4, 9, 18, 38, 561, DateTimeKind.Local).AddTicks(8391)
                        },
                        new
                        {
                            Id = new Guid("45f63b40-0685-4fd1-90c3-05c9c54b5596"),
                            PatientId = new Guid("af5995b3-bfc5-4afe-b0de-658d1cb7992f"),
                            VisitTime = new DateTime(2022, 12, 6, 9, 18, 38, 561, DateTimeKind.Local).AddTicks(8441)
                        },
                        new
                        {
                            Id = new Guid("d5880b44-00eb-4f88-a7d5-407ecb234bc4"),
                            PatientId = new Guid("d7eecffe-2139-4953-915f-d6e7f97f72f1"),
                            VisitTime = new DateTime(2022, 12, 8, 9, 18, 38, 561, DateTimeKind.Local).AddTicks(8445)
                        });
                });

            modelBuilder.Entity("exam_back.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d7eecffe-2139-4953-915f-d6e7f97f72f1"),
                            Birthday = new DateTime(2003, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Mykhailo",
                            Surname = "Vovkanych"
                        },
                        new
                        {
                            Id = new Guid("af5995b3-bfc5-4afe-b0de-658d1cb7992f"),
                            Birthday = new DateTime(2002, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Taras",
                            Surname = "Shevchenko"
                        },
                        new
                        {
                            Id = new Guid("9ac3971e-01c3-4515-a418-0c9a55be8488"),
                            Birthday = new DateTime(1994, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Stepan",
                            Surname = "Bandera"
                        },
                        new
                        {
                            Id = new Guid("2e11df19-8346-4823-9400-4381e6aa9c2d"),
                            Birthday = new DateTime(1982, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Lesia",
                            Surname = "Ukrainka"
                        });
                });

            modelBuilder.Entity("exam_back.Models.MedicalHistory", b =>
                {
                    b.HasOne("exam_back.Models.Patient", "Patient")
                        .WithMany("History")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("exam_back.Models.Patient", b =>
                {
                    b.Navigation("History");
                });
#pragma warning restore 612, 618
        }
    }
}
