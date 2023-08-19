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
using System.Data.Sql;

namespace BonusProje1
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        public string numara;
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DERSAD,SINAV1,SINAV2,PROJE,ORTALAMA,DURUM from TBLNOTLAR INNER JOIN TBLDERSLER ON  TBLNOTLAR.DERSID=TBLDERSLER.DERSID WHERE OGRID=@p1", bgl.baglanti());


            komut.Parameters.AddWithValue("@p1", numara);

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;  

            //Formumun text kısmında öğrenci ismi yazsın;

            SqlCommand komut2=new SqlCommand("select*from TBLOGRENCILER where OGRID="+numara,bgl.baglanti());
            
          
            SqlDataReader dr = komut2.ExecuteReader();  
            while(dr.Read())
            {
                this.Text = dr[1].ToString() + " " + dr[2].ToString();
            }

            bgl.baglanti().Close();
        }
    }
}
