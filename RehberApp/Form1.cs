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
namespace RehberApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-9DQS8R7\\MSSQLSERVER01;Initial Catalog=Rehber;Integrated Security=True");

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From KISILER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void temizle()
        {
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            maskedTextBox5.Text = "";
            maskedTextBox2.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
         listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into KISILER (AD,SOYAD,TELEFON,MAIL) values (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p2", maskedTextBox3.Text);
            komut.Parameters.AddWithValue("@p3", maskedTextBox4.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox5.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişi Rehbere Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
                maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
                maskedTextBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                maskedTextBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                maskedTextBox4.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                maskedTextBox5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
           



        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(maskedTextBox1.Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From KISILER where ID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", id);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişi Rehberden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(maskedTextBox1.Text);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update KISILER set AD=@p1,SOYAD=@p2,TELEFON=@p3,MAIL=@p4 where ID=@p5", baglanti);
            komut.Parameters.AddWithValue("@p1", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@p2", maskedTextBox3.Text);
            komut.Parameters.AddWithValue("@p3", maskedTextBox4.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox5.Text);
            komut.Parameters.AddWithValue("@p5", id);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişi Rehberde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}
