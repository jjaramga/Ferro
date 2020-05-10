﻿// <auto-generated />
using System;
using Ferroviario.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ferroviario.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ferroviario.Web.Data.Entities.ChangeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FirstServiceId");

                    b.Property<int?>("SecondServiceId");

                    b.Property<string>("State");

                    b.HasKey("Id");

                    b.HasIndex("FirstServiceId");

                    b.HasIndex("SecondServiceId");

                    b.ToTable("Changes");
                });

            modelBuilder.Entity("Ferroviario.Web.Data.Entities.RequestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<string>("Description");

                    b.Property<DateTime>("FinishDate");

                    b.Property<DateTime>("InitialDate");

                    b.Property<string>("State");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Ferroviario.Web.Data.Entities.RequestTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("RequestTypes");
                });

            modelBuilder.Entity("Ferroviario.Web.Data.Entities.ServiceDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ServiceDetails");
                });

            modelBuilder.Entity("Ferroviario.Web.Data.Entities.ServiceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("FinalHour");

                    b.Property<string>("FinalStation")
                        .IsRequired();

                    b.Property<TimeSpan>("InitialHour");

                    b.Property<string>("InitialStation")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("ServiceDetailId");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ServiceDetailId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Ferroviario.Web.Data.Entities.ChangeEntity", b =>
                {
                    b.HasOne("Ferroviario.Web.Data.Entities.ServiceEntity", "FirstService")
                        .WithMany()
                        .HasForeignKey("FirstServiceId");

                    b.HasOne("Ferroviario.Web.Data.Entities.ServiceEntity", "SecondService")
                        .WithMany()
                        .HasForeignKey("SecondServiceId");
                });

            modelBuilder.Entity("Ferroviario.Web.Data.Entities.RequestEntity", b =>
                {
                    b.HasOne("Ferroviario.Web.Data.Entities.RequestTypeEntity", "Type")
                        .WithMany("Requests")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ferroviario.Web.Data.Entities.ServiceEntity", b =>
                {
                    b.HasOne("Ferroviario.Web.Data.Entities.ServiceDetailEntity", "ServiceDetail")
                        .WithMany()
                        .HasForeignKey("ServiceDetailId");
                });
#pragma warning restore 612, 618
        }
    }
}