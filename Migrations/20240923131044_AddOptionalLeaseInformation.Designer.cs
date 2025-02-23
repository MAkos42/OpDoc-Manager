﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OpDoc_Manager.Data;

#nullable disable

namespace OpDoc_Manager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240923131044_AddOptionalLeaseInformation")]
    partial class AddOptionalLeaseInformation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift", b =>
                {
                    b.Property<Guid>("UniqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("UniqueId");

                    b.ToTable("Forklifts");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+LeaseInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("LeaseeCompany")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeaseeContact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeaseeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeaseeOrgUnit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeaseePosition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeaserCompany")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeaserContact")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeaserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeaserOrgUnit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LeaserPosition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LeaseInformation");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+OperatorInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("ForkliftAdminContact")
                        .HasColumnType("text");

                    b.Property<string>("ForkliftAdminPosition")
                        .HasColumnType("text");

                    b.Property<string>("ForkliftAdministrator")
                        .HasColumnType("text");

                    b.Property<bool>("IsDifferentOperator")
                        .HasColumnType("boolean");

                    b.Property<string>("OperationArea")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Operator")
                        .HasColumnType("text");

                    b.Property<string>("OperatorAddress")
                        .HasColumnType("text");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OwnerAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TechnicianName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TechnicianPosition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly?>("TransferDate")
                        .HasColumnType("date");

                    b.Property<string>("TransferID")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserPosition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OperatorInformation");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift", b =>
                {
                    b.OwnsOne("OpDoc_Manager.Models.Forklift+GeneralInformation", "General", b1 =>
                        {
                            b1.Property<Guid>("ForkliftUniqueId")
                                .HasColumnType("uuid");

                            b1.Property<string>("OperatorType")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("OperatorType");

                            b1.Property<string>("PowerSource")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PowerSource");

                            b1.Property<DateOnly>("EntryIntoService")
                                .HasColumnType("date")
                                .HasColumnName("EntryIntoService");

                            b1.Property<string>("OperationMode")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("OperationMode");

                            b1.Property<string>("Manufacturer")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Manufacturer");

                            b1.Property<int>("ManufacturingYear")
                                .HasColumnType("integer")
                                .HasColumnName("ManufacturingYear");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Name");

                            b1.Property<string>("ProductionNumber")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("ProductionNumber");

                            b1.Property<string>("Model")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Model");

                            b1.HasKey("ForkliftUniqueId");

                            b1.ToTable("Forklifts");

                            b1.WithOwner()
                                .HasForeignKey("ForkliftUniqueId");
                        });

                    b.Navigation("General")
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+LeaseInformation", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift+OperatorInformation", null)
                        .WithOne("LeaseInformation")
                        .HasForeignKey("OpDoc_Manager.Models.Forklift+LeaseInformation", "Id");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+OperatorInformation", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift", null)
                        .WithOne("Operator")
                        .HasForeignKey("OpDoc_Manager.Models.Forklift+OperatorInformation", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift", b =>
                {
                    b.Navigation("Operator")
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+OperatorInformation", b =>
                {
                    b.Navigation("LeaseInformation");
                });
#pragma warning restore 612, 618
        }
    }
}
