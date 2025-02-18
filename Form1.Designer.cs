namespace Programming_03_Assignment
{
    partial class IndexPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblLogin = new Label();
            txtEmail = new TextBox();
            btnSubmit = new Button();
            lblRegister = new Label();
            btnRegister = new Button();
            txtPassword = new TextBox();
            btnExit = new Button();
            lblWelcome = new Label();
            btnThemeToggle = new Button();
            toggleTip = new ToolTip(components);
            lblAdminInstructions = new Label();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogin.Location = new Point(461, 147);
            lblLogin.Margin = new Padding(4, 0, 4, 0);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(99, 45);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Login";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(326, 215);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(350, 39);
            txtEmail.TabIndex = 1;
            // 
            // btnSubmit
            // 
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSubmit.Location = new Point(434, 403);
            btnSubmit.Margin = new Padding(4, 5, 4, 5);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(150, 67);
            btnSubmit.TabIndex = 3;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Location = new Point(381, 527);
            lblRegister.Margin = new Padding(4, 0, 4, 0);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(288, 25);
            lblRegister.TabIndex = 0;
            lblRegister.Text = "Not a current user? Register below!";
            // 
            // btnRegister
            // 
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegister.Location = new Point(434, 580);
            btnRegister.Margin = new Padding(4, 5, 4, 5);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(150, 67);
            btnRegister.TabIndex = 4;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(326, 317);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(350, 39);
            txtPassword.TabIndex = 2;
            // 
            // btnExit
            // 
            btnExit.Cursor = Cursors.Hand;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(901, 663);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(150, 67);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(176, 22);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(706, 81);
            lblWelcome.TabIndex = 7;
            lblWelcome.Text = "SME Product Registration";
            // 
            // btnThemeToggle
            // 
            btnThemeToggle.Cursor = Cursors.Hand;
            btnThemeToggle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemeToggle.Location = new Point(1003, 20);
            btnThemeToggle.Margin = new Padding(4, 5, 4, 5);
            btnThemeToggle.Name = "btnThemeToggle";
            btnThemeToggle.Size = new Size(56, 67);
            btnThemeToggle.TabIndex = 8;
            toggleTip.SetToolTip(btnThemeToggle, "Switch between light-mode and dark-mode.");
            btnThemeToggle.UseVisualStyleBackColor = true;
            btnThemeToggle.Click += btnThemeToggle_Click;
            // 
            // toggleTip
            // 
            toggleTip.ToolTipTitle = "Toggle Theme";
            // 
            // lblAdminInstructions
            // 
            lblAdminInstructions.AutoSize = true;
            lblAdminInstructions.Location = new Point(176, 686);
            lblAdminInstructions.Name = "lblAdminInstructions";
            lblAdminInstructions.Size = new Size(703, 25);
            lblAdminInstructions.TabIndex = 9;
            lblAdminInstructions.Text = "To access the admin dashboard, create an account with the \"@SME.com\" email domain.";
            // 
            // IndexPage
            // 
            AcceptButton = btnSubmit;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(1073, 738);
            Controls.Add(lblAdminInstructions);
            Controls.Add(btnThemeToggle);
            Controls.Add(lblWelcome);
            Controls.Add(btnExit);
            Controls.Add(txtPassword);
            Controls.Add(btnRegister);
            Controls.Add(lblRegister);
            Controls.Add(btnSubmit);
            Controls.Add(txtEmail);
            Controls.Add(lblLogin);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 5, 4, 5);
            MaximumSize = new Size(1095, 794);
            Name = "IndexPage";
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Page";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private TextBox txtEmail;
        private Button btnSubmit;
        private Label lblRegister;
        private Button btnRegister;
        private TextBox txtPassword;
        private Button btnExit;
        private Label lblWelcome;
        private Button btnThemeToggle;
        private ToolTip toolTip1;
        private ToolTip toggleTip;
        private Label lblAdminInstructions;
    }
}
