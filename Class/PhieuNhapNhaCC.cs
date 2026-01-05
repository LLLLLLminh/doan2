using DataAccess_System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Class
{
    public class PhieuNhapNhaCC : Phieu
    {
        public int LoaiPhieu { get; set; }
        public int NhaCC_ID { get; set; }
        public int DonViNhan_ID { get; set; }
        public int NguoiNhan_ID { get; set; }
        public string? DienGiai { get; set; }
        public int TrangThai { get; set; }
        public PhieuNhapNhaCC()
        {
            SP_Name = "sp_PhieuNhapNhaCC";
        }
        public override int Add()
        {
            para.Clear();
            para.Add(new SqlParameter("@LoaiPhieu", LoaiPhieu));
            para.Add(new SqlParameter("@NhaCC_ID", NhaCC_ID));
            para.Add(new SqlParameter("@DonViNhan_ID", DonViNhan_ID));
            para.Add(new SqlParameter("@NguoiNhan_ID", NguoiNhan_ID));
            para.Add(new SqlParameter("@DienGiai", DienGiai));
            para.Add(new SqlParameter("@TrangThai", TrangThai));

            return base.Add();
        }
        public override int Update(int phieu_id)
        {
            para.Clear();
            para.Add(new SqlParameter("@LoaiPhieu", LoaiPhieu));
            para.Add(new SqlParameter("@NhaCC_ID", NhaCC_ID));
            para.Add(new SqlParameter("@DonViNhan_ID", DonViNhan_ID));
            para.Add(new SqlParameter("@NguoiNhan_ID", NguoiNhan_ID));
            para.Add(new SqlParameter("@DienGiai", DienGiai));
            para.Add(new SqlParameter("@TrangThai", TrangThai));

            return base.Update(phieu_id);
        }
        public override bool GetByPhieu_ID(int phieu_id)
        {
            var p1 = new SqlParameter("@Action", "GetByPhieu_ID");
            var p3 = new SqlParameter("@Phieu_ID", phieu_id);
            DataTable dt = DatabaseHelper.ExecuteDataTable(
                SP_Name,
                CommandType.StoredProcedure,
                p1, p3
            );
            if (dt.Rows.Count == 0) return false;

            ExtractDataRow(dt.Rows[0]);

            return true;
        }

        public override void ExtractDataRow(DataRow dr)
        {
            if (dr == null) return;
            LoaiPhieu = (int)dr["LoaiPhieu"];
            NhaCC_ID = (int)dr["NhaCC_ID"];
            DonViNhan_ID = (int)dr["DonViNhan_ID"];
            NguoiNhan_ID = (int)dr["NguoiNhan_ID"];
            DienGiai = dr["DienGiai"].ToString();
            TrangThai = (int)dr["TrangThai"];

            base.ExtractDataRow(dr);
        }
    }
}
