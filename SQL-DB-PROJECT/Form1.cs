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
using System.Data.SqlClient;

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
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-39U8THB\SQLEXPRESS;Initial Catalog=SalesDB;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            //URUNLERIN KRITIK SEVIYESI

            SqlCommand KOMUT = new SqlCommand("EXECUTE KRITIK", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(KOMUT);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;

            //GRAFIGE VERI CEKME
            baglanti.Open();
            SqlCommand KOMUT2 = new SqlCommand("SELECT CATEGORYNAME,COUNT(*) FROM TBLCATEGORY INNER JOIN TBLPRODUCT ON TBLCATEGORY.CATEGORYID=TBLPRODUCT.CATEGORY GROUP BY CATEGORYNAME", baglanti);
            SqlDataReader DR = KOMUT2.ExecuteReader();
            while(DR.Read())
            {
                chart1.Series["CATEGORY"].Points.AddXY(DR[0], DR[1]);

            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand KOMUT3 = new SqlCommand("SELECT CITY,COUNT(*) FROM TBLCUSTOMER GROUP BY CITY", baglanti);
            SqlDataReader DR1 = KOMUT3.ExecuteReader();
            while(DR1.Read())
            {
                chart2.Series["CITY"].Points.AddXY(DR1[0], DR1[1]);
            }
            baglanti.Close();
        }
    }
}
