namespace QuanLyBanHang_Admin.Models
{
    public class CNhanVien
    {
        public string Manv { get; set; } = null!;
        public string? Tennv { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public bool? Phai { get; set; }
        public string? Diachi { get; set; }
        public string? Password { get; set; }
        public static Nhanvien chuyendoi(CNhanVien x) {
            Nhanvien nhanvien = new Nhanvien();
            nhanvien.Manv = x.Manv;
            nhanvien.Tennv = x.Tennv;
            nhanvien.Ngaysinh = x.Ngaysinh;
            nhanvien.Phai= x.Phai;
            nhanvien.Diachi= x.Diachi;
            nhanvien.Password= x.Password;
            return nhanvien;
        }
        public static CNhanVien chuyendoi(Nhanvien x)
        {
            CNhanVien cnhanvien = new CNhanVien();
            cnhanvien.Manv = x.Manv;
            cnhanvien.Tennv= x.Tennv;
            cnhanvien.Ngaysinh= x.Ngaysinh;
            cnhanvien.Phai = x.Phai;
            cnhanvien.Diachi = x.Diachi;
            cnhanvien.Password=x.Password;
            return cnhanvien;
        }
    }
}
