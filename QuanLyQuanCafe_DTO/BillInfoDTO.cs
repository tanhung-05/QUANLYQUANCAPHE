using System;
using System.Data;

namespace QuanLyQuanCafe_DTO
{
    public class BillInfoDTO
    {
        public int ID { get; set; }
        public int IDHoaDon { get; set; }
        public int IDMon { get; set; }
        public int SoLuong { get; set; }

        public BillInfoDTO(int id, int idHoaDon, int idMon, int soLuong)
        {
            this.ID = id;
            this.IDHoaDon = idHoaDon;
            this.IDMon = idMon;
            this.SoLuong = soLuong;
        }

        public BillInfoDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.IDHoaDon = (int)row["IDHoaDon"];
            this.IDMon = (int)row["IDMon"];
            this.SoLuong = (int)row["SoLuong"];
        }
    }
}