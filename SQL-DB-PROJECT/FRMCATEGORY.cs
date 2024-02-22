using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQL_DB_PROJECT
{
    public partial class FRMCATEGORY : Form
    {
        public FRMCATEGORY()
        {
            InitializeComponent();
        }
        //Data Source=DESKTOP-39U8THB\SQLEXPRESS;Initial Catalog=SalesDB;Integrated Security=True

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-39U8THB\SQLEXPRESS;Initial Catalog=SalesDB;Integrated Security=True");

        private void BTNLIST_Click(object sender, EventArgs e)
        {
            SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM TBLCATEGORY",baglanti);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            dataGridView1.DataSource = DT;
        }

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into tblcategory (categoryname) values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", TXTCATEGORYNAME.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("save success");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TXTCATEGORYID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TXTCATEGORYNAME.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
           
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete  from TBLCATEGORY where categoryid=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", TXTCATEGORYID.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("DELETE SUCCESS");
        }

        private void BTNGUNCELLE_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("UPDATE TBLCATEGORY SET CATEGORYNAME=@P1 WHERE CATEGORYID=@P2", baglanti);
            komut4.Parameters.AddWithValue("@p1",TXTCATEGORYNAME.Text);
            komut4.Parameters.AddWithValue("@p2", TXTCATEGORYID.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("UPDATE SUCCESS");
        }
    }
}
