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
            SqlCommand komut2 = new SqlCommand("insert into tblcustomer(customername,surename,city,cash) values (@p1,@p2,@p3,@p4)", baglanti);
            komut2.Parameters.AddWithValue("@p1", TXTMUSTERYAD.Text);
            komut2.Parameters.AddWithValue("@p2", TXTMUSTERYSOYAD.Text);
            komut2.Parameters.AddWithValue("@p3", CBSEHIR.Text);
            komut2.Parameters.AddWithValue("@p4", TXTCASH.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("customer save successfully");
            Listele();
            
        }
        void sil()
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from tblcustomer where customerid=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", TXTMUSTERYID.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("delete successfully");
            Listele();
        }
        void Guncelle()
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("UPDATE TBLCUSTOMER SET CUSTOMERNAME=@P1,SURENAME=@P2,CITY=@P3,CASH=@P4 WHERE CUSTOMERID=@P5", baglanti);
            komut4.Parameters.AddWithValue("@P1", TXTMUSTERYAD.Text);
            komut4.Parameters.AddWithValue("@P2", TXTMUSTERYSOYAD.Text);
            komut4.Parameters.AddWithValue("@P3", CBSEHIR.Text);
            komut4.Parameters.AddWithValue("@P4",Decimal.Parse( TXTCASH.Text));
            komut4.Parameters.AddWithValue("@P5", TXTMUSTERYID.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("update successfully");
            Listele();
        }
        void Search()
        {
            SqlCommand ara = new SqlCommand("select * from tblcustomer where customername=@p1", baglanti);
            ara.Parameters.AddWithValue("@p1", TXTMUSTERYAD.Text);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
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

        private void BTNSAVE_Click(object sender, EventArgs e)
        {
            Ekle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            sil();
        }

        private void BTNGUNCELLE_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        private void BTNARA_Click(object sender, EventArgs e)
        {
            Search();
        }
    }
}
