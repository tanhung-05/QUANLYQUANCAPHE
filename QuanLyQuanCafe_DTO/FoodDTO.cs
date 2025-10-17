using System;
using System.Data;

namespace QuanLyQuanCafe_DTO
{
    public class FoodDTO
    {
        public int ID { get; set; }
        public string TenMon { get; set; }
        public int IDDanhMuc { get; set; }
        public float Gia { get; set; }

        public FoodDTO(int id, string tenMon, int idDanhMuc, float gia)
        {
            this.ID = id;
            this.TenMon = tenMon;
            this.IDDanhMuc = idDanhMuc;
            this.Gia = gia;
        }

        public FoodDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.TenMon = row["TenMon"].ToString();
            this.IDDanhMuc = (int)row["IDDanhMuc"];
            this.Gia = (float)Convert.ToDouble(row["Gia"].ToString());
        }
    }
}