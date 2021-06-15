﻿// <auto-generated />
using System;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.AvailablilityStatus", b =>
                {
                    b.Property<long>("AvailabilityStatus_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("availability_status_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AvailabilityStatus_CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 6, 9, 13, 13, 32, 955, DateTimeKind.Utc).AddTicks(5251))
                        .HasColumnName("availability_status_creation_date");

                    b.Property<DateTime>("AvailabilityStatus_ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("availability_status_modified_date");

                    b.Property<string>("AvailabilityStatus_Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AvailabilityStatus_ID");

                    b.HasIndex("AvailabilityStatus_Name")
                        .IsUnique()
                        .HasFilter("[AvailabilityStatus_Name] IS NOT NULL");

                    b.ToTable("availablility_status");
                });

            modelBuilder.Entity("DAL.Entities.Good", b =>
                {
                    b.Property<long>("Good_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("good")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AvailablilityStatus_ID")
                        .HasColumnType("bigint")
                        .HasColumnName("availability_status_id");

                    b.Property<DateTime>("Good_CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 6, 9, 13, 13, 32, 957, DateTimeKind.Utc).AddTicks(6462))
                        .HasColumnName("creation_date");

                    b.Property<string>("Good_Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("good_descript");

                    b.Property<DateTime>("Good_ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("modified_date");

                    b.Property<string>("Good_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("good_name");

                    b.Property<long>("Good_Specification_ID")
                        .HasColumnType("bigint")
                        .HasColumnName("specification_id");

                    b.Property<long>("Manufacturer_ID")
                        .HasColumnType("bigint")
                        .HasColumnName("manufecturer_id");

                    b.Property<long?>("SpecificationGood_Spec_ID")
                        .HasColumnType("bigint");

                    b.HasKey("Good_ID");

                    b.HasIndex("AvailablilityStatus_ID");

                    b.HasIndex("Manufacturer_ID");

                    b.HasIndex("SpecificationGood_Spec_ID");

                    b.ToTable("good");
                });

            modelBuilder.Entity("DAL.Entities.Manufacturer", b =>
                {
                    b.Property<long>("Manufacturer_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("manufacturer_id")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Manufacturer_CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 6, 9, 13, 13, 32, 941, DateTimeKind.Utc).AddTicks(8154))
                        .HasColumnName("manufacturer_creation_date");

                    b.Property<string>("Manufacturer_Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("manufacturer_description");

                    b.Property<DateTime>("Manufacturer_ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1900, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                        .HasColumnName("manufacturer_modified_date");

                    b.Property<string>("Manufacturer_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("manufacturer_name");

                    b.HasKey("Manufacturer_ID");

                    b.ToTable("manufacturer");
                });

            modelBuilder.Entity("DAL.Entities.Specification", b =>
                {
                    b.Property<long>("Good_Spec_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("specification")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Good_Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("good_color");

                    b.Property<bool>("Good_IsGaming")
                        .HasMaxLength(50)
                        .HasColumnType("bit")
                        .HasColumnName("good_is_gaming");

                    b.Property<string>("Good_Size")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("good_size");

                    b.Property<string>("Good_Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("good_type");

                    b.HasKey("Good_Spec_ID");

                    b.ToTable("specification");
                });

            modelBuilder.Entity("DAL.Entities.Good", b =>
                {
                    b.HasOne("DAL.Entities.AvailablilityStatus", "AvailablilityStatus")
                        .WithMany("Goods")
                        .HasForeignKey("AvailablilityStatus_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Manufacturer", "Manufacturer")
                        .WithMany("Goods")
                        .HasForeignKey("Manufacturer_ID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Specification", "Specification")
                        .WithMany()
                        .HasForeignKey("SpecificationGood_Spec_ID");

                    b.Navigation("AvailablilityStatus");

                    b.Navigation("Manufacturer");

                    b.Navigation("Specification");
                });

            modelBuilder.Entity("DAL.Entities.AvailablilityStatus", b =>
                {
                    b.Navigation("Goods");
                });

            modelBuilder.Entity("DAL.Entities.Manufacturer", b =>
                {
                    b.Navigation("Goods");
                });
#pragma warning restore 612, 618
        }
    }
}
