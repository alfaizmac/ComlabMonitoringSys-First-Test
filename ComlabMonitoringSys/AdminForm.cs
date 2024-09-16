using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;

namespace ComlabMonitoringSys
{

    public partial class AdminForm : Form
    {
        private SqlConnection connection = new SqlConnection("Data Source=MSI;Initial Catalog=CRUD;Integrated Security=True");

        private string connectionString = "Data Source=MSI;Initial Catalog=CRUD;Integrated Security=True";

        public AdminForm()
        {
            InitializeComponent();
            customDesign();
            UserDeleteButtonCustom();
            UserOtherButtonCustom();

            AddRemoveItemListHide();
            AutoHideTransaction();

            InitializeDataGridView();

            PopulateDataGridView();

            RefreshDataGridView();
            AutoRefreshDataGridVIewsTimer.Start();
        }


        private void customDesign()
        {
            ManagementSubMenuPanel.Visible = false;
            LogsReportsSubMenuPanel.Visible = false;
            SettingsMaintenanceSubMenuPanel.Visible = false;
            AlertsSupportSubMenuPanel.Visible = false;

        }

        private void hideSubMenu()
        {
            if (ManagementSubMenuPanel.Visible == true)
                ManagementSubMenuPanel.Visible = false;
            if (LogsReportsSubMenuPanel.Visible == true)
                LogsReportsSubMenuPanel.Visible = false;
            if (SettingsMaintenanceSubMenuPanel.Visible == true)
                SettingsMaintenanceSubMenuPanel.Visible = false;
            if (AlertsSupportSubMenuPanel.Visible == true)
                AlertsSupportSubMenuPanel.Visible = false;


        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();

                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }


        private void AddNewItem()
        {
            string newItem;
            newItem = AddRemoveItemListTextBox.Text;

            // Check if the item already exists in the SQL Server table
            if (ItemExistsInDatabase(newItem))
            {
                // Display a message indicating that the item already exists
                MessageBox.Show("This item is already in the list.", "Duplicate Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Add the new item to the SQL Server table
                MessageBox.Show("Successfully Added to the list.", "Added item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Addtothelist(newItem);

                // Refresh the ComboBox with the updated list of items
                PopulateComboBox();
            }
        }

        private bool ItemExistsInDatabase(string item)
        {
            try
            {
                connection.Open();

                // SQL query to check if the item exists in the table
                string query = "SELECT COUNT(*) FROM ItemListComboBox WHERE ItemName = @ItemName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemName", item);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking for item existence: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        private void Addtothelist(string item)
        {

            try
            {
                connection.Open();

                // SQL query to insert the new item into the table
                string query = "INSERT INTO ItemListComboBox (ItemName) VALUES (@ItemName)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ItemName", item);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding item to database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }


        }

        private void Removetothelist()
        {

            if (StorageComboBox.SelectedIndex != -1)
            {
                try
                {
                    string selectedItem = StorageComboBox.SelectedItem.ToString();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM ItemListComboBOx WHERE ItemName = @ItemName"; // Replace YourTableName and ItemColumn with actual names
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ItemName", selectedItem);
                            command.ExecuteNonQuery();
                        }
                    }

                    StorageComboBox.Items.RemoveAt(StorageComboBox.SelectedIndex);
                    MessageBox.Show("Item deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");

            }
        }

        private void PopulateComboBox()
        {
            try
            {
                connection.Open();

                // Clear the ComboBox
                StorageComboBox.Items.Clear();

                // SQL query to retrieve all items from the table
                string query = "SELECT ItemName FROM ItemListComboBox";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                // Add each item to the ComboBox
                while (reader.Read())
                {
                    StorageComboBox.Items.Add(reader["ItemName"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing ComboBox: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void LoadComputerInformation()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ComputerName, IPAddress, MACAddress FROM Computers";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        ComputersDatagridView.DataSource = dataTable;
                    }
                }

                UpdateComputerStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading computer information: " + ex.Message);
            }
        }


        private void UpdateComputerStatus()
        {
            foreach (DataGridViewRow row in ComputersDatagridView.Rows)
            {
                // Check if the row is not a header row
                if (!row.IsNewRow)
                {
                    // Get the value of the IPAddress cell
                    DataGridViewCell ipAddressCell = row.Cells["IPAddress"];
                    if (ipAddressCell != null && ipAddressCell.Value != null)
                    {
                        string ipAddress = ipAddressCell.Value.ToString();
                        // Now you have the IP address, proceed to check its online status
                        bool isOnline = IsComputerOnline(ipAddress);
                        // Update the ComputerStatus cell based on the online status
                        DataGridViewCell statusCell = row.Cells["ComputerStatus"];
                        statusCell.Value = isOnline ? "Online" : "Offline";
                    }
                    else
                    {
                        // Handle the case where the cell value is null
                        // For example, display an error message or log it
                        Console.WriteLine("IPAddress cell value is null or cell does not exist.");
                    }
                }
            }
        }

        private bool IsComputerOnline(string ipAddress)
        {
            bool isOnline = false;
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(ipAddress);
                isOnline = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Handle the exception if ping fails
                // For example, log the error or return false
            }
            return isOnline;
        }


        private void InitializeDataGridView()
        {
            ComputersDatagridView.Columns.Add("ComputerStatus", "Computer Status");
        }

        private void ShutdownButton()
        {
            string computerName = ShutCompterNameTextBox.Text.Trim();
            string ipAddress = ShutIPTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(computerName) || string.IsNullOrWhiteSpace(ipAddress))
            {
                MessageBox.Show("Please enter both computer name and IP address.");
                return;
            }

            if (!PingComputer(ipAddress))
            {
                MessageBox.Show($"Computer {computerName} at {ipAddress} is not reachable.");
                return;
            }

            string shutdownCommand = $"/s /f /m \\\\{ipAddress}";

            try
            {
                Process.Start("shutdown", shutdownCommand);
                MessageBox.Show($"Shutdown command sent to {computerName} at {ipAddress}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending shutdown command: {ex.Message}");
            }
        }

