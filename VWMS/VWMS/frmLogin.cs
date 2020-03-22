using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VWMS.CommonClass;

namespace VWMS
{
    public partial class frmLogin : Form
    {
        DataCon datacon = new DataCon();
        DataOperate dataoperate = new DataOperate();

        public frmLogin()
        {
            InitializeComponent();          
        }

        /**
         * 单击“登录”按钮，先判断是否输入用户名，如果没有就提示输入，否则判断输入的用户名与数据库的记录是否一致，一致则显示主窗体
         * 
         * **/
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                errorProName.SetError(txtName, "用户名不能为空！");
            }
            else
            {
                errorProName.Clear();   //清楚错误提示信息
                string strSql = "select * from tb_admin where name='" + txtName.Text + "'and pwd='" + txtPwd.Text + "'";
                DataSet ds = dataoperate.getDs(strSql, "tb_admin");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.Hide();    //隐藏当前窗体
                    frmMain frmmain = new frmMain();    //实例化主窗体对象
                    frmmain.Show();     //显示主窗体
                }
                else
                {
                    MessageBox.Show("用户名或密码错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //点击“退出”按钮时，退出程序
        private void btnExit_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        //按下“ENTER”键时，自动将鼠标焦点移到密码输入框
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtPwd.Focus();
                e.Handled = true;
            }
        }

        //按下“ENTER”键时，自动将鼠标焦点移到登录按钮
        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.Focus();
                e.Handled = true;
            }
        }
    }
}
