﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Context;

namespace project.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20211222093000_IntiCreate10")]
    partial class IntiCreate10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.Models.DoiTuong", b =>
                {
                    b.Property<string>("MaDoiTuong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenDoiTuong")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaDoiTuong");

                    b.ToTable("DoiTuongs");
                });

            modelBuilder.Entity("Project.Models.Khoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenKhoa")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Khoas");
                });

            modelBuilder.Entity("Project.Models.KhuVuc", b =>
                {
                    b.Property<string>("MaKhuVuc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenKhuVuc")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaKhuVuc");

                    b.ToTable("KhuVucs");
                });

            modelBuilder.Entity("Project.Models.Nganh", b =>
                {
                    b.Property<string>("MaNganh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("KhoaId")
                        .HasColumnType("int");

                    b.Property<string>("TenNganh")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaNganh");

                    b.HasIndex("KhoaId");

                    b.ToTable("Nganhs");
                });

            modelBuilder.Entity("Project.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MoTa")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenRole")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Project.Models.StudentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChiHoKhau")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DiaChiLienHe")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("DiemHoa10")
                        .HasColumnType("float");

                    b.Property<double>("DiemHoa11")
                        .HasColumnType("float");

                    b.Property<double>("DiemHoa12")
                        .HasColumnType("float");

                    b.Property<double>("DiemLy10")
                        .HasColumnType("float");

                    b.Property<double>("DiemLy11")
                        .HasColumnType("float");

                    b.Property<double>("DiemLy12")
                        .HasColumnType("float");

                    b.Property<double>("DiemTb10")
                        .HasColumnType("float");

                    b.Property<double>("DiemTb11")
                        .HasColumnType("float");

                    b.Property<double>("DiemTb12")
                        .HasColumnType("float");

                    b.Property<double>("DiemTb_UuTien")
                        .HasColumnType("float");

                    b.Property<double>("DiemToan10")
                        .HasColumnType("float");

                    b.Property<double>("DiemToan11")
                        .HasColumnType("float");

                    b.Property<double>("DiemToan12")
                        .HasColumnType("float");

                    b.Property<string>("DoiTuongId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("GioiTinh")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("HoTen")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HoTenBo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HoTenMe")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Hocba10_url")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Hocba11_url")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Hocba12_url")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("KhuVucId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgaySinh")
                        .HasMaxLength(30)
                        .HasColumnType("datetime2");

                    b.Property<string>("SdtBo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SdtMe")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SoCCCD")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SoDienThoai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tinh10Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tinh11Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tinh12Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TruongLop10Id")
                        .HasColumnType("int");

                    b.Property<int>("TruongLop11Id")
                        .HasColumnType("int");

                    b.Property<int>("TruongLop12Id")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoiTuongId")
                        .IsUnique()
                        .HasFilter("[DoiTuongId] IS NOT NULL");

                    b.HasIndex("KhuVucId")
                        .IsUnique()
                        .HasFilter("[KhuVucId] IS NOT NULL");

                    b.HasIndex("Tinh10Id")
                        .IsUnique()
                        .HasFilter("[Tinh10Id] IS NOT NULL");

                    b.HasIndex("Tinh11Id")
                        .IsUnique()
                        .HasFilter("[Tinh11Id] IS NOT NULL");

                    b.HasIndex("Tinh12Id")
                        .IsUnique()
                        .HasFilter("[Tinh12Id] IS NOT NULL");

                    b.HasIndex("TruongLop10Id")
                        .IsUnique();

                    b.HasIndex("TruongLop11Id")
                        .IsUnique();

                    b.HasIndex("TruongLop12Id")
                        .IsUnique();

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("StudentInfos");
                });

            modelBuilder.Entity("Project.Models.StudentNguyenVong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaNganh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaToHop")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Stt_NguyenVong")
                        .HasColumnType("int");

                    b.Property<int>("StudentInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaNganh");

                    b.HasIndex("MaToHop");

                    b.HasIndex("StudentInfoId");

                    b.ToTable("StudentNguyenVongs");
                });

            modelBuilder.Entity("Project.Models.Tinh", b =>
                {
                    b.Property<string>("MaTinh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenTinh")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaTinh");

                    b.ToTable("Tinhs");
                });

            modelBuilder.Entity("Project.Models.ToHop", b =>
                {
                    b.Property<string>("MaToHop")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenToHop")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaToHop");

                    b.ToTable("ToHops");
                });

            modelBuilder.Entity("Project.Models.Truong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiaChi")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("MaTruong")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TenTruong")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Truongs");
                });

            modelBuilder.Entity("Project.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Create_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Update_At")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Project.Models.Nganh", b =>
                {
                    b.HasOne("Project.Models.Khoa", "Khoa")
                        .WithMany("Nganhs")
                        .HasForeignKey("KhoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Khoa");
                });

            modelBuilder.Entity("Project.Models.StudentInfo", b =>
                {
                    b.HasOne("Project.Models.DoiTuong", "DoiTuong")
                        .WithOne("StudentInfo")
                        .HasForeignKey("Project.Models.StudentInfo", "DoiTuongId");

                    b.HasOne("Project.Models.KhuVuc", "KhuVuc")
                        .WithOne("StudentInfo")
                        .HasForeignKey("Project.Models.StudentInfo", "KhuVucId");

                    b.HasOne("Project.Models.Tinh", "Tinh10")
                        .WithOne("Tinh10Info")
                        .HasForeignKey("Project.Models.StudentInfo", "Tinh10Id");

                    b.HasOne("Project.Models.Tinh", "Tinh11")
                        .WithOne("Tinh11Info")
                        .HasForeignKey("Project.Models.StudentInfo", "Tinh11Id");

                    b.HasOne("Project.Models.Tinh", "Tinh12")
                        .WithOne("Tinh12Info")
                        .HasForeignKey("Project.Models.StudentInfo", "Tinh12Id");

                    b.HasOne("Project.Models.Truong", "Truong10")
                        .WithOne("Truong10Info")
                        .HasForeignKey("Project.Models.StudentInfo", "TruongLop10Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Project.Models.Truong", "Truong11")
                        .WithOne("Truong11Info")
                        .HasForeignKey("Project.Models.StudentInfo", "TruongLop11Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Project.Models.Truong", "Truong12")
                        .WithOne("Truong12Info")
                        .HasForeignKey("Project.Models.StudentInfo", "TruongLop12Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Project.Models.User", "User")
                        .WithOne("StudentInfo")
                        .HasForeignKey("Project.Models.StudentInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DoiTuong");

                    b.Navigation("KhuVuc");

                    b.Navigation("Tinh10");

                    b.Navigation("Tinh11");

                    b.Navigation("Tinh12");

                    b.Navigation("Truong10");

                    b.Navigation("Truong11");

                    b.Navigation("Truong12");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project.Models.StudentNguyenVong", b =>
                {
                    b.HasOne("Project.Models.Nganh", "Nganh")
                        .WithMany()
                        .HasForeignKey("MaNganh");

                    b.HasOne("Project.Models.ToHop", "ToHop")
                        .WithMany()
                        .HasForeignKey("MaToHop");

                    b.HasOne("Project.Models.StudentInfo", "StudentInfo")
                        .WithMany("StudentNguyenVongs")
                        .HasForeignKey("StudentInfoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Nganh");

                    b.Navigation("StudentInfo");

                    b.Navigation("ToHop");
                });

            modelBuilder.Entity("Project.Models.User", b =>
                {
                    b.HasOne("Project.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Project.Models.DoiTuong", b =>
                {
                    b.Navigation("StudentInfo");
                });

            modelBuilder.Entity("Project.Models.Khoa", b =>
                {
                    b.Navigation("Nganhs");
                });

            modelBuilder.Entity("Project.Models.KhuVuc", b =>
                {
                    b.Navigation("StudentInfo");
                });

            modelBuilder.Entity("Project.Models.StudentInfo", b =>
                {
                    b.Navigation("StudentNguyenVongs");
                });

            modelBuilder.Entity("Project.Models.Tinh", b =>
                {
                    b.Navigation("Tinh10Info");

                    b.Navigation("Tinh11Info");

                    b.Navigation("Tinh12Info");
                });

            modelBuilder.Entity("Project.Models.Truong", b =>
                {
                    b.Navigation("Truong10Info");

                    b.Navigation("Truong11Info");

                    b.Navigation("Truong12Info");
                });

            modelBuilder.Entity("Project.Models.User", b =>
                {
                    b.Navigation("StudentInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
