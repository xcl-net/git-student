using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentModel;//
using StudentDAL;//

namespace StudentBLL//____________________________三层架构设计（业务逻辑层）
{
    public class StInfoBll
    {

        #region 实例化一个数据访问层对象
        StInfoDal Dal = new StInfoDal(); 
        #endregion

        #region 信息展示的业务逻辑处理
        /// <summary>
        /// 获取用户信息的列表
        /// </summary>
        /// <returns>数据访问层返回的数据集</returns>
        public List<Stmodel> GetStInfoList()
        {
            //业务逻辑层没有，所以转到数据访问层获取数据
            return Dal.GetStInfoList();
        } 
        #endregion

        #region 添加功能的业务逻辑处理
        /// <summary>
        /// 插入学生的信息
        /// </summary>
        /// <param name="model">从UI层传递的要插入的实体</param>
        /// <returns>是否是插入成功的bool值</returns>
        public bool StInfoAdd(Stmodel model)
        {
            //调用数据访问层
            int state = Dal.StInfoAdd(model);
            if (state > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion

        #region 更新功能业务的业务逻辑处理
        /// <summary>
        /// 根据id更新当前用户的信息
        /// </summary>
        /// <param name="model">model的所有属性</param>
        /// <returns>是否修改成功bool值</returns>
        public bool StInfoUpdate(Stmodel model)//接收StInfoUpdate  UI层获取的model实体类
        {
            if (Dal.StInfoUpdate(model) > 0)//将实体model传递到Dal更新方法中去
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 根据id值查询记录信息
        /// </summary>
        /// <param name="id">从更新UI传递过来的Sid值</param>
        /// <returns>从数据层查询的返回记录信息</returns>
        public Stmodel GetStInfo(int id)
        {
            //转到Dal层
            return Dal.GetStInfo(id);
        } 
        #endregion

        #region 删除功能的业务逻辑处理
        /// <summary>
        /// 根据Id进行删除一条数据操作
        /// </summary>
        /// <param name="id">要删除记录的id</param>
        /// <returns>影响的行数</returns>
        public bool StInfoDel(int id)
        {
            if (Dal.StInfoDel(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        } 
        #endregion

        #region 导出到Excel的业务逻辑处理
        /// <summary>
        /// 导出到Excel表,直接传递到UI层就ok!
        /// </summary>
        public void StInfoListToExecl()
        {
            Dal.StInfoListToExecl();
        } 
        #endregion
    }
}
