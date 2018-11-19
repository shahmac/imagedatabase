using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\2016cse181\WindowsFormsApp3\WindowsFormsApp3\Database1.mdf;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into sample values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("DELETE");
        }

        private void save_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into sample values('" + textBox1.Text + "','" + textBox2.Text+"','" +textBox3.Text+"')";
            cmd.ExecuteNonQueryAsync();
            con.Close();
            MessageBox.Show("saved");
        }

        private void update_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into sample values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            cmd.ExecuteNonQueryAsync();
            
            MessageBox.Show("update");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                image.Text = openFileDialog1.FileName;
            pictureBox1.ImageLocation = openFileDialog1.FileName; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //FileStream fs1 = new FileStream();
            Byte[] mypic = File.ReadAllBytes(openFileDialog1.FileName);

            SqlCommand cmd1 = new SqlCommand("insert into storeimage(id,photo_field) values('1',@pic)",con);
            SqlParameter prm = new SqlParameter("@pic", SqlDbType.VarBinary,mypic.Length,ParameterDirection.Input,false,0,0,null,DataRowVersion.Current,mypic);
            cmd1.Parameters.Add(prm);
            cmd1.ExecuteNonQuery();

        }

        private void display_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from sample";
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
    }
}
