using System.Text.Json;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            DeSerializePasswords(); // converts it from json file to password objects
            RefreshDataGrid(); // refreshes the data grid so it can show the correct data
            dataGridPasswords.ClearSelection(); // ensure no rows selected by default
            SetSaveAddButtonText(); //chacks whether to display add or save on save button
            IsLoading = false; // set loading to false so the rest of the program knows that it is done loading
        }

        private void buttonCopyToCB_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textPassword.Text); // copies the password to the clipboard by setting the text in the password textbox as the clipboard data
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            textPassword.UseSystemPasswordChar = !textPassword.UseSystemPasswordChar; // toggles the password to be shown or hidden

            if (textPassword.UseSystemPasswordChar == true)
                buttonShow.BackgroundImage = Properties.Resources.ShowPassword; // if it is *** then it will have the show password icon
            else
                buttonShow.BackgroundImage = Properties.Resources.HidePassword; // because it is a toggle the only other option can be it isn't *** so it will have the hide password icon
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {
            buttonShow.Enabled = buttonCopyToCB.Enabled = !string.IsNullOrWhiteSpace(textPassword.Text); // checks if it is empty. As you want the buttons to be enabled only it isn't blank, a ! is used
        }
        
        private void SetPasswordCount()
        {
            groupPasswords.Text = $"{groupPasswords.Tag.ToString()} ({dataGridPasswords.Rows.Count})";//method to set the password title of the data grid group box. 
            // It takes the tag of the group box (password) because it is more versatile and and the number of rows as that is how many passwords there are.
        }

        private void SetSaveAddButtonText()
        {
            buttonSave.Text = SelectedPasswordIndex == -1 ? "&Add" : "&Save"; // checks if a password is selected. If it is then it will show save, if not it will show add
            buttonDelete.Enabled = SelectedPasswordIndex != -1; // checks if a password is selected. If it is then it will enable the delete button, if not it will disable it
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textWebsite.Text = textUser.Text = textPassword.Text = textNotes.Text = string.Empty; // sets all the text boxes to empty
            dataGridPasswords.ClearSelection(); // means that no row is selected
            SelectedPasswordIndex = -1; // reverses the flag to indicate a password isn't selected
            SetSaveAddButtonText(); // changes the text of the save button to add and disables delete
        }

        private void dataGridPasswords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == (int)Columns.Password) // checks if the column is the password column
            {
                dataGridPasswords.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = e.Value; // makes the text displayed equal the password mask
                e.Value = new string('*', PasswordMaskLength); // changes the value of the cells to the password mask
            }
        }

        private void dataGridPasswords_SelectionChanged(object sender, EventArgs e)
        {
            if (!IsLoading && dataGridPasswords.SelectedRows.Count > 0)//checks if the data grid is done loading and if there is a row selected
            {
                var selectedRow = dataGridPasswords.SelectedRows[0];

                textWebsite.Text = selectedRow.Cells[(int)Columns.Website].Value.ToString();// sets the text boxes to the values of the selected row
                textUser.Text = selectedRow.Cells[(int)Columns.Username].Value.ToString();
                textPassword.Text = selectedRow.Cells[(int)Columns.Password].Tag?.ToString();
                textNotes.Text = selectedRow.Cells[(int)Columns.Notes].Value.ToString();

                SelectedPasswordIndex = selectedRow.Index; // changes the flag to indicate a password is selected

                SetSaveAddButtonText(); // changes the text of the save button to save and enables delete
            }
        }
        /// <summary>
        /// checks if data has been entered into the text boxes and if it is actually valid. 
        /// If it isn't then it will show an error message and focus on the text box that needs to be filled in
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// checks if there is valid data present and then adds it to the list of passwords or updates the password in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!IsValidData()) return;

            if (SelectedPasswordIndex == -1)
            {
                Passwords.Add(new Password { Website = textWebsite.Text, Username = textUser.Text, Pwd = textPassword.Text, Notes = textNotes.Text });
                SelectedPasswordIndex = Passwords.Count - 1; // sets the selected password index to the last password in the list
            }
            else
                Passwords[SelectedPasswordIndex] = new Password { Website = textWebsite.Text, Username = textUser.Text, Pwd = textPassword.Text, Notes = textNotes.Text };

            // refresh the data grid
            RefreshDataGrid();
            dataGridPasswords.Rows[SelectedPasswordIndex].Selected = true;
            SetSaveAddButtonText();
            SaveChanges();
        }
        /// <summary>
        /// saves the changes to the json file
        /// </summary>
        private void SaveChanges()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(Passwords, options);

            File.WriteAllText(Path.Join(Path.GetTempPath(), "passwords.json"), json);
        }
        /// <summary>
        /// converts the json file to password objects
        /// </summary>
        private void DeSerializePasswords()
        {
            Passwords = new List<Password>();
            string passwordFile = Path.Join(Path.GetTempPath(), "passwords.json");

            if(!File.Exists(passwordFile)) return;// makes sure the path is exists and breaks the method if it doesn't

            var json = File.ReadAllText(passwordFile);
            Passwords = json != null ? JsonSerializer.Deserialize<List<Password>>(json) : new List<Password>();
        }

        /// <summary>
        /// first it makes sure a password is selected and then it removes it from the list of passwords.
        /// It also refreshes the data grid, saves the changes and simulates the clear button being clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// changes the source to null and then back to the list of passwords to refresh the data grid.
        /// </summary>
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