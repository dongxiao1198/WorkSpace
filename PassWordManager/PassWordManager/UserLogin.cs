using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace PassWordManager
{
    public partial class UserLogin : Form
    {
        public string UserPassWord;
        public UserLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            UserPassWord = textBoxPassWord.Text;
            if (UserPassWord != "xiaog0147")
            {
                MessageBox.Show("密码错误！");
                textBoxPassWord.Text = "";
                textBoxPassWord.Focus();
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            } 
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBoxPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserPassWord = textBoxPassWord.Text;
                if (UserPassWord != "xiaog0147")
                {
                    MessageBox.Show("密码错误！");
                    textBoxPassWord.Text = "";
                    textBoxPassWord.Focus();
                    return;
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                } 
            }
        }
    }
}
