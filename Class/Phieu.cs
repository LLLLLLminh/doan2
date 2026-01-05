using DataAccess_System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Class
{
    public abstract class Phieu
    {
        public int Phieu_ID { get; set; }
        public string? SoPhieu { get; set; }
        public string? NoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public int NguoiTao_ID { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public int NguoiCapNhat_ID { get; set; }

        protected string SP_Name = "";
        protected List<SqlParameter> para = new List<SqlParameter>();
        public Phieu()
        {
            NgayTao = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            NgayCapNhat = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
        }
        public virtual int Add()
        {
            para.Add(new SqlParameter("@Action", "Add"));
            var outputID = new SqlParameter("@Phieu_ID", SqlDbType.Int);
            outputID.Direction = ParameterDirection.Output;
            para.Add(outputID);
            para.Add(new SqlParameter("@SoPhieu", SoPhieu));
            para.Add(new SqlParameter("@NoiTao", NoiTao));
            para.Add(new SqlParameter("@NgayTao", NgayTao));
            para.Add(new SqlParameter("@NguoiTao_ID", NguoiTao_ID));
            para.Add(new SqlParameter("@NgayCapNhat", NgayCapNhat));
            para.Add(new SqlParameter("@NguoiCapNhat_ID", NguoiCapNhat_ID));
            try
            {
                DatabaseHelper.ExecuteScalar(
                    SP_Name,
                    CommandType.StoredProcedure,
                    para.ToArray()
                );
            }
            catch (Exception ex)
            {
                return -1;
            }
            return (int)outputID.Value;
        }
        public virtual int Update(int phieu_id)
        {
            para.Add(new SqlParameter("@Action", "Update"));
            para.Add(new SqlParameter("@Phieu_ID", phieu_id));
            para.Add(new SqlParameter("@SoPhieu", SoPhieu));
            para.Add(new SqlParameter("@NoiTao", NoiTao));
            para.Add(new SqlParameter("@NgayTao", NgayTao));
            para.Add(new SqlParameter("@NguoiTao_ID", NguoiTao_ID));
            para.Add(new SqlParameter("@NgayCapNhat", NgayCapNhat));
            para.Add(new SqlParameter("@NguoiCapNhat_ID", NguoiCapNhat_ID));

            try
            {
                DatabaseHelper.ExecuteScalar(
                    SP_Name,
                    CommandType.StoredProcedure,
                    para.ToArray()
                );
            }
            catch (Exception ex)
            {
                return -1;
            }
            return phieu_id;
        }
        public virtual int Delete(int phieu_id)
        {
            para.Add(new SqlParameter("@Action", "Delete"));
            para.Add(new SqlParameter("@Phieu_ID", phieu_id));
            return DatabaseHelper.ExecuteNonQuery(
                SP_Name,
                CommandType.StoredProcedure,
                para.ToArray()
            );
        }
        public abstract bool GetByPhieu_ID(int phieu_id);
        public virtual void ExtractDataRow(DataRow dr)
        {
            if (dr == null) return;
            Phieu_ID = (int)dr["Phieu_ID"];
            SoPhieu = dr["SoPhieu"].ToString();
            NoiTao = dr["NoiTao"].ToString();
            NgayTao = (DateTime)dr["NgayTao"];
            NguoiTao_ID = (int)dr["NguoiTao_ID"];
            NgayCapNhat = (DateTime)dr["NgayCapNhat"];
            NguoiCapNhat_ID = (int)dr["NguoiCapNhat_ID"];
        }
    }
}
