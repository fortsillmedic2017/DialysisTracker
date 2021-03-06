﻿// <auto-generated />
using System;
using DialysisPatientTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DialysisPatientTracker.Migrations
{
    [DbContext(typeof(DialysisAppDbContext))]
    partial class DialysisAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DialysisPatientTracker.Models.CompleteList", b =>
                {
                    b.Property<int>("CompleteListID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccessType");

                    b.Property<string>("Address");

                    b.Property<string>("Age");

                    b.Property<string>("BiCarb");

                    b.Property<string>("CaBath");

                    b.Property<string>("Comments");

                    b.Property<DateTime>("DOB");

                    b.Property<string>("DialyzerSize");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("KBath");

                    b.Property<string>("LastName");

                    b.Property<string>("MedicalRecord");

                    b.Property<string>("NaBath");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Physician");

                    b.Property<int?>("PhysicianID");

                    b.Property<string>("Temp");

                    b.Property<string>("TreatmentDays");

                    b.Property<string>("TreatmentTime");

                    b.HasKey("CompleteListID");

                    b.HasIndex("PhysicianID");

                    b.ToTable("CompleteLists");

                    b.HasDiscriminator<string>("Discriminator").HasValue("CompleteList");
                });

            modelBuilder.Entity("DialysisPatientTracker.Models.Physician", b =>
                {
                    b.Property<int>("PhysicianID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellPhone")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("OfficePhone")
                        .IsRequired();

                    b.HasKey("PhysicianID");

                    b.ToTable("Physicians");
                });

            modelBuilder.Entity("DialysisPatientTracker.Models.SearchOptions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MedicalRecord")
                        .IsRequired();

                    b.Property<string>("Physician")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("SearchOptions");
                });

            modelBuilder.Entity("DialysisPatientTracker.Models.UserAccount", b =>
                {
                    b.Property<int>("UserAccountID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("UserAccountID");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("DialysisPatientTracker.Models.PatientDemographics", b =>
                {
                    b.HasBaseType("DialysisPatientTracker.Models.CompleteList");


                    b.ToTable("PatientDemographics");

                    b.HasDiscriminator().HasValue("PatientDemographics");
                });

            modelBuilder.Entity("DialysisPatientTracker.Models.PatientMasterList", b =>
                {
                    b.HasBaseType("DialysisPatientTracker.Models.CompleteList");


                    b.ToTable("PatientMasterList");

                    b.HasDiscriminator().HasValue("PatientMasterList");
                });

            modelBuilder.Entity("DialysisPatientTracker.Models.TreatmentMasterList", b =>
                {
                    b.HasBaseType("DialysisPatientTracker.Models.CompleteList");


                    b.ToTable("TreatmentMasterList");

                    b.HasDiscriminator().HasValue("TreatmentMasterList");
                });

            modelBuilder.Entity("DialysisPatientTracker.Models.CompleteList", b =>
                {
                    b.HasOne("DialysisPatientTracker.Models.Physician")
                        .WithMany("CompleteLists")
                        .HasForeignKey("PhysicianID");
                });
#pragma warning restore 612, 618
        }
    }
}
