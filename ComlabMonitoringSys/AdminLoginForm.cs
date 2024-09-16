using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComlabMonitoringSys
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
            timer1.Start();
            AdminUserTextBox.Focus();

            AdminUserTextBox.Text = "Username";
            AdminPassTextBox2.Text = "Password";

        }

        private void AdminLogin()
        {
            string user, pass;
            user = AdminUserTextBox.Text;
            pass = AdminPassTextBox2.Text;

            if (user == "admin" && pass == "admin")

            {
                this.Hide();
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
            }

            //new login
            else if (user == "Username" && pass == "Password")
            {
                MessageBox.Show("Please enter your username and password.", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AdminUserTextBox.Focus();
            }
            else if (user == "" && pass == "Password")
            {
                MessageBox.Show("Please enter your username and password.", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (user == "Username" && pass == "")
            {
                MessageBox.Show("Please enter your username and password.", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AdminUserTextBox.Focus();
            }


            else if (pass == "")
            {
                MessageBox.Show("Please enter password.", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AdminPassTextBox2.Focus();

            }
            else if (user == "")
            {
                MessageBox.Show("Please enter your username.", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AdminUserTextBox.Focus();

            }

            else if (user != "admin" && pass != "admin")
            {
                MessageBox.Show("Your Username and Password is incorrect. Please try again", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AdminUserTextBox.Focus();

            }

            else if (user == "admin" && pass != "admin")
            {
                MessageBox.Show("Your password is incorrect. Please try again.", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AdminPassTextBox2.Focus();
            }
            else if (user != "admin" && pass == "admin")
            {
                MessageBox.Show("Your username is incorrect. Please try again.", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                AdminUserTextBox.Focus();

            }

            else
            {
                MessageBox.Show("Invalid username and password. Please try again.", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                AdminUserTextBox.Text = "Username";
                AdminPassTextBox2.Text = "Password";
                AdminUserTextBox.Focus();
            }
        }

        private void AdminEye_MouseDown(object sender, MouseEventArgs e)
        {
            AdminPassTextBox2.Hide();
        }

        private void AdminEye_MouseUp(object sender, MouseEventArgs e)
        {
            AdminPassTextBox2.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AdminPassTextBox1.Text = AdminPassTextBox2.Text;
        }

        private void AdminLoginButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void AdminUserTextBox_Enter(object sender, EventArgs e)
        {
            if (AdminUserTextBox.Text == "Username")
            {
                AdminUserTextBox.Text = "";
            }
        }

        private void AdminUserTextBox_Leave(object sender, EventArgs e)
        {
            if (AdminUserTextBox.Text == "")
            {
                AdminUserTextBox.Text = "Username";

            }
        }

        private void AdminPassTextBox2_Enter(object sender, EventArgs e)
        {
            if (AdminPassTextBox2.Text == "Password")
            {
                AdminPassTextBox2.Text = "";
                AdminPassTextBox2.PasswordChar = '●';
            }
        }

        private void AdminPassTextBox2_Leave(object sender, EventArgs e)
        {
            if (AdminPassTextBox2.Text == "")
            {
                AdminPassTextBox2.Text = "Password";
                AdminPassTextBox2.PasswordChar = '\0';
            }
        }

        private void AdminLoginButton2_Click(object sender, EventArgs e)
        {
            AdminLogin();
        }

        private void AdminUserTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { AdminLogin(); }
        }

        private void AdminPassTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { AdminLogin(); }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }
    }
    
}
