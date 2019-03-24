using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace accou
{
    public partial class department : Form
    {
        public department()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { MessageBox.Show("يوجد خطأ بالإدخال"); }
            else
            {

                SqlConnection con = new SqlConnection(Class1.x);
                con.Open();
                SqlCommand com1 = new SqlCommand("select d_name from department where d_name = @d_name", con);
                SqlParameter p1 = new SqlParameter("@d_name", textBox1.Text);
                com1.Parameters.Add(p1);
                com1.CommandType = CommandType.Text;
                SqlDataReader reder1 = com1.ExecuteReader();
                if (reder1.HasRows == true) { MessageBox.Show("القسم موجود مسبقاً"); reder1.Close(); }


                else
                {
                    SqlConnection con1 = new SqlConnection(Class1.x);
                    con1.Open();
                    SqlCommand com = new SqlCommand("INSERT INTO department (d_name) VALUES  (@d_name)", con1);
                    SqlParameter p = new SqlParameter("@d_name", textBox1.Text);
                    com.Parameters.Add(p);
                    com.CommandType = CommandType.Text;
                    SqlDataReader reder = com.ExecuteReader();
                    MessageBox.Show("تمت الأضافة"); reder.Close();
                }
                con.Close();
                textBox1.Text = "";
            }
        }

        private void department_Load(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Class1.x);
                con.Open();
                SqlCommand com = new SqlCommand("delete from department where d_name =@d_name  ", con);
                SqlParameter p = new SqlParameter("@d_name", comboBox2.Text);
                com.CommandType = CommandType.Text;
                com.Parameters.Add(p);
                SqlDataReader reder = com.ExecuteReader();

                con.Close();
                comboBox2.Text = "";
                MessageBox.Show("تم الحذف"); reder.Close();
            }
            catch { MessageBox.Show("حدث خطأ "); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("select d_name from department  ", con);
            com.CommandType = CommandType.Text;
            SqlDataReader reder = com.ExecuteReader();
            while (reder.Read())
            {
                comboBox1.Items.Add(reder[0]);
                comboBox2.Items.Add(reder[0]);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Class1.x);
                con.Open();
                SqlCommand com = new SqlCommand(" UPDATE  department SET   d_name =@d_name where d_name=@name ", con);
                SqlParameter p = new SqlParameter("@d_name", comboBox1.Text);
                SqlParameter p1 = new SqlParameter("@name", textBox2.Text);
                com.CommandType = CommandType.Text;
                com.Parameters.Add(p);
                com.Parameters.Add(p1);
                SqlDataReader reder = com.ExecuteReader();

                con.Close();
                comboBox1.Text = "";
                MessageBox.Show("تم التعديل"); reder.Close();
            }
            catch { MessageBox.Show("حدث خطأ "); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = comboBox1.Text;
        }
    }
}
