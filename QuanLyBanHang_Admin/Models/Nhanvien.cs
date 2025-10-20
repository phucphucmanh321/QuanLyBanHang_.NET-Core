﻿using System;
using System.Collections.Generic;

namespace QuanLyBanHang_Admin.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Phieugiaohangs = new HashSet<Phieugiaohang>();
        }

        public string Manv { get; set; } = null!;
        public string? Tennv { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public bool? Phai { get; set; }
        public string? Diachi { get; set; }
        public string? Password { get; set; }
        public byte? Vaitro { get; set; }

        public virtual ICollection<Phieugiaohang> Phieugiaohangs { get; set; }
    }
}
