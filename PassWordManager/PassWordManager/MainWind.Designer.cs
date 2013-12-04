namespace PassWordManager
{
    partial class MainWind
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewmain = new System.Windows.Forms.DataGridView();
            this.Program = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewmain)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewmain
            // 
            this.dataGridViewmain.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewmain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewmain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewmain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Program,
            this.Username,
            this.Password,
            this.Remark});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewmain.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewmain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewmain.Location = new System.Drawing.Point(0, 29);
            this.dataGridViewmain.Name = "dataGridViewmain";
            this.dataGridViewmain.RowHeadersVisible = false;
            this.dataGridViewmain.RowTemplate.Height = 23;
            this.dataGridViewmain.Size = new System.Drawing.Size(526, 468);
            this.dataGridViewmain.TabIndex = 0;
            // 
            // Program
            // 
            this.Program.HeaderText = "程序";
            this.Program.Name = "Program";
            this.Program.Width = 80;
            // 
            // Username
            // 
            this.Username.HeaderText = "账号";
            this.Username.Name = "Username";
            this.Username.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Username.Width = 180;
            // 
            // Password
            // 
            this.Password.HeaderText = "密码";
            this.Password.Name = "Password";
            this.Password.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Password.Width = 120;
            // 
            // Remark
            // 
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.Width = 120;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(449, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // MainWind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 497);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridViewmain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密码管理器";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewmain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewmain;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Program;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}

