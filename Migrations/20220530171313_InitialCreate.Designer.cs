// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnitOfWork.Data;

#nullable disable

namespace UnitOfWork.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220530171313_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UnitOfWork.Models.Alquiler", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<DateTime?>("dateTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("precio")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("alquileres");
                });

            modelBuilder.Entity("UnitOfWork.Models.Pelicula", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("Alquilerid")
                        .HasColumnType("int");

                    b.Property<DateTime?>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Alquilerid");

                    b.ToTable("peliculas");
                });

            modelBuilder.Entity("UnitOfWork.Models.Pelicula", b =>
                {
                    b.HasOne("UnitOfWork.Models.Alquiler", null)
                        .WithMany("peliculas")
                        .HasForeignKey("Alquilerid");
                });

            modelBuilder.Entity("UnitOfWork.Models.Alquiler", b =>
                {
                    b.Navigation("peliculas");
                });
#pragma warning restore 612, 618
        }
    }
}
