﻿// <auto-generated />
using ComputerDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ComputerWebAPI.Migrations
{
    [DbContext(typeof(ComputerContext))]
    [Migration("20180403171251_CreateMemory")]
    partial class CreateMemory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComputerLibrary.Models.Computer", b =>
                {
                    b.Property<long>("ComputerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfiguracionName");

                    b.Property<string>("HardDrive");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("MemoryId");

                    b.Property<long?>("MemoryId1");

                    b.Property<string>("Processor");

                    b.HasKey("ComputerId");

                    b.HasIndex("MemoryId1");

                    b.ToTable("Computer");
                });

            modelBuilder.Entity("ComputerLibrary.Models.Memory", b =>
                {
                    b.Property<long>("MemoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("SizeGb");

                    b.Property<string>("Speed");

                    b.HasKey("MemoryId");

                    b.ToTable("Memory");
                });

            modelBuilder.Entity("ComputerLibrary.Models.Computer", b =>
                {
                    b.HasOne("ComputerLibrary.Models.Memory", "Memory")
                        .WithMany("Computers")
                        .HasForeignKey("MemoryId1");
                });
#pragma warning restore 612, 618
        }
    }
}