using System;
using System.Data;

namespace QuanLyQuanCafe_DTO
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string TenDangNhap { get; set; }

        public EmployeeDTO(int id, string hoTen, string soDienThoai, string tenDangNhap)
        {
            this.ID = id;
            this.HoTen = hoTen;
            this.SoDienThoai = soDienThoai;
            this.TenDangNhap = tenDangNhap;
        }

        public EmployeeDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.HoTen = row["HoTen"].ToString();
            this.SoDienThoai = row["SoDienThoai"].ToString();
            this.TenDangNhap = row["TenDangNhap"].ToString();
        }
    }
}