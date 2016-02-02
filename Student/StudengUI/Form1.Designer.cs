namespace StudengUI
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MyDataList = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdata = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSbirthday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSgender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSheight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSweight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSaddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MyDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // MyDataList
            // 
            this.MyDataList.AllowUserToAddRows = false;
            this.MyDataList.AllowUserToDeleteRows = false;
            this.MyDataList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MyDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MyDataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnSname,
            this.ColumnSbirthday,
            this.ColumnSgender,
            this.ColumnSheight,
            this.ColumnSweight,
            this.ColumnSaddress});
            this.MyDataList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MyDataList.Location = new System.Drawing.Point(41, 101);
            this.MyDataList.Name = "MyDataList";
            this.MyDataList.ReadOnly = true;
            this.MyDataList.RowHeadersVisible = false;
            this.MyDataList.RowTemplate.Height = 23;
            this.MyDataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MyDataList.Size = new System.Drawing.Size(903, 435);
            this.MyDataList.TabIndex = 0;
            this.MyDataList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.MyDataList_CellFormatting);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Location = new System.Drawing.Point(139, 554);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdata
            // 
            this.btnUpdata.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdata.Location = new System.Drawing.Point(352, 554);
            this.btnUpdata.Name = "btnUpdata";
            this.btnUpdata.Size = new System.Drawing.Size(75, 23);
            this.btnUpdata.TabIndex = 1;
            this.btnUpdata.Text = "修改";
            this.btnUpdata.UseVisualStyleBackColor = true;
            this.btnUpdata.Click += new System.EventHandler(this.btnUpdata_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDel.Location = new System.Drawing.Point(558, 554);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 1;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(389, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "学生信息表";
            // 
            // btnToExcel
            // 
            this.btnToExcel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnToExcel.Location = new System.Drawing.Point(750, 554);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(75, 23);
            this.btnToExcel.TabIndex = 3;
            this.btnToExcel.Text = "导出Excel";
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // ColumnID
            // 
            this.ColumnID.DataPropertyName = "Sid";
            this.ColumnID.HeaderText = "编号";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            // 
            // ColumnSname
            // 
            this.ColumnSname.DataPropertyName = "Sname";
            this.ColumnSname.HeaderText = "姓名";
            this.ColumnSname.Name = "ColumnSname";
            this.ColumnSname.ReadOnly = true;
            // 
            // ColumnSbirthday
            // 
            this.ColumnSbirthday.DataPropertyName = "Sbirthday";
            this.ColumnSbirthday.HeaderText = "出生日期";
            this.ColumnSbirthday.Name = "ColumnSbirthday";
            this.ColumnSbirthday.ReadOnly = true;
            // 
            // ColumnSgender
            // 
            this.ColumnSgender.DataPropertyName = "Sgender";
            this.ColumnSgender.HeaderText = "性别";
            this.ColumnSgender.Name = "ColumnSgender";
            this.ColumnSgender.ReadOnly = true;
            // 
            // ColumnSheight
            // 
            this.ColumnSheight.DataPropertyName = "Sheight";
            this.ColumnSheight.HeaderText = "身高(M)";
            this.ColumnSheight.Name = "ColumnSheight";
            this.ColumnSheight.ReadOnly = true;
            // 
            // ColumnSweight
            // 
            this.ColumnSweight.DataPropertyName = "Sweight";
            this.ColumnSweight.HeaderText = "体重(Kg)";
            this.ColumnSweight.Name = "ColumnSweight";
            this.ColumnSweight.ReadOnly = true;
            // 
            // ColumnSaddress
            // 
            this.ColumnSaddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnSaddress.DataPropertyName = "Saddress";
            this.ColumnSaddress.HeaderText = "家庭住址";
            this.ColumnSaddress.Name = "ColumnSaddress";
            this.ColumnSaddress.ReadOnly = true;
            this.ColumnSaddress.Width = 78;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 600);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnUpdata);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.MyDataList);
            this.Name = "Main";
            this.Text = "学生信息表";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyDataList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MyDataList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdata;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSbirthday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSgender;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSheight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSweight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSaddress;
    }
}

