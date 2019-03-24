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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("اسم المستخدم أو كلمة المرور خطأ الرجاء التأكد منها وشكراً ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
            else
            {


                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand com = new SqlCommand("select * from login where ((user_name=@user_name)and (password=@password)) ", mycon);
                SqlParameter p = new SqlParameter("@user_name", textBox1.Text);
                SqlParameter p1 = new SqlParameter("@password", textBox2.Text);
                com.CommandType = CommandType.Text;
                com.Parameters.Add(p);
                com.Parameters.Add(p1);
                SqlDataReader myreder = com.ExecuteReader();
                if (myreder.HasRows == false)
                {
                    MessageBox.Show("اسم المستخدم أو كلمة المرور  خطأ الرجاء التأكد منه وشكراً ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    mycon.Close();
                }

                else
                {
                    Class1.x1 = textBox1.Text;

                    MessageBox.Show("أهلاً بك مرة أخرى", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                    menu frm = new menu();
                    frm.StartPosition = FormStartPosition.CenterScreen;

                    frm.ShowDialog();

                }
                textBox2.Text = "";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(MessageBox.Show("هل تريد الخروج؟", "خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
            {
                Close();
            }
        }

        
    }
}
