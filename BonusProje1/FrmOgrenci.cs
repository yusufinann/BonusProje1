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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        DataSet1TableAdapters.TBLOGRENCILERTableAdapter ds = new DataSet1TableAdapters.TBLOGRENCILERTableAdapter();

        public void OgrenciListele()
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();    
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();// Form yüklendiğinde datagridview e veriler gelmiş olsun

            //KULUPLERi Comboboxa çekme işlemi
            SqlCommand komut = new SqlCommand("select*from TBLKULUPLER", bgl.baglanti());
            SqlDataAdapter da= new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox1.DisplayMember = "KULUPAD";  // DisplayMember  ve VlueMember Kullanımı (149.Ders)- Uygulama Geliştirerek C# Öğrenin: A'dan Z'ye Eğitim Seti
            comboBox1.ValueMember = "KULUPID";
            comboBox1.DataSource = dt;

            bgl.baglanti().Close();

            label7.Visible = false;  //dataGridView in double click özelliği ile radiobuttona veri çekme işlemi için.
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciListele();
        }
        public string cinsiyet = "";
        private void button2_Click(object sender, EventArgs e)
        {
            string cinsiyet = "";  //eşittir "" (tırnak aç kapa) dememin sebebi if else yazarken else bloğunu illa yazcam diye bir kaide olmamış oluyor.Başlangıç değeri atamış olduk.
            if(radioButton1.Checked==true)
            {
                cinsiyet = "kız";
            }

            if (radioButton2.Checked == true)
            {
                cinsiyet = "Erkek";
            }
            ds.OgrenciEkle(TxtOgrenciAd.Text, TxtOgrenciSoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), cinsiyet);
            MessageBox.Show("Öğrenci Ekleme İşlemi Yapıldı","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
            OgrenciListele();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TxtOgrenciId.Text= comboBox1.SelectedValue.ToString();  //ComboBoxtaki seçili Kulubün id değeri  TxtOgrenciId kutusuna yazdırılabilir.
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtOgrenciId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtOgrenciAd.Text= dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtOgrenciSoyad.Text= dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            label7.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();

            if (label7.Text == "Erkek")
            {
                radioButton2.Checked = true;
            }
            if (label7.Text == "Kız")
            {
                radioButton1.Checked = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtOgrenciAd.Text, TxtOgrenciSoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), cinsiyet,int.Parse(TxtOgrenciId.Text));
            MessageBox.Show("Öğrenci Güncelleme İşlemi Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OgrenciListele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(TxtOgrenciId.Text));
            MessageBox.Show("Öğrenci Silme İşlemi Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OgrenciListele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource= ds.OgrenciAra(TxtAra.Text);
        }
    }
}
