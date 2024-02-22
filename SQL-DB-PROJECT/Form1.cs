using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_DB_PROJECT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTNCATEGORY_Click(object sender, EventArgs e)
        {
            FRMCATEGORY FR = new FRMCATEGORY();
            FR.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FRMCUSTOMER fr2 = new FRMCUSTOMER();
            fr2.Show();
        }
    }
}
