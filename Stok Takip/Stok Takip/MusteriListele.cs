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
    public partial class MusteriListele : Form
    {
        public MusteriListele()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;uid=root;password=2008salih;database=sukru");

        private void MusteriListele_Load(object sender, EventArgs e)
        {
            kayitGoster();
        }
        private void kayitGoster()
        {
            baglanti.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select *from musteri", baglanti);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand("update musteri set adsoyad='"+textBox2.Text+"',telefon='"+textBox3.Text+"',adres='"+textBox4.Text+"',email='"+textBox5.Text+"' where tc='"+textBox1.Text+"'",baglanti);
            command.ExecuteNonQuery();
            baglanti.Close();
            kayitGoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand("delete from musteri where tc='" + dataGridView1.CurrentRow.Cells["tc"].Value.ToString() + "'", baglanti);
            command.ExecuteNonQuery();
            baglanti.Close();
            kayitGoster();
            MessageBox.Show("Kayıt Silindi");
            

        }
    }
}
