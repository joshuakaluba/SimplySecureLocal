﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimplySecureLocal.Data.DataContext;

namespace SimplySecureLocal.Data.Migrations
{
    [DbContext(typeof(SimplySecureDataContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SimplySecureLocal.Data.Models.BootMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<Guid>("ModuleId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("BootMessages");
                });

            modelBuilder.Entity("SimplySecureLocal.Data.Models.HeartBeat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<Guid>("ModuleId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("HeartBeats");
                });

            modelBuilder.Entity("SimplySecureLocal.Data.Models.StatusChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<Guid>("ModuleId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("StatusChanges");
                });
#pragma warning restore 612, 618
        }
    }
}
