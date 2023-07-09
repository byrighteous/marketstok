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
    public partial class ÜrünEkle : Form
    {
        public ÜrünEkle()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;uid=root;password=2008salih;database=sukru");
        public void veriGoster()
        {
            baglanti.Open();
            MySqlDataAdapter adapter=new MySqlDataAdapter("select *from urun",baglanti);
            DataTable tablo=new DataTable();
            adapter.Fill(tablo);
            dataGridView1.DataSource= tablo;
            baglanti.Close();

        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand("insert into urun (barkodno,urunadi,miktar,alis,satis) values ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4+"','"+textBox5.Text+"')",baglanti);
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün Eklendi");
            baglanti.Close();
            veriGoster();
        }

        private void ÜrünEkle_Load(object sender, EventArgs e)
        {
            veriGoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand("delete from urun where id='" + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "'",baglanti);
            command.ExecuteNonQuery();
            baglanti.Close();
            veriGoster();
        }
    }
}
