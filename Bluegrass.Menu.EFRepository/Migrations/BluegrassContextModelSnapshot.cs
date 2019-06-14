﻿// <auto-generated />
using System;
using Bluegrass.Menu.EFRepository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bluegrass.Menu.EFRepository.Migrations
{
    [DbContext(typeof(BluegrassContext))]
    partial class BluegrassContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bluegrass.Menu.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Icon")
                        .HasMaxLength(50);

                    b.Property<int?>("MenuId");

                    b.Property<int?>("ParentId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("Bluegrass.Menu.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Bluegrass.Menu.Models.Menu", b =>
                {
                    b.HasOne("Bluegrass.Menu.Models.Menu")
                        .WithMany("Children")
                        .HasForeignKey("MenuId");

                    b.HasOne("Bluegrass.Menu.Models.Menu", "ParentMenu")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("Bluegrass.Menu.Models.User", "User")
                        .WithMany("Menu")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
