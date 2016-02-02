using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentModel;//
using StudentBLL;//

namespace StudengUI//____________________________三层架构设计（表示层）[更新界面UI]
{
    public partial class StInfoUpdate : Form
    {

        #region 实例化出业务逻辑层对象Bll
        StInfoBll Bll = new StInfoBll(); 
        #endregion

        #region 设置有参数的构造函数//接收从Main窗体中选中一条记录的对应的id值（就是这个人的代号）
        //写一个字段Sid，等待赋值...........
        private int Sid;

        public StInfoUpdate(int id)
        {
            InitializeComponent();

            this.Sid = id;
        } 
        #endregion

        #region 更新窗体加载的完成，需要将选中的id的所有信息，从model加载到更新界面中...（经历里拿到这个人的id,到数据库中查询该人的所有信息，通过“更新”窗体加载事件，进行页面展示）
        public void StInfoUpdate_Load(object sender, EventArgs e)
        {
            #region 生日连动选择：代码块（一）；
            cmbYear.Items.Clear();
            for (int year = 1900; year <= 2020; year++)
            {
                cmbYear.Items.Add(year);
            }
            #endregion

            Stmodel model = Bll.GetStInfo(this.Sid);
            this.txtName.Text = model.Sname;
            this.cmbYear.Text = model.Sbirthday.ToString().Substring(0, 4);

            #region 将数据库封装好的model中Sbirthday切割出来年份的“月数”显示在combox选项中：
            if (model.Sbirthday.ToString().Substring(6, 1) == "/")//当从model返回的月份是一位数的进行剪切前边读到的斜杠“/”
            {
                cmbMonth.Text = model.Sbirthday.ToString().Substring(5, 1);
            }
            else
            {
                cmbMonth.Text = model.Sbirthday.ToString().Substring(5, 2);
            }
            #endregion

            #region 将数据库封装好的model中Sbirthday切割出来每月份的“天数”显示在combox选项中：
            if (model.Sbirthday.ToString().Substring(7, 1) == "/" && model.Sbirthday.ToString().Substring(9, 1) == "")//2000/12/1  
            {
                this.cmbDay.Text = model.Sbirthday.ToString().Substring(8, 1);
            }
            else if (model.Sbirthday.ToString().Substring(6, 1) == "/" && model.Sbirthday.ToString().Substring(8, 1) == "") //2000/1/1
            {
                this.cmbDay.Text = model.Sbirthday.ToString().Substring(7, 1);
            }
            else if (model.Sbirthday.ToString().Substring(6, 1) == "/" && model.Sbirthday.ToString().Substring(8, 1) != "") //2000/1/12
            {
                this.cmbDay.Text = model.Sbirthday.ToString().Substring(7, 2);
            }
            else//2000/12/12
            {
                this.cmbDay.Text = model.Sbirthday.ToString().Substring(8, 2);
            }
            #endregion

            if (model.Sgender.Equals(true))//bool值是否是true
            {
                this.radioMan.Checked = true;
            }
            else
            {
                this.radioWomen.Checked = true;
            }
            if (model.Sheight.ToString() == "0.00")
            {
                this.txtHeight.Text = null;
            }
            else
            {
                this.txtHeight.Text = model.Sheight.ToString();
            }
            if (model.Sweight.ToString() == "0")
            {
                this.txtWeight.Text = null;
            }
            else
            {
                this.txtWeight.Text = model.Sweight.ToString();
            }

            this.txtAddress.Text = model.Saddress;

        } 
       

        #region 生日连动选择：代码块（二）；
        private void cmbYear_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cmbMonth.Items.Clear();
            for (int month = 1; month <= 12; month++)
            {
                cmbMonth.Items.Add(month);
            }
        }


        private void cmbMonth_SelectedIndexChanged_1(object sender, EventArgs e)
        {
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

        #region 点击“更新”按钮，进行数据的保存（这个过程其实，和记录的添加是一样的代码，在这里进行了：1.数据的类型转换（难点五星级）2.文本输入的格式控制（自己百度的！））
        private void btnUpadate_Click(object sender, EventArgs e)
        {
            //点击“更新”按钮事件：将修该过的每个属性封装为实体model传递到Bll层
            Stmodel model = new Stmodel();
            IsOkForm yanzheng = new IsOkForm();


            #region  ***************对非空选项:为空，就报警！*************
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                MessageBox.Show("姓名不能为空！", "SQL提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string STR_Birthday = cmbYear.Text.Trim() + "-" + cmbMonth.Text.Trim() + "-" + cmbDay.Text.Trim();
            //如果年、月、日有一个是空的就报警！
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


            #region ********对可空的选型处理：如果内容为空，不做任何处理；否则，进行格式验证***************
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

            string heightYanZhengHou = this.txtHeight.Text.Trim();
            string weightYanZhengHou = this.txtWeight.Text.Trim();

            model.Sname = this.txtName.Text;
            model.Sbirthday = DateTime.Parse(Convert.ToDateTime(STR_Birthday).ToString("yyyy-MM-dd"));
            if (this.radioMan.Checked == true)//若是Man被选中，就给model赋值为true
            {
                model.Sgender.Equals(true);
            }
            else
            {
                model.Sgender.Equals(false);
            };
            #region 对身高、体重使用.TryParse(),不使用Convert.toDecimal()这种，因为这个转化处理为空，报异常多
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
            model.Saddress = this.txtAddress.Text;


            model.Sid = Sid;//id还没有，所以要把id传进来,通过构造函数来传递


            //通过业务逻辑层中的StInfoUpdate()将封装好的model进行处理，根据Bll处理结果写如下
            if (Bll.StInfoUpdate(model))
            {
                MessageBox.Show("修改成功！", "SQL提示", MessageBoxButtons.OK);
                this.Hide();
                Main main = new Main();
                main.Show();
            }
            else
            {
                MessageBox.Show("修改失败！", "SQL提示", MessageBoxButtons.OK);
            }
        } 
        #endregion
    }
}
