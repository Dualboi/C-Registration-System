using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_03_Assignment
{
    /// <summary>
    /// A helper class for toggling between light and dark themes on multiple forms.
    /// </summary>
    public class ThemeToggleHelper
    {
        // Singleton session instance for helper.
        private static ThemeToggleHelper? session;

        /// <summary>
        /// Gets the singleton instance of the helper class.
        /// </summary>
        public static ThemeToggleHelper Session => session ??= new();

        // Colours for dark theme.
        private readonly Color darkBGColour = Color.Black;
        private readonly Color darkFGColour = Color.White;

        // Colours for light theme.
        private readonly Color lightBGColour = Color.White;
        private readonly Color lightFGColour = Color.Black;

        /// <summary>
        /// A list of forms that are currently open and have the theme applied.
        /// </summary>
        private readonly List<Form> openForms = [];

        /// <summary>
        /// Gets or sets if dark mode is enabled.
        /// </summary>
        public bool IsDarkMode { get; private set; } = false;

        /// <summary>
        /// Creates a new instance of the helper class.
        /// Loads the currently set default theme from settings.
        /// </summary>
        private ThemeToggleHelper()
        {
            IsDarkMode = Properties.Settings.Default.Theme;
        }

        /// <summary>
        /// Registers forms to check if the theme is applied.
        /// Removes the form when it is closed.
        /// </summary>
        /// <param name="form">The form that is registered.</param>
        public void RegisterForm(Form form)
        {
            if (!openForms.Contains(form))
            {
                openForms.Add(form);
                form.FormClosed += (s, args) => openForms.Remove(form);
            }
        }

        /// <summary>
        /// Toggles between themes, applying the current theme to all registered forms.
        /// </summary>
        /// <param name="_">Required for compatibility with some event handlers.</param>
        public void Toggle(Form _)
        {
            IsDarkMode = !IsDarkMode;

            foreach (var form in openForms)
            {
                ApplyTheme(form, IsDarkMode ? darkBGColour : lightBGColour, IsDarkMode ? darkFGColour : lightFGColour);
            }

            Properties.Settings.Default.Theme = IsDarkMode;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Applies current theme to new form on form change.
        /// </summary>
        /// <param name="form">The form that the theme will be applied to.</param>
        public void ApplyTheme(Form form)
        {
            ApplyTheme(form, IsDarkMode ? darkBGColour : lightBGColour, IsDarkMode ? darkFGColour : lightFGColour);
        }

        /// <summary>
        /// Using recursion, this applies the back/foreground colours to a control and its children.
        /// </summary>
        /// <param name="control">The control to apply the theme.</param>
        /// <param name="backColour">The background colour variable.</param>
        /// <param name="foreColour">The foreground colour variable.</param>
        private static void ApplyTheme(Control control, Color backColour, Color foreColour)
        {
            if (control is DataGridView dgv)
            {
                dgv.BackgroundColor = backColour;
                dgv.DefaultCellStyle.BackColor = backColour;
                dgv.DefaultCellStyle.ForeColor = foreColour;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = backColour;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = foreColour;
                dgv.RowHeadersDefaultCellStyle.BackColor = backColour;
                dgv.RowHeadersDefaultCellStyle.ForeColor = foreColour;
                dgv.GridColor = foreColour; 
            }
            else
            {
                control.BackColor = backColour;
                control.ForeColor = foreColour;
            }

            if (control.HasChildren)
            {
                foreach (Control childControl in control.Controls)
                {
                    ApplyTheme(childControl, backColour, foreColour);
                }
            }

            // Turns labels tagged "asterisk" red.
            if (control is Label lbl && lbl.Tag?.ToString() == "asterisk")
            {
                lbl.ForeColor = ThemeToggleHelper.Session.IsDarkMode ? Color.Red : Color.Red;
            }
        }
    }
}
