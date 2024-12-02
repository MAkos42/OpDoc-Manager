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
    [Migration("20241202143425_RenamedPIRPerformerToTechnician")]
    partial class RenamedPIRPerformerToTechnician
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
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

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+AdapterInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AdapterInformation");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+AdapterRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ForkliftId")
                        .HasColumnType("uuid");

                    b.Property<int>("LoadCenterDistance")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ForkliftId");

                    b.ToTable("Adapters");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+CustomInspectionPeriod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("CheckInspectionPeriod")
                        .HasColumnType("integer");

                    b.Property<string>("CheckInspectionType")
                        .HasColumnType("text");

                    b.Property<Guid>("ForkliftId")
                        .HasColumnType("uuid");

                    b.Property<int>("MainInspectionPeriod")
                        .HasColumnType("integer");

                    b.Property<string>("MainInspectionType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ManufacturerOperatingHours")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<int>("StructuralInspectionPeriod")
                        .HasColumnType("integer");

                    b.Property<string>("StructuralInspectionType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ForkliftId");

                    b.ToTable("CustomInspectionPeriods");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+Engine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("EngineType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Engines");

                    b.UseTptMappingStrategy();
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

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+MaintenanceReport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("ForkliftId")
                        .HasColumnType("uuid");

                    b.Property<int>("OperatingHours")
                        .HasColumnType("integer");

                    b.Property<string>("RepairDetails")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ForkliftId");

                    b.ToTable("MaintenanceReports");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+ModelInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("EngineId")
                        .HasColumnType("uuid");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OperationMode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("OperationMode");

                    b.Property<string>("OperatorType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("OperatorType");

                    b.Property<string>("PowerSource")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("PowerSource");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EngineId")
                        .IsUnique();

                    b.HasIndex("Manufacturer", "Type")
                        .IsUnique();

                    b.ToTable("ForkliftModels");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+OperatorInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("ForkliftAdminContact")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OperatorAddress")
                        .IsRequired()
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

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+PeriodicInspectionInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("InspectionCategory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("LastInspectionDate")
                        .HasColumnType("date");

                    b.Property<int?>("MSZ9750InspectionGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("MainInspectionPeriodMonths")
                        .HasColumnType("integer");

                    b.Property<int>("MainInspectionPeriodOpHours")
                        .HasColumnType("integer");

                    b.Property<string>("ManufacturerInspectionId")
                        .HasColumnType("text");

                    b.Property<DateOnly>("NextInspectionDate")
                        .HasColumnType("date");

                    b.Property<int>("NextInspectionOpHours")
                        .HasColumnType("integer");

                    b.Property<int>("OperatingHours")
                        .HasColumnType("integer");

                    b.Property<string>("OperatorInspectionId")
                        .HasColumnType("text");

                    b.Property<int>("StructuralInspectionMonths")
                        .HasColumnType("integer");

                    b.Property<int>("StructuralInspectionOpHours")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("PeriodicInspectionInformation");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+PeriodicInspectionResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CurrentOperatingHours")
                        .HasColumnType("integer");

                    b.Property<Guid>("ForkliftId")
                        .HasColumnType("uuid");

                    b.Property<bool>("HasPassedInspection")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("InspectionDate")
                        .HasColumnType("date");

                    b.Property<string>("InspectionReportId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("RequiredInspectionDate")
                        .HasColumnType("date");

                    b.Property<int>("RequiredOperationHours")
                        .HasColumnType("integer");

                    b.Property<string>("Technician")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ForkliftId");

                    b.ToTable("periodicInspections");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+UserManualInformation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("DateOfTransfer")
                        .HasColumnType("date");

                    b.Property<bool>("IsOnlineManual")
                        .HasColumnType("boolean");

                    b.Property<DateOnly?>("LeaseReturnDate")
                        .HasColumnType("date");

                    b.Property<string>("LeaseeSigneeName")
                        .HasColumnType("text");

                    b.Property<string>("LeaseeSigneePosition")
                        .HasColumnType("text");

                    b.Property<string>("LeaserSigneeName")
                        .HasColumnType("text");

                    b.Property<string>("LeaserSigneePosition")
                        .HasColumnType("text");

                    b.Property<string>("ManualWebsite")
                        .HasColumnType("text");

                    b.Property<string>("RecipientSigneeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RecipientSigneePosition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RecipientType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplierSigneeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplierSigneePosition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplierType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserManualInformation");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+ElectricEngine", b =>
                {
                    b.HasBaseType("OpDoc_Manager.Models.Forklift+Engine");

                    b.Property<int>("BatteryCellCount")
                        .HasColumnType("integer");

                    b.Property<string>("BatteryManufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BatteryType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BatteryVoltage")
                        .HasColumnType("integer");

                    b.Property<string>("FrequencyConverterManufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FrequencyConverterPerformance")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FrequencyConverterType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InverterManufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InverterPerformance")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InverterType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MotorManufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("MotorOutput")
                        .HasColumnType("double precision");

                    b.Property<int>("MotorRPM")
                        .HasColumnType("integer");

                    b.Property<int>("NominalBatteryCapacity")
                        .HasColumnType("integer");

                    b.ToTable("ElectricEngines", (string)null);
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+InternalCombustionEngine", b =>
                {
                    b.HasBaseType("OpDoc_Manager.Models.Forklift+Engine");

                    b.Property<string>("CatalyticConverter")
                        .HasColumnType("text");

                    b.Property<int>("CylinderVolume")
                        .HasColumnType("integer");

                    b.Property<string>("EnviromentalClassification")
                        .HasColumnType("text");

                    b.Property<int>("FuelCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NatGasSafetyValveType")
                        .HasColumnType("text");

                    b.Property<double>("RatedOutput")
                        .HasColumnType("double precision");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("ICEngine", (string)null);
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift", b =>
                {
                    b.OwnsOne("OpDoc_Manager.Models.Forklift+GeneralInformation", "General", b1 =>
                        {
                            b1.Property<Guid>("ForkliftUniqueId")
                                .HasColumnType("uuid");

                            b1.Property<string>("EngineProductionNumber")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("EngineProductionNumber");

                            b1.Property<DateOnly>("EntryIntoService")
                                .HasColumnType("date")
                                .HasColumnName("EntryIntoService");

                            b1.Property<int>("ManufacturingYear")
                                .HasColumnType("integer")
                                .HasColumnName("ManufacturingYear");

                            b1.Property<Guid>("ModelId")
                                .HasColumnType("uuid")
                                .HasColumnName("ModelId");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Name");

                            b1.Property<string>("ProductionNumber")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("ProductionNumber");

                            b1.HasKey("ForkliftUniqueId");

                            b1.HasIndex("ModelId");

                            b1.ToTable("Forklifts");

                            b1.WithOwner()
                                .HasForeignKey("ForkliftUniqueId");

                            b1.HasOne("OpDoc_Manager.Models.Forklift+ModelInformation", "Model")
                                .WithMany()
                                .HasForeignKey("ModelId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("Model");
                        });

                    b.Navigation("General")
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+AdapterInformation", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift", null)
                        .WithOne("Adapter")
                        .HasForeignKey("OpDoc_Manager.Models.Forklift+AdapterInformation", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+AdapterRecord", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift+AdapterInformation", null)
                        .WithMany("AdapterList")
                        .HasForeignKey("ForkliftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+CustomInspectionPeriod", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift+PeriodicInspectionInformation", null)
                        .WithMany("CustomInspectionPeriodRecord")
                        .HasForeignKey("ForkliftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+LeaseInformation", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift+OperatorInformation", null)
                        .WithOne("LeaseInformation")
                        .HasForeignKey("OpDoc_Manager.Models.Forklift+LeaseInformation", "Id");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+MaintenanceReport", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift+PeriodicInspectionInformation", null)
                        .WithMany("MaintenanceReports")
                        .HasForeignKey("ForkliftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+ModelInformation", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift+Engine", "Engine")
                        .WithOne()
                        .HasForeignKey("OpDoc_Manager.Models.Forklift+ModelInformation", "EngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("OpDoc_Manager.Models.Forklift+LiftMechanism", "LiftMechanism", b1 =>
                        {
                            b1.Property<Guid>("ModelInformationId")
                                .HasColumnType("uuid");

                            b1.Property<int>("FreeLift")
                                .HasColumnType("integer")
                                .HasColumnName("FreeLift");

                            b1.Property<double>("LiftSpeedLoaded")
                                .HasColumnType("double precision")
                                .HasColumnName("LiftSpeedLoaded");

                            b1.Property<double>("LiftSpeedUnloaded")
                                .HasColumnType("double precision")
                                .HasColumnName("LiftSpeedUnloaded");

                            b1.Property<double>("LoadCapacity")
                                .HasColumnType("double precision")
                                .HasColumnName("LoadCapacity");

                            b1.Property<double>("MastBackwardTiltAngle")
                                .HasColumnType("double precision")
                                .HasColumnName("MastBackwardTiltAngle");

                            b1.Property<double>("MastForwardTiltAngle")
                                .HasColumnType("double precision")
                                .HasColumnName("MastForwardTiltAngle");

                            b1.Property<double>("MaxHeightMaxLoad")
                                .HasColumnType("double precision")
                                .HasColumnName("MaxHeightMaxLoad");

                            b1.Property<int>("MaxLiftHeight")
                                .HasColumnType("integer")
                                .HasColumnName("MaxLiftHeight");

                            b1.Property<int>("NominalLiftHeight")
                                .HasColumnType("integer")
                                .HasColumnName("NominalLiftHeight");

                            b1.HasKey("ModelInformationId");

                            b1.ToTable("ForkliftModels");

                            b1.WithOwner()
                                .HasForeignKey("ModelInformationId");
                        });

                    b.OwnsOne("OpDoc_Manager.Models.Forklift+RoadInformation", "RoadInformation", b1 =>
                        {
                            b1.Property<Guid>("ModelInformationId")
                                .HasColumnType("uuid");

                            b1.Property<int>("BackWheelCount")
                                .HasColumnType("integer")
                                .HasColumnName("BackWheelCount");

                            b1.Property<double>("BackWheelPressure")
                                .HasColumnType("double precision")
                                .HasColumnName("BackWheelPressure");

                            b1.Property<string>("BackWheelSize")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("BackWheelSize");

                            b1.Property<int?>("BatteryWeight")
                                .HasColumnType("integer")
                                .HasColumnName("BatteryWeight");

                            b1.Property<int>("BreakingForce")
                                .HasColumnType("integer")
                                .HasColumnName("BreakingForce");

                            b1.Property<int>("DrawbarPull")
                                .HasColumnType("integer")
                                .HasColumnName("DrawbarPull");

                            b1.Property<int>("FrontWheelCount")
                                .HasColumnType("integer")
                                .HasColumnName("FrontWheelCount");

                            b1.Property<double>("FrontWheelPressure")
                                .HasColumnType("double precision")
                                .HasColumnName("FrontWheelPressure");

                            b1.Property<string>("FrontWheelSize")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("FrontWheelSize");

                            b1.Property<int>("GroundClearance")
                                .HasColumnType("integer")
                                .HasColumnName("GroundClearance");

                            b1.Property<int>("HeightMastLowered")
                                .HasColumnType("integer")
                                .HasColumnName("HeightMastLowered");

                            b1.Property<int>("HeightMastRaised")
                                .HasColumnType("integer")
                                .HasColumnName("HeightMastRaised");

                            b1.Property<int>("HeightTransportPosition")
                                .HasColumnType("integer")
                                .HasColumnName("HeightTransportPosition");

                            b1.Property<int>("InnerTurningCircle")
                                .HasColumnType("integer")
                                .HasColumnName("InnerTurningCircle");

                            b1.Property<int>("Length")
                                .HasColumnType("integer")
                                .HasColumnName("Length");

                            b1.Property<int>("OperationalWeight")
                                .HasColumnType("integer")
                                .HasColumnName("OperationalWeight");

                            b1.Property<int>("OuterTurningCircle")
                                .HasColumnType("integer")
                                .HasColumnName("OuterTurningCircle");

                            b1.Property<int>("ParkingBreakForce")
                                .HasColumnType("integer")
                                .HasColumnName("ParkingBreakForce");

                            b1.Property<double>("TopSpeedWithLoad")
                                .HasColumnType("double precision")
                                .HasColumnName("TopSpeedWithLoad");

                            b1.Property<double>("TopSpeedWithoutLoad")
                                .HasColumnType("double precision")
                                .HasColumnName("TopSpeedWithoutLoad");

                            b1.Property<int>("TrackWidthBack")
                                .HasColumnType("integer")
                                .HasColumnName("TrackWidthBack");

                            b1.Property<int>("TrackWidthFront")
                                .HasColumnType("integer")
                                .HasColumnName("TrackWidthFront");

                            b1.Property<int>("Wheelbase")
                                .HasColumnType("integer")
                                .HasColumnName("Wheelbase");

                            b1.Property<int>("Width")
                                .HasColumnType("integer")
                                .HasColumnName("Width");

                            b1.HasKey("ModelInformationId");

                            b1.ToTable("ForkliftModels");

                            b1.WithOwner()
                                .HasForeignKey("ModelInformationId");
                        });

                    b.Navigation("Engine");

                    b.Navigation("LiftMechanism")
                        .IsRequired();

                    b.Navigation("RoadInformation")
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+OperatorInformation", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift", null)
                        .WithOne("Operator")
                        .HasForeignKey("OpDoc_Manager.Models.Forklift+OperatorInformation", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+PeriodicInspectionInformation", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift", null)
                        .WithOne("PeriodicInspection")
                        .HasForeignKey("OpDoc_Manager.Models.Forklift+PeriodicInspectionInformation", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+PeriodicInspectionResult", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift+PeriodicInspectionInformation", null)
                        .WithMany("InspectionResults")
                        .HasForeignKey("ForkliftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+UserManualInformation", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift", null)
                        .WithOne("UserManual")
                        .HasForeignKey("OpDoc_Manager.Models.Forklift+UserManualInformation", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+ElectricEngine", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift+Engine", null)
                        .WithOne()
                        .HasForeignKey("OpDoc_Manager.Models.Forklift+ElectricEngine", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+InternalCombustionEngine", b =>
                {
                    b.HasOne("OpDoc_Manager.Models.Forklift+Engine", null)
                        .WithOne()
                        .HasForeignKey("OpDoc_Manager.Models.Forklift+InternalCombustionEngine", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift", b =>
                {
                    b.Navigation("Adapter")
                        .IsRequired();

                    b.Navigation("Operator")
                        .IsRequired();

                    b.Navigation("PeriodicInspection")
                        .IsRequired();

                    b.Navigation("UserManual")
                        .IsRequired();
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+AdapterInformation", b =>
                {
                    b.Navigation("AdapterList");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+OperatorInformation", b =>
                {
                    b.Navigation("LeaseInformation");
                });

            modelBuilder.Entity("OpDoc_Manager.Models.Forklift+PeriodicInspectionInformation", b =>
                {
                    b.Navigation("CustomInspectionPeriodRecord");

                    b.Navigation("InspectionResults");

                    b.Navigation("MaintenanceReports");
                });
#pragma warning restore 612, 618
        }
    }
}
