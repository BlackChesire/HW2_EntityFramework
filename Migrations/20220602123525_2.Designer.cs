﻿// <auto-generated />
using System;
using HW2_EntityFramework.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HW2_EntityFramework.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220602123525_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HW2_EntityFramework.DataModels.Frame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("height")
                        .HasColumnType("int");

                    b.Property<int>("width")
                        .HasColumnType("int");

                    b.Property<int>("x")
                        .HasColumnType("int");

                    b.Property<int>("y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Frames");
                });

            modelBuilder.Entity("HW2_EntityFramework.DataModels.Point", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ShapeId")
                        .HasColumnType("int");

                    b.Property<int>("color")
                        .HasColumnType("int");

                    b.Property<string>("tav")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("x")
                        .HasColumnType("int");

                    b.Property<int>("y")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ShapeId");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("HW2_EntityFramework.DataModels.Shape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FrameId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FrameId");

                    b.ToTable("Shapes");
                });

            modelBuilder.Entity("HW2_EntityFramework.DataModels.Point", b =>
                {
                    b.HasOne("HW2_EntityFramework.DataModels.Shape", null)
                        .WithMany("point")
                        .HasForeignKey("ShapeId");
                });

            modelBuilder.Entity("HW2_EntityFramework.DataModels.Shape", b =>
                {
                    b.HasOne("HW2_EntityFramework.DataModels.Frame", null)
                        .WithMany("shapes")
                        .HasForeignKey("FrameId");
                });

            modelBuilder.Entity("HW2_EntityFramework.DataModels.Frame", b =>
                {
                    b.Navigation("shapes");
                });

            modelBuilder.Entity("HW2_EntityFramework.DataModels.Shape", b =>
                {
                    b.Navigation("point");
                });
#pragma warning restore 612, 618
        }
    }
}
