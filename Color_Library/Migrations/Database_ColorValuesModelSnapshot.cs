﻿// <auto-generated />
using Color_Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Color_Library.Migrations
{
    [DbContext(typeof(Database_ColorValues))]
    partial class Database_ColorValuesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("Color_Library.ColorValues", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Blue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("Green")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Red")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Transparency")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Colors");
                });
#pragma warning restore 612, 618
        }
    }
}
