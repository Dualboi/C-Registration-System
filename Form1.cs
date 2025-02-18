using Microsoft.Data.Sqlite;
using Windows.Media.Protection.PlayReady;

namespace Programming_03_Assignment
{
    /// <summary>
    /// Represents the main index page of the application, providing login functionality.
    /// </summary>
    public partial class IndexPage : Form
    {
        /// <summary>
        /// Intialises a new instance of the <see cref="IndexPage"/> class.
        /// </summary>
        public IndexPage()
        {
            InitializeComponent();

            // Set placeholder text and password character masking.
            txtEmail.PlaceholderText = "Enter your email";
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.PasswordChar = '*';

            // Apply the current theme and register the form.
            ThemeToggleHelper.Session.ApplyTheme(this);
            ThemeToggleHelper.Session.RegisterForm(this);
            btnThemeToggle.Text = ThemeToggleHelper.Session.IsDarkMode
                ? "🌙"
                : "☀";
        }

        /// <summary>
        ///  Handles the <c>Register</c> button click event. Navigates to the registration form.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Create an instance of RegisterPage and closes this page.
            RegisterPage registerPage = new();

            ThemeToggleHelper.Session.ApplyTheme(registerPage);

            registerPage.Show();

            this.Hide();

            registerPage.FormClosed += (s, args) => this.Close();
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
        /// Handles the <c>Submit</c> button click event. Validates user credentials and navigates to the appropriate page.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            try
            {
                DatabaseHelper dbHelper = new();
                Client user = dbHelper.ValidateUser(email, password);

                if (user != null)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Store the client ID in the session.
                    SessionManager.CurrentClientID = user.ClientID;

                    // Navigates to the appropriate page based on the user's role.
                    if (user.IsAdmin)
                    {
                        // Navigate to the admin form.
                        AdminPage adminPage = new();
                        ThemeToggleHelper.Session.ApplyTheme(adminPage);
                        adminPage.Show();
                        this.Hide();
                        adminPage.FormClosed += (s, args) => this.Close();
                    }
                    else
                    {
                        // Navigate to the client form.
                        ClientPage clientPage = new();
                        ThemeToggleHelper.Session.ApplyTheme(clientPage);
                        clientPage.Show();
                        this.Hide();
                        clientPage.FormClosed += (s, args) => this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// Handles the <c>Theme Toggle</c> button click event. Toggles the application's theme.
        /// </summary>
        /// <param name="sender">Contains reference to object that raised event.</param>
        /// <param name="e">Contains event data.</param>
        private void btnThemeToggle_Click(object sender, EventArgs e)
        {
            ThemeToggleHelper.Session.Toggle(this);

            btnThemeToggle.Text = ThemeToggleHelper.Session.IsDarkMode
                ? "🌙"
    :           "☀";
        }
    }
}   
