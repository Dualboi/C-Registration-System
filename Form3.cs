using System;
using System.Data;
using System.Drawing.Printing;

namespace Programming_03_Assignment
{
    /// <summary>
    /// Represents the administrative page for managing client data.
    /// </summary>
    public partial class AdminPage : Form
    {
        private bool isAscending = true; // Default sorting order

        /// <summary>
        /// Intialises a new instance of the <see cref="AdminPage"/> class.
        /// </summary>
        public AdminPage()
        {
            InitializeComponent();

            txtSearch.PlaceholderText = "Search";

            // Register form for theme management.
            ThemeToggleHelper.Session.RegisterForm(this);
            btnThemeToggle.Text = ThemeToggleHelper.Session.IsDarkMode
                ? "🌙"
                : "☀";
        }

        /// <summary>
        /// Handles the <c>Home</c> button click event. Navigates back to the IndexPage.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnHome_Click(object sender, EventArgs e)
        {
            SessionManager.ClearSession();
            NavigationHelper.NavigateToForm(this, new IndexPage());
        }

        /// <summary>
        /// Handles the <c>Exit</c> button click event. Confirms and exits the application.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            NavigationHelper.ConfirmAndExit(this);
        }

        /// <summary>
        /// Loads client data and populates the combo box with filter options.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void AdminPage_Load(object sender, EventArgs e)
        {
            int userId = SessionManager.CurrentClientID;

            if (userId <= 0)
            {
                MessageBox.Show("You must log in first.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            DatabaseHelper dbHelper = new();
            Client client = dbHelper.GetClientById(userId);

            if (client != null)
            {
                // Display the user's data
                lblAdmin.Text = $"Welcome {client.Forename} {client.Surname}.";

                // Fetch user-specific data
                List<Client> userData = dbHelper.GetUserData();

                if (userData != null && userData.Count > 0)
                {
                    DisplayClients(userData);
                }
                else
                {
                    MessageBox.Show("No data found for the user.");
                }
            }
            else
            {
                MessageBox.Show("User data could not be retrieved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            PopulateFieldsComboBox();
        }

        /// <summary>
        /// Handles the <c>Client Submit</c> button click event. Searches for clients by forename.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnClientSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string forename = txtSearch.Text;

                if (string.IsNullOrEmpty(forename))
                {
                    MessageBox.Show("Please enter a forename to search.");
                    return;
                }

                DatabaseHelper dbHelper = new();
                List<Client> clients = dbHelper.GetUserData(forename: forename);

                DisplayClients(clients);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Displays a list of clients in the DataGridView.
        /// </summary>
        /// <param name="clients">The clients data to display.</param>
        private void DisplayClients(List<Client> clients)
        {
            if (clients == null || clients.Count == 0)
            {
                MessageBox.Show("No results found.");
                return;
            }

            DataTable adminTable = ClientDataHelper.GenerateAdminDataTable(clients);

            dataGridAdminView.DataSource = adminTable;
        }

        /// <summary>
        /// Handles the <c>Reset</c> button click event. Resets the search/filter and displays all clients.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                // Fetch all clients from the database
                DatabaseHelper dbHelper = new();
                List<Client> clients = dbHelper.GetUserData();

                // Display all clients in the DataGridView
                DisplayClients(clients);

                txtSearch.Text = string.Empty; // Clear the search field

                MessageBox.Show("Search reset successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while resetting data: {ex.Message}");
            }
        }

        /// <summary>
        /// Handles the <c>Print</c> button click event. Prints the client data.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new();
            PrintDocument printDocument = new();

            printDialog.Document = printDocument;
            printDocument.PrintPage += (s, ev) => PrintGridView(ev);

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        /// <summary>
        /// Prints the DataGridView content.
        /// </summary>
        /// <param name="e">Contains event data.</param>
        private void PrintGridView(PrintPageEventArgs e)
        {
            var printer = new DataGridPrinter(dataGridAdminView);
            printer.PrintGridView(e);
        }

        /// <summary>
        /// Handles the <c>Remove</c> button click event. Deletes the selected client(s) from the database. 
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if any rows are selected.
                if (dataGridAdminView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm delete action.
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete the selected record(s)?",
                                                             "Confirm Delete",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    DatabaseHelper databaseHelper = new();

                    foreach (DataGridViewRow row in dataGridAdminView.SelectedRows)
                    {
                        // Get the client using the helper function.
                        int clientID = Convert.ToInt32(row.Cells["ClientID"].Value);

                        // Remove the client using the helper function.
                        databaseHelper.DeleteClient(clientID);

                        // Remove the row from the data grid.
                        dataGridAdminView.Rows.Remove(row);
                    }

                    MessageBox.Show("Select record(s) deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured while deleting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// Populates the filter combo box with field names.
        /// </summary>
        private void PopulateFieldsComboBox()
        {
            var fields = new List<string>
            {
            "ClientID", "Forename", "Surname", "EmailAddress", "PhoneNumber",
            "Address", "City", "Postcode", "Software", "LaptopsPC", "Games",
            "OfficeTools", "Accessories"
             };

            comboFilter.DataSource = fields;
        }

        /// <summary>
        /// Handles the <c>Filter</c> button click event. Sorts client data based on the selected field.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedField = comboFilter.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrEmpty(selectedField))
            {
                MessageBox.Show("Please select a field to sort by.");
                return;
            }

            string order = isAscending ? "ASC" : "DESC";
            isAscending = !isAscending; // Toggle order for next click

            try
            {
                var databaseHelper = new DatabaseHelper();
                var sortedClients = databaseHelper.GetSortedData(selectedField, order);

                // Assuming you are using a DataGridView to display data
                dataGridAdminView.DataSource = sortedClients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        /// <summary>
        /// Handles the <c>Theme Toggle</c> button click event. Toggles the application theme.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnThemeToggle_Click(object sender, EventArgs e)
        {
            ThemeToggleHelper.Session.Toggle(this);

            btnThemeToggle.Text = ThemeToggleHelper.Session.IsDarkMode
                ? "🌙"
                : "☀";
        }
    }
}
