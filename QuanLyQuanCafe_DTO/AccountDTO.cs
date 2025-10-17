using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe_DTO
{
    public class AccountDTO
    {
        public string TenDangNhap { get; set; }
        public string TenHienThi { get; set; }
        public string MatKhau { get; set; }
        public int IDLoaiTaiKhoan { get; set; }

        public AccountDTO(string tenDangNhap, string tenHienThi, int idLoai, string matKhau = null)
        {
            this.TenDangNhap = tenDangNhap;
            this.TenHienThi = tenHienThi;
            this.IDLoaiTaiKhoan = idLoai;
            this.MatKhau = matKhau;
        }

        public AccountDTO(DataRow row)
        {
            this.TenDangNhap = row["TenDangNhap"].ToString();
            this.TenHienThi = row["TenHienThi"].ToString();
            this.IDLoaiTaiKhoan = (int)row["IDLoaiTaiKhoan"];
            this.MatKhau = row["MatKhau"].ToString();
        }
    }
}
