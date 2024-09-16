using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ComlabMonitoringSys
{
    public partial class UserForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=CRUD;Integrated Security=True");

        private SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=CRUD;Integrated Security=True");

        private string connectionString = "Data Source=MSI;Initial Catalog=CRUD;Integrated Security=True";

        public UserForm()
        {
            InitializeComponent();
            TimeInLabel2.Text = DateTime.Now.ToString("dddd, hh:mm:ss tt MMMM dd, yyyy");
            PCNameLabel2.Text = Environment.MachineName;
            RealTImeTimer.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RealTImeTimer_Tick(object sender, EventArgs e)
        {
            RealTimerLabel2.Text = DateTime.Now.ToString("dddd, hh:mm:ss tt MMMM dd, yyyy");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateStatusToOffline();

            DeleteOfflineUsers();
        }


        private void UpdateStatusToOffline()
        {
            
            try
            {
                string computerName = Environment.MachineName;
                using (SqlConnection connection = new SqlConnection(connectionString))

                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE RealTime SET Status = 'Offline' WHERE ComputerName = @ComputerName", connection);
                    command.Parameters.AddWithValue("@ComputerName", computerName);
                    command.ExecuteNonQuery();

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status to Offline: " + ex.Message);
            }
        }

        private void DeleteOfflineUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM RealTime WHERE Status = 'Offline'", connection);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting offline users: " + ex.Message);
            }
        }


    }
}
