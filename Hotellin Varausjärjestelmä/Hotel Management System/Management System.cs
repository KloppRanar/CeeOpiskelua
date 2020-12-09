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
    public partial class Management_System : Form
    {
        public Management_System()
        {
            InitializeComponent();
        }

        private void Management_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //makeing available to open clients menu page
        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients manageCli = new Clients();
            manageCli.ShowDialog();
        }

        //makeing available to open reservation menu page
        private void reservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservations manageReserv = new Reservations();
            manageReserv.ShowDialog();
        }

        //makeing available to open rooms menu page
        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rooms manageRooms = new Rooms();
            manageRooms.ShowDialog();
        }
    }
}
