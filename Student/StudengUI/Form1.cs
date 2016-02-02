using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentModel;//引入
using StudentBLL;//引入


namespace StudengUI//____________________________三层架构设计（表示层）[信息界面展示 && 删除UI]
{
    public partial class Main : Form
    {
        #region 实例化一个业务逻辑层
        StInfoBll Bll = new StInfoBll(); 
        #endregion

        #region 系统自带的代码
        public Main()
        {
            InitializeComponent();
        } 
        #endregion

        #region 信息展示功能

        private void Main_Load(object sender, EventArgs e)
        {
            //（4）调用业务逻辑层访问数据，，转BLL，，对一个表的增删改查都要写在一个表中

            List<Stmodel> list = Bll.GetStInfoList();

            #region 列表男女选用combox时候的设置
            //ColumnSgender.DataSource = list;
            //ColumnSgender.DisplayMember = "Sgender"; 
            #endregion


            this.MyDataList.DataSource = list;
        }
        #region MyDataList_CellFormatting列表性别列，"男""女"显示处理；身高是否可空，体重是否可空显示为空（null）(难度：五星级！)
        private void MyDataList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string str = e.Value.ToString().ToLower();
                e.Value = str.Equals("true") ? "男" : "女";
            }


            if (e.ColumnIndex == 4)
            {
                decimal d = (decimal)e.Value;
                e.Value = d == 0 ? null : e.Value;

            }
            if (e.ColumnIndex == 5)
            {
                int i = (int)e.Value;
                e.Value = i == 0 ? null : e.Value;

            }
        }
        #endregion
        #endregion

        #region 添加按钮功能
        private void btnAdd_Click(object sender, EventArgs e)
        {
            StInfoAdd add = new StInfoAdd();
            add.Show();
            this.Hide();
        } 
        #endregion

        #region 更新按钮功能

        /// <summary>
        /// 更新按钮功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdata_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.MyDataList.SelectedRows[0].Cells[0].Value);
            //弹出修改框
            StInfoUpdate update = new StInfoUpdate(id);//通过这个类中构造函数传id值
            update.Show();
            this.Hide();

        } 
        #endregion

        #region 删除功能
        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.MyDataList.SelectedRows[0].Cells[0].Value);
            //MessageBox.Show(id.ToString());//show中的类型是string
            //拿到id值直接删除就可以，去Bll中做处理
            if (Bll.StInfoDel(id))
            {
                MessageBox.Show("删除成功!");
                List<Stmodel> list = Bll.GetStInfoList();
                this.MyDataList.DataSource = list;

            }
            else
            {
                MessageBox.Show("删除失败!");
            }
        } 
        #endregion

        #region 导出到Excel功能
        private void btnToExcel_Click(object sender, EventArgs e)
        {
            //需要数据层做数据查询，并保存到excel，到Dal层去
            Bll.StInfoListToExecl();
            MessageBox.Show("导出Excel文件成功！");
        } 
        #endregion


    }
}

