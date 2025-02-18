using System;
using System.Data;
using System.Drawing.Printing;
using System.Text;

namespace Programming_03_Assignment
{
    /// <summary>
    /// Represents the client page, providing functionality to display and manage client data.
    /// </summary>
    public partial class ClientPage : Form
    {
        /// <summary>
        /// Intialises a new instance of the <see cref="ClientPage"/> class.
        /// </summary>
        public ClientPage()
        {
            InitializeComponent();

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
        /// Handles the <c>form load</c> event. Fetches and displays client data.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void ClientPage_Load(object sender, EventArgs e)
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
                lblWelcome.Text = $"Welcome {client.Forename} {client.Surname}.";

                // Fetch user-specific data
                List<Client> userData = dbHelper.GetUserData(userId);

                if (userData != null && userData.Count > 0)
                {
                    DisplayClient(userData);
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
        }

        /// <summary>
        /// Displays client data in the DataGridView.
        /// </summary>
        /// <param name="clients">A list of clients to display.</param>
        private void DisplayClient(List<Client> clients)
        {
            if (clients == null || clients.Count == 0)
            {
                MessageBox.Show("No results found.");
                return;
            }

            DataTable clientTable = ClientDataHelper.GenerateClientDataTable(clients[0]);

            dataGridUserView.DataSource = clientTable;

            // Formats boolean fields in the DataGridView as checkboxes.
            foreach (DataGridViewRow row in dataGridUserView.Rows)
            {
                if (row.Cells["Field"].Value != null)
                {
                    string? fieldValue = row.Cells["Field"].Value?.ToString();

                    // Check if the field is one of the boolean fields
                    if (fieldValue == "Software" || fieldValue == "LaptopsPC" || fieldValue == "Games" || fieldValue == "OfficeTools" || fieldValue == "Accessories")
                    {
                        // Set the cell to a checkbox cell with the boolean value
                        bool currentValue = row.Cells["Value"].Value != DBNull.Value && Convert.ToBoolean(row.Cells["Value"].Value);
                        row.Cells["Value"] = new DataGridViewCheckBoxCell { Value = currentValue };

                        // Center the checkbox cell by setting its alignment
                        row.Cells["Value"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the <c>Download</c> button click event. Exports DataGridView data to a CSV file.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*",
                Title = "Save Data as CSV"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                CSVHelper.ExportDataGridViewToCsv(dataGridUserView, filePath);
            }
        }      

        /// <summary>
        /// Handles the <c>Print</c> button click event. Prints DataGridView content.
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
            var printer = new DataGridPrinter(dataGridUserView);
            printer.PrintGridView(e);
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
