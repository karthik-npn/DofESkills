namespace Password_Manager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            groupPassword = new GroupBox();
            textNotes = new TextBox();
            label3 = new Label();
            buttonCopyToCB = new Button();
            buttonShow = new Button();
            textPassword = new TextBox();
            label2 = new Label();
            textUser = new TextBox();
            labelUser = new Label();
            textWebsite = new TextBox();
            label1 = new Label();
            dataGridPasswords = new DataGridView();
            buttonSave = new Button();
            buttonClear = new Button();
            groupPasswords = new GroupBox();
            toolTipCommon = new ToolTip(components);
            buttonDelete = new Button();
            groupPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPasswords).BeginInit();
            groupPasswords.SuspendLayout();
            SuspendLayout();
            // 
            // groupPassword
            // 
            groupPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupPassword.Controls.Add(textNotes);
            groupPassword.Controls.Add(label3);
            groupPassword.Controls.Add(buttonCopyToCB);
            groupPassword.Controls.Add(buttonShow);
            groupPassword.Controls.Add(textPassword);
            groupPassword.Controls.Add(label2);
            groupPassword.Controls.Add(textUser);
            groupPassword.Controls.Add(labelUser);
            groupPassword.Controls.Add(textWebsite);
            groupPassword.Controls.Add(label1);
            groupPassword.ForeColor = SystemColors.Highlight;
            groupPassword.Location = new Point(12, 12);
            groupPassword.Name = "groupPassword";
            groupPassword.Size = new Size(444, 206);
            groupPassword.TabIndex = 0;
            groupPassword.TabStop = false;
            groupPassword.Text = "Password Details";
            // 
            // textNotes
            // 
            textNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textNotes.BorderStyle = BorderStyle.FixedSingle;
            textNotes.Location = new Point(102, 167);
            textNotes.MaxLength = 1000;
            textNotes.Name = "textNotes";
            textNotes.Size = new Size(320, 23);
            textNotes.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(21, 170);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 8;
            label3.Text = "Notes :";
            // 
            // buttonCopyToCB
            // 
            buttonCopyToCB.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCopyToCB.BackgroundImage = Properties.Resources.CopyToClipboard;
            buttonCopyToCB.BackgroundImageLayout = ImageLayout.Stretch;
            buttonCopyToCB.FlatStyle = FlatStyle.Flat;
            buttonCopyToCB.Location = new Point(398, 123);
            buttonCopyToCB.Name = "buttonCopyToCB";
            buttonCopyToCB.Size = new Size(27, 23);
            buttonCopyToCB.TabIndex = 5;
            toolTipCommon.SetToolTip(buttonCopyToCB, "Copy to Clipboard");
            buttonCopyToCB.UseVisualStyleBackColor = true;
            buttonCopyToCB.Click += buttonCopyToCB_Click;
            // 
            // buttonShow
            // 
            buttonShow.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonShow.BackgroundImage = Properties.Resources.ShowPassword;
            buttonShow.BackgroundImageLayout = ImageLayout.Stretch;
            buttonShow.FlatStyle = FlatStyle.Flat;
            buttonShow.Location = new Point(370, 123);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(27, 23);
            buttonShow.TabIndex = 4;
            toolTipCommon.SetToolTip(buttonShow, "Show/Hide");
            buttonShow.UseVisualStyleBackColor = true;
            buttonShow.Click += buttonShow_Click;
            // 
            // textPassword
            // 
            textPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textPassword.BorderStyle = BorderStyle.FixedSingle;
            textPassword.Location = new Point(102, 123);
            textPassword.MaxLength = 100;
            textPassword.Name = "textPassword";
            textPassword.Size = new Size(271, 23);
            textPassword.TabIndex = 3;
            textPassword.UseSystemPasswordChar = true;
            textPassword.TextChanged += textPassword_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(21, 126);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 4;
            label2.Text = "Password :";
            // 
            // textUser
            // 
            textUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textUser.BorderStyle = BorderStyle.FixedSingle;
            textUser.Location = new Point(102, 78);
            textUser.MaxLength = 100;
            textUser.Name = "textUser";
            textUser.Size = new Size(320, 23);
            textUser.TabIndex = 2;
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.ForeColor = SystemColors.ControlText;
            labelUser.Location = new Point(21, 81);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(36, 15);
            labelUser.TabIndex = 2;
            labelUser.Text = "User :";
            // 
            // textWebsite
            // 
            textWebsite.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textWebsite.BorderStyle = BorderStyle.FixedSingle;
            textWebsite.Location = new Point(102, 36);
            textWebsite.MaxLength = 100;
            textWebsite.Name = "textWebsite";
            textWebsite.Size = new Size(320, 23);
            textWebsite.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(21, 39);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "Website :";
            // 
            // dataGridPasswords
            // 
            dataGridPasswords.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.Silver;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridPasswords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridPasswords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridPasswords.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridPasswords.Dock = DockStyle.Fill;
            dataGridPasswords.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridPasswords.Location = new Point(3, 19);
            dataGridPasswords.MultiSelect = false;
            dataGridPasswords.Name = "dataGridPasswords";
            dataGridPasswords.RowTemplate.Height = 25;
            dataGridPasswords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridPasswords.ShowCellToolTips = false;
            dataGridPasswords.Size = new Size(540, 230);
            dataGridPasswords.TabIndex = 9;
            dataGridPasswords.CellFormatting += dataGridPasswords_CellFormatting;
            dataGridPasswords.SelectionChanged += dataGridPasswords_SelectionChanged;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSave.Location = new Point(476, 48);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 7;
            buttonSave.Text = "&Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonClear
            // 
            buttonClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClear.Location = new Point(476, 89);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 8;
            buttonClear.Text = "&Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // groupPasswords
            // 
            groupPasswords.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupPasswords.Controls.Add(dataGridPasswords);
            groupPasswords.ForeColor = SystemColors.Highlight;
            groupPasswords.Location = new Point(12, 224);
            groupPasswords.Name = "groupPasswords";
            groupPasswords.Size = new Size(546, 252);
            groupPasswords.TabIndex = 4;
            groupPasswords.TabStop = false;
            groupPasswords.Tag = "Passwords";
            groupPasswords.Text = "Passwords";
            // 
            // buttonDelete
            // 
            buttonDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonDelete.Enabled = false;
            buttonDelete.Location = new Point(476, 130);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 9;
            buttonDelete.Text = "&Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 488);
            Controls.Add(buttonDelete);
            Controls.Add(groupPasswords);
            Controls.Add(buttonClear);
            Controls.Add(buttonSave);
            Controls.Add(groupPassword);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(586, 527);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Password Manager";
            Load += MainForm_Load;
            groupPassword.ResumeLayout(false);
            groupPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPasswords).EndInit();
            groupPasswords.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupPassword;
        private TextBox textPassword;
        private Label label2;
        private TextBox textUser;
        private Label labelUser;
        private TextBox textWebsite;
        private Label label1;
        private Button buttonShow;
        private DataGridView dataGridPasswords;
        private Button buttonSave;
        private Button buttonClear;
        private GroupBox groupPasswords;
        private Button buttonCopyToCB;
        private TextBox textNotes;
        private Label label3;
        private ToolTip toolTipCommon;
        private Button buttonDelete;
    }
}