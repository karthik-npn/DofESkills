using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Manager
{
    public partial class MainForm : Form
    {
        const int PasswordMaskLength = 5;
        enum Columns
        {
            Website = 0,
            Username,
            Password,
            Notes
        }

        List<Password> passwords = new List<Password>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            passwords = new List<Password>
            {
                new Password { Website = "www.google.com", Username = "user1", Pwd = "password", Notes = "notes" },
                new Password { Website = "Custom", Username = "user2", Pwd = "324234", Notes = "some notes" }
            };

            dataGridPasswords.DataSource = passwords;

            SetPasswordCount();

        }

        private void buttonCopyToCB_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textPassword.Text);
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            textPassword.UseSystemPasswordChar = !textPassword.UseSystemPasswordChar;

            if (textPassword.UseSystemPasswordChar == true)
                buttonShow.BackgroundImage = Properties.Resources.ShowPassword;
            else
                buttonShow.BackgroundImage = Properties.Resources.HidePassword;
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {
            buttonShow.Enabled = buttonCopyToCB.Enabled = !string.IsNullOrWhiteSpace(textPassword.Text);
        }

        private void dataGridPasswords_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //MessageBox.Show("Row added");
        }
        private void SetPasswordCount()
        {
            groupPasswords.Text = $"{groupPasswords.Tag.ToString()} ({dataGridPasswords.Rows.Count})";
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textWebsite.Text = textUser.Text = textPassword.Text = textNotes.Text = string.Empty;
        }

        private void dataGridPasswords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == (int)Columns.Password)
            {
                dataGridPasswords.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = e.Value;
                e.Value = new string('*', PasswordMaskLength);
            }
        }

        private void dataGridPasswords_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridPasswords.SelectedRows.Count > 0)
            {   
                var selectedRow = dataGridPasswords.SelectedRows[0];

                textWebsite.Text = selectedRow.Cells[(int)Columns.Website].Value.ToString();
                textUser.Text = selectedRow.Cells[(int)Columns.Username].Value.ToString();
                textPassword.Text = selectedRow.Cells[(int)Columns.Password].Tag?.ToString();
                textNotes.Text = selectedRow.Cells[(int)Columns.Notes].Value.ToString();
            }
        }
    }
}