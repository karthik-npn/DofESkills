using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace Password_Manager
{
    public partial class MainForm : Form
    {
        const int PasswordMaskLength = 5;
        bool IsLoading = true;
        int SelectedPasswordIndex = -1;

        enum Columns
        {
            Website = 0,
            Username,
            Password,
            Notes
        }

        List<Password> Passwords = new List<Password>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DeSerializePasswords();
            RefreshDataGrid();
            dataGridPasswords.ClearSelection(); // ensure no rows selected by default
            SetSaveAddButtonText();
            IsLoading = false;
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

        private void SetSaveAddButtonText()
        {
            buttonSave.Text = SelectedPasswordIndex == -1 ? "&Add" : "&Save";
            buttonDelete.Enabled = SelectedPasswordIndex != -1;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textWebsite.Text = textUser.Text = textPassword.Text = textNotes.Text = string.Empty;
            dataGridPasswords.ClearSelection();
            SelectedPasswordIndex = -1;
            SetSaveAddButtonText();
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
            if (!IsLoading && dataGridPasswords.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridPasswords.SelectedRows[0];

                textWebsite.Text = selectedRow.Cells[(int)Columns.Website].Value.ToString();
                textUser.Text = selectedRow.Cells[(int)Columns.Username].Value.ToString();
                textPassword.Text = selectedRow.Cells[(int)Columns.Password].Tag?.ToString();
                textNotes.Text = selectedRow.Cells[(int)Columns.Notes].Value.ToString();

                SelectedPasswordIndex = selectedRow.Index;

                SetSaveAddButtonText();
            }
        }
        private bool IsValidData()
        {
            if (string.IsNullOrWhiteSpace(textWebsite.Text))
            {
                MessageBox.Show("Please enter a value for Website", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textWebsite.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textUser.Text))
            {
                MessageBox.Show("Please enter a value for User", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textUser.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("Please enter a value for Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPassword.Focus();
                return false;
            }

            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!IsValidData()) return;

            if (SelectedPasswordIndex == -1)
            {
                Passwords.Add(new Password { Website = textWebsite.Text, Username = textUser.Text, Pwd = textPassword.Text, Notes = textNotes.Text });
                SelectedPasswordIndex = Passwords.Count - 1;
            }
            else
                Passwords[SelectedPasswordIndex] = new Password { Website = textWebsite.Text, Username = textUser.Text, Pwd = textPassword.Text, Notes = textNotes.Text };

            // refresh the data grid
            RefreshDataGrid();
            dataGridPasswords.Rows[SelectedPasswordIndex].Selected = true;
            SetSaveAddButtonText();
            SaveChanges();
        }
        private void SaveChanges()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(Passwords, options);

            MessageBox.Show(json);
            File.WriteAllText(Path.Join(Path.GetTempPath(), "passwords.json"), json);
        }
        private void DeSerializePasswords()
        {
            Passwords = new List<Password>();
            string passwordFile = Path.Join(Path.GetTempPath(), "passwords.json");

            if(!File.Exists(passwordFile)) return;

            var json = File.ReadAllText(passwordFile);
            Passwords = json != null ? JsonSerializer.Deserialize<List<Password>>(json) : new List<Password>();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (SelectedPasswordIndex == -1) return;
            Passwords.RemoveAt(SelectedPasswordIndex);
            // refresh the data grid
            RefreshDataGrid();
            buttonClear.PerformClick();
            SelectedPasswordIndex = -1;
            SetSaveAddButtonText();
            SaveChanges();
        }

        private void RefreshDataGrid()
        {
            dataGridPasswords.DataSource = null;
            IsLoading = true;
            dataGridPasswords.DataSource = Passwords;
            IsLoading = false;
            SetPasswordCount();
        }
    }
}