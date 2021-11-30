﻿// <auto-generated />
using System;
using EasyHealth_Demo.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyHealth_Demo.Migrations
{
    [DbContext(typeof(ClientContext))]
    [Migration("20211130094715_SixthUpdate")]
    partial class SixthUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EasyHealth_Demo.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"), 1L, 1);

                    b.Property<string>("AdminEmail")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"), 1L, 1);

                    b.Property<string>("AppBookingChannelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("AppointmentDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("AppointmentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentId");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("DoctorId")
                        .IsUnique();

                    b.HasIndex("HospitalId")
                        .IsUnique();

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientId = 100,
                            Email = "andthen23@gmail.com",
                            FirstName = "Akmal",
                            LastName = "Faisal",
                            PasswordHash = "$2a$12$ocDGfpobOAfJiFiG/Efs5e3kM1ZmqsJ2xsuTFD16UEUMkYACINlpq",
                            PhoneNumber = "0134122235"
                        });
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.ClientReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorRating")
                        .HasColumnType("int");

                    b.Property<bool>("IsDoctorRecommended")
                        .HasColumnType("bit");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ReviewDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("WaitTimeRating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("DoctorId")
                        .IsUnique();

                    b.ToTable("ClientReviews");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("HospitalId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PracticingFrom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("DoctorId");

                    b.HasIndex("HospitalId")
                        .IsUnique();

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.Hospital", b =>
                {
                    b.Property<int>("HospitalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HospitalId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("FirstconsultationFee")
                        .HasColumnType("int");

                    b.Property<int>("FollowupconsultationFee")
                        .HasColumnType("int");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Pincode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("HospitalId");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.LoginModel", b =>
                {
                    b.Property<string>("EmailEntered")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PasswordEntered")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.ToTable("CurrentUser");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.RegisterAdminModel", b =>
                {
                    b.Property<string>("AdminEmailEntered")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ConfirmAdminPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("registerAdminRequest");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.RegisterModel", b =>
                {
                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.ToTable("registerRequest");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.Appointment", b =>
                {
                    b.HasOne("EasyHealth_Demo.Models.Client", "Client")
                        .WithOne("Appointment")
                        .HasForeignKey("EasyHealth_Demo.Models.Appointment", "ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EasyHealth_Demo.Models.Doctor", "Doctor")
                        .WithOne("Appointment")
                        .HasForeignKey("EasyHealth_Demo.Models.Appointment", "DoctorId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("EasyHealth_Demo.Models.Hospital", "Hospital")
                        .WithOne("Appointment")
                        .HasForeignKey("EasyHealth_Demo.Models.Appointment", "HospitalId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Doctor");

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.ClientReview", b =>
                {
                    b.HasOne("EasyHealth_Demo.Models.Client", "Client")
                        .WithOne("ClientReview")
                        .HasForeignKey("EasyHealth_Demo.Models.ClientReview", "ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EasyHealth_Demo.Models.Doctor", "Doctor")
                        .WithOne("ClientReview")
                        .HasForeignKey("EasyHealth_Demo.Models.ClientReview", "DoctorId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.Doctor", b =>
                {
                    b.HasOne("EasyHealth_Demo.Models.Hospital", "Hospital")
                        .WithOne("Doctor")
                        .HasForeignKey("EasyHealth_Demo.Models.Doctor", "HospitalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.Client", b =>
                {
                    b.Navigation("Appointment");

                    b.Navigation("ClientReview");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.Doctor", b =>
                {
                    b.Navigation("Appointment");

                    b.Navigation("ClientReview");
                });

            modelBuilder.Entity("EasyHealth_Demo.Models.Hospital", b =>
                {
                    b.Navigation("Appointment");

                    b.Navigation("Doctor");
                });
#pragma warning restore 612, 618
        }
    }
}
