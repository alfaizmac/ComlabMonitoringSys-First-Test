using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using ComponentFactory.Krypton.Toolkit;
using System.Runtime.InteropServices;
using RJCodeAdvance.RJControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.NetworkInformation;



namespace ComlabMonitoringSys
{
    public partial class Form1 : Form
    {

        //cannot AlT TAB
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)] 
        public static extern short GetAsyncKeyState(int vKey);
        private const int VK_MENU = 0x12;
        //cannot AlT TAB

       
        public Form1()
        {
            InitializeComponent();

            InstallSystem();

            SetPCNameLabel();
            PassCharTimer.Start();
            //AutoShutdownTimer.Start();
            //CloseOtherAppTimer.Start(); don't start this ever! too dangerous!
            UserTextBox.Focus();
            UserTextBox.Text = "Username";
            PassTextBox2.Text = "Password";


            //cannot AlT TAB
            this.FormBorderStyle = FormBorderStyle.None; // Hide window border
            this.WindowState = FormWindowState.Maximized; // Maximize the window to full screen
            this.TopMost = true; // Keep the window on top of other windows
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            //cannot AlT TAB

            
        }

        SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=CRUD;Integrated Security=True");


        public string GetLocalIPAddress()
            {
                // Get the local IP address
                string localIP = string.Empty;
                foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
                return localIP;
            }

            public string GetMacAddress()
            {
                // Get the MAC address
                string macAddress = string.Empty;
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface nic in nics)
                {
                    if (nic.NetworkInterfaceType != NetworkInterfaceType.Ethernet)
                        continue;

                    macAddress = nic.GetPhysicalAddress().ToString();
                    break;
                }
                return macAddress;
            }

        public void InstallSystem()
        {
            string computerName = System.Environment.MachineName;

            if (!IsComputerNameExists(computerName))
            {
                AddComputerNameToDatabase(computerName);
                MessageBox.Show("New Computer Added.");
            }

        }

        private bool IsComputerNameExists(string computerName)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=CRUD;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Computers WHERE ComputerName = @ComputerName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ComputerName", computerName);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void AddComputerNameToDatabase(string computerName)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=CRUD;Integrated Security=True"))
            {
                string IP, MAC;
                IP = GetLocalIPAddress();
                MAC = GetMacAddress();
                connection.Open();
                string query = "INSERT INTO Computers (ComputerName, IPAddress, MACAddress, InstallationDateTime) VALUES (@ComputerName, @IPAddress, @MACAddress, @InstallationDateTime)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ComputerName", Environment.MachineName);
                command.Parameters.AddWithValue("@IPAddress", IP);
                command.Parameters.AddWithValue("@MACAddress", MAC);
                command.Parameters.AddWithValue("@InstallationDateTime", DateTime.Now.ToString("hh:mm:ss tt MMMM dd, yyyy"));
                command.ExecuteNonQuery();
            }
        }

      

            private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;


            }
        }
        private void SetPCNameLabel()
        {
            // Set the text of the label to the name of the PC
            label1.Text = Environment.MachineName;
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Userlogin();

        }
        private void Userlogin()
        {

            string user, pass;
            user = UserTextBox.Text;
            pass = PassTextBox2.Text;

            using (SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=CRUD;Integrated Security=True"))
            {
                string query = "SELECT * FROM Users WHERE UserID = @username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", user);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["Role"].ToString() != "User")
                    {
                        MessageBox.Show("Incorrect user ID and password. Please try again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                        else if (reader["Role"].ToString() == "User")
                    {
                        // User ID exists in the database
                        string storedPassword = reader["Password"].ToString();

                        if (pass == storedPassword)
                        {
                            // Successful login
                            // Proceed to main application form or dashboard


                            string username, stat;

                            con.Open();

                            username = UserTextBox.Text;
                            

                            string Userlog = "INSERT INTO UsersLog (ComputerName, UserID, TimeIn) VALUES (@ComputerName, @UserID, @TimeIn)";
                            SqlCommand UserlogCMD = new SqlCommand(Userlog, con);
                            UserlogCMD.Parameters.AddWithValue("@ComputerName", Environment.MachineName);
                            UserlogCMD.Parameters.AddWithValue("@UserID", username);
                            UserlogCMD.Parameters.AddWithValue("@TimeIn", DateTime.Now.ToString("hh:mm:ss tt MMMM dd, yyyy"));
                            UserlogCMD.ExecuteNonQuery();


                            stat = "Online";
                            string Status = "INSERT INTO RealTime (Status, UserName, ComputerName, IPAddress, TimeIn) VALUES (@Status, @UserName, @ComputerName, @IPAddress, @TimeIn)";
                            SqlCommand Statuscmd = new SqlCommand(Status, con);
                            Statuscmd.Parameters.AddWithValue("@Status", stat);
                            Statuscmd.Parameters.AddWithValue("@UserName", username);
                            Statuscmd.Parameters.AddWithValue("@ComputerName", Environment.MachineName);
                            Statuscmd.Parameters.AddWithValue("@IPAddress", GetLocalIPAddress());
                            Statuscmd.Parameters.AddWithValue("@TimeIn", DateTime.Now.ToString("hh:mm:ss tt MMMM dd, yyyy"));
                            Statuscmd.ExecuteNonQuery();

                            con.Close();   

                        

                            CloseOtherAppTimer.Stop();
                            this.Hide();
                            this.Close();
                            UserForm userForm = new UserForm();
                            userForm.Show();

                        }
                        else
                        {
                            // Password is incorrect
                            MessageBox.Show("Incorrect password. Please try again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
                else
                {
                    // User ID does not exist in the database
                    MessageBox.Show("Invalid username. Please try again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

            

        private void rjButton3_Click(object sender, EventArgs e)
        {
            AdminLoginForm adminLoginForm = new AdminLoginForm();
            this.Hide();
            this.Close();
           
            adminLoginForm.Show();
            CloseOtherAppTimer.Stop();
        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            WelcomePanel.BringToFront();
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to turns off the PC?", "Shut Down", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                System.Diagnostics.Process.Start("shutdown", " /s /t 0");
            }
        }


        private void rjButton7_MouseDown_1(object sender, MouseEventArgs e)
        {
            PassTextBox2.Hide();
        }

        private void rjButton7_MouseUp_1(object sender, MouseEventArgs e)
        {
            PassTextBox2.Show();
        }



        private void PassTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { Userlogin(); }

        }


        private void kryptonButton2_MouseDown(object sender, MouseEventArgs e)
        {
            PassTextBox2.Hide();
        }

        private void kryptonButton2_MouseUp(object sender, MouseEventArgs e)
        {
            PassTextBox2.Show();
        }

        private void UserLoginButton_Click(object sender, EventArgs e)
        {
                Userlogin();
           
        }

        private void PassTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Userlogin();
            }
        }

        private void UserTextBox_Enter(object sender, EventArgs e)
        {
            if (UserTextBox.Text == "Username")
            {
                UserTextBox.Text = "";
            }
        }

        private void UserTextBox_Leave(object sender, EventArgs e)
        {
            if (UserTextBox.Text == "")
            {
                UserTextBox.Text = "Username";
            }
        }

        private void PassTextBox2_Enter(object sender, EventArgs e)
        {
            if (PassTextBox2.Text == "Password")
            {
                PassTextBox2.Text = "";
                PassTextBox2.PasswordChar = '●';
            }
        }

        private void PassTextBox2_Leave(object sender, EventArgs e)
        {
            if (PassTextBox2.Text == "")
            {
                PassTextBox2.Text = "Password";
                PassTextBox2.PasswordChar = '\0';
            }
        }

        private void UserTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { Userlogin(); }
        }

        private void AutoShutdownTimer_Tick(object sender, EventArgs e)
        {
            //Process.Start("shutdown.exe", " -s -t 00");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                e.Handled = true;
            }
        }

        private void CloseOtherAppTimer_Tick(object sender, EventArgs e)
        {
            CloseOtherApplications();
        }
        private void CloseOtherApplications()
        {
            Process currentProcess = Process.GetCurrentProcess();

            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                try
                {
                    if (process.Id != currentProcess.Id)
                    {
                        process.Kill();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void PassCharTImer_Tick(object sender, EventArgs e)
        {
            PassTextBox1.Text = PassTextBox2.Text;

            //AdminForm adminForm = new AdminForm();
           // adminForm.Show();
            //this.Hide();
            //this.Close();
            //PassCharTimer.Stop();
        }

    }
}
