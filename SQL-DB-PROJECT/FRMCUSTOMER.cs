using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_DB_PROJECT
{
    public partial class FRMCUSTOMER : Form
    {
        public FRMCUSTOMER()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-39U8THB\SQLEXPRESS;Initial Catalog=SalesDB;Integrated Security=True");
        private void FRMCUSTOMER_Load(object sender, EventArgs e)
        {
            Listele();

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from cities", baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while(dr.Read())
            {
                CBSEHIR.Items.Add(dr["sehiradi"]);
            }
            baglanti.Close();
        }
        void Listele()
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLCUSTOMER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void Ekle()
        {
            baglanti.Open();
            
        }

        private void BTNLIST_Click(object sender, EventArgs e)
        {
            Listele();
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TXTMUSTERYID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TXTMUSTERYAD.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TXTMUSTERYSOYAD.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CBSEHIR.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TXTCASH.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
