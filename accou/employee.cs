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
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SqlConnection con5 = new SqlConnection(Class1.x);
            con5.Open();
            SqlCommand com5 = new SqlCommand(" SELECT  user_id, user_name, dept_no, address, mobile, telephone, birthdate, e_mail, notes, price_id from employee where (user_name=@user_name) ", con5);

            SqlParameter p = new SqlParameter("@user_name", comboBox1.Text);
            com5.CommandType = CommandType.Text;

            com5.Parameters.Add(p);
            SqlDataReader myreader5 = com5.ExecuteReader();

            if (myreader5.HasRows == false)
            {
                MessageBox.Show("لا يوجد ");
            }
            else
            {
                while (myreader5.Read())
                {
                    dataGridView1.Rows.Add(myreader5[0], myreader5[1], myreader5[2], myreader5[3], myreader5[4], myreader5[5], myreader5[6], myreader5[7], myreader5[8], myreader5[9]);

                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Convert.ToString(MessageBox.Show("هل انت متاكد من انك تريد الحذف", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("delete from employee where (user_id=@user_id)", mycon);
                SqlParameter p = new SqlParameter("@user_id", Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                mycom.CommandType = CommandType.Text;
                mycom.Parameters.Add(p);
                SqlDataReader myreader = mycom.ExecuteReader();
                myreader.Close();
                dataGridView1.Rows.Clear();




            }




        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value) == "" || Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value) == "" || Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value) == "" || Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value) == "" || Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value) == "" || Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value) == "" || Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[9].Value) == "")
                    MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                else
                {
                    SqlConnection mycon1 = new SqlConnection(Class1.x);
                    mycon1.Open();
                    SqlCommand mycom1 = new SqlCommand("UPDATE  employee  SET  user_name=@user_name, dept_no=@dept_no, address=@address, mobile=@mobile, telephone=@telephone, birthdate=@birthdate, e_mail=@e_mail, notes=@notes, price_id=@price_id where user_id =@user_id ", mycon1);
                    SqlParameter p0 = new SqlParameter("@user_id", Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    SqlParameter p = new SqlParameter("@user_name", dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    SqlParameter p1 = new SqlParameter("@dept_no", dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    SqlParameter p2 = new SqlParameter("@address", dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    SqlParameter p3 = new SqlParameter("@mobile", Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()));
                    SqlParameter p4 = new SqlParameter("@telephone", Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    SqlParameter p5 = new SqlParameter("@birthdate", dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    SqlParameter p6 = new SqlParameter("@e_mail", dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                    SqlParameter p7 = new SqlParameter("@notes", dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                    SqlParameter p8 = new SqlParameter("@price_id", Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString()));

                    mycom1.CommandType = CommandType.Text;
                    mycom1.Parameters.Add(p0);
                    mycom1.Parameters.Add(p);
                    mycom1.Parameters.Add(p1);
                    mycom1.Parameters.Add(p2);
                    mycom1.Parameters.Add(p3);
                    mycom1.Parameters.Add(p4);
                    mycom1.Parameters.Add(p5);
                    mycom1.Parameters.Add(p6);
                    mycom1.Parameters.Add(p7);
                    mycom1.Parameters.Add(p8);

                    SqlDataReader myreader1 = mycom1.ExecuteReader();

                }
            }
            catch { MessageBox.Show("حدث خطأ في التعديل"); }
        }

        private void employee_Load(object sender, EventArgs e)
        {


            dataGridView1.Rows.Clear();
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("select * from employee ", con);


            com.CommandType = CommandType.Text;
            SqlDataReader r = com.ExecuteReader();
            while (r.Read())
            {
                dataGridView1.Rows.Add(r[0], r[1], r[2], r[3], r[4], r[5], r[6], r[7], r[8], r[9]);
            }
            r.Close();
           

            SqlCommand com2 = new SqlCommand("select user_name from employee ", con);

            SqlDataReader reder = com2.ExecuteReader();
            while (reder.Read())
            {
                comboBox1.Items.Add(reder[0]);

            }
            reder.Close();



            SqlCommand com3 = new SqlCommand("select d_name from department ", con);

            SqlDataReader reder2 = com3.ExecuteReader();
            while (reder2.Read())
            {
                comboBox2.Items.Add(reder2[0]);

            }
            reder2.Close();
            con.Close();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox6.Text = dateTimePicker1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom2 = new SqlCommand("select user_name from employee where (user_name = @user_name)", mycon);
                SqlParameter p15 = new SqlParameter("@user_name", textBox1.Text);
                mycom2.CommandType = CommandType.Text;
                mycom2.Parameters.Add(p15);
                SqlDataReader myreader = mycom2.ExecuteReader();
                if (myreader.HasRows)
                {
                    MessageBox.Show("عذراً ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    mycon.Close();
                }
                else if (textBox1.Text == "" || comboBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "" || textBox9.Text == "")
                    MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                else
                {

                    SqlConnection mycon1 = new SqlConnection(Class1.x);
                    mycon1.Open();
                    SqlCommand mycom1 = new SqlCommand("INSERT INTO employee (user_name, dept_no, address, mobile, telephone, birthdate, e_mail, notes, price_id) VALUES  (@user_name, @dept_no, @address, @mobile, @telephone, @birthdate, @e_mail, @notes, @price_id)", mycon1);
                    SqlParameter p = new SqlParameter("@user_name", textBox1.Text);
                    SqlParameter p1 = new SqlParameter("@dept_no", comboBox2.Text);
                    SqlParameter p2 = new SqlParameter("@address", textBox3.Text);
                    SqlParameter p3 = new SqlParameter("@mobile", Convert.ToInt32(textBox4.Text));
                    SqlParameter p4 = new SqlParameter("@telephone", Convert.ToInt32(textBox5.Text));
                    SqlParameter p5 = new SqlParameter("@birthdate", textBox6.Text);
                    SqlParameter p6 = new SqlParameter("@e_mail", textBox7.Text);
                    SqlParameter p7 = new SqlParameter("@notes", textBox8.Text);
                    SqlParameter p8 = new SqlParameter("@price_id", Convert.ToInt32(textBox9.Text));

                    mycom1.CommandType = CommandType.Text;
                    mycom1.Parameters.Add(p);
                    mycom1.Parameters.Add(p1);
                    mycom1.Parameters.Add(p2);
                    mycom1.Parameters.Add(p3);
                    mycom1.Parameters.Add(p4);
                    mycom1.Parameters.Add(p5);
                    mycom1.Parameters.Add(p6);
                    mycom1.Parameters.Add(p7);
                    mycom1.Parameters.Add(p8);

                    SqlDataReader myreader1 = mycom1.ExecuteReader();

                    textBox1.Text = "";
                    comboBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";



                    MessageBox.Show("تم الحفظ بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    ////textBox11.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                }
            }
            catch { MessageBox.Show("حدث خطأ بالأدخال"); }
        }

        



    }
}
