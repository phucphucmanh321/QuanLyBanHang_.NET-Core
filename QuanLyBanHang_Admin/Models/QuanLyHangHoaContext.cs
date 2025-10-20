﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuanLyBanHang_Admin.Models
{
    public partial class QuanLyHangHoaContext : DbContext
    {
        public QuanLyHangHoaContext()
        {
        }

        public QuanLyHangHoaContext(DbContextOptions<QuanLyHangHoaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietphieudathang> Chitietphieudathangs { get; set; } = null!;
        public virtual DbSet<Chitietphieugiaohang> Chitietphieugiaohangs { get; set; } = null!;
        public virtual DbSet<Hanghoa> Hanghoas { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Loaihanghoa> Loaihanghoas { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<Nhasanxuat> Nhasanxuats { get; set; } = null!;
        public virtual DbSet<Phieudathang> Phieudathangs { get; set; } = null!;
        public virtual DbSet<Phieugiaohang> Phieugiaohangs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-93LT62R;Initial Catalog=QuanLyBanHang;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietphieudathang>(entity =>
            {
                entity.HasKey(e => new { e.Mapdh, e.Mahang });

                entity.ToTable("chitietphieudathang");

                entity.Property(e => e.Mapdh)
                    .HasMaxLength(50)
                    .HasColumnName("mapdh");

                entity.Property(e => e.Mahang)
                    .HasMaxLength(50)
                    .HasColumnName("mahang");

                entity.Property(e => e.Dongia).HasColumnName("dongia");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.HasOne(d => d.MahangNavigation)
                    .WithMany(p => p.Chitietphieudathangs)
                    .HasForeignKey(d => d.Mahang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chitietphieudathang_hanghoa");

                entity.HasOne(d => d.MapdhNavigation)
                    .WithMany(p => p.Chitietphieudathangs)
                    .HasForeignKey(d => d.Mapdh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chitietphieudathang_phieudathang");
            });

            modelBuilder.Entity<Chitietphieugiaohang>(entity =>
            {
                entity.HasKey(e => new { e.Mapgh, e.Mahang });

                entity.ToTable("chitietphieugiaohang");

                entity.Property(e => e.Mapgh)
                    .HasMaxLength(50)
                    .HasColumnName("mapgh");

                entity.Property(e => e.Mahang)
                    .HasMaxLength(50)
                    .HasColumnName("mahang");

                entity.Property(e => e.Donvitinh)
                    .HasMaxLength(50)
                    .HasColumnName("donvitinh");

                entity.Property(e => e.Soluong).HasColumnName("soluong");

                entity.HasOne(d => d.MahangNavigation)
                    .WithMany(p => p.Chitietphieugiaohangs)
                    .HasForeignKey(d => d.Mahang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chitietphieugiaohang_hanghoa");

                entity.HasOne(d => d.MapghNavigation)
                    .WithMany(p => p.Chitietphieugiaohangs)
                    .HasForeignKey(d => d.Mapgh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_chitietphieugiaohang_phieugiaohang");
            });

            modelBuilder.Entity<Hanghoa>(entity =>
            {
                entity.HasKey(e => e.Mahang);

                entity.ToTable("hanghoa");

                entity.Property(e => e.Mahang)
                    .HasMaxLength(50)
                    .HasColumnName("mahang");

                entity.Property(e => e.Dongia).HasColumnName("dongia");

                entity.Property(e => e.Donvitinh)
                    .HasMaxLength(50)
                    .HasColumnName("donvitinh");

                entity.Property(e => e.Hinh)
                    .HasMaxLength(50)
                    .HasColumnName("hinh");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(50)
                    .HasColumnName("maloai");

                entity.Property(e => e.Mansx)
                    .HasMaxLength(50)
                    .HasColumnName("mansx");

                entity.Property(e => e.Tenhang)
                    .HasMaxLength(50)
                    .HasColumnName("tenhang");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Hanghoas)
                    .HasForeignKey(d => d.Maloai)
                    .HasConstraintName("FK_hanghoa_loaihanghoa");

                entity.HasOne(d => d.MansxNavigation)
                    .WithMany(p => p.Hanghoas)
                    .HasForeignKey(d => d.Mansx)
                    .HasConstraintName("FK_hanghoa_nhasanxuat");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh);

                entity.ToTable("khachhang");

                entity.Property(e => e.Makh)
                    .HasMaxLength(50)
                    .HasColumnName("makh");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("diachi");

                entity.Property(e => e.Dienthoai)
                    .HasMaxLength(50)
                    .HasColumnName("dienthoai");

                entity.Property(e => e.Namsinh).HasColumnName("namsinh");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Phai).HasColumnName("phai");

                entity.Property(e => e.Tenkh)
                    .HasMaxLength(50)
                    .HasColumnName("tenkh");
            });

            modelBuilder.Entity<Loaihanghoa>(entity =>
            {
                entity.HasKey(e => e.Maloai);

                entity.ToTable("loaihanghoa");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(50)
                    .HasColumnName("maloai");

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(50)
                    .HasColumnName("tenloai");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv);

                entity.ToTable("nhanvien");

                entity.Property(e => e.Manv)
                    .HasMaxLength(50)
                    .HasColumnName("manv");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("diachi");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Phai).HasColumnName("phai");

                entity.Property(e => e.Tennv)
                    .HasMaxLength(50)
                    .HasColumnName("tennv");

                entity.Property(e => e.Vaitro).HasColumnName("vaitro");
            });

            modelBuilder.Entity<Nhasanxuat>(entity =>
            {
                entity.HasKey(e => e.Mansx);

                entity.ToTable("nhasanxuat");

                entity.Property(e => e.Mansx)
                    .HasMaxLength(50)
                    .HasColumnName("mansx");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("diachi");

                entity.Property(e => e.Tennsx)
                    .HasMaxLength(50)
                    .HasColumnName("tennsx");
            });

            modelBuilder.Entity<Phieudathang>(entity =>
            {
                entity.HasKey(e => e.Mapdh);

                entity.ToTable("phieudathang");

                entity.Property(e => e.Mapdh)
                    .HasMaxLength(50)
                    .HasColumnName("mapdh");

                entity.Property(e => e.Diachigh)
                    .HasMaxLength(50)
                    .HasColumnName("diachigh");

                entity.Property(e => e.Makh)
                    .HasMaxLength(50)
                    .HasColumnName("makh");

                entity.Property(e => e.Ngaydh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaydh");

                entity.Property(e => e.Ngaygh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaygh");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Phieudathangs)
                    .HasForeignKey(d => d.Makh)
                    .HasConstraintName("FK_phieudathang_khachhang");
            });

            modelBuilder.Entity<Phieugiaohang>(entity =>
            {
                entity.HasKey(e => e.Mapgh);

                entity.ToTable("phieugiaohang");

                entity.Property(e => e.Mapgh)
                    .HasMaxLength(50)
                    .HasColumnName("mapgh");

                entity.Property(e => e.Diachigh)
                    .HasMaxLength(50)
                    .HasColumnName("diachigh");

                entity.Property(e => e.Manv)
                    .HasMaxLength(50)
                    .HasColumnName("manv");

                entity.Property(e => e.Mapdh)
                    .HasMaxLength(50)
                    .HasColumnName("mapdh");

                entity.Property(e => e.Ngaygh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaygh");

                entity.Property(e => e.Tennguoinhan)
                    .HasMaxLength(50)
                    .HasColumnName("tennguoinhan");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Phieugiaohangs)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_phieugiaohang_nhanvien");

                entity.HasOne(d => d.MapdhNavigation)
                    .WithMany(p => p.Phieugiaohangs)
                    .HasForeignKey(d => d.Mapdh)
                    .HasConstraintName("FK_phieugiaohang_phieudathang");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
