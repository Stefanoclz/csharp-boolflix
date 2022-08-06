﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using csharp_boolflix.DataBase;

#nullable disable

namespace csharp_boolflix.Migrations
{
    [DbContext(typeof(BoolflixContext))]
    [Migration("20220805202020_ChanegOnVideo")]
    partial class ChanegOnVideo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("csharp_boolflix.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("csharp_boolflix.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("csharp_boolflix.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsChild")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaylistId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId")
                        .IsUnique()
                        .HasFilter("[PlaylistId] IS NOT NULL");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("csharp_boolflix.Models.VideoContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CoverImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VideoContents");

                    b.HasDiscriminator<string>("Discriminator").HasValue("VideoContent");
                });

            modelBuilder.Entity("GenreVideoContent", b =>
                {
                    b.Property<int>("GenresListId")
                        .HasColumnType("int");

                    b.Property<int>("VideoContentsId")
                        .HasColumnType("int");

                    b.HasKey("GenresListId", "VideoContentsId");

                    b.HasIndex("VideoContentsId");

                    b.ToTable("GenreVideoContent");
                });

            modelBuilder.Entity("PlaylistVideoContent", b =>
                {
                    b.Property<int>("PlaylistsListId")
                        .HasColumnType("int");

                    b.Property<int>("VideoContentsId")
                        .HasColumnType("int");

                    b.HasKey("PlaylistsListId", "VideoContentsId");

                    b.HasIndex("VideoContentsId");

                    b.ToTable("PlaylistVideoContent");
                });

            modelBuilder.Entity("ProfileVideoContent", b =>
                {
                    b.Property<int>("ProfilesId")
                        .HasColumnType("int");

                    b.Property<int>("VideoContentsId")
                        .HasColumnType("int");

                    b.HasKey("ProfilesId", "VideoContentsId");

                    b.HasIndex("VideoContentsId");

                    b.ToTable("ProfileVideoContent");
                });

            modelBuilder.Entity("csharp_boolflix.Models.Film", b =>
                {
                    b.HasBaseType("csharp_boolflix.Models.VideoContent");

                    b.HasDiscriminator().HasValue("Film");
                });

            modelBuilder.Entity("csharp_boolflix.Models.Profile", b =>
                {
                    b.HasOne("csharp_boolflix.Models.Playlist", "Playlist")
                        .WithOne("Profile")
                        .HasForeignKey("csharp_boolflix.Models.Profile", "PlaylistId");

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("GenreVideoContent", b =>
                {
                    b.HasOne("csharp_boolflix.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("csharp_boolflix.Models.VideoContent", null)
                        .WithMany()
                        .HasForeignKey("VideoContentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlaylistVideoContent", b =>
                {
                    b.HasOne("csharp_boolflix.Models.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistsListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("csharp_boolflix.Models.VideoContent", null)
                        .WithMany()
                        .HasForeignKey("VideoContentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProfileVideoContent", b =>
                {
                    b.HasOne("csharp_boolflix.Models.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("csharp_boolflix.Models.VideoContent", null)
                        .WithMany()
                        .HasForeignKey("VideoContentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("csharp_boolflix.Models.Playlist", b =>
                {
                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
