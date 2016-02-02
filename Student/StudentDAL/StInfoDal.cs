using System;
using System.Collections.Generic;
using System.Data;//DataTable
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModel;
using System.Data.SqlClient;//SqlParameter
using NPOI.SS.UserModel;//NPOI程序集
using NPOI.HSSF.UserModel;//NPOI程序集
using System.IO;//导出excel需要

namespace StudentDAL//____________________________三层架构设计（数据访问层）
{
    public class StInfoDal
    {
        #region 数据集，使用sqlHelper.ExecuteDataTable()，整张表查询（“查”）
        public List<Stmodel> GetStInfoList()
        {
            string cmdText = "select Sid, Sname, Sbirthday, Sgender, Sheight, Sweight, Saddress from Students";

            DataTable tb = sqlHelper.ExecuteDataTable(cmdText);

            List<Stmodel> list = new List<Stmodel>();
            if (tb.Rows.Count > 0)
            {
                foreach (DataRow row in tb.Rows)
                {
                    Stmodel model = new Stmodel();
                    model.Sid = Convert.ToInt32(row["Sid"]);//不为空
                    model.Sname = Convert.ToString(row["Sname"]);//不为空
                    model.Sbirthday = DateTime.Parse(row["Sbirthday"].ToString());//不为空
                    if (row["Sgender"].ToString().ToLower() == "true")//不为空
                    {
                        model.Sgender = true;
                    }
                    else
                    {
                        model.Sgender = false;
                    }
                    //model.Sheight = Convert.IsDBNull(row["Sheight"]) ? null : (decimal?)row["Sheight"];
                    if (row["Sheight"] == DBNull.Value)
                    {
                        model.Sheight = null;
                    }
                    else
                    {
                        model.Sheight = (decimal?)row["Sheight"];
                    }
                    if (row["Sweight"] == DBNull.Value)
                    {
                        model.Sweight = null;
                    }
                    else
                    {
                        model.Sweight = (int?)row["Sweight"];
                    }
                    //model.Sweight = Convert.IsDBNull(row["Sweight"]) ? null : (int?)row["Sweight"];
                    model.Saddress = Convert.IsDBNull(row["Saddress"]) ? null : row["Saddress"].ToString();

                    list.Add(model);
                }
            }
            return list;
        } 
        #endregion

        #region  添加学生信息，<returns>返回受影响的行数，使用sqlHelper.ExcuteNonQuery()非查询方法，操纵数据库（“增”）
        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="model">从业务逻辑层传入实体</param>
        /// <returns>返回受影响的行数</returns>
        public int StInfoAdd(Stmodel model)
        {
            string cmdText = "insert into Students(Sname, Sbirthday, Sgender, Sheight, Sweight, Saddress) values(@Sname, @Sbirthday, @Sgender, @Sheight, @Sweight, @Saddress)";
            SqlParameter[] param ={ new SqlParameter("@Sname",model.Sname),  //param不要使用关键字了
                                    new SqlParameter("@Sbirthday",model.Sbirthday), 
                                    new SqlParameter("@Sgender",model.Sgender),
                                    new SqlParameter("@Sheight",model.Sheight),
                                    new SqlParameter("@Sweight",model.Sweight),
                                    new SqlParameter("@Saddress",model.Saddress) };
            return sqlHelper.ExcuteNonQuery(cmdText, param);//返回插入后受影响的行数
        } 
        #endregion

        #region 根据选中MyDataList表中id来更新当前用户的信息，使用参数化传值，使用sqlHelper.ExcuteNonQuery()非查询方法，操纵数据库（改）
        /// <summary>
        /// 根据选中MyDataList表中id来更新当前用户的信息
        /// </summary>
        /// <param name="model">model中的id</param>
        /// <returns>返回受影响的函数</returns>
        public int StInfoUpdate(Stmodel model)
        {
            string cmdText = "update Students set Sname=@Sname,Sbirthday=@Sbirthday,Sgender=@Sgender,Sheight=@Sheight,Sweight=@Sweight,Saddress=@Saddress where Sid=@Sid";
            SqlParameter[] param ={ new SqlParameter("@Sname",model.Sname), 
                                    new SqlParameter("@Sbirthday",model.Sbirthday), 
                                    new SqlParameter("@Sgender",model.Sgender),
                                    new SqlParameter("@Sheight",model.Sheight),
                                    new SqlParameter("@Sweight",model.Sweight),
                                    new SqlParameter("@Saddress",model.Saddress),
                                    new SqlParameter("@Sid",model.Sid)};
            return sqlHelper.ExcuteNonQuery(cmdText, param);//返回更新过后受影响的行数

        } 
        #endregion

