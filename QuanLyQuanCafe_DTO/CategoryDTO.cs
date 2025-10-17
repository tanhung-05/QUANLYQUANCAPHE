using System;
using System.Data;

namespace QuanLyQuanCafe_DTO
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string TenDanhMuc { get; set; }

        public CategoryDTO(int id, string tenDanhMuc)
        {
            this.ID = id;
            this.TenDanhMuc = tenDanhMuc;
        }

        public CategoryDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.TenDanhMuc = row["TenDanhMuc"].ToString();
        }
    }
}