﻿// <auto-generated />
using MVC_uppgift.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_uppgift.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220529195632_addedSecondJapanCity")]
    partial class addedSecondJapanCity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.4.22229.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVC_uppgift.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Kyoto"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 1,
                            Name = "Hiroshima"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            Name = "Paris"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            Name = "Gävle"
                        });
                });

            modelBuilder.Entity("MVC_uppgift.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Japan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "France"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sweden"
                        });
                });

            modelBuilder.Entity("MVC_uppgift.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Japanese"
                        },
                        new
                        {
                            Id = 2,
                            Name = "French"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Swedish"
                        });
                });

            modelBuilder.Entity("MVC_uppgift.Models.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("LanguageId");

                    b.ToTable("Peoples");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            LanguageId = 1,
                            Name = "Tony montana",
                            PhoneNumber = 24523421
                        },
                        new
                        {
                            Id = 2,
                            CityId = 2,
                            LanguageId = 2,
                            Name = "Werrever Tommorow",
                            PhoneNumber = 345363234
                        },
                        new
                        {
                            Id = 3,
                            CityId = 3,
                            LanguageId = 3,
                            Name = "Lu Xiaojun",
                            PhoneNumber = 43523413
                        });
                });

            modelBuilder.Entity("MVC_uppgift.Models.PeopleLanguage", b =>
                {
                    b.Property<int>("PeopleId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("PeopleId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PeopleLanguages");
                });

            modelBuilder.Entity("MVC_uppgift.Models.City", b =>
                {
                    b.HasOne("MVC_uppgift.Models.Country", null)
                        .WithMany("ListOfCities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVC_uppgift.Models.People", b =>
                {
                    b.HasOne("MVC_uppgift.Models.City", "City")
                        .WithMany("ListOfPeople")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_uppgift.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("MVC_uppgift.Models.PeopleLanguage", b =>
                {
                    b.HasOne("MVC_uppgift.Models.Language", "Language")
                        .WithMany("PeopleLanguagues")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_uppgift.Models.People", "People")
                        .WithMany("PeopleLanguagues")
                        .HasForeignKey("PeopleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("People");
                });

            modelBuilder.Entity("MVC_uppgift.Models.City", b =>
                {
                    b.Navigation("ListOfPeople");
                });

            modelBuilder.Entity("MVC_uppgift.Models.Country", b =>
                {
                    b.Navigation("ListOfCities");
                });

            modelBuilder.Entity("MVC_uppgift.Models.Language", b =>
                {
                    b.Navigation("PeopleLanguagues");
                });

            modelBuilder.Entity("MVC_uppgift.Models.People", b =>
                {
                    b.Navigation("PeopleLanguagues");
                });
#pragma warning restore 612, 618
        }
    }
}
