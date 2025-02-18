namespace Programming_03_Assignment
{
    partial class ClientPage
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            btnHome = new Button();
            btnDownload = new Button();
            btnPrint = new Button();
            btnExit = new Button();
            lblWelcome = new Label();
            dataGridUserView = new DataGridView();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printDialog1 = new PrintDialog();
            btnThemeToggle = new Button();
            toggleTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dataGridUserView).BeginInit();
            SuspendLayout();
            // 
            // btnHome
            // 
            btnHome.Cursor = Cursors.Hand;
            btnHome.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.Location = new Point(631, 12);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(105, 40);
            btnHome.TabIndex = 1;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnDownload
            // 
            btnDownload.Cursor = Cursors.Hand;
            btnDownload.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDownload.Location = new Point(631, 238);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(105, 40);
            btnDownload.TabIndex = 3;
            btnDownload.Text = "Download Data";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += btnDownload_Click;
            // 
            // btnPrint
            // 
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrint.Location = new Point(631, 140);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(105, 40);
            btnPrint.TabIndex = 2;
            btnPrint.Text = "Print Data";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnExit
            // 
            btnExit.Cursor = Cursors.Hand;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(631, 398);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(105, 40);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(24, 19);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(63, 25);
            lblWelcome.TabIndex = 16;
            lblWelcome.Text = "label1";
            // 
            // dataGridUserView
            // 
            dataGridUserView.AllowUserToAddRows = false;
            dataGridUserView.AllowUserToDeleteRows = false;
            dataGridUserView.AllowUserToResizeColumns = false;
            dataGridUserView.AllowUserToResizeRows = false;
            dataGridUserView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridUserView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridUserView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridUserView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridUserView.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridUserView.Location = new Point(24, 57);
            dataGridUserView.Margin = new Padding(2);
            dataGridUserView.Name = "dataGridUserView";
            dataGridUserView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridUserView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridUserView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridUserView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridUserView.Size = new Size(578, 381);
            dataGridUserView.TabIndex = 0;
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
            btnThemeToggle.TabIndex = 17;
            toggleTip.SetToolTip(btnThemeToggle, "Switch between light-mode and dark-mode.");
            btnThemeToggle.UseVisualStyleBackColor = true;
            btnThemeToggle.Click += btnThemeToggle_Click;
            // 
            // toggleTip
            // 
            toggleTip.ToolTipTitle = "Toggle Theme";
            // 
            // ClientPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(753, 450);
            Controls.Add(btnThemeToggle);
            Controls.Add(dataGridUserView);
            Controls.Add(lblWelcome);
            Controls.Add(btnExit);
            Controls.Add(btnPrint);
            Controls.Add(btnDownload);
            Controls.Add(btnHome);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximumSize = new Size(773, 499);
            Name = "ClientPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Client Page";
            Load += ClientPage_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridUserView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHome;
        private Button btnDownload;
        private Button btnPrint;
        private Button btnExit;
        private Label lblWelcome;
        private DataGridView dataGridUserView;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintDialog printDialog1;
        private Button btnThemeToggle;
        private ToolTip toggleTip;
    }
}