using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_03_Assignment
{
    /// <summary>
    /// Provides helper methods for form navigation and common actions like exit confirmation.
    /// </summary>
    public static class NavigationHelper
    {
        /// <summary>
        /// Navigates to a new form and hides the current form.
        /// </summary>
        /// <param name="currentForm">The current form to hide.</param>
        /// <param name="nextForm">The new form to navigate to.</param>
        public static void NavigateToForm(Form currentForm, Form nextForm)
        {
            if (nextForm == null || currentForm == null) throw new ArgumentNullException();

            // Apply the theme to the next form.
            ThemeToggleHelper.Session.ApplyTheme(nextForm);

            // Show the next form.
            nextForm.Show();

            // Hide the current form.
            currentForm.Hide();

            // Set up the closing event to ensure current form closes.
            nextForm.FormClosed += (s, args) => currentForm.Close();
        }

        /// <summary>
        /// Displays an exit confirmation dialog and closes the form if confirmed.
        /// </summary>
        /// <param name="currentForm">The current form to close.</param>
        public static void ConfirmAndExit(Form currentForm)
        {
            ArgumentNullException.ThrowIfNull(currentForm);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                currentForm.Close();
            }
        }
    }
}
