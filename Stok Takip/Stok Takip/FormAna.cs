using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Stok_Takip
{
    public partial class FormAna : Form
    {
        public FormAna()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection("server=localhost;uid=root;password=2008salih;database=sukru");
        private void urunGoster()
        {
            baglanti.Open();
            MySqlDataAdapter command = new MySqlDataAdapter("select *from urun", baglanti);
            DataTable table = new DataTable();
            command.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();
        }
        private void musteriGoster()
        {
            baglanti.Open();
            MySqlDataAdapter command = new MySqlDataAdapter("select *from musteri", baglanti);
            DataTable table = new DataTable();
            command.Fill(table);
            dataGridView2.DataSource = table;
            baglanti.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            MusteriEkle musteriEkle= new MusteriEkle();
            musteriEkle.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MusteriListele listele= new MusteriListele();  
            listele.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ÜrünEkle ekle = new ÜrünEkle();
            ekle.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ÜrünListele ürünListele=new ÜrünListele();
            ürünListele.Show();
        }

        private void FormAna_Load(object sender, EventArgs e)
        {
            urunGoster();
            musteriGoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand("delete from musteri where tc='" + dataGridView1.CurrentRow.Cells["tc"].Value.ToString() + "'", baglanti);
            command.ExecuteNonQuery();
            baglanti.Close();
            musteriGoster();

        }
    }
}
