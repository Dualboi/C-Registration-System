namespace Programming_03_Assignment
{
    partial class AdminPage
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            btnExit = new Button();
            btnHome = new Button();
            btnPrint = new Button();
            btnRemove = new Button();
            btnClientSubmit = new Button();
            btnFilter = new Button();
            txtSearch = new TextBox();
            lblAdmin = new Label();
            dataGridAdminView = new DataGridView();
            btnReset = new Button();
            comboFilter = new ComboBox();
            printDialog1 = new PrintDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            btnThemeToggle = new Button();
            toggleTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dataGridAdminView).BeginInit();
            SuspendLayout();
            // 
            // btnExit
            // 
            btnExit.Cursor = Cursors.Hand;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(631, 398);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(105, 40);
            btnExit.TabIndex = 9;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.Location = new Point(631, 12);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(105, 40);
            btnHome.TabIndex = 6;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnPrint
            // 
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrint.Location = new Point(631, 169);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(105, 40);
            btnPrint.TabIndex = 7;
            btnPrint.Text = "Print Data";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnRemove
            // 
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemove.Location = new Point(631, 257);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(105, 40);
            btnRemove.TabIndex = 8;
            btnRemove.Text = "Remove Data";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnClientSubmit
            // 
            btnClientSubmit.Cursor = Cursors.Hand;
            btnClientSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClientSubmit.Location = new Point(251, 12);
            btnClientSubmit.Name = "btnClientSubmit";
            btnClientSubmit.Size = new Size(105, 40);
            btnClientSubmit.TabIndex = 1;
            btnClientSubmit.Text = "Search";
            btnClientSubmit.UseVisualStyleBackColor = true;
            btnClientSubmit.Click += btnClientSubmit_Click;
            // 
            // btnFilter
            // 
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFilter.Location = new Point(251, 58);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(105, 40);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(12, 19);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(222, 29);
            txtSearch.TabIndex = 0;
            // 
            // lblAdmin
            // 
            lblAdmin.AutoSize = true;
            lblAdmin.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAdmin.Location = new Point(362, 68);
            lblAdmin.Name = "lblAdmin";
            lblAdmin.Size = new Size(63, 25);
            lblAdmin.TabIndex = 25;
            lblAdmin.Text = "label1";
            // 
            // dataGridAdminView
            // 
            dataGridAdminView.AllowUserToAddRows = false;
            dataGridAdminView.AllowUserToDeleteRows = false;
            dataGridAdminView.AllowUserToResizeColumns = false;
            dataGridAdminView.AllowUserToResizeRows = false;
            dataGridAdminView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridAdminView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridAdminView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridAdminView.Location = new Point(12, 104);
            dataGridAdminView.Name = "dataGridAdminView";
            dataGridAdminView.ReadOnly = true;
            dataGridAdminView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridAdminView.Size = new Size(600, 334);
            dataGridAdminView.TabIndex = 5;
            // 
            // btnReset
            // 
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnReset.Location = new Point(362, 12);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(105, 40);
            btnReset.TabIndex = 4;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // comboFilter
            // 
            comboFilter.Cursor = Cursors.Hand;
            comboFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboFilter.FormattingEnabled = true;
            comboFilter.Items.AddRange(new object[] { "ClientID", "Forename", "Surname", "EmailAddress", "PhoneNumber", "Address", "City", "Postcode", "Software", "LaptopsPC", "Games", "OfficeTools", "Accessories" });
            comboFilter.Location = new Point(12, 70);
            comboFilter.Name = "comboFilter";
            comboFilter.Size = new Size(222, 23);
            comboFilter.TabIndex = 2;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // btnThemeToggle
            // 
            btnThemeToggle.Cursor = Cursors.Hand;
            btnThemeToggle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThemeToggle.Location = new Point(586, 12);
            btnThemeToggle.Name = "btnThemeToggle";
            btnThemeToggle.Size = new Size(39, 40);
            btnThemeToggle.TabIndex = 26;
            toggleTip.SetToolTip(btnThemeToggle, "Switch between light-mode and dark-mode.");
            btnThemeToggle.UseVisualStyleBackColor = true;
            btnThemeToggle.Click += btnThemeToggle_Click;
            // 
            // toggleTip
            // 
            toggleTip.ToolTipTitle = "Toggle Theme";
            // 
            // AdminPage
            // 
            AcceptButton = btnClientSubmit;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(753, 450);
            Controls.Add(btnThemeToggle);
            Controls.Add(btnReset);
            Controls.Add(dataGridAdminView);
            Controls.Add(lblAdmin);
            Controls.Add(comboFilter);
            Controls.Add(txtSearch);
            Controls.Add(btnFilter);
            Controls.Add(btnClientSubmit);
            Controls.Add(btnRemove);
            Controls.Add(btnPrint);
            Controls.Add(btnHome);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximumSize = new Size(773, 499);
            Name = "AdminPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Page";
            Load += AdminPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridAdminView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExit;
        private Button btnHome;
        private Button btnPrint;
        private Button btnRemove;
        private Button btnClientSubmit;
        private Button btnFilter;
        private TextBox txtSearch;
        private Label lblAdmin;
        private DataGridView dataGridAdminView;
        private Button btnReset;
        private ComboBox comboFilter;
        private PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button btnThemeToggle;
        private ToolTip toggleTip;
    }
}