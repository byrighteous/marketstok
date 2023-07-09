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
    public partial class ÜrünListele : Form
    {
        public ÜrünListele()
        {
            InitializeComponent();
        }
        MySqlConnection baglanti = new MySqlConnection("server=localhost;uid=root;password=2008salih;database=sukru");
        private void kayitGoster()
        {
            baglanti.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select *from urun", baglanti);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand("update urun set urunadi='" + textBox2.Text + "',miktar='" + textBox3.Text + "',alis='" + textBox4.Text + "',satis='" + textBox5.Text + "' where barkodno='" + textBox1.Text + "'", baglanti);
            command.ExecuteNonQuery();
            baglanti.Close();
            kayitGoster();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["urunadi"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["miktar"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["alis"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["satis"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand command = new MySqlCommand("delete from urun where barkodno='" + dataGridView1.CurrentRow.Cells["barkodno"].Value+ "'", baglanti);
            command.ExecuteNonQuery();
            baglanti.Close();
            kayitGoster();
            MessageBox.Show("Kayıt Silindi");
        }

        private void ÜrünListele_Load(object sender, EventArgs e)
        {
            kayitGoster();
        }
    }
}
