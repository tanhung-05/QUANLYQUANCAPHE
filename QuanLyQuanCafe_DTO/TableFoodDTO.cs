using System;
using System.Data;

namespace QuanLyQuanCafe_DTO
{
    public class TableFoodDTO
    {
        public int ID { get; set; }
        public string TenBan { get; set; }
        public string TrangThai { get; set; }

        public TableFoodDTO(int id, string tenBan, string trangThai)
        {
            this.ID = id;
            this.TenBan = tenBan;
            this.TrangThai = trangThai;
        }

        public TableFoodDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.TenBan = row["TenBan"].ToString();
            this.TrangThai = row["TrangThai"].ToString();
        }
    }
}