using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Hotel_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            CONNECT conn = new CONNECT();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            string query = "SELECT * FROM `users` WHERE `username`=@usn AND `password`=@pass";

            command.CommandText = query;
            command.Connection = conn.GetMySqlConnection();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username_txtBox.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password_txtBox.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            //when username and password exists or not
            if(table.Rows.Count > 0)
            {
                //if username and password are correct, login will continue with main management form   
                this.Hide();
                Management_System mform = new Management_System();
                mform.Show();
            }
            else
            {
                if(username_txtBox.Text.Trim().Equals(""))
                {
                    MessageBox.Show("This username is incorrect!", "W A R N I N G !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (password_txtBox.Text.Trim().Equals(""))
                {
                    MessageBox.Show("This password is incorrect!", "W A R N I N G !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!", "W A R N I N G !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
