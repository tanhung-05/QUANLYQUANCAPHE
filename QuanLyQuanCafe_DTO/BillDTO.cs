using System;
using System.Data;

namespace QuanLyQuanCafe_DTO
{
    public class BillDTO
    {
        public int ID { get; set; }
        public DateTime? NgayVao { get; set; }
        public DateTime? NgayRa { get; set; }
        public int IDBan { get; set; }
        public int TrangThai { get; set; }

        public BillDTO(int id, DateTime? ngayVao, DateTime? ngayRa, int idBan, int trangThai)
        {
            this.ID = id;
            this.NgayVao = ngayVao;
            this.NgayRa = ngayRa;
            this.IDBan = idBan;
            this.TrangThai = trangThai;
        }

        public BillDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.NgayVao = (DateTime?)row["NgayVao"];

            var dateCheckOutTemp = row["NgayRa"];
            if (dateCheckOutTemp.ToString() != "")
                this.NgayRa = (DateTime?)dateCheckOutTemp;

            this.IDBan = (int)row["IDBan"];
            this.TrangThai = (int)row["TrangThai"];
        }
    }
}