using Programming_03_Assignment;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Xunit;

namespace Project_Testing
{
    /// <summary>
    /// This file tests the integration of ThemeToggleHelper.
    /// </summary>

    public class ThemeToggleHelperTests
    {
        /// <summary>
        /// Tests that the session is created.
        /// </summary>
        [Fact]
        public void SessionReturnsSingletonInstance()
        {
            /// Arrange: Prepare instances for comparison.
            var session1 = ThemeToggleHelper.Session;
            var session2 = ThemeToggleHelper.Session;

            /// Assert: verify that the sessions created are not null.
            Assert.NotNull(session1);
            Assert.Same(session1, session2); /// Singleton instance
        }

        /// <summary>
        /// Tests change of DarkMode using toggle.
        /// </summary>
        [Fact]
        public void TogglesBetweenLightAndDarkThemes()
        {
            /// Arrange: Create sessions and a mock form.
            var helper = ThemeToggleHelper.Session;
            var mockForm = new Form();
            helper.RegisterForm(mockForm);

            /// Arrange: Add DarkMode to one instance and toggle DarkMode 
            /// by calling the Toggle method in another instance to compare two results.
            bool initialDarkMode = helper.IsDarkMode;
            helper.Toggle(mockForm); /// Toggle to the opposite theme.
            bool toggledDarkMode = helper.IsDarkMode;

            /// Assert: Verify first instance is not equal to second toggled instance.
            Assert.NotEqual(initialDarkMode, toggledDarkMode); /// Ensure toggled
        }

        /// <summary>
        /// Tests that the theme applied is the correct colour.
        /// </summary>
        [Fact]
        public void AppliesThemeToFormAndControls()
        {
            /// Arrange: creates new session, creates mock form, 
            /// adds var childControl with value asterisk to check color is not changed.
            var helper = ThemeToggleHelper.Session;
            var mockForm = new Form();
            var childControl = new Label { Tag = "asterisk" };
            mockForm.Controls.Add(childControl);

            /// Act: Calls ThemeToggleHelper to apply theme to the mock form.
            helper.ApplyTheme(mockForm);

            /// Arrange: Assign expected colours to the mock form text, background and asterisks.
            Color expectedBackColor = helper.IsDarkMode ? Color.Black : Color.White;
            Color expectedForeColor = helper.IsDarkMode ? Color.White : Color.Black;
            Color expectedChildColor = helper.IsDarkMode ? Color.Red : Color.Red;

            /// Assert: Check that colours equal expected outcome once DarkMode is applied.
            Assert.Equal(expectedBackColor, mockForm.BackColor);
            Assert.Equal(expectedForeColor, mockForm.ForeColor);
            /// Assert: Verify label with "asterisk" tag is still red.
            Assert.Equal(expectedChildColor, childControl.ForeColor);
        }

        /// <summary>
        /// Tests that forms are registered correctly for theme management across different forms.
        /// </summary>
        [Fact]
        public void RegisterFormAddsFormToOpenForms()
        {
            /// Arrange: Creates new session and mock form.
            var helper = ThemeToggleHelper.Session;
            var mockForm = new Form();

            /// Act: Registers forms to check if theme is applied to the mock form.
            helper.RegisterForm(mockForm);

            /// Act: Use reflection to access the private field "openForms" in the ThemeToggleHelper class.
            /// This is necessary because "openForms" is private and cannot be accessed directly during testing.
            var openFormsField = typeof(ThemeToggleHelper).GetField("openForms", System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Instance);

            /// Act: Retrieve the value of the "openForms" field from the helper instance.
            /// The field is expected to be a List<Form>, so we cast it accordingly.
            var openForms = (List<Form>)openFormsField?.GetValue(helper);

            /// Assert: Verify that the mockForm is included in the openForms list.
            /// This ensures that the RegisterForm method correctly adds the form to the list.
            Assert.Contains(mockForm, openForms);
        }

    }
}