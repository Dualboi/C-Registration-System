using Microsoft.Data.Sqlite;
using System;
using static Programming_03_Assignment.ValidationHelper;

namespace Programming_03_Assignment
{
    /// <summary>
    /// Represents the registration page for new users.
    /// </summary>
    public partial class RegisterPage : Form
    {
        /// <summary>
        /// Intialises a new instance of the <see cref="RegisterPage"/> class.
        /// </summary>
        public RegisterPage()
        {
            InitializeComponent();

            // Set placeholder text for inputs.
            txtForename.PlaceholderText = "Forename";
            txtSurname.PlaceholderText = "Surname";
            txtEmail.PlaceholderText = "Email";
            txtEmailConfirm.PlaceholderText = "Confirm email";
            txtPassword.PlaceholderText = "Password";
            txtPasswordConfirm.PlaceholderText = "Confirm password";
            txtPhone.PlaceholderText = "Phone Number";
            txtAddress.PlaceholderText = "Street";
            txtCity.PlaceholderText = "City";
            txtPostcode.PlaceholderText = "Postcode";
            txtPassword.PasswordChar = '*';
            txtPasswordConfirm.PasswordChar = '*';

            // Apply the current theme and register the form.
            ThemeToggleHelper.Session.RegisterForm(this);
            btnThemeToggle.Text = ThemeToggleHelper.Session.IsDarkMode
                ? "🌙"
                : "☀";
        }

        /// <summary>
        /// Handles the <c>Register</c> button click event. Validates inputs and registers a new client.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnRegisterSubmit_Click(object sender, EventArgs e)
        {
            var data = new RegistrationData
            {
                Forename = txtForename.Text.Trim(),
                Surname = txtSurname.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                EmailConfirm = txtEmailConfirm.Text.Trim(),
                Password = txtPassword.Text,
                PasswordConfirm = txtPasswordConfirm.Text,
                PhoneNumber = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                City = txtCity.Text.Trim(),
                Postcode = txtPostcode.Text.Trim(),
                Software = chkSoftware.Checked,
                LaptopsPC = chkLaptopsPC.Checked,
                Games = chkGames.Checked,
                OfficeTools = chkOfficeTools.Checked,
                Accessories = chkAccessories.Checked
            };

            // Validate user input.
            var errors = ValidationHelper.Validate(data);

            if (errors.Count > 0)
            {
                // If you have multiple errors, you can join them into a single message, or show them individually
                MessageBox.Show(string.Join("\n", errors), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DatabaseHelper dbHelper = new();

                // Check if the email already exists.
                if (dbHelper.EmailExists(data.Email))
                {
                    MessageBox.Show("An account with this email already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create and insert a new client object with the user inputs.
                Client client = new()
                {
                    Forename = data.Forename,
                    Surname = data.Surname,
                    EmailAddress = data.Email,
                    PhoneNumber = data.PhoneNumber,
                    HashedPassword = data.Password,
                    Address = data.Address,
                    City = data.City,
                    Postcode = data.Postcode,
                    Software = data.Software,
                    LaptopsPC = data.LaptopsPC,
                    Games = data.Games,
                    OfficeTools = data.OfficeTools,
                    Accessories = data.Accessories
                };

                int rowsAffected = dbHelper.InsertClient(client);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Navigate to the IndexPage.
                    IndexPage homePage = new();
                    ThemeToggleHelper.Session.ApplyTheme(homePage);
                    homePage.Show();
                    this.Hide();
                    homePage.FormClosed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("An error occurred while submitting data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqliteException sqlEx)
            {
                MessageBox.Show("A database error occurred:\n" + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
   
