using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyBanHang_Admin.Migrations
{
    public partial class Chitietphieudathang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "khachhang",
                columns: table => new
                {
                    makh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tenkh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    namsinh = table.Column<int>(type: "int", nullable: true),
                    phai = table.Column<bool>(type: "bit", nullable: true),
                    dienthoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khachhang", x => x.makh);
                });

            migrationBuilder.CreateTable(
                name: "loaihanghoa",
                columns: table => new
                {
                    maloai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tenloai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loaihanghoa", x => x.maloai);
                });

            migrationBuilder.CreateTable(
                name: "nhanvien",
                columns: table => new
                {
                    manv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tennv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "datetime", nullable: true),
                    phai = table.Column<bool>(type: "bit", nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    vaitro = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhanvien", x => x.manv);
                });

            migrationBuilder.CreateTable(
                name: "nhasanxuat",
                columns: table => new
                {
                    mansx = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tennsx = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhasanxuat", x => x.mansx);
                });

            migrationBuilder.CreateTable(
                name: "phieudathang",
                columns: table => new
                {
                    mapdh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngaydh = table.Column<DateTime>(type: "datetime", nullable: true),
                    ngaygh = table.Column<DateTime>(type: "datetime", nullable: true),
                    diachigh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    makh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieudathang", x => x.mapdh);
                    table.ForeignKey(
                        name: "FK_phieudathang_khachhang",
                        column: x => x.makh,
                        principalTable: "khachhang",
                        principalColumn: "makh");
                });

            migrationBuilder.CreateTable(
                name: "hanghoa",
                columns: table => new
                {
                    mahang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    tenhang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    donvitinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dongia = table.Column<double>(type: "float", nullable: true),
                    hinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    maloai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    mansx = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hanghoa", x => x.mahang);
                    table.ForeignKey(
                        name: "FK_hanghoa_loaihanghoa",
                        column: x => x.maloai,
                        principalTable: "loaihanghoa",
                        principalColumn: "maloai");
                    table.ForeignKey(
                        name: "FK_hanghoa_nhasanxuat",
                        column: x => x.mansx,
                        principalTable: "nhasanxuat",
                        principalColumn: "mansx");
                });

            migrationBuilder.CreateTable(
                name: "phieugiaohang",
                columns: table => new
                {
                    mapgh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ngaygh = table.Column<DateTime>(type: "datetime", nullable: true),
                    diachigh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    tennguoinhan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    mapdh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    manv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phieugiaohang", x => x.mapgh);
                    table.ForeignKey(
                        name: "FK_phieugiaohang_nhanvien",
                        column: x => x.manv,
                        principalTable: "nhanvien",
                        principalColumn: "manv");
                    table.ForeignKey(
                        name: "FK_phieugiaohang_phieudathang",
                        column: x => x.mapdh,
                        principalTable: "phieudathang",
                        principalColumn: "mapdh");
                });

            migrationBuilder.CreateTable(
                name: "chitietphieudathang",
                columns: table => new
                {
                    mapdh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mahang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dongia = table.Column<double>(type: "float", nullable: true),
                    soluong = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chitietphieudathang", x => new { x.mapdh, x.mahang });
                    table.ForeignKey(
                        name: "FK_chitietphieudathang_hanghoa",
                        column: x => x.mahang,
                        principalTable: "hanghoa",
                        principalColumn: "mahang");
                    table.ForeignKey(
                        name: "FK_chitietphieudathang_phieudathang",
                        column: x => x.mapdh,
                        principalTable: "phieudathang",
                        principalColumn: "mapdh");
                });

            migrationBuilder.CreateTable(
                name: "chitietphieugiaohang",
                columns: table => new
                {
                    mapgh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mahang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    donvitinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    soluong = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chitietphieugiaohang", x => new { x.mapgh, x.mahang });
                    table.ForeignKey(
                        name: "FK_chitietphieugiaohang_hanghoa",
                        column: x => x.mahang,
                        principalTable: "hanghoa",
                        principalColumn: "mahang");
                    table.ForeignKey(
                        name: "FK_chitietphieugiaohang_phieugiaohang",
                        column: x => x.mapgh,
                        principalTable: "phieugiaohang",
                        principalColumn: "mapgh");
                });

            migrationBuilder.CreateIndex(
                name: "IX_chitietphieudathang_mahang",
                table: "chitietphieudathang",
                column: "mahang");

            migrationBuilder.CreateIndex(
                name: "IX_chitietphieugiaohang_mahang",
                table: "chitietphieugiaohang",
                column: "mahang");

            migrationBuilder.CreateIndex(
                name: "IX_hanghoa_maloai",
                table: "hanghoa",
                column: "maloai");

            migrationBuilder.CreateIndex(
                name: "IX_hanghoa_mansx",
                table: "hanghoa",
                column: "mansx");

            migrationBuilder.CreateIndex(
                name: "IX_phieudathang_makh",
                table: "phieudathang",
                column: "makh");

            migrationBuilder.CreateIndex(
                name: "IX_phieugiaohang_manv",
                table: "phieugiaohang",
                column: "manv");

            migrationBuilder.CreateIndex(
                name: "IX_phieugiaohang_mapdh",
                table: "phieugiaohang",
                column: "mapdh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chitietphieudathang");

            migrationBuilder.DropTable(
                name: "chitietphieugiaohang");

            migrationBuilder.DropTable(
                name: "hanghoa");

            migrationBuilder.DropTable(
                name: "phieugiaohang");

            migrationBuilder.DropTable(
                name: "loaihanghoa");

            migrationBuilder.DropTable(
                name: "nhasanxuat");

            migrationBuilder.DropTable(
                name: "nhanvien");

            migrationBuilder.DropTable(
                name: "phieudathang");

            migrationBuilder.DropTable(
                name: "khachhang");
        }
    }
}
