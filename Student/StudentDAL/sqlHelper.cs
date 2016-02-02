using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;//ConfigurationManager
using System.Data.SqlClient;
using System.Data;//SqlDataReader

namespace StudentDAL
{
    public class sqlHelper
    {
        #region 连接数据库功能的字符串，字符串实际上是保存在了表示层的App.config配置文件中，使用情况：“增”“删”“改”“查”
        private static readonly string ConnStr = ConfigurationManager.ConnectionStrings["connSTB"].ToString(); 
        #endregion

        #region 对数据库的“查”，“查”有两种方法，欲知详情，请展开查看！
        #region SqlDataReader，返回的是一个SqlDataReader对象（就是一条记录），使用情况：逐条查记录
        public static SqlDataReader ExecuteDataReader(string cmdText, params SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }

        }
        #endregion




        //在ADO.NET中有两种数据访问；
        //第一种：SqlDataReader，特点：一条条的记录返回
        //第二种：适配器加上数据集;特点：将整个表中数据的内容返回
        //
        //下面演示的是用第二种，数据集




        #region 适配器+数据集（SqlDataAdapter+DataTable），返回额是一个DataTable（就是一张二维表），使用情况：整张表的查询
        public static DataTable ExecuteDataTable(string cmdText)
        {
            using (SqlConnection conn1 = new SqlConnection(ConnStr))
            {
                conn1.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn1;
                    cmd.CommandText = cmdText;
                    cmd.CommandTimeout = 5;

                    DataTable dt = new DataTable();

                    using (SqlDataAdapter sd = new SqlDataAdapter(cmd))
                    {
                        sd.Fill(dt);//适配器+数据集
                        return dt;
                    }

                }
            }

        }
        #endregion 
        #endregion

        #region ExcuteNonQuery（）使用情况：对数据库执行“增”“删”“改”
        public static int ExcuteNonQuery(string cmdText, params SqlParameter[] param)
        {
            //创建连接
            using (SqlConnection conn2 = new SqlConnection(ConnStr))
            {
                conn2.Open();
                using (SqlCommand cmd = new SqlCommand(cmdText, conn2))
                {
                    cmd.Parameters.AddRange(param);
                    return cmd.ExecuteNonQuery();//返回受影响的行数
                }
            }

        } 
        #endregion
    }
}
