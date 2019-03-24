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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("عذراً كلمة السر خاطئة", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
            else
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("select * from login where (user_name = 'admin') and (password = @pass)", mycon);
                SqlParameter p = new SqlParameter("@pass", textBox1.Text);
                mycom.Parameters.Add(p);
                mycom.CommandType = CommandType.Text;
                SqlDataReader myreader = mycom.ExecuteReader();
                if (myreader.HasRows == true)
                {
                    groupBox2.Visible = true;
                    groupBox3.Visible = true;
                    groupBox4.Visible = true;
                    groupBox1.Visible = false;
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("عذراً كلمة السر خاطئة", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                }
                mycon.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
            else
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("insert into login ([user_name] , [password]) values (@user_name , @password) ", mycon);
                SqlParameter p = new SqlParameter("@user_name", textBox2.Text);
                SqlParameter p1 = new SqlParameter("@password", textBox3.Text);
                mycom.Parameters.Add(p);
                mycom.Parameters.Add(p1);
                mycom.CommandType = CommandType.Text;
                SqlDataReader myreader = mycom.ExecuteReader();
                MessageBox.Show("تم الحفظ بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "admin")
            {
                MessageBox.Show("هذا المستخدم رئيسي لا يمكن حذفه", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
            else if (comboBox2.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("الرجاء عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
            else
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("select *  from login where (user_name = @u_n and password = @pass ) ", mycon);
                SqlParameter p = new SqlParameter("@u_n", comboBox2.Text);
                SqlParameter p1 = new SqlParameter("@pass", textBox5.Text);
                mycom.Parameters.Add(p);
                mycom.Parameters.Add(p1);
                mycom.CommandType = CommandType.Text;
                SqlDataReader myreader = mycom.ExecuteReader();
                if (myreader.HasRows == false)
                {
                    MessageBox.Show("اسم المستخدم أو كلمة السر خاطئة", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    textBox5.Text = "";

                }
                else
                {
                    myreader.Close();
                    mycom.CommandText = "delete from login where (user_name = @u_n1 and password = @pass1 ) ";
                    SqlParameter p2 = new SqlParameter("@u_n1", comboBox2.Text);
                    SqlParameter p3 = new SqlParameter("@pass1", textBox5.Text);
                    mycom.Parameters.Add(p2);
                    mycom.Parameters.Add(p3);
                    mycom.CommandType = CommandType.Text;
                    mycom.Connection = mycon;
                    myreader = mycom.ExecuteReader();
                    MessageBox.Show("تم الحذف بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    textBox5.Text = "";
                    comboBox2.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
            else
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("update login set [password] = @pass where (user_name = @u_n ) ", mycon);
                SqlParameter p = new SqlParameter("@u_n", comboBox1.Text);
                SqlParameter p1 = new SqlParameter("@pass", textBox4.Text);
                mycom.Parameters.Add(p);
                mycom.Parameters.Add(p1);
                mycom.CommandType = CommandType.Text;
                SqlDataReader myreader = mycom.ExecuteReader();
                MessageBox.Show("تم الحفظ بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                textBox4.Text = "";
                comboBox1.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            SqlConnection mycon = new SqlConnection(Class1.x);
            mycon.Open();
            SqlCommand mycom = new SqlCommand("select user_name from login ", mycon);

            mycom.CommandType = CommandType.Text;
            SqlDataReader myreader = mycom.ExecuteReader();
            while (myreader.Read())
            {
                comboBox1.Items.Add(myreader[0].ToString());
                comboBox2.Items.Add(myreader[0].ToString());
            }
        }

       
    }
}
