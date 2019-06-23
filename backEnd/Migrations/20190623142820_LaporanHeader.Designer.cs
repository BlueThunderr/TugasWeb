﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backEnd.Models;

namespace backEnd.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190623142820_LaporanHeader")]
    partial class LaporanHeader
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backEnd.Models.LaporanHeader", b =>
                {
                    b.Property<Guid>("LaporanHeaderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("JudulLaporan");

                    b.Property<string>("Keterangan");

                    b.Property<string>("Status");

                    b.Property<DateTime>("TglBuat");

                    b.Property<DateTime?>("TglSelesai");

                    b.Property<Guid>("UserId");

                    b.HasKey("LaporanHeaderId");

                    b.HasIndex("UserId");

                    b.ToTable("LaporanHeaders");
                });

            modelBuilder.Entity("backEnd.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<string>("level");

                    b.Property<string>("password");

                    b.Property<string>("userName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("backEnd.Models.LaporanHeader", b =>
                {
                    b.HasOne("backEnd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
