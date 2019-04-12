﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OptimusZQ.DAL;

namespace OptimusZQ.DAL.Migrations
{
    [DbContext(typeof(OptimusDbContext))]
    partial class OptimusDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OptimusZQ.DAL.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FileName");

                    b.Property<int?>("FolderId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("OptimusZQ.DAL.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FullPath");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentFolderId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ParentFolderId");

                    b.HasIndex("UserId");

                    b.ToTable("Folders");
                });

            modelBuilder.Entity("OptimusZQ.DAL.Models.SharedFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("FileId");

                    b.Property<string>("Scopes");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("UserId");

                    b.ToTable("SharedFiles");
                });

            modelBuilder.Entity("OptimusZQ.DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Login");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OptimusZQ.DAL.Models.File", b =>
                {
                    b.HasOne("OptimusZQ.DAL.Models.Folder", "Folder")
                        .WithMany("Files")
                        .HasForeignKey("FolderId");
                });

            modelBuilder.Entity("OptimusZQ.DAL.Models.Folder", b =>
                {
                    b.HasOne("OptimusZQ.DAL.Models.Folder", "ParentFolder")
                        .WithMany("Folders")
                        .HasForeignKey("ParentFolderId");

                    b.HasOne("OptimusZQ.DAL.Models.User", "User")
                        .WithMany("Folders")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("OptimusZQ.DAL.Models.SharedFile", b =>
                {
                    b.HasOne("OptimusZQ.DAL.Models.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId");

                    b.HasOne("OptimusZQ.DAL.Models.User", "User")
                        .WithMany("SharedFiles")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
