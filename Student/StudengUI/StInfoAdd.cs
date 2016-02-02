using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentBLL;//
using StudentModel;//   

namespace StudengUI//____________________________三层架构设计（表示层）[添加界面UI]
{
    public partial class StInfoAdd : Form
    {
        
        #region 实例化出业务逻辑层对象Bll
        StInfoBll Bll = new StInfoBll(); 
        #endregion

        #region 系统自带的代码
        public StInfoAdd()
        {
            InitializeComponent();
        } 
        #endregion

        #region 这里主要是在加载窗体的过程，将连动的生日comBox的数据进行加载
        private void StInfoAdd_Load(object sender, EventArgs e)
        {
            #region 生日连动选择：代码块（一）；
            cmbYear.Items.Clear();
            for (int year = 1900; year <= 1903; year++)
            {
                cmbYear.Items.Add(year);
            }
            #endregion////切记：要写在加载这个函数中！

        }

        #region 生日连动选择：代码块（二）；

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMonth.Items.Clear();
            for (int month = 1; month <= 12; month++)
            {
                cmbMonth.Items.Add(month);
            }
        }
  
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //如果是从更新框复制过来的panel的空间，则需要对每个组建进行重新绑定：：就是重新双击该按钮
            //cmbYear_SelectedIndexChanged..cmbMonth_SelectedIndexChanged
            int year = Convert.ToInt32(cmbYear.Text);
            int month = Convert.ToInt32(cmbMonth.Text);
            int days;
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                days = 31;
            }
            else if (month == 04 || month == 06 || month == 09 || month == 11)
            {
                days = 30;
            }
            else if (month == 2 && (year % 400 == 0 || (year % 4 == 0 && year / 100 != 0)))
            {
                days = 29;
            }
            else
            {
                days = 28;
            }
            cmbDay.Items.Clear();

            for (int j = 1; j <= days; j++)
            {
                cmbDay.Items.Add(j);
            }

        }
        #endregion 
        #endregion

        #region 单击“添加”按钮事件--做出相应的处理

        /// <summary>
        /// 获取用户输入的内容，并封装到model中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpadate_Click(object sender, EventArgs e)
        {
            Stmodel model = new Stmodel();

            #region ***************对非空选项:为空，就报警！*************
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                MessageBox.Show("姓名不能为空！", "SQL提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string STR_Birthday = this.cmbYear.Text.Trim() + "-" + this.cmbMonth.Text.Trim() + "-" + this.cmbDay.Text.Trim();
            if (string.IsNullOrEmpty(cmbYear.Text.Trim()) || string.IsNullOrEmpty(cmbYear.Text.Trim()) || string.IsNullOrEmpty(cmbDay.Text.Trim()))
            {
                MessageBox.Show("年、月、日不能为空！", "SQL提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.radioMan.Checked.Equals(false) && this.radioWomen.Checked.Equals(false))
            {
                MessageBox.Show("性别不能为空！", "SQL提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            #region ********对可空的选型：如果内容为空，不做任何处理；否则，进行格式验证***************
            IsOkForm yanzheng = new IsOkForm();
            //身高是可以为空的
            if (string.IsNullOrEmpty(this.txtHeight.Text))
            {

                model.Sheight = null;//为空赋值为null

            }
            else if (!(yanzheng.IsDecimal(this.txtHeight.Text)))//不为空就验证,验证通过就在下面继续赋值
            {
                MessageBox.Show("身高非数字或格式不正确！", "SQL提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;


            }
            //体重是可以为空的
            if (string.IsNullOrEmpty(this.txtWeight.Text))
            {

                model.Sweight = null;//为空赋值为null
            }
            else if (!(yanzheng.IsIntNumber(this.txtWeight.Text) && yanzheng.IsIntNumberLength(this.txtWeight.Text)))//不为空就验证,验证通过就在下面继续赋值
            {
                MessageBox.Show("体重为非数字或格式不正确！", "SQL提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion

            #region 在这里进行这样的故事：1.数据的类型转换（难点五星级）2.文本输入的格式控制（自己百度的！））
            string bithday = STR_Birthday;
            bool gender = false;
            if (this.radioMan.Checked)
            {
                gender = true;
            }

            string heightYanZhengHou = this.txtHeight.Text.Trim();
            string weightYanZhengHou = this.txtWeight.Text.Trim();

            model.Sname = this.txtName.Text.Trim();
            model.Sbirthday = DateTime.Parse(Convert.ToDateTime(bithday).ToString("yyyy-MM-dd"));
            model.Sgender = gender;

            #region 对身高、体重使用Decimal.TryParse(),Int32.TryParse(）这种转化方法，不使用Convert.toDecimal()这种，因为这个转化处理为空的情况，报异常多（能让你抓狂！！）
            decimal result = 0;
            if (Decimal.TryParse(heightYanZhengHou, out result))
            {

                model.Sheight = result;
            }
            else
            {
                model.Sheight = 0;
            }

            int result1 = 0;
            if (Int32.TryParse(weightYanZhengHou, out result1))
            {
                model.Sweight = result1;
            }
            else
            {
                model.Sweight = 0;
            }
            #endregion
            //model.Sweight = Convert.ToInt32(weightYanZhengHou);//就是这个：不建议使用的方法！！
            model.Saddress = this.txtAddress.Text.Trim();
            #endregion



            #region 调用业务逻辑层的返回值（可以这么讲，有没有添加成功：业务逻辑层StInfoAdd（）方法说了算数；

            if (Bll.StInfoAdd(model))//业务逻辑层返回时为"真"就是添加成功
            {
                MessageBox.Show("添加成功！", "SQL提示", MessageBoxButtons.OK);
                this.Hide();
                Main main = new Main();
                main.Show();

            }
            else
            {
                MessageBox.Show("添加失败！", "SQL提示", MessageBoxButtons.OK);
            }
            #endregion

        } 
        #endregion
        
    }
}

