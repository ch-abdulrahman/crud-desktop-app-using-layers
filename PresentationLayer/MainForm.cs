using System;
using System.Windows.Forms;
using CRUD.BussinessLayer;

namespace CRUD.PresentationLayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //@@@@ load event for MainForm @@@//
        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowAllButton_Click();
        }

        //@@@@ click event for InsertButton @@@//
        private void InsertButton_Click(object sender, EventArgs e)
        {
            var gender = maleRadioBtn.Checked ? "Male" : femaleRadioBtn.Checked ? "Female" : "";

            var n = Student.Insert(nameTextBox.Text, gender, dobDateTimePicker.Value, contactTextBox.Text, addressTextBox.Text, cityComboBox.Text);

            if (n > 0)
            {
                MessageBox.Show("Record is added successfully.");
                ShowAllButton_Click();
            }
        }


        //@@@@ click event for UpdateButton @@@//
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var gender = maleRadioBtn.Checked ? "Male" : femaleRadioBtn.Checked ? "Female" : "";

            var n = Student.Update(int.Parse(idTextBox.Text), nameTextBox.Text, gender, dobDateTimePicker.Value, contactTextBox.Text, addressTextBox.Text, cityComboBox.Text);

            if (n > 0)
            {
                MessageBox.Show("Record is updated successfully.");
                ShowAllButton_Click();
            }
        }

        //@@@@ click event for DeleteButton @@@//
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var n = Student.Delete(int.Parse(idTextBox.Text));

            if (n > 0)
            {
                MessageBox.Show("Record is deleted successfully.");
                ShowAllButton_Click();
            }
        }

        //@@@@ click event for ShowAllButton @@@//
        private void ShowAllButton_Click(object sender = null, EventArgs e = null)
        {
            dataGridView.DataSource = Student.SelectAll();
            ResetButton_Click();
        }


        //@@@@ click event for ResetButton @@@//
        private void ResetButton_Click(object sender = null, EventArgs e = null)
        {
            idTextBox.Clear();
            nameTextBox.Clear();
            contactTextBox.Clear();
            addressTextBox.Clear();
            cityComboBox.ResetText();
            dobDateTimePicker.ResetText();
            maleRadioBtn.Checked = femaleRadioBtn.Checked = false;
        }

        //@@@@ click event for SearchButton @@@//

        private void SearchButton_Click(object sender, EventArgs e)
        {
            dataGridView.DataSource = Student.Search(searchTextBox.Text);
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // if any row is selected 
            if (e.RowIndex >= 0)
            {
                // current selected row
                var row = dataGridView.Rows[e.RowIndex];

                // set data in form controls
                idTextBox.Text = row.Cells["id"].Value.ToString();
                nameTextBox.Text = row.Cells["name"].Value.ToString();
                dobDateTimePicker.Text = row.Cells["dob"].Value.ToString();
                contactTextBox.Text = row.Cells["contact"].Value.ToString();
                addressTextBox.Text = row.Cells["address"].Value.ToString();
                cityComboBox.Text = row.Cells["city"].Value.ToString();
                maleRadioBtn.Checked = row.Cells["gender"].Value.ToString() == "Male";
                femaleRadioBtn.Checked = row.Cells["gender"].Value.ToString() == "Female";
            }
        }

    }
}
