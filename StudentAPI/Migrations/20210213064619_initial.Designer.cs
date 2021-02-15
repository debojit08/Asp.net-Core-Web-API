﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentAPI;

namespace StudentAPI.Migrations
{
    [DbContext(typeof(studentDBContext))]
    [Migration("20210213064619_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentAPI.studentInfo", b =>
                {
                    b.Property<int>("stdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("course")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("stdId");

                    b.ToTable("studentTable");
                });
#pragma warning restore 612, 618
        }
    }
}
