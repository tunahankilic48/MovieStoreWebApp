﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStore.Models.DataAccess;

#nullable disable

namespace MovieStore.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieStarring", b =>
                {
                    b.Property<int>("PerformedMoviesId")
                        .HasColumnType("int");

                    b.Property<int>("StarringsId")
                        .HasColumnType("int");

                    b.HasKey("PerformedMoviesId", "StarringsId");

                    b.HasIndex("StarringsId");

                    b.ToTable("MovieStarring");
                });

            modelBuilder.Entity("MovieStore.Models.Entities.Category", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnOrder(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("MovieStore.Models.Entities.Director", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnOrder(4);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnOrder(2);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.ToTable("Directors", (string)null);
                });

            modelBuilder.Entity("MovieStore.Models.Entities.Language", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.ToTable("Languages", (string)null);
                });

            modelBuilder.Entity("MovieStore.Models.Entities.Movie", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<int?>("DirectorId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnOrder(4);

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnOrder(10);

                    b.Property<int?>("LanguageId")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnOrder(7);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(2);

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("decimal(7,2)")
                        .HasColumnOrder(8);

                    b.Property<DateTime?>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("date")
                        .HasColumnOrder(5);

                    b.Property<short?>("RunningTimeMin")
                        .HasColumnType("smallint")
                        .HasColumnOrder(6);

                    b.Property<int?>("Stock")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnOrder(9);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("LanguageId");

                    b.ToTable("Movies", (string)null);
                });

            modelBuilder.Entity("MovieStore.Models.Entities.Starring", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnOrder(4);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnOrder(2);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnOrder(3);

                    b.HasKey("Id");

                    b.ToTable("Starrings", (string)null);
                });

            modelBuilder.Entity("MovieStarring", b =>
                {
                    b.HasOne("MovieStore.Models.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("PerformedMoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieStore.Models.Entities.Starring", null)
                        .WithMany()
                        .HasForeignKey("StarringsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieStore.Models.Entities.Movie", b =>
                {
                    b.HasOne("MovieStore.Models.Entities.Category", "Category")
                        .WithMany("Movies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieStore.Models.Entities.Director", "Director")
                        .WithMany("DirectedMovies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieStore.Models.Entities.Language", "Language")
                        .WithMany("OriginalLanguageOfMovies")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Director");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("MovieStore.Models.Entities.Category", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MovieStore.Models.Entities.Director", b =>
                {
                    b.Navigation("DirectedMovies");
                });

            modelBuilder.Entity("MovieStore.Models.Entities.Language", b =>
                {
                    b.Navigation("OriginalLanguageOfMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
