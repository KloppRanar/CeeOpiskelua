using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hotel_Management_System
{
    /*
     * create a class client to:
     * 1.add a new client
     * 2.edit client data
     * 3.remove client
     * 4.get all clients
     */
    class CLIENT
    {
        CONNECT conn = new CONNECT();
        // creating a function to add a new client
        public bool insertClient(String fname, String sname, String phone, String address, String zip, String country, String gender)
        {
            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO `clients`(`fname`, `sname`, `phone`, `address`, `zip`, `country`, `gender`) VALUES (@fnm,@snm,@phn,@adr,@zip,@cnt,@gnd)";
            /* fnm - first name
             * snm - surname
             * phn - phone
             * adr - address
             * zip - zip code
             * cnt - country
             * gnd - gender
             */
            command.CommandText = insertQuery;
            command.Connection = conn.GetMySqlConnection();

            //@fnm,@snm,@phn,@adr,@zip,@cnt,@gnd
            command.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@snm", MySqlDbType.VarChar).Value = sname;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@zip", MySqlDbType.VarChar).Value = zip;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;
            command.Parameters.Add("@gnd", MySqlDbType.VarChar).Value = gender;

            conn.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }

        //creating a function to get the list of clients
        public DataTable getClients()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `clients`", conn.GetMySqlConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        /*
         * creating function to edit (change) client data
         */
        public bool editClient(int id, String fname, String sname, String phone, String address, String zip, String country, String gender)
        {
            MySqlCommand command = new MySqlCommand();
            
            //first change ->insertQuery ->editQuery
            //between exclamation marks i add for editing data -> String editQuery = ""; 
            String editQuery = "UPDATE `clients` SET `fname`=@fnm,`sname`=@snm,`phone`=@phn,`address`=@adr,`zip`=@zip,`country`=@cnt,`gender`=@gnd WHERE `id`=@cid";
            /* fnm - first name
             * snm - surname
             * phn - phone
             * adr - address
             * zip - zip code
             * cnt - country
             * gnd - gender
             */
            command.CommandText = editQuery;
            command.Connection = conn.GetMySqlConnection();

            //@cid,@fnm,@snm,@phn,@adr,@zip,@cnt,@gnd
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@snm", MySqlDbType.VarChar).Value = sname;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@zip", MySqlDbType.VarChar).Value = zip;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;
            command.Parameters.Add("@gnd", MySqlDbType.VarChar).Value = gender;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }


        //Creating function to delete client from database
        public bool removeClient(int id)
        {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = "DELETE FROM `clients` WHERE `id`=@cid";
            command.CommandText = removeQuery;
            command.Connection = conn.GetMySqlConnection();

            //@cid
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;
            }
        }
    }
}
