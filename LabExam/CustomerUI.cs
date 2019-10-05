using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabExam.BLL;
using LabExam.Model;
using System.Data.SqlClient;


namespace LabExam
{
    public partial class CustomerUI : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        int indexRow;
        public CustomerUI()
        {
            InitializeComponent();
            //districtComboBox.Text = "Select";
        }

        private void serachButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Search(nameTextBox.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();

            Button btnName = sender as Button;
            switch (btnName.Text)
            {
                case "Save":
                    
                    //Mandatory
                    if (String.IsNullOrEmpty(addressTextBox.Text))
                    {
                        addressLabel.Text = "Address can not be Empty!!";
                        return;
                    }
                    if (String.IsNullOrEmpty(nameTextBox.Text))
                    {
                        nameLabel.Text = "Name can not be Empty!!";
                        return;
                    }
                    //if (String.IsNullOrEmpty(districtComboBox.Text))
                    //{
                    //    districtLabel.Text = "district can not be Empty!!";
                    //    return;
                    //}

                    customer.Address = addressTextBox.Text;
                    customer.Contact = contactTextBox.Text;
                    customer.Code = Convert.ToInt32(codeTextBox.Text);
                    customer.Name = nameTextBox.Text;
                    customer.DistrictId = Convert.ToInt32(districtComboBox.SelectedValue);
                    //Unique
                    if (_customerManager.IsCodeExist(customer))
                    {
                        codeLabel.Text = codeTextBox.Text + " Already Exist!!";
                        return;
                    }
                    if (_customerManager.IsContactExist(customer))
                    {
                        contactLabel.Text = contactTextBox.Text + " Already Exist";
                        return;
                    }
                    //Validity
                    if (codeTextBox.Text.Length != 4)
                    {
                        codeLabel.Text = "Code Must be 4 Digit";
                        return;
                    }
                    if (contactTextBox.Text.Length != 11)
                    {
                        contactLabel.Text = "Contact Must be 11 Digit";
                        return;
                    }


                    //Add/Insert
                    if (_customerManager.Add(customer))
                    {
                        Clear();
                        MessageBox.Show("Saved");
                    }
                    else
                    {
                        MessageBox.Show("Not Saved");
                    }
                    //showDataGridView.DataSource = dataTable;
                    showDataGridView.DataSource = _customerManager.Display();
                    break;
                case "Update":
                    //Set Id as Mandatory
                    if (String.IsNullOrEmpty(nameTextBox.Text))
                    {
                        MessageBox.Show("Id Can not be Empty!!!");
                        return;
                    }
                    //Mandatory
                    if (String.IsNullOrEmpty(addressTextBox.Text))
                    {
                        addressLabel.Text = "Address can not be Empty!!";
                        return;
                    }
                    if (String.IsNullOrEmpty(nameTextBox.Text))
                    {
                        nameLabel.Text = "Name can not be Empty!!";
                        return;
                    }
                    customer.Code = Convert.ToInt32(codeTextBox.Text);
                    customer.Name = nameTextBox.Text;
                    customer.Address = addressTextBox.Text;
                    customer.Contact = contactTextBox.Text;
                    customer.DistrictId = Convert.ToInt32(districtComboBox.SelectedValue);
                    //Unique
                    if (_customerManager.IsCodeExist(customer))
                    {
                        codeLabel.Text = codeTextBox.Text + " Already Exist!!";
                        return;
                    }
                    if (_customerManager.IsContactExist(customer))
                    {
                        contactLabel.Text = contactTextBox.Text + " Already Exist";
                        return;
                    }
                    //Validity
                    if (codeTextBox.Text.Length != 4)
                    {
                        codeLabel.Text = "Code Must be 4 Digit";
                        return;
                    }
                    if (contactTextBox.Text.Length != 11)
                    {
                        contactLabel.Text = "Contact Must be 11 Digit";
                        return;
                    }
                    if (_customerManager.Update(customer))
                    {
                        MessageBox.Show("Updated");
                        showDataGridView.DataSource = _customerManager.Display();
                    }
                    else
                    {
                        MessageBox.Show("Not Updated");
                    }
                    saveButton.Text = "Save";
                    break;
            }





            
        }

        private void ShowDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                indexRow = e.RowIndex;
                DataGridViewRow row = showDataGridView.Rows[indexRow];
                codeTextBox.Text = row.Cells[1].Value.ToString();
                nameTextBox.Text = row.Cells[2].Value.ToString();
                addressTextBox.Text = row.Cells[3].Value.ToString();
                contactTextBox.Text = row.Cells[4].Value.ToString();
                districtComboBox.Text = row.Cells[5].Value.ToString();
                saveButton.Text = "Update";         
        }
        private void CustomerUI_Load(object sender, EventArgs e)
        {
            districtComboBox.DataSource = _customerManager.districtCombo();
            districtComboBox.SelectedItem = null;
            districtComboBox.SelectedText = "--Select--";
        }



        private void ShowDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            showDataGridView.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }

        public void Clear()
        {
            codeLabel.Visible = false;
            contactLabel.Visible = false;
            nameLabel.Visible = false;
            addressLabel.Visible = false;
            districtLabel.Visible = false;
            codeTextBox.Clear();
            nameTextBox.Clear();
            contactTextBox.Clear();
            addressTextBox.Clear();
            districtComboBox.SelectedItem = null;
            districtComboBox.SelectedText = "--Select--";
        }
    }
}
