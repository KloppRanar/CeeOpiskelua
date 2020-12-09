using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System
{
    public partial class Clients : Form
    {
        //Next code line will make adding new client possible
        CLIENT client = new CLIENT();
        public Clients()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {  //this is CLEAR FIELDS button, forgot to change name before opening
            textBoxName.Text = "";
            textBoxSurname.Text = "";
            textBoxPhone.Text = "";
            textBoxAddress.Text = "";
            textBoxZip.Text = "";
            textBoxCountry.Text = "";
            /*RadioButton = "";
            if(radioButton_Male.Checked) //THIS IS NOT WORKING AS NEEDED JET
            {
                gender = "Male";
            }
            else if(radioButton_Female.Checked)
            {
                gender = "Female";
            }
            */
        }

        private void add_client_button_Click(object sender, EventArgs e)
        { //filling up fields will automaticly show up in database
            String fname = textBoxName.Text;
            String sname = textBoxSurname.Text;
            String phone = textBoxPhone.Text;
            String address = textBoxAddress.Text;
            String zip = textBoxZip.Text;
            String country = textBoxCountry.Text;
            
            //radio button code
            String gender; 
            if(radioButton_Male.Checked == true)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }


            //this "if loop" is required to fill up minimum: first name, surname and phone number to proceed process
            if(fname.Trim().Equals("") || sname.Trim().Equals("") || phone.Trim().Equals(""))
            {
                MessageBox.Show("First name, Surname and Phone number are mandatory!", "MISSING DATA!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Boolean insertClient = client.insertClient(fname, sname, phone, address, zip, country, gender);

                if (insertClient)
                {
                    //this code in this exact place will update table after clicking ADD CLIENT
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("Client added successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Fill up all the fields!", "W A R N I N G !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        //will make database client sheet available to see in program
        private void Clients_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.getClients();

            this.dataGridView1.DefaultCellStyle.Font = new Font("Poor Richard", 10); //text font and size in table
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Red; //text color in table

            this.dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Red; //when selected, text color
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray; //when selected, back color
        }

        //EDIT EDIT EDIT EDIT EDIT
        private void edit_client_button_Click(object sender, EventArgs e)
        {
            int id;
            String fname = textBoxName.Text;
            String sname = textBoxSurname.Text;
            String phone = textBoxPhone.Text;
            String address = textBoxAddress.Text;
            String zip = textBoxZip.Text;
            String country = textBoxCountry.Text;

            //RadioButton code to change gender if needed
            String gender;
            if (radioButton_Male.Checked == true)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            //try catch method to avoid program to collapse. Instead gives Error what means it is ID ERROR!
            try
            {
                id = Convert.ToInt32(textBoxID.Text);

                //this "if loop" is required to fill up minimum: first name, surname and phone number to proceed process
                if (fname.Trim().Equals("") || sname.Trim().Equals("") || phone.Trim().Equals(""))
                {
                    MessageBox.Show("First name, Surname and Phone number are mandatory!", "MISSING DATA!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Boolean insertClient = client.editClient(id, fname, sname, phone, address, zip, country, gender);

                    if (insertClient)
                    {
                        //this code in this exact place will update table after clicking ADD CLIENT
                        dataGridView1.DataSource = client.getClients();
                        MessageBox.Show("Client info updated successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Non of the fields were updated!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //this code will display client data ON CLICK!
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxSurname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxAddress.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBoxZip.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBoxCountry.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }


        //remove button, to delete client from database
        private void remove_client_button_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                
                if(client.removeClient(id))
                {
                    //this code in this exact place will Update gridview when press REMOVE button
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("Client Deleted successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Deleting client from database failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
