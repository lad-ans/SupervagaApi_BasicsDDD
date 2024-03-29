﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Supervaga.Infra.Data.DataContexts;

#nullable disable

namespace Supervaga.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220212052826_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Supervaga.Domain.Ads.Ad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("application_id");

                    b.Property<string>("AudienceGender")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("audience_gender");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("category");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 2, 12, 7, 28, 26, 128, DateTimeKind.Local).AddTicks(9740))
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("description");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("expires_at");

                    b.Property<bool>("IsFreelance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("is_freelance");

                    b.Property<float?>("SalaryOffer")
                        .HasColumnType("real")
                        .HasColumnName("salary_offer");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("title");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("Category");

                    b.HasIndex("Description");

                    b.HasIndex("Id");

                    b.HasIndex("Title");

                    b.HasIndex("UserId");

                    b.ToTable("tb_ad", (string)null);
                });

            modelBuilder.Entity("Supervaga.Domain.Ads.Advantage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ad_id");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.HasIndex("Id");

                    b.HasIndex("Title");

                    b.ToTable("tb_advantage", (string)null);
                });

            modelBuilder.Entity("Supervaga.Domain.Ads.Requirement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ad_id");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.HasIndex("Id");

                    b.HasIndex("Title");

                    b.ToTable("tb_requirement", (string)null);
                });

            modelBuilder.Entity("Supervaga.Domain.Applications.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ad_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("expires_at");

                    b.HasKey("Id");

                    b.HasIndex("AdId")
                        .IsUnique();

                    b.HasIndex("Id");

                    b.ToTable("tb_application", (string)null);
                });

            modelBuilder.Entity("Supervaga.Domain.Applications.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("AdId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id_ad");

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("application_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsCv")
                        .HasColumnType("bit")
                        .HasColumnName("is_cv");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id_user");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tb_candidate", (string)null);
                });

            modelBuilder.Entity("Supervaga.Domain.Documents.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content_type");

                    b.Property<string>("FileName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("file_name");

                    b.Property<long?>("FileSize")
                        .HasMaxLength(100)
                        .HasColumnType("bigint")
                        .HasColumnName("file_size");

                    b.Property<string>("FileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FileName");

                    b.HasIndex("Id");

                    b.ToTable("tb_document", (string)null);
                });

            modelBuilder.Entity("Supervaga.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("avatar");

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("biography");

                    b.Property<string>("Cv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cv");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("email");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("phone");

                    b.Property<string>("Provider")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("provider");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("role");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tag");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("Id");

                    b.HasIndex("Name");

                    b.ToTable("tb_user", (string)null);
                });

            modelBuilder.Entity("Supervaga.Domain.Ads.Ad", b =>
                {
                    b.HasOne("Supervaga.Domain.Users.User", "User")
                        .WithOne()
                        .HasForeignKey("Supervaga.Domain.Ads.Ad", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_tb_user_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Supervaga.Domain.Ads.Advantage", b =>
                {
                    b.HasOne("Supervaga.Domain.Ads.Ad", "Ad")
                        .WithMany("Advantages")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("Supervaga.Domain.Ads.Requirement", b =>
                {
                    b.HasOne("Supervaga.Domain.Ads.Ad", "Ad")
                        .WithMany("Requirements")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("Supervaga.Domain.Applications.Application", b =>
                {
                    b.HasOne("Supervaga.Domain.Ads.Ad", "Ad")
                        .WithOne()
                        .HasForeignKey("Supervaga.Domain.Applications.Application", "AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_tb_application_ad_id_ad");

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("Supervaga.Domain.Applications.Candidate", b =>
                {
                    b.HasOne("Supervaga.Domain.Applications.Application", "Application")
                        .WithMany("Candidates")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("Supervaga.Domain.Ads.Ad", b =>
                {
                    b.Navigation("Advantages");

                    b.Navigation("Requirements");
                });

            modelBuilder.Entity("Supervaga.Domain.Applications.Application", b =>
                {
                    b.Navigation("Candidates");
                });
#pragma warning restore 612, 618
        }
    }
}
