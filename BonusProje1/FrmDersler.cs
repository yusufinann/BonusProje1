using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }

        //Nesnemi Metotlarımda kullanmak için Dışarda Ortak Olarak tanımlayayım:
        DataSet1TableAdapters.TBLDERSLERTableAdapter ds = new DataSet1TableAdapters.TBLDERSLERTableAdapter();
        private void FrmDersler_Load(object sender, EventArgs e)
        {
           //DataSet ile TBLDERSLER tablomun verilerini çok daha pratik bir şekilde çekelim;
           
            dataGridView1.DataSource= ds.DersListesi();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //DataSet ile Ders Ekleme(INSERT) işlemi;

            ds.DersEkle(TxtDersAd.Text);
            MessageBox.Show("Ders Ekleme İşlemi Yapılmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = ds.DersListesi();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DataSet ile Ders Listeleme işlemi;
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DataSet ile Ders Silme (DELETE) işlemi;
            ds.DersSil(byte.Parse(TxtDersId.Text));  //Parametremin alıcağı değeri içine yazdım.Byte türünde istediği için byte a çevirdim.
            MessageBox.Show("Ders Silme İşlemi Yapılmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(TxtDersAd.Text,byte.Parse(TxtDersId.Text));
            MessageBox.Show("Ders Güncelleme İşlemi Yapılmıştır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridView cell click Özelliği

            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtDersId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtDersAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