        private bool PingComputer(string ipAddress)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = ping.Send(ipAddress);
                return (reply.Status == IPStatus.Success);
            }
            catch
            {
                return false;
            }
        }

        private bool CheckIfUserExists(string userID)
        {
            // Your code to check if the user exists in the database goes here
            // Return true if the user exists, false otherwise
            return false; // Placeholder, replace with your actual implementation
        }
        private void AddUser()
        {
            // Retrieve user input
            string userId = UserIDTextBox.Text;
            string password = PasswordTextBox.Text;
            string email = EmailTextBox.Text;
            string role = "";

            bool userExists = CheckIfUserExists(UserIDTextBox.Text);

            // If the user already exists, display a formal warning message
            if (userExists)
            {
                MessageBox.Show("The provided User ID already exists. Please choose a different User ID.", "User ID Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method to prevent further execution
            }

            if (UserRadioButton.Checked)
            {
                role = "User";
            }
            else if (AdminRadioButton.Checked)
            {
                role = "Admin";
            }

            // Validate email format
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Construct SQL query to insert the record
            string query = "INSERT INTO UserS (UserID, Password, Email, Role) VALUES (@UserID, @Password, @Email, @Role)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Role", role);

                    // Open the connection and execute the command
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the user was successfully added
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Optionally, refresh the UI or update the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Failed to add user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to validate email format
        private bool IsValidEmail(string email)
        {
            // Regular expression pattern for validating email format
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, pattern);
        }
    private void UserDeleteButton()
        {
            // Prompt the user to confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Retrieve the UserID of the user to be deleted
                string userIdToDelete = UserIDTextBox.Text;

                // Construct the SQL query to delete the user
                string connectionString = "Data Source=MSI;Initial Catalog=CRUD;Integrated Security=True";
                string query = "DELETE FROM UserS WHERE UserID = @UserID";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@UserID", userIdToDelete);

                        // Open the connection and execute the command
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if the user was successfully deleted
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Optionally, refresh the UI or update the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("User not found or could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
    }

    private void UserEditButton()
        {
            string userId = UserIDTextBox.Text;
            string newPassword = PasswordTextBox.Text;
            string newEmail = EmailTextBox.Text;
            string newRole = UserRadioButton.Checked ? "User" : "Admin"; // Determine the role based on the selected radio button

            // Validate the email format
            if (!IsValidEmail(newEmail))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Construct the SQL query to update user information
            string connectionString = "Data Source=MSI;Initial Catalog=CRUD;Integrated Security=True";
            string query = "UPDATE UserS SET Password = @Password, Email = @Email, Role = @Role WHERE UserID = @UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@Password", newPassword);
                    command.Parameters.AddWithValue("@Email", newEmail);
                    command.Parameters.AddWithValue("@Role", newRole);

                    // Open the connection and execute the command
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the user information was successfully updated
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Optionally, refresh the UI or update the DataGridView
                    }
                    else
                    {
                        MessageBox.Show("User not found or could not be updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user information: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void PopulateDataGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM RealTime WHERE Status = 'Online'", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    ComputersStatisDataGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void RefreshDataGridView()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter UserSAdapter = new SqlDataAdapter("SELECT * FROM UserS", connection);
                DataTable UserSdataTable = new DataTable();
                UserSAdapter.Fill(UserSdataTable);
                UsersDataGridView.DataSource = UserSdataTable;

                SqlDataAdapter ComputersAdapter = new SqlDataAdapter("SELECT * FROM Computers", connection);
                DataTable ComputersdataTable = new DataTable();
                ComputersAdapter.Fill(ComputersdataTable);
                ComputersDatagridView.DataSource = ComputersdataTable;

                SqlDataAdapter RealTimeAdapter = new SqlDataAdapter("SELECT * FROM RealTime", connection);
                DataTable RealTimedataTable = new DataTable();
                RealTimeAdapter.Fill(RealTimedataTable);
                ComputersDatagridView.DataSource = RealTimedataTable;

            }
        }

        




    private void SideMenuPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
   

        }
        private void LogsReportsButton_Click(object sender, EventArgs e)
        {
            showSubMenu(LogsReportsSubMenuPanel);
        }
        private void ManagementButton_Click(object sender, EventArgs e)
        {
            showSubMenu(ManagementSubMenuPanel);
            RefreshDataGridView();


        }

        private void SettingsMaintenanceButton_Click(object sender, EventArgs e)
        {
            showSubMenu(SettingsMaintenanceSubMenuPanel);

        }

        private void AlertsSupport_Click(object sender, EventArgs e)
        {
            showSubMenu(AlertsSupportSubMenuPanel);
        }

        private void UsersButton_Click(object sender, EventArgs e)
        {
            UsersPanel.BringToFront();
            UserRadioButton.Checked = true;

            AutoHideTransaction();
            ColorButtonMaroon();
        }

        private void ComputersButton_Click(object sender, EventArgs e)
        {
            
            LoadComputerInformation();
            ComputersPanel.BringToFront();
            AutoHideTransaction();
            ColorButtonMaroon(); 
        }

        private void StorageManagementButton_Click(object sender, EventArgs e)
        {
            PopulateComboBox();
            AutoHideTransaction();
            StoragePanel.BringToFront();
            NewRadioButton.Checked = true;
            BorrowNewRadioButton.Checked = true;
            panel4.Visible = false;

            ColorButtonMaroon();
        }

        private void RealTimeButton_Click_1(object sender, EventArgs e)
        {
            LoadComputerInformation();
            ComputersStatusPanel.BringToFront();
            AutoHideTransaction();
            ColorButtonMaroon();


            PopulateDataGridView();
        }

        private void UsageReportsButton_Click(object sender, EventArgs e)
        {
            
        }

        private void UserActivityLogs_Click(object sender, EventArgs e)
        {
            
        }

        private void ComputerUsageLogs_Click(object sender, EventArgs e)
        {
            
        }

        private void GeneralSettingsButton_Click(object sender, EventArgs e)
        {
            
        }

        private void NotificationPreferenceButton_Click(object sender, EventArgs e)
        {
            
        }

        private void SystemMaintenance_Click(object sender, EventArgs e)
        {
            
        }

        private void HelpSupportButton_Click(object sender, EventArgs e)
        {
            
        }

        private void AlertsNotificationButton_Click(object sender, EventArgs e)
        {
            
        }



        private void AdminForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cRUDDataSet.UserS' table. You can move, or remove it, as needed.
            this.userSTableAdapter.Fill(this.cRUDDataSet.UserS);
            // TODO: This line of code loads data into the 'computerLabManagementMonitoringSystemDataSet.UsersTable' table. You can move, or remove it, as needed.
            this.usersTableTableAdapter.Fill(this.computerLabManagementMonitoringSystemDataSet.UsersTable);

        }

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void ColorButton()
        {
            //User InsideButton
            if (UserTransactionLabel.Text == "Delete User" && UserTransactionLabel.Visible == true)
            {
                DeleteUserButton.BackColor = Color.Red;
            }
            else
            {
                DeleteUserButton.BackColor = Color.Maroon;
            }

            if (UserTransactionLabel.Text == "Add User" && UserTransactionLabel.Visible == true)
            {
                AddUserButton.BackColor = Color.Red;
            }
            else
            {
                AddUserButton.BackColor = Color.Maroon;
            }

            if (UserTransactionLabel.Text == "Edit User" && UserTransactionLabel.Visible == true)
            {
                EditUserButton.BackColor = Color.Red;
            }
            else
            {
                EditUserButton.BackColor = Color.Maroon;
            }

            //Management Buttons inside
            if (StorageTransactionLabel.Text == "Delete Item" && StorageTransactionLabel.Visible == true)
            {
                StorageDeleteButton.BackColor = Color.Red;
            }
            else
            {
                StorageDeleteButton.BackColor = Color.Maroon;
            }

            if (StorageTransactionLabel.Text == "Edit Item" && StorageTransactionLabel.Visible == true)
            {
                StorageEditButton.BackColor = Color.Red;
            }
            else
            {
                StorageEditButton.BackColor = Color.Maroon;
            }
            if (StorageTransactionLabel.Text == "Add Item" && StorageTransactionLabel.Visible == true)
            {
                StorageAddButton.BackColor = Color.Red;
            }
            else
            {
                StorageAddButton.BackColor = Color.Maroon;
            }
            if (StorageTransactionLabel.Text == "Borrow Item" && StorageTransactionLabel.Visible == true)
            {
                BorrowItemButton.BackColor = Color.Red;
            }
            else
            {
                BorrowItemButton.BackColor = Color.Maroon;
            }

            if(RemoveComputerLabel.Visible == true && RemoveComputerLabel.Text == "Remove Computer") 
            {
                ComputersRemoveButton.BackColor = Color.Red;
            }
            else
            {
                ComputersRemoveButton.BackColor= Color.Maroon;
            }
            

        }

        private void ColorButtonMaroon()
        {
            //Users Buttons
            EditUserButton.BackColor = Color.Maroon;
            AddUserButton.BackColor = Color.Maroon;
            DeleteUserButton.BackColor = Color.Maroon;

            //Computers Button
            RemoveComputerLabel.Text = "NA";
            ComputersRemoveButton.BackColor = Color.Maroon;

            //Storage Buttons
            StorageDeleteButton.BackColor = Color.Maroon;
            StorageEditButton.BackColor = Color.Maroon;
            StorageAddButton.BackColor = Color.Maroon;
            BorrowItemButton.BackColor = Color.Maroon;


        }

        private void AutoHideTransaction()
        {
            ComputerDataGridViewPanel.Size = new System.Drawing.Size(1584, 927);
            ComputersDatagridView.Size = new System.Drawing.Size(1508, 806);
            UserDataGridViewPanel.Size = new System.Drawing.Size(1584, 927);
            UsersDataGridView.Size = new System.Drawing.Size(1508, 806);
            StorageListPanel.Size = new System.Drawing.Size(1584, 927);
            StorageDataGridView.Size = new System.Drawing.Size(1508, 806);
            ComputersStatusDataGridViewPanel.Size = new System.Drawing.Size(1584, 927);
            ComputersStatisDataGridView.Size = new System.Drawing.Size(1508, 806);

            AddRemoveItemListHide();
        }

        private void AutoShowTransaction()
        {
            UserDataGridViewPanel.Size = new System.Drawing.Size(1036, 927);
            UsersDataGridView.Size = new System.Drawing.Size(957, 806);
            ComputerDataGridViewPanel.Size = new System.Drawing.Size(1036, 927);
            ComputersDatagridView.Size = new System.Drawing.Size(957, 806);
            StorageListPanel.Size = new System.Drawing.Size(1036, 927);
            StorageDataGridView.Size = new System.Drawing.Size(957, 806);
            ComputersStatusDataGridViewPanel.Size = new System.Drawing.Size(1036, 927);
            ComputersStatisDataGridView.Size = new System.Drawing.Size(957, 806);
        }
        private void UserDeleteButtonCustom()
        {
            PasswordTextBox.Visible = false;
            label9.Visible = false;
            pictureBox7.Visible = false;
            label10.Visible = false;
            pictureBox8.Visible = false;
            EmailTextBox.Visible = false;
            label11.Visible = false;
            UserRadioButton.Visible = false;
            AdminRadioButton.Visible = false;

            DeleteConfirmButton.Visible = true;
            EditConfirmButton.Visible = false;
            AddConfirmButton.Visible = false;



            CancelButton.Location = new System.Drawing.Point(95, 265);
        }

        private void UserOtherButtonCustom()
        {
            PasswordTextBox.Visible = true;
            label9.Visible = true;
            pictureBox7.Visible = true;
            label10.Visible = true;
            pictureBox8.Visible = true;
            EmailTextBox.Visible = true;
            label11.Visible = true;
            UserRadioButton.Visible = true;
            AdminRadioButton.Visible = true;

            DeleteConfirmButton.Visible = false;
            EditConfirmButton.Visible = true;
            AddConfirmButton.Visible = true;

            CancelButton.Location = new System.Drawing.Point(95, 629);
        }

        private void AddItemListShow()
        {
            AddRemoveItemListLabel.Visible = true;
            AddRemoveItemListTextBox.Visible = true;
            AddItemListButton.Visible = true;
            CancelItemListButton.Visible = true;

            CancelItemListButton2.Visible = false;
            RemoveItemListButton.Visible = false;
            label19.Visible = false;
            StorageComboBox.Visible = false;

            //Storage Full tRasaction
            label12.Visible = false;
            StorageQuantityTextBox.Visible = false;
            label17.Visible = false;
            NewRadioButton.Visible = false;
            OldRadioButton.Visible = false;
            DefectRadioButton.Visible = false;
            label18.Visible = false;
            label23.Visible = false;
            StoragePriceTextBox.Visible = false;
            label24.Visible = false;
            StorageSupplierTextBox.Visible = false;
            label25.Visible = false;
            StorageWarrantyDateTImePicker.Visible = false;
            StorageCancelButton.Visible = false;
            StorageEditItemButton.Visible = false;
            StorageAddItemButton.Visible = false;
            StorageDeleteItemButton.Visible = false;
            StorageBarrowItemButton.Visible = false;

            panel4.Visible = false;
        }

        private void RemoveItemListShow()
        {
            AddRemoveItemListLabel.Visible = false;
            AddRemoveItemListTextBox.Visible = false;
            AddItemListButton.Visible = false;
            CancelItemListButton.Visible = false;

            CancelItemListButton2.Visible = true;
            RemoveItemListButton.Visible = true;
            label19.Visible = true;
            StorageComboBox.Visible = true;

            //Storage Full tRasaction
            label12.Visible = false;
            StorageQuantityTextBox.Visible = false;
            label17.Visible = false;
            NewRadioButton.Visible = false;
            OldRadioButton.Visible = false;
            DefectRadioButton.Visible = false;
            label18.Visible = false;
            label23.Visible = false;
            StoragePriceTextBox.Visible = false;
            label24.Visible = false;
            StorageSupplierTextBox.Visible = false;
            label25.Visible = false;
            StorageWarrantyDateTImePicker.Visible = false;
            StorageCancelButton.Visible = false;
            StorageEditItemButton.Visible = false;
            StorageAddItemButton.Visible = false;
            StorageDeleteItemButton.Visible = false;
            StorageBarrowItemButton.Visible = false;

            panel4.Visible = false;
        }
        private void AddRemoveItemListHide()
        {
            StorageComboBox.Visible = true;
            label19.Visible = true;

            label12.Visible = true;
            StorageQuantityTextBox.Visible = true;
            label17.Visible = true;
            NewRadioButton.Visible = true;
            OldRadioButton.Visible = true;
            DefectRadioButton.Visible = true;
            label18.Visible = true;
            label23.Visible = true;
            StoragePriceTextBox.Visible = true;
            label24.Visible = true;
            StorageSupplierTextBox.Visible = true;
            label25.Visible = true;
            StorageWarrantyDateTImePicker.Visible = true;
            StorageCancelButton.Visible = true;
            StorageEditItemButton.Visible = true;
            StorageAddItemButton.Visible = true;
            StorageDeleteItemButton.Visible = true;
            StorageBarrowItemButton.Visible = true;

            AddRemoveItemListLabel.Visible = false;
            AddRemoveItemListTextBox.Visible = false;
            AddItemListButton.Visible = false;
            CancelItemListButton.Visible = false;

            CancelItemListButton2.Visible = false;
            RemoveItemListButton.Visible = false;

            panel4.Visible = false;
        }

        private void StorageAddItemListHide()
        {
            RemoveItemListButtonShow.Visible = false;
            AddItemListButtonShow.Visible = false;
            
        }
        private void StorageAddItemListShow()
        {
            RemoveItemListButtonShow.Visible = true;
            AddItemListButtonShow.Visible = true;

        }

        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            AutoShowTransaction();

            UserDeleteButtonCustom();
            UserTransactionLabel.Text = "Delete User";

            UserIDLabel.Text = "Enter User ID to Delete :";

            ColorButton();
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            AutoShowTransaction();

            AddConfirmButton.BringToFront();
            UserTransactionLabel.Text = "Add User";
            UserOtherButtonCustom();

            ColorButton();
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            AutoShowTransaction();

            EditConfirmButton.BringToFront();
            UserTransactionLabel.Text = "Edit User";
            UserOtherButtonCustom();
            UserIDLabel.Text = "Enter User ID to Edit :";

            ColorButton();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            AutoHideTransaction();
            ColorButtonMaroon();
        }

        private void EditConfirmButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Edit User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                UserEditButton();

            }
       
        }

        private void AddConfirmButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Add User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AddUser();

            }
        }

        private void DeleteConfirmButton_Click(object sender, EventArgs e)
        {
            UserDeleteButton();
        }

        private void ComputerCancelButton_Click(object sender, EventArgs e)
        {
            AutoHideTransaction();
            ColorButtonMaroon();
        }

        private void ComputersRemoveButton_Click(object sender, EventArgs e)
        {
            RemoveComputerLabel.Text = "Remove Computer";
            ColorButton();
            AutoShowTransaction();
        }


        private void StorageDeleteButton_Click(object sender, EventArgs e)
        {

            StorageTransactionLabel.Text = "Delete Item";
            ColorButton();
            AutoShowTransaction();

            AddRemoveItemListHide();
            StorageAddItemListShow(); 
        }

        private void StorageAddButton_Click(object sender, EventArgs e)
        {

            StorageAddItemButton.BringToFront();
            StorageTransactionLabel.Text = "Add Item";
            ColorButton();
            AutoShowTransaction();
            AddRemoveItemListHide();
            StorageAddItemListShow(); 
        }

        private void StorageEditButton_Click(object sender, EventArgs e)
        {
            StorageEditItemButton.BringToFront();
            StorageTransactionLabel.Text = "Edit Item";
            ColorButton();
            AutoShowTransaction();
            AddRemoveItemListHide();
            StorageAddItemListShow();
        }
        private void BorrowItemButton_Click(object sender, EventArgs e)
        {
            StorageAddItemListHide();
            AddRemoveItemListHide();
            StorageTransactionLabel.Text = "Borrow Item";
            ColorButton();

            AutoShowTransaction();
            AddRemoveItemListHide();

            panel4.Visible = true;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddItemListButtonShow_Click(object sender, EventArgs e)
        {
            AddItemListShow();
            

            AddRemoveItemListLabel.Text = "Add Item List";
        }

        private void RemoveItemListButtonShow_Click(object sender, EventArgs e)
        {
            RemoveItemListShow();
            label19.Text = "Remove Item List";
            AddRemoveItemListLabel.Text = "Remove Item List";

        }

        private void RemoveItemListButton_Click(object sender, EventArgs e)
        {
            Removetothelist();
            PopulateComboBox();
        }

        private void AddItemListButton_Click(object sender, EventArgs e)
        {
            AddNewItem();
            PopulateComboBox();
            

        }
        private void CancelItemListButton_Click(object sender, EventArgs e)
        {
            AddRemoveItemListHide();
        }

        private void CancelItemListButton2_Click(object sender, EventArgs e)
        {
            AddRemoveItemListHide();

        }


        private void AddRemoveItemListTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                PopulateComboBox();
                AddNewItem();
            }
        }

        private void StorageComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { Removetothelist();
                PopulateComboBox();
                AddNewItem();
            }
        }

        private void StorageCancelButton_Click_1(object sender, EventArgs e)
        {
            AddRemoveItemListHide();
            AutoHideTransaction();
            ColorButtonMaroon();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            PopulateDataGridView();
            RefreshDataGridView();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            AutoShowTransaction();
        }

        private void ShutdowComputerCancelButton_Click(object sender, EventArgs e)
        {
            AutoHideTransaction();
        }

        private void ComputerRemoveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to turns off the PC?", "Shut Down", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ShutdownButton();
            }
        }

        private void UserReloadButton_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void ComputerReloadButton_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void AutoRefreshDataGridVIews_Tick(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void FShutDownButton_Click(object sender, EventArgs e)
        {
            ShutdownButton();
        }
    }
}
