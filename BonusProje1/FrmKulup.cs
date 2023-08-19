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

namespace BonusProje1
{
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        public void KulupListele()
        {
            //DatagridView e TBLKULUPLER tablomdan Veri çekelim;

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select*from TBLKULUPLER", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            KulupListele();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            KulupListele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLKULUPLER (KULUPAD) values (@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            KulupListele();
            MessageBox.Show("Kulüp Listeye Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBLKULUPLER set KULUPAD=@p1 where KULUPID=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKulupAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtKulupId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            KulupListele();
            MessageBox.Show("Kulüp güncellendi ve eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtKulupId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtKulupAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBLKULUPLER where KULUPID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKulupId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            KulupListele();
            MessageBox.Show("Kulüp Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
                
        }
    }
}
