using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using JbsaPrintDataGridView;

namespace accou
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            itemsDataGridView.Rows.Clear();
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT items.item_id, items.item, items.quantity, items.price, items.imported_co, items.made_in, items.purches_date, items.sale_date, items.warranty, price.cost, price.wholesale, price.half_wholesale, price.retail from items ,price  where items.price=price.price_id  ", con);


            com.CommandType = CommandType.Text;
            SqlDataReader r = com.ExecuteReader();
            while (r.Read())
            {
                itemsDataGridView.Rows.Add(r[0], r[1], r[2], r[3], r[4], r[5], r[6], r[7], r[8], r[9], r[10], r[11], r[12]);
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(MessageBox.Show("هل انت متاكد من انك تريد الحذف", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
            {
                SqlConnection con = new SqlConnection(Class1.x);
                con.Open();
                SqlCommand com = new SqlCommand("delete from items where(item_id=@item_id)", con);
                SqlParameter p = new SqlParameter("@item_id", Convert.ToInt32(textBox8.Text));
                com.CommandType = CommandType.Text;
                com.Parameters.Add(p);
                SqlDataReader reder = com.ExecuteReader();
                MessageBox.Show("تم الحذف");
                reder.Close();
                itemsDataGridView.Rows.Clear();
            }
        }

        private void itemsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox8.Text = itemsDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            itemsDataGridView.Rows.Clear();
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT items.item_id, items.item, items.quantity, items.price, items.imported_co, items.made_in, items.purches_date, items.sale_date, items.warranty, price.cost, price.wholesale, price.half_wholesale, price.retail from items ,price  where items.price=price.price_id  AND(item=@item) ", con);

            SqlParameter p = new SqlParameter("@item", comboBox1.Text);
            com.CommandType = CommandType.Text;

            com.Parameters.Add(p);
            SqlDataReader myreader = com.ExecuteReader();

            if (myreader.HasRows == false)
            {
                MessageBox.Show("لا يوجد ");
            }
            else
            {
                while (myreader.Read())
                {
                    itemsDataGridView.Rows.Add(myreader[0], myreader[1], myreader[2], myreader[3], myreader[4], myreader[5], myreader[6], myreader[7], myreader[8], myreader[9], myreader[10], myreader[11], myreader[12]);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection mycon2 = new SqlConnection(Class1.x);
            mycon2.Open();
            SqlCommand mycom2 = new SqlCommand("UPDATE price SET cost = @cost, wholesale =@wholesale, half_wholesale = @half_wholesale, retail = @retail WHERE price_id = @price_id", mycon2);
            mycom2.CommandType = CommandType.Text;
            SqlParameter p12 = new SqlParameter("@price_id", Convert.ToInt32(textBox8.Text));
            SqlParameter p8 = new SqlParameter("@cost", Convert.ToInt32(textBox3.Text));
            SqlParameter p9 = new SqlParameter("@wholesale", Convert.ToInt32(textBox19.Text));
            SqlParameter p10 = new SqlParameter("@half_wholesale", Convert.ToInt32(textBox18.Text));
            SqlParameter p11 = new SqlParameter("@retail", Convert.ToInt32(textBox17.Text));

            mycom2.Parameters.Add(p8);
            mycom2.Parameters.Add(p9);
            mycom2.Parameters.Add(p10);
            mycom2.Parameters.Add(p11);
            mycom2.Parameters.Add(p12);
            SqlDataReader myreader2 = mycom2.ExecuteReader();
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            mycon2.Close();

            SqlConnection mycon1 = new SqlConnection(Class1.x);
            mycon1.Open();
            SqlCommand mycom1 = new SqlCommand("UPDATE items SET item = @item, quantity = @quantity,  imported_co = @imported_co, made_in = @made_in, purches_date = @purches_date, sale_date = @sale_date, warranty = @warranty  WHERE (item_id = @item_id)", mycon1);
            mycom1.CommandType = CommandType.Text;
            SqlParameter p0 = new SqlParameter("@item_id", Convert.ToInt32(textBox8.Text));
            SqlParameter p = new SqlParameter("@item", textBox1.Text);
            SqlParameter p1 = new SqlParameter("@quantity", Convert.ToInt32(textBox2.Text));
            SqlParameter p3 = new SqlParameter("@imported_co", textBox4.Text);
            SqlParameter p4 = new SqlParameter("@made_in", textBox5.Text);
            SqlParameter p5 = new SqlParameter("@purches_date", dateTimePicker1.Text);
            SqlParameter p6 = new SqlParameter("@sale_date", dateTimePicker2.Text);
            SqlParameter p7 = new SqlParameter("@warranty", Convert.ToInt32(textBox6.Text));
            mycom1.Parameters.Add(p0);
            mycom1.Parameters.Add(p);
            mycom1.Parameters.Add(p1);
            mycom1.Parameters.Add(p3);
            mycom1.Parameters.Add(p4);
            mycom1.Parameters.Add(p5);
            mycom1.Parameters.Add(p6);
            mycom1.Parameters.Add(p7);




            SqlDataReader myreader1 = mycom1.ExecuteReader();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox8.Text = "";



            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            MessageBox.Show("تمالحفظ بنجاح ");

        }

        private void itemsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                textBox1.Text = itemsDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = itemsDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = itemsDataGridView.Rows[e.RowIndex].Cells[9].Value.ToString();
                textBox4.Text = itemsDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox5.Text = itemsDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox9.Text = itemsDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox6.Text = itemsDataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBox10.Text = itemsDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox19.Text = itemsDataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
                textBox18.Text = itemsDataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
                textBox17.Text = itemsDataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();
            }
            catch { MessageBox.Show("حدث خطأ بالأدخال"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // try
          //  {

                SqlConnection mycon0 = new SqlConnection(Class1.x);
                mycon0.Open();
                SqlCommand mycom0 = new SqlCommand("select max(item_id) from items", mycon0);

                int m = (int)mycom0.ExecuteScalar() + 1;
                textBox20.Text = m.ToString();
                mycon0.Close();

                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom2 = new SqlCommand("select item  from items where (item = @item)", mycon);
                SqlParameter p15 = new SqlParameter("@item", textBox1.Text);
                mycom2.CommandType = CommandType.Text;
                mycom2.Parameters.Add(p15);

                SqlDataReader myreader = mycom2.ExecuteReader();

                if (myreader.HasRows)
                {
                    MessageBox.Show("عذراً ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    mycon.Close();
                }

                else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    MessageBox.Show("عذراً يجب عدم ترك حقل فارغ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                else
                {

                    SqlConnection mycon1 = new SqlConnection(Class1.x);
                    mycon1.Open();
                    SqlCommand mycom1 = new SqlCommand("INSERT INTO items (item, quantity, price,  imported_co, made_in, purches_date, sale_date, warranty) VALUES (@item, @quantity,@price , @imported_co, @made_in, @purches_date, @sale_date, @warranty)", mycon1);
                    SqlParameter p = new SqlParameter("@item", textBox1.Text);
                    SqlParameter p1 = new SqlParameter("@quantity", Convert.ToInt32(textBox2.Text));
                    SqlParameter p2 = new SqlParameter("@price", Convert.ToInt32(textBox20.Text));
                    SqlParameter p3 = new SqlParameter("@imported_co", textBox4.Text);
                    SqlParameter p4 = new SqlParameter("@made_in", textBox5.Text);
                    SqlParameter p5 = new SqlParameter("@purches_date", textBox9.Text);
                    SqlParameter p6 = new SqlParameter("@sale_date", textBox10.Text);
                    SqlParameter p7 = new SqlParameter("@warranty", Convert.ToInt32(textBox6.Text));

                    mycom1.CommandType = CommandType.Text;
                    mycom1.Parameters.Add(p);
                    mycom1.Parameters.Add(p1);
                    mycom1.Parameters.Add(p2);
                    mycom1.Parameters.Add(p3);
                    mycom1.Parameters.Add(p4);
                    mycom1.Parameters.Add(p5);
                    mycom1.Parameters.Add(p6);
                    mycom1.Parameters.Add(p7);

                    SqlDataReader myreader1 = mycom1.ExecuteReader();
                    mycon1.Close();

                    SqlConnection mycon3 = new SqlConnection(Class1.x);
                    mycon3.Open();
                    SqlCommand mycom3 = new SqlCommand("INSERT INTO price  (cost, wholesale, half_wholesale, retail) VALUES (@cost, @wholesale, @half_wholesale, @retail)", mycon3);
                    SqlParameter p8 = new SqlParameter("@cost", Convert.ToInt32(textBox3.Text));
                    SqlParameter p9 = new SqlParameter("@wholesale", Convert.ToInt32(textBox19.Text));
                    SqlParameter p10 = new SqlParameter("@half_wholesale", Convert.ToInt32(textBox18.Text));
                    SqlParameter p11 = new SqlParameter("@retail", Convert.ToInt32(textBox17.Text));
                    mycom3.CommandType = CommandType.Text;
                    mycom3.Parameters.Add(p8);
                    mycom3.Parameters.Add(p9);
                    mycom3.Parameters.Add(p10);
                    mycom3.Parameters.Add(p11);
                    SqlDataReader myreader3 = mycom3.ExecuteReader();
                    mycon3.Close();


                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox9.Text = "";
                    textBox19.Text = "";
                    textBox18.Text = "";
                    textBox17.Text = "";
                    textBox20.Text = "";




                    MessageBox.Show("تم الحفظ بنجاح", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    ////textBox11.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                }
          //  }
           // catch { MessageBox.Show("حدث خطأ بالأدخال"); }
        }

        private void menu_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("select item from items ", con);
            com.CommandType = CommandType.Text;
            SqlDataReader reder = com.ExecuteReader();
            while (reder.Read())
            {
                comboBox1.Items.Add(reder[0]);
                comboBox3.Items.Add(reder[0]);
                comboBox2.Items.Add(reder[0]);
                comboBox6.Items.Add(reder[0]);
            }
            reder.Close();
            com.CommandText = "SELECT  company_name FROM  companies";
            com.Connection = con;
            reder = com.ExecuteReader();
            while (reder.Read())
            {
                
                comboBox4.Items.Add(reder[0]);
                comboBox5.Items.Add(reder[0]);
                comboBox8.Items.Add(reder[0]);
                comboBox9.Items.Add(reder[0]);
            }
            reder.Close();

            com.CommandText = "select bill_id from bills";
            com.Connection = con;
            reder = com.ExecuteReader();
            while (reder.Read()) { bill_id2.Text = Convert.ToString(Convert.ToInt32(reder[0]) + 1); }

            con.Close();











        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox9.Text = dateTimePicker2.Text;

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox10.Text = dateTimePicker1.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void إدارةالحساباتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Class1.x1 == "admin")
            {
                admin frm = new admin();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذراً لا تملك صلاحية للدخول لهذه الواجهة", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("select item, quantity  from items where item = @item ", con);
            SqlParameter p = new SqlParameter("@item", comboBox3.Text);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(p);
            SqlDataReader reder = com.ExecuteReader();
            while (reder.Read())
            {
                dataGridView2.Rows.Add(reder[0], reder[1]);
            }
            con.Close();
        }



        private void سجلالموظفينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Class1.x1 == "admin")
            {
                employee frm = new employee();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذراً لا تملك صلاحية للدخول لهذه الواجهة", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
        }

        private void إدارةالأقسامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Class1.x1 == "admin")
            {
                department frm = new department();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("عذراً لا تملك صلاحية للدخول لهذه الواجهة", "", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT items.item_id, items.item, items.quantity, items.price, items.imported_co, items.made_in, items.purches_date, items.sale_date, items.warranty, price.cost, price.wholesale, price.half_wholesale, price.retail from items ,price  where items.price=price.price_id  ", con);
            com.CommandType = CommandType.Text;
            SqlDataReader r = com.ExecuteReader();
            while (r.Read())
            {
                textBox16.Text = Convert.ToString(r[5]);
                textBox7.Text = Convert.ToString(r[2]);
                textBox15.Text = Convert.ToString(r[11]);
                //(r[0], r[1], , r[3], r[4], , r[6], r[7], r[8], r[9], , r[11], r[12]);
            }
            r.Close();

            com.CommandText = "select bill_id from bills";
            com.Connection = con;
            r = com.ExecuteReader();
            while (r.Read()) { bill_id.Text = Convert.ToString(Convert.ToInt32(r[0]) + 1); }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox16.Text == "" || textBox15.Text == "" || textBox21.Text == "" || textBox13.Text == "" || textBox7.Text == "")
                {
                    MessageBox.Show("الرجاء عدم ترك حقل فارغ");
                }
                else
                {
                    dataGridView1.Rows.Add(bill_id.Text, Convert.ToString(comboBox4.SelectedItem), Convert.ToString(comboBox2.SelectedItem), textBox16.Text, textBox15.Text, textBox14.Text, textBox13.Text, textBox21.Text);
                    textBox11.Text = Convert.ToString(Convert.ToInt32(textBox11.Text) + Convert.ToInt32(textBox13.Text));
                    if (radioButton1.Checked == true)
                    {
                        SqlConnection mycon = new SqlConnection(Class1.x);
                        mycon.Open();
                        SqlCommand mycom = new SqlCommand("INSERT INTO bills (sale_date,  price ,num , bill_id2 , com) VALUES (@sale_date,@price,1 , @bill_id2 , @com)", mycon);
                        mycom.CommandType = CommandType.Text;

                        SqlParameter p1 = new SqlParameter("@sale_date", Convert.ToString(textBox21.Text));
                        SqlParameter p2 = new SqlParameter("@bill_id2", Convert.ToInt32(bill_id2.Text));
                        SqlParameter p3 = new SqlParameter("@price", Convert.ToInt32(textBox13.Text));
                        
                        SqlParameter p5 = new SqlParameter("@com", Convert.ToInt32(company.Text));

                        mycom.Parameters.Add(p1);
                        mycom.Parameters.Add(p2);
                        mycom.Parameters.Add(p3);
                        
                        mycom.Parameters.Add(p5);

                        SqlDataReader myreader = mycom.ExecuteReader();
                        myreader.Close();

                    }
                    else
                    {
                        SqlConnection mycon = new SqlConnection(Class1.x);
                        mycon.Open();
                        SqlCommand mycom = new SqlCommand("INSERT INTO bills (sale_date,  price ,num , bill_id2 , com) VALUES (@sale_date,@price,2 , @bill_id2 , @com)", mycon);
                        mycom.CommandType = CommandType.Text;

                        SqlParameter p1 = new SqlParameter("@sale_date", Convert.ToString(textBox21.Text));
                        SqlParameter p2 = new SqlParameter("@bill_id2", Convert.ToInt32(bill_id2.Text));
                        SqlParameter p3 = new SqlParameter("@price", Convert.ToInt32(textBox13.Text));
                        
                        SqlParameter p5 = new SqlParameter("@com", Convert.ToInt32(company.Text));

                        mycom.Parameters.Add(p1);
                        mycom.Parameters.Add(p2);
                        mycom.Parameters.Add(p3);
                     
                        mycom.Parameters.Add(p5);

                        SqlDataReader myreader = mycom.ExecuteReader();
                        myreader.Close();

                    }


                }
                SqlConnection con = new SqlConnection(Class1.x);
                con.Open();
                SqlCommand com = new SqlCommand("UPDATE items SET quantity = quantity - @quantity  WHERE (item = @item)", con);
                SqlParameter p = new SqlParameter("@item", Convert.ToString(comboBox2.SelectedItem));
                SqlParameter p11 = new SqlParameter("@quantity", Convert.ToInt32(textBox14.Text));
                com.CommandType = CommandType.Text;
                com.Parameters.Add(p);
                com.Parameters.Add(p11);
                SqlDataReader reder = com.ExecuteReader();



            }
            catch
            {
                MessageBox.Show("الرجاء الانتباه");
            }
        }



        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox14.Text) > Convert.ToInt32(textBox7.Text)) { MessageBox.Show("????"); }
         
            if (textBox14.Text == "")
                textBox13.Text = Convert.ToString(0);
            else
            {
                try
                {
                    int x = Convert.ToInt32(textBox14.Text);
                    int y = Convert.ToInt32(textBox15.Text);
                    int z = x * y;
                    textBox13.Text = Convert.ToString(z);
                }
                catch
                { MessageBox.Show("الرجاء ادخال الصيغة الصحيحة");
                textBox14.Text = "";
                }
            }
        }



        private void button14_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox11.Text);
            int y = Convert.ToInt32(textBox12.Text);
            int z = x - y;
            textBox11.Text = Convert.ToString(z);
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            textBox21.Text = dateTimePicker3.Text;



        }

        private void bill_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            PrintJbsaDataGridView.Print_Grid(dataGridView1);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToString(MessageBox.Show("هل انت متاكد من انك تريد الحذف", "", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)) == "Yes")
            {
                SqlConnection mycon = new SqlConnection(Class1.x);
                mycon.Open();
                SqlCommand mycom = new SqlCommand("DELETE FROM bills where (bill_id=@bill_id)", mycon);
                SqlParameter p = new SqlParameter("@bill_id", Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                mycom.CommandType = CommandType.Text;
                mycom.Parameters.Add(p);
                SqlDataReader myreader = mycom.ExecuteReader();
                myreader.Close();
                dataGridView1.Rows.Clear();




            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox22.Text == "")
                {
                    if (radioButton3.Checked == true)
                    {
                        dataGridView3.Rows.Clear();
                        SqlConnection con = new SqlConnection(Class1.x);
                        con.Open();
                        SqlCommand com = new SqlCommand("SELECT  bill_id2, sale_date,price FROM  bills  where com=@com and num = 1 ", con);

                        
                        SqlParameter p1 = new SqlParameter("@com", Convert.ToInt32(company2.Text));
                        com.CommandType = CommandType.Text;

                        
                        com.Parameters.Add(p1);
                        SqlDataReader myreader = com.ExecuteReader();

                        if (myreader.HasRows == false)
                        {
                            MessageBox.Show("لا يوجد ");
                        }
                        else
                        {
                            while (myreader.Read())
                            {
                                dataGridView3.Rows.Add(myreader[0], myreader[1], myreader[2]);

                            }
                        }

                    }
                    else
                    {
                        dataGridView4.Rows.Clear();
                        SqlConnection con1 = new SqlConnection(Class1.x);
                        con1.Open();
                        SqlCommand com1 = new SqlCommand("SELECT  bill_id2, sale_date,price FROM  bills  where com=@com and num = 2 ", con1);

                        SqlParameter p10 = new SqlParameter("@com", Convert.ToInt32(company2.Text));
                        com1.CommandType = CommandType.Text;

                        com1.Parameters.Add(p10);
                        SqlDataReader myreader1 = com1.ExecuteReader();

                        if (myreader1.HasRows == false)
                        {
                            MessageBox.Show("لا يوجد ");
                        }
                        else
                        {
                            while (myreader1.Read())
                            {
                                dataGridView4.Rows.Add(myreader1[0], myreader1[1], myreader1[2]);

                            }
                        }
                    }
                }
                else
                {
                    if (radioButton3.Checked == true)
                    {
                        dataGridView3.Rows.Clear();
                        SqlConnection con2 = new SqlConnection(Class1.x);
                        con2.Open();
                        SqlCommand com2 = new SqlCommand("SELECT  bill_id2, sale_date,price FROM  bills  where bill_id2 = @bill_id2 and num = 1 ", con2);

                        SqlParameter p3 = new SqlParameter("@bill_id2", Convert.ToInt32(textBox22.Text));
                       
                        com2.CommandType = CommandType.Text;

                        com2.Parameters.Add(p3);
                     
                        SqlDataReader myreader2 = com2.ExecuteReader();

                        if (myreader2.HasRows == false)
                        {
                            MessageBox.Show("لا يوجد ");
                        }
                        else
                        {
                            while (myreader2.Read())
                            {
                                dataGridView3.Rows.Add(myreader2[0], myreader2[1], myreader2[2]);

                            }
                        }

                    }
                    else
                    {
                        dataGridView4.Rows.Clear();
                        SqlConnection con3 = new SqlConnection(Class1.x);
                        con3.Open();
                        SqlCommand com3 = new SqlCommand("SELECT  bill_id2, sale_date, price FROM  bills  where bill_id2 = @bill_id2 and num = 2 ", con3);

                        SqlParameter p5 = new SqlParameter("@bill_id2", Convert.ToInt32(textBox22.Text));
                        com3.CommandType = CommandType.Text;

                        com3.Parameters.Add(p5);
                        SqlDataReader myreader3 = com3.ExecuteReader();

                        if (myreader3.HasRows == false)
                        {
                            MessageBox.Show("لا يوجد ");
                        }
                        else
                        {
                            while (myreader3.Read())
                            {
                                dataGridView4.Rows.Add(myreader3[0], myreader3[1], myreader3[2]);

                            }
                        }
                    }
                
                
                }





        }
            catch { MessageBox.Show("الرجاء الانتباه"); }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("select company_no from companies ", con);
            com.CommandType = CommandType.Text;
            SqlDataReader reder = com.ExecuteReader();
            while (reder.Read())
            {
                company.Text = Convert.ToString(reder[0]);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("select company_no from companies ", con);
            com.CommandType = CommandType.Text;
            SqlDataReader reder = com.ExecuteReader();
            while (reder.Read())
            {
               company2.Text = Convert.ToString(reder[0]);
            }

           

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {

                SqlConnection con1 = new SqlConnection(Class1.x);
                con1.Open();
                SqlCommand com1 = new SqlCommand("SELECT SUM(price) FROM bills WHERE (num = 1) AND (com = @com)", con1);
                com1.CommandType = CommandType.Text;
                SqlParameter p1 = new SqlParameter("@com", Convert.ToInt32(company2.Text));
                com1.Parameters.Add(p1);
                SqlDataReader reder1 = com1.ExecuteReader();
                while (reder1.Read())
                {
                    textBox23.Text = Convert.ToString(reder1[0]);
                }
            }
            else
            {

                SqlConnection con2 = new SqlConnection(Class1.x);
                con2.Open();
                SqlCommand com2 = new SqlCommand("SELECT SUM(price) FROM bills WHERE (num = 2) AND (com = @com)", con2);
                com2.CommandType = CommandType.Text;
                SqlParameter p2 = new SqlParameter("@com", Convert.ToInt32(company2.Text));
                com2.Parameters.Add(p2);
                SqlDataReader reder2 = com2.ExecuteReader();
                while (reder2.Read())
                {
                    textBox24.Text = Convert.ToString(reder2[0]);
                }



            }

            salary.Text = Convert.ToString(Convert.ToInt32(textBox23.Text) - Convert.ToInt32(textBox24.Text));


            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("UPDATE companies SET rest =  @rest  WHERE (company_name = @company_name)", con);
            SqlParameter p = new SqlParameter("@company_name", Convert.ToString(comboBox5.SelectedItem));
            SqlParameter p10 = new SqlParameter("@rest", Convert.ToInt32(salary.Text));
            com.CommandType = CommandType.Text;
            com.Parameters.Add(p);
            com.Parameters.Add(p10);
            SqlDataReader reder = com.ExecuteReader();


        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("UPDATE items SET quantity = quantity + @quantity  WHERE (item = @item)", con);
            SqlParameter p = new SqlParameter("@item", Convert.ToString(comboBox6.SelectedItem));
            SqlParameter p1 = new SqlParameter("@quantity", Convert.ToInt32(textBox25.Text));
            com.CommandType = CommandType.Text;
            com.Parameters.Add(p);
            com.Parameters.Add(p1);
            SqlDataReader reder = com.ExecuteReader();
            reder.Close();
            com.CommandText = "SELECT item, quantity FROM items WHERE (item = @ite) ";
            com.Connection = con;

            SqlParameter p3 = new SqlParameter("@ite", Convert.ToString(comboBox6.SelectedItem));
            com.Parameters.Add(p3);
            reder = com.ExecuteReader();
            while (reder.Read())
            {
                dataGridView5.Rows.Add(reder[0], reder[1]);

            }

            con.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com1 = new SqlCommand("select company_name from companies where company_name = @c_name", con);
            SqlParameter p1 = new SqlParameter("@c_name", textBox41.Text);
            com1.Parameters.Add(p1);
            com1.CommandType = CommandType.Text;
            SqlDataReader reder1 = com1.ExecuteReader();
            if (reder1.HasRows == true) { MessageBox.Show("الشركة موجودة مسبقاً"); reder1.Close(); }


            else
            {
                SqlConnection con1 = new SqlConnection(Class1.x);
                con1.Open();
                SqlCommand com = new SqlCommand("INSERT INTO companies (company_name, company_address, company_tel, fax, other) VALUES  (@c_name, @c_add, @c_tel, @c_fax, @c_other)", con1);
                SqlParameter p = new SqlParameter("@c_name", textBox41.Text);
                SqlParameter p5 = new SqlParameter("@c_add", textBox39.Text);
                SqlParameter p2 = new SqlParameter("@c_tel", textBox36.Text);
                SqlParameter p3 = new SqlParameter("@c_fax", textBox38.Text);
                SqlParameter p4 = new SqlParameter("@c_other", textBox35.Text);
                com.Parameters.Add(p);
                com.Parameters.Add(p5);
                com.Parameters.Add(p2);
                com.Parameters.Add(p3);
                com.Parameters.Add(p4);
                com.CommandType = CommandType.Text;
                SqlDataReader reder = com.ExecuteReader();
                MessageBox.Show("تمت الأضافة"); reder.Close();
            }
            con.Close();
            textBox41.Text = "";
            textBox39.Text = "";
            textBox36.Text = "";
            textBox38.Text = "";
            textBox35.Text = "";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Class1.x);
                con.Open();
                SqlCommand com = new SqlCommand(" UPDATE  companies SET   company_name =@c_name, company_address =@c_add, company_tel =@c_tel, fax =@c_fax, other =@c_other where company_name=@name ", con);
                SqlParameter p = new SqlParameter("@c_name", comboBox8.Text);
                SqlParameter p1 = new SqlParameter("@c_add", textBox43.Text);
                SqlParameter p2 = new SqlParameter("@c_tel", textBox40.Text);
                SqlParameter p3 = new SqlParameter("@c_fax", textBox42.Text);
                SqlParameter p4 = new SqlParameter("@c_other", textBox37.Text);
                SqlParameter p5 = new SqlParameter("@name", textBox34.Text);
                com.CommandType = CommandType.Text;
                com.Parameters.Add(p);
                com.Parameters.Add(p1);
                com.Parameters.Add(p2);
                com.Parameters.Add(p3);
                com.Parameters.Add(p4);
                com.Parameters.Add(p5);
                SqlDataReader reder = com.ExecuteReader();

                con.Close();
                comboBox8.Text = "";
                textBox43.Text = "";
                textBox40.Text = "";
                textBox42.Text = "";
                textBox37.Text = "";
                MessageBox.Show("تم التعديل"); reder.Close();
            }
            catch { MessageBox.Show("حدث خطأ "); }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox34.Text = comboBox8.Text;
            SqlConnection con = new SqlConnection(Class1.x);
                con.Open();
                SqlCommand com = new SqlCommand("SELECT company_name, company_address, company_tel, fax, other   FROM companies   WHERE(company_name = @name)", con);
                SqlParameter p = new SqlParameter("@name", textBox34.Text);
                com.Parameters.Add(p);
                com.CommandType = CommandType.Text;
                SqlDataReader reder = com.ExecuteReader();
                 }

        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Class1.x);
                con.Open();
                SqlCommand com = new SqlCommand("delete from companies where company_name =@c_name  ", con);
                SqlParameter p = new SqlParameter("@c_name", comboBox9.Text);
                com.CommandType = CommandType.Text;
                com.Parameters.Add(p);
                SqlDataReader reder = com.ExecuteReader();

                con.Close();
                comboBox9.Text = "";
                MessageBox.Show("تم الحذف"); reder.Close();
            }
            catch { MessageBox.Show("حدث خطأ "); }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            comboBox8.Items.Clear();
            comboBox9.Items.Clear();
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT  company_name FROM  companies", con);
            com.CommandType = CommandType.Text;
            SqlDataReader reder = com.ExecuteReader();
            while (reder.Read())
            {
                comboBox8.Items.Add(reder[0]);
                comboBox9.Items.Add(reder[0]);
            }
            reder.Close();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void itemsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Class1.x);
            con.Open();
            SqlCommand com = new SqlCommand("UPDATE companies SET rest = rest - @rest  WHERE (company_name = @company_name)", con);
            SqlParameter p = new SqlParameter("@company_name", Convert.ToString(comboBox5.SelectedItem));
            SqlParameter p1 = new SqlParameter("@rest", Convert.ToInt32(textBox44.Text));
            com.CommandType = CommandType.Text;
            com.Parameters.Add(p);
            com.Parameters.Add(p1);
            SqlDataReader reder = com.ExecuteReader();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(Class1.x);
            con1.Open();
            SqlCommand com1 = new SqlCommand("SELECT rest FROM companies WHERE (company_name = @company_name) ", con1);
            SqlParameter p = new SqlParameter("@company_name", Convert.ToString(comboBox5.SelectedItem));
            
            com1.CommandType = CommandType.Text;
            
            com1.Parameters.Add(p);
            SqlDataReader reder1 = com1.ExecuteReader();
            while (reder1.Read())
            {
                textBox45.Text = Convert.ToString(reder1[0]);
            }
        }

       

        
        }

       
       
      
        

       
       
        }
    