        #region 根据id从数据库中查询记录信息<returns>这个id对应的数据库中保存的信息，使用sqlHelper.ExecuteDataReader一条条记录查询
        /// <summary>
        /// 根据id从数据库中查询记录信息
        /// </summary>
        /// <param name="id">从业务逻辑层传过来的id值</param>
        /// <returns>这个id对应的数据库中保存的信息</returns>
        public Stmodel GetStInfo(int id)
        {
            //根据id查信息
            string cmdText = "select Sid, Sname, Sbirthday, Sgender, Sheight, Sweight, Saddress from Students where Sid=@Sid ";
            SqlParameter param = new SqlParameter("@Sid", id);
            SqlDataReader record = sqlHelper.ExecuteDataReader(cmdText, param);//一条条记录的查询
            //查询结果并且封装到一个实例化的实体model中
            Stmodel model = new Stmodel();
            while (record.Read())//数据表中记录不是一条，所以要循环读取
            {

                model.Sid = Convert.ToInt32(record["Sid"]);//不为空
                model.Sname = Convert.ToString(record["Sname"]);//不为空
                model.Sbirthday = DateTime.Parse(record["Sbirthday"].ToString());//不为空
                if (record["Sgender"].ToString().ToLower() == "true")//不为空
                {
                    model.Sgender = true;
                }
                else
                {
                    model.Sgender = false;
                }
                model.Sheight = Convert.IsDBNull(record["Sheight"]) ? null : (decimal?)record["Sheight"];
                model.Sweight = Convert.IsDBNull(record["Sweight"]) ? null : (int?)record["Sweight"];
                model.Saddress = Convert.IsDBNull(record["Saddress"]) ? null : record["Saddress"].ToString();

            }
            record.Close();//记得关闭这个对象
            return model;//将记录中的值封装到了model中，返回model
        } 
        #endregion

        #region 根据Id进行删除一条数据操作，<returns>影响的行数（“删”）
        /// <summary>
        /// 根据Id进行删除一条数据操作
        /// </summary>
        /// <param name="id">要删除记录的id</param>
        /// <returns>影响的行数</returns>
        public int StInfoDel(int id)//接收选中行的id
        {
            string cmdText = "delete from Students where Sid=@Sid";
            SqlParameter param = new SqlParameter("@Sid", id);
            return sqlHelper.ExcuteNonQuery(cmdText, param);
        } 
        #endregion

        #region 导出到Excel表，使用sqlHelper.ExecuteDataReader()利用reader对象结合NPOI（“导出”）
        /// <summary>
        /// 导出到Excel表
        /// </summary>
        public void StInfoListToExecl()
        {
            //1 查找数据


            string cmdText = "select Sid, Sname, Sbirthday, Sgender, Sheight, Sweight, Saddress from Students";

            SqlDataReader reader = sqlHelper.ExecuteDataReader(cmdText);

            IWorkbook Stbook = new HSSFWorkbook();//无参数表示创建一个工作簿

            ISheet Stsheet = Stbook.CreateSheet("Students");//一般创建的表名字是和Sql中的表名字是一样的

            IRow headrow = Stsheet.CreateRow(0);//设置行号索引为0
            for (int i = 0; i < reader.FieldCount; i++)
            {
                ICell headName = headrow.CreateCell(i);//创建单元格
                headName.SetCellValue(reader.GetName(i));//将reader中读取首行索引的值读取到首行单元格中去

            }

            int index = 1;//初始化行号为0、、//设置首行0变为1
            while (reader.Read())//结合reader创建表
            {
                IRow row = Stsheet.CreateRow(index);//创建表格中行

                for (int i = 0; i < reader.FieldCount; i++)//根据reader对象属性中FieldCount判断有多少列
                {
                    ICell cell = row.CreateCell(i);
                    cell.SetCellValue(reader.GetValue(i).ToString());//将reader中的值读取到单元格中去


                }
                index++;
            }
            using (FileStream stream = File.Open(@"C:\Stduents.xls", FileMode.OpenOrCreate))//保存路径，及保存名
            {
                Stbook.Write(stream);

            }
        } 
        #endregion
    }
}
