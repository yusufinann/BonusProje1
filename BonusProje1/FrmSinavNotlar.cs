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
using System.Data;
using System.Data.SqlClient;

namespace BonusProje1
{
    public partial class FrmSinavNotlar : Form
    {
        public FrmSinavNotlar()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        DataSet1TableAdapters.TBLNOTLARTableAdapter ds = new DataSet1TableAdapters.TBLNOTLARTableAdapter();
        DataSet1TableAdapters.TBLOGRENCILERTableAdapter dg = new DataSet1TableAdapters.TBLOGRENCILERTableAdapter();//dataGridOgrenciler için.
        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            //Dersleri Comboboxa çekme işlemi
            SqlCommand komut = new SqlCommand("select*from TBLDERSLER", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DisplayMember = "DERSAD";  // DisplayMember  ve VlueMember Kullanımı (149.Ders)- Uygulama Geliştirerek C# Öğrenin: A'dan Z'ye Eğitim Seti
            comboBox1.ValueMember = "DERSID";
            comboBox1.DataSource = dt;

            bgl.baglanti().Close();

            dataGridOgrenciler.DataSource = dg.OgrenciListesi();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListele(int.Parse(TxtOgrenciId.Text));
        }
        public int notid;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            notid = int.Parse(dataGridView1.Rows[secilen].Cells[0].Value.ToString());
           
            TxtOgrenciId.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtSinav2.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();





        }

     
     
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            int sınav1, sınav2, proje;
            double ortalama;
            string durum;
            sınav1 = Convert.ToInt32(TxtSinav1.Text);
            sınav2 = Convert.ToInt32(TxtSinav2.Text);
            proje = Convert.ToInt32(TxtProje.Text);
            ortalama = (sınav1 + sınav2 + proje) / 3;
            TxtOrtalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";
            }
       
        }


        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
           ds.NotGuncelle( int.Parse(TxtOgrenciId.Text),byte.Parse( TxtSinav1.Text), byte.Parse(TxtSinav2.Text), byte.Parse(TxtProje.Text), byte.Parse(TxtOrtalama.Text), bool.Parse(TxtDurum.Text), notid);
           MessageBox.Show("Öğrenci Güncelleme İşlemi Yapıldı","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = ds.NotListele(int.Parse(TxtOgrenciId.Text));
        }

        private void BtnOgrenciEkle_Click(object sender, EventArgs e)
        {
           
        }
    }
}