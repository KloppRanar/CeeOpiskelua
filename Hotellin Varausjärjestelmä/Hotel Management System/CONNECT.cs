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
     * this class connects project with  mysql database
     */
    class CONNECT
    {
        private MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3307;username=root;password=;database=hotel_db");
    
        //function to return our database
        public MySqlConnection GetMySqlConnection()
        {
            return connection;
        }

        //function to open the connection
        public void openConnection()
        {
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        //function to close the connection
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
