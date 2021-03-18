﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.Models;

namespace SocialNetwork.Migrations
{
    [DbContext(typeof(SocialNetworkContext))]
    partial class SocialNetworkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SocialNetwork.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FollowerId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImageCaption")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImageDescription")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserAbout")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SocialNetwork.Models.User", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", null)
                        .WithMany("JoinEntities")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("SocialNetwork.Models.User", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
