using System;
using System.Data;

namespace QuanLyQuanCafe_DTO
{
    public class MenuDTO
    {
        public string TenMon { get; set; }
        public int SoLuong { get; set; }
        public float Gia { get; set; }
        public float ThanhTien { get; set; }

        public MenuDTO(string tenMon, int soLuong, float gia, float thanhTien = 0)
        {
            this.TenMon = tenMon;
            this.SoLuong = soLuong;
            this.Gia = gia;
            this.ThanhTien = thanhTien;
        }

        public MenuDTO(DataRow row)
        {
            this.TenMon = row["TenMon"].ToString();
            this.SoLuong = (int)row["SoLuong"];
            this.Gia = (float)Convert.ToDouble(row["Gia"].ToString());
            this.ThanhTien = (float)Convert.ToDouble(row["ThanhTien"].ToString());
        }
    }
}