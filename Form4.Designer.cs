namespace Programming_03_Assignment
{
    partial class RegisterPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblForm = new Label();
            txtForename = new TextBox();
            txtSurname = new TextBox();
            txtEmail = new TextBox();
            txtEmailConfirm = new TextBox();
            txtPassword = new TextBox();
            txtPasswordConfirm = new TextBox();
            txtCity = new TextBox();
            txtAddress = new TextBox();
            txtPostcode = new TextBox();
            btnRegisterSubmit = new Button();
            btnHome = new Button();
            btnExit = new Button();
            txtPhone = new TextBox();
            chkSoftware = new CheckBox();
            chkLaptopsPC = new CheckBox();
            chkGames = new CheckBox();
            chkOfficeTools = new CheckBox();
            chkAccessories = new CheckBox();
            lblRegisterProducts = new Label();
            lblForenameAsterisk = new Label();
            lblConfirmPasswordAsterisk = new Label();
            lblPasswordAsterisk = new Label();
            lblSurnameAsterisk = new Label();
            lblConfirmEmailAsterisk = new Label();
            lblEmailAsterisk = new Label();
            lblPhoneAsterisk = new Label();
            lblCityAsterisk = new Label();
            lblAddressAsterisk = new Label();
            lblPostcodeAsterisk = new Label();
            btnThemeToggle = new Button();
            toggleTip = new ToolTip(components);
            SuspendLayout();
            // 
            // lblForm
            // 
            lblForm.AutoSize = true;
            lblForm.Font = new Font("Segoe UI", 24F, FontStyle.Underline, GraphicsUnit.Point, 0);
            lblForm.Location = new Point(125, 38);
            lblForm.Name = "lblForm";
            lblForm.Size = new Size(349, 45);
            lblForm.TabIndex = 1;
            lblForm.Text = "Account Creation Form";
            // 
            // txtForename
            // 
            txtForename.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtForename.Location = new Point(34, 114);
            txtForename.Name = "txtForename";
            txtForename.Size = new Size(246, 29);
            txtForename.TabIndex = 0;
            // 
            // txtSurname
            // 
            txtSurname.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSurname.Location = new Point(308, 114);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(246, 29);
            txtSurname.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(34, 171);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(246, 29);
            txtEmail.TabIndex = 2;
            // 
            // txtEmailConfirm
            // 
            txtEmailConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmailConfirm.Location = new Point(308, 171);
            txtEmailConfirm.Name = "txtEmailConfirm";
            txtEmailConfirm.Size = new Size(246, 29);
            txtEmailConfirm.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(34, 225);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(246, 29);
            txtPassword.TabIndex = 4;
            // 
            // txtPasswordConfirm
            // 
            txtPasswordConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPasswordConfirm.Location = new Point(308, 225);
            txtPasswordConfirm.Name = "txtPasswordConfirm";
            txtPasswordConfirm.Size = new Size(246, 29);
            txtPasswordConfirm.TabIndex = 5;
            // 
            // txtCity
            // 
            txtCity.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCity.Location = new Point(34, 337);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(246, 29);
            txtCity.TabIndex = 8;
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtAddress.Location = new Point(308, 284);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(246, 29);
            txtAddress.TabIndex = 7;
            // 
            // txtPostcode
            // 
            txtPostcode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPostcode.Location = new Point(308, 337);
            txtPostcode.Name = "txtPostcode";
            txtPostcode.Size = new Size(246, 29);
            txtPostcode.TabIndex = 9;
            // 
            // btnRegisterSubmit
            // 
            btnRegisterSubmit.Cursor = Cursors.Hand;
            btnRegisterSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRegisterSubmit.Location = new Point(182, 388);
            btnRegisterSubmit.Name = "btnRegisterSubmit";
            btnRegisterSubmit.Size = new Size(224, 40);
            btnRegisterSubmit.TabIndex = 15;
            btnRegisterSubmit.Text = "Submit";
            btnRegisterSubmit.UseVisualStyleBackColor = true;
            btnRegisterSubmit.Click += btnRegisterSubmit_Click;
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.Location = new Point(631, 12);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(105, 40);
            btnHome.TabIndex = 16;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnExit
            // 
            btnExit.Cursor = Cursors.Hand;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(636, 398);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(105, 40);
            btnExit.TabIndex = 17;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPhone.Location = new Point(34, 284);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(246, 29);
            txtPhone.TabIndex = 6;
            // 
            // chkSoftware
            // 
            chkSoftware.AutoSize = true;
            chkSoftware.Location = new Point(607, 116);
            chkSoftware.Margin = new Padding(2);
            chkSoftware.Name = "chkSoftware";
            chkSoftware.Size = new Size(72, 19);
            chkSoftware.TabIndex = 10;
            chkSoftware.Text = "Software";
            chkSoftware.UseVisualStyleBackColor = true;
            // 
            // chkLaptopsPC
            // 
            chkLaptopsPC.AutoSize = true;
            chkLaptopsPC.Location = new Point(607, 174);
            chkLaptopsPC.Margin = new Padding(2);
            chkLaptopsPC.Name = "chkLaptopsPC";
            chkLaptopsPC.Size = new Size(93, 19);
            chkLaptopsPC.TabIndex = 11;
            chkLaptopsPC.Text = "Laptops/PCs";
            chkLaptopsPC.UseVisualStyleBackColor = true;
            // 
            // chkGames
            // 
            chkGames.AutoSize = true;
            chkGames.Location = new Point(607, 227);
            chkGames.Margin = new Padding(2);
            chkGames.Name = "chkGames";
            chkGames.Size = new Size(62, 19);
            chkGames.TabIndex = 12;
            chkGames.Text = "Games";
            chkGames.UseVisualStyleBackColor = true;
            // 
            // chkOfficeTools
            // 
            chkOfficeTools.AutoSize = true;
            chkOfficeTools.Location = new Point(607, 287);
            chkOfficeTools.Margin = new Padding(2);
            chkOfficeTools.Name = "chkOfficeTools";
            chkOfficeTools.Size = new Size(89, 19);
            chkOfficeTools.TabIndex = 13;
            chkOfficeTools.Text = "Office Tools";
            chkOfficeTools.UseVisualStyleBackColor = true;
            // 
            // chkAccessories
            // 
            chkAccessories.AutoSize = true;
            chkAccessories.Location = new Point(607, 341);
            chkAccessories.Margin = new Padding(2);
            chkAccessories.Name = "chkAccessories";
            chkAccessories.Size = new Size(87, 19);
            chkAccessories.TabIndex = 14;
            chkAccessories.Text = "Accessories";
            chkAccessories.UseVisualStyleBackColor = true;
            // 
            // lblRegisterProducts
            // 
            lblRegisterProducts.AutoSize = true;
            lblRegisterProducts.Location = new Point(560, 77);
            lblRegisterProducts.Margin = new Padding(2, 0, 2, 0);
            lblRegisterProducts.Name = "lblRegisterProducts";
            lblRegisterProducts.Size = new Size(170, 15);
            lblRegisterProducts.TabIndex = 30;
            lblRegisterProducts.Text = "Register a product or products.";
            // 
            // lblForenameAsterisk
            // 
            lblForenameAsterisk.AutoSize = true;
            lblForenameAsterisk.ForeColor = Color.Red;
            lblForenameAsterisk.Location = new Point(15, 119);
            lblForenameAsterisk.Margin = new Padding(2, 0, 2, 0);
            lblForenameAsterisk.Name = "lblForenameAsterisk";
            lblForenameAsterisk.Size = new Size(12, 15);
            lblForenameAsterisk.TabIndex = 31;
            lblForenameAsterisk.Tag = "asterisk";
            lblForenameAsterisk.Text = "*";
            // 
            // lblConfirmPasswordAsterisk
            // 
            lblConfirmPasswordAsterisk.AutoSize = true;
            lblConfirmPasswordAsterisk.ForeColor = Color.Red;
            lblConfirmPasswordAsterisk.Location = new Point(289, 176);
            lblConfirmPasswordAsterisk.Margin = new Padding(2, 0, 2, 0);
            lblConfirmPasswordAsterisk.Name = "lblConfirmPasswordAsterisk";
            lblConfirmPasswordAsterisk.Size = new Size(12, 15);
            lblConfirmPasswordAsterisk.TabIndex = 32;
            lblConfirmPasswordAsterisk.Tag = "asterisk";
            lblConfirmPasswordAsterisk.Text = "*";
            // 
            // lblPasswordAsterisk
            // 
            lblPasswordAsterisk.AutoSize = true;
            lblPasswordAsterisk.ForeColor = Color.Red;
            lblPasswordAsterisk.Location = new Point(15, 176);
            lblPasswordAsterisk.Margin = new Padding(2, 0, 2, 0);
            lblPasswordAsterisk.Name = "lblPasswordAsterisk";
            lblPasswordAsterisk.Size = new Size(12, 15);
            lblPasswordAsterisk.TabIndex = 33;
            lblPasswordAsterisk.Tag = "asterisk";
            lblPasswordAsterisk.Text = "*";
            // 
            // lblSurnameAsterisk
            // 
            lblSurnameAsterisk.AutoSize = true;
            lblSurnameAsterisk.ForeColor = Color.Red;
            lblSurnameAsterisk.Location = new Point(289, 119);
            lblSurnameAsterisk.Margin = new Padding(2, 0, 2, 0);
            lblSurnameAsterisk.Name = "lblSurnameAsterisk";
            lblSurnameAsterisk.Size = new Size(12, 15);
            lblSurnameAsterisk.TabIndex = 34;
            lblSurnameAsterisk.Tag = "asterisk";
            lblSurnameAsterisk.Text = "*";
            // 
            // lblConfirmEmailAsterisk
            // 
            lblConfirmEmailAsterisk.AutoSize = true;
            lblConfirmEmailAsterisk.ForeColor = Color.Red;
            lblConfirmEmailAsterisk.Location = new Point(289, 230);
            lblConfirmEmailAsterisk.Margin = new Padding(2, 0, 2, 0);
            lblConfirmEmailAsterisk.Name = "lblConfirmEmailAsterisk";
            lblConfirmEmailAsterisk.Size = new Size(12, 15);
            lblConfirmEmailAsterisk.TabIndex = 35;
            lblConfirmEmailAsterisk.Tag = "asterisk";
            lblConfirmEmailAsterisk.Text = "*";
            // 
            // lblEmailAsterisk
            // 
            lblEmailAsterisk.AutoSize = true;
            lblEmailAsterisk.ForeColor = Color.Red;
            lblEmailAsterisk.Location = new Point(15, 230);
            lblEmailAsterisk.Margin = new Padding(2, 0, 2, 0);
            lblEmailAsterisk.Name = "lblEmailAsterisk";
            lblEmailAsterisk.Size = new Size(12, 15);
            lblEmailAsterisk.TabIndex = 36;
            lblEmailAsterisk.Tag = "asterisk";
            lblEmailAsterisk.Text = "*";
            // 
            // lblPhoneAsterisk
            // 
            lblPhoneAsterisk.AutoSize = true;
            lblPhoneAsterisk.ForeColor = Color.Red;
            lblPhoneAsterisk.Location = new Point(15, 289);
            lblPhoneAsterisk.Margin = new Padding(2, 0, 2, 0);
            lblPhoneAsterisk.Name = "lblPhoneAsterisk";
            lblPhoneAsterisk.Size = new Size(12, 15);
            lblPhoneAsterisk.TabIndex = 37;
            lblPhoneAsterisk.Tag = "asterisk";
            lblPhoneAsterisk.Text = "*";
            // 
            // lblCityAsterisk
            // 
            lblCityAsterisk.AutoSize = true;
            lblCityAsterisk.ForeColor = Color.Red;
            lblCityAsterisk.Location = new Point(15, 342);
            lblCityAsterisk.Margin = new Padding(2, 0, 2, 0);
            lblCityAsterisk.Name = "lblCityAsterisk";
            lblCityAsterisk.Size = new Size(12, 15);
            lblCityAsterisk.TabIndex = 38;
            lblCityAsterisk.Tag = "asterisk";
            lblCityAsterisk.Text = "*";
            // 
            // lblAddressAsterisk
            // 
            lblAddressAsterisk.AutoSize = true;
            lblAddressAsterisk.ForeColor = Color.Red;
            lblAddressAsterisk.Location = new Point(289, 289);
            lblAddressAsterisk.Margin = new Padding(2, 0, 2, 0);
            lblAddressAsterisk.Name = "lblAddressAsterisk";
            lblAddressAsterisk.Size = new Size(12, 15);
            lblAddressAsterisk.TabIndex = 39;
            lblAddressAsterisk.Tag = "asterisk";
            lblAddressAsterisk.Text = "*";
            // 
            // lblPostcodeAsterisk
            // 
            lblPostcodeAsterisk.AutoSize = true;
            lblPostcodeAsterisk.ForeColor = Color.Red;
            lblPostcodeAsterisk.Location = new Point(289, 343);
            lblPostcodeAsterisk.Margin = new Padding(2, 0, 2, 0);
            lblPostcodeAsterisk.Name = "lblPostcodeAsterisk";
            lblPostcodeAsterisk.Size = new Size(12, 15);
            lblPostcodeAsterisk.TabIndex = 40;
            lblPostcodeAsterisk.Tag = "asterisk";
            lblPostcodeAsterisk.Text = "*";
            // 
            // btnThemeToggle
            // 
            btnThemeToggle.Cursor = Cursors.Hand;
            btnThemeToggle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemeToggle.Location = new Point(586, 12);
            btnThemeToggle.Name = "btnThemeToggle";
            btnThemeToggle.Size = new Size(39, 40);
            btnThemeToggle.TabIndex = 41;
            toggleTip.SetToolTip(btnThemeToggle, "Switch between light-mode and dark-mode.");
            btnThemeToggle.UseVisualStyleBackColor = true;
            btnThemeToggle.Click += btnThemeToggle_Click;
            // 
            // toggleTip
            // 
            toggleTip.ToolTipTitle = "Toggle Theme";
            // 
            // RegisterPage
            // 
            AcceptButton = btnRegisterSubmit;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(753, 450);
            Controls.Add(btnThemeToggle);
            Controls.Add(lblPostcodeAsterisk);
            Controls.Add(lblAddressAsterisk);
            Controls.Add(lblCityAsterisk);
            Controls.Add(lblPhoneAsterisk);
            Controls.Add(lblEmailAsterisk);
            Controls.Add(lblConfirmEmailAsterisk);
            Controls.Add(lblSurnameAsterisk);
            Controls.Add(lblPasswordAsterisk);
            Controls.Add(lblConfirmPasswordAsterisk);
            Controls.Add(lblForenameAsterisk);
            Controls.Add(lblRegisterProducts);
            Controls.Add(chkAccessories);
            Controls.Add(chkOfficeTools);
            Controls.Add(chkGames);
            Controls.Add(chkLaptopsPC);
            Controls.Add(chkSoftware);
            Controls.Add(txtPhone);
            Controls.Add(btnExit);
            Controls.Add(btnHome);
            Controls.Add(btnRegisterSubmit);
            Controls.Add(txtPostcode);
            Controls.Add(txtAddress);
            Controls.Add(txtCity);
            Controls.Add(txtPasswordConfirm);
            Controls.Add(txtPassword);
            Controls.Add(txtEmailConfirm);
            Controls.Add(txtEmail);
            Controls.Add(txtSurname);
            Controls.Add(txtForename);
            Controls.Add(lblForm);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximumSize = new Size(773, 499);
            Name = "RegisterPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register Page";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblForm;
        private TextBox txtForename;
        private TextBox txtSurname;
        private TextBox txtEmail;
        private TextBox txtEmailConfirm;
        private TextBox txtPassword;
        private TextBox txtPasswordConfirm;
        private TextBox txtCity;
        private TextBox txtAddress;
        private TextBox txtPostcode;
        private Button btnRegisterSubmit;
        private Button btnHome;
        private Button btnExit;
        private TextBox txtPhone;
        private CheckBox chkSoftware;
        private CheckBox chkLaptopsPC;
        private CheckBox chkGames;
        private CheckBox chkOfficeTools;
        private CheckBox chkAccessories;
        private Label lblRegisterProducts;
        private Label lblForenameAsterisk;
        private Label lblConfirmPasswordAsterisk;
        private Label lblPasswordAsterisk;
        private Label lblSurnameAsterisk;
        private Label lblConfirmEmailAsterisk;
        private Label lblEmailAsterisk;
        private Label lblPhoneAsterisk;
        private Label lblCityAsterisk;
        private Label lblAddressAsterisk;
        private Label lblPostcodeAsterisk;
        private Button btnThemeToggle;
        private ToolTip toggleTip;
    }
}