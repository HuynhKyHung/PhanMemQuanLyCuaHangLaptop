using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace QLCuaHangViTinh
{
    public class QL_NguoiDung
    {
        public int Check_Config()
        {
            if (Properties.Settings.Default.QL_CuaHangViTinhConnectionString == string.Empty)
                return 1;
            SqlConnection _SqlConn = new SqlConnection(Properties.Settings.Default.QL_CuaHangViTinhConnectionString);
            try
            {
                if (_SqlConn.State == System.Data.ConnectionState.Closed)
                    _SqlConn.Open();
                return 0;
            }
            catch
            {
                return 2;
            }
        }
        public enum LoginResult
        {
            /// <summary>
            /// wrong username or password
            /// </summary>
            Invalid,
            /// <summary>
            /// user has been disable
            /// </summary>
            Disable,
            /// <summary>
            /// Login success
            /// </summary>
            Success
        }
        public int Check_User(string pUser, string pPass)
        {
            SqlDataAdapter daUser = new SqlDataAdapter("select * from QL_NguoiDung where TenDangNhap = '" + pUser + "' and MatKhau='" + pPass + "'", Properties.Settings.Default.QL_CuaHangViTinhConnectionString);
            DataTable dt = new DataTable();
            daUser.Fill(dt);
            if (dt.Rows.Count == 0)
                return 0;
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
            {
                return 1;
            }
            return 2;
        }
        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }
        public DataTable GetDBName(string pServer, string pUser, string pPassword)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select name from sys.Datatbases", "Datasource=" + pServer + ";Initial Catalog=master; User ID=" + pUser + ";pwd= " + pPassword + "");
            da.Fill(dt);
            return dt;
        }
    }
}

