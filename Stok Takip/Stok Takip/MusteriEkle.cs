using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Stok_Takip
{
    public partial class MusteriEkle : Form
    {
        public MusteriEkle()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;uid=root;password=2008salih;database=sukru");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand("insert into musteri (tc,adsoyad,telefon,adres,email) values ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"')",baglanti);
            command.ExecuteNonQuery();
            MessageBox.Show("Kayıt Eklendi","Başarılı!");

        }
    }
}
