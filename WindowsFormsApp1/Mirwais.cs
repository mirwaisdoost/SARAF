using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Mirwais : Form
    {
        public Mirwais()
        {
            InitializeComponent();
            tableLayoutPanel1.AutoScroll = true;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(typeof(int));
            comboBox1.Items.Add(typeof(float));
            comboBox1.Items.Add(typeof(double));
            comboBox1.Items.Add(typeof(string));
        }

        int p_dt = 0;        //position of adding new DataTable
        int p = 0;           //position of adding new columns in tablelayoutPanel
        int c = 1;           //nomber of tablelayoutPanel columns
        TextBox[] text = new TextBox[100];
        Label[] label = new Label[100];
        ComboBox[] combo = new ComboBox[100];
        int[] nul = new int[100];
        int[] b_f_k = new int[100]; // The column which will be added to the combo box in child table
        int[] p_k = new int[100];   //palce primary key position
        int[] f_k = new int[100];   //place foreign key position
        int[] t_f_c = new int[100];      //table first column in tablelayoutPanel
        int[] t_l_c = new int[100];      //table last column in tablelayoutPanel
        DataSet ds = new DataSet("MyDatabase");
        DataTable dt;
        int index;

        private void button1_Click_1(object sender, EventArgs e)
        {
            text[p] = new TextBox();
            label[p] = new Label();
            combo[p] = new ComboBox();
            try
            {
                if (textBox1.Enabled == true)
                {
                    dt = new DataTable();
                    ds.Tables.Add(dt);
                    t_f_c[p_dt] = p;
                    p_dt++;
                }
                t_l_c[p_dt-1] = p;
                dt.TableName = textBox1.Text;
                DataColumn cl = new DataColumn(textBox2.Text, (Type)comboBox1.SelectedItem,textBox5.Text);
                ds.Tables[p_dt-1].Columns.Add(cl);

                if (checkBox1.Checked)
                    nul[p] = 1;
                else
                    nul[p] = 0;

                if (checkBox2.Checked)
                    p_k[p] = 1;
                else
                    p_k[p] = 0;

                if (checkBox3.Checked)
                    f_k[p] = 1;
                else
                    f_k[p] = 0;

                if (checkBox4.Checked)
                    b_f_k[p] = 1;
                else
                    b_f_k[p] = 0;

                combo[p].Height = label[p].Height-1;
                combo[p].Width = label[p].Width;
                label[p].Text = textBox2.Text;
                text[p].Margin = new Padding(0, 0, 0, 0);
                combo[p].Margin = new Padding(0, 0, 0, 0);
                label[p].Margin = new Padding(0, 0, 0, 0);
                label[p].BackColor = Color.LightBlue;
                label[p].TextAlign = ContentAlignment.MiddleLeft;
                tableLayoutPanel1.ColumnCount = c;

                if (p_k[p] == 1)
                {

                    dt.PrimaryKey = new DataColumn[] { ds.Tables[p_dt - 1].Columns[p-t_f_c[p_dt-1]] };
                }

                dataGridView1.DataSource = ds.Tables[p_dt-1];
                if (textBox1.Enabled == true)
                {
                    comboBox2.Items.Add(textBox1.Text);
                    comboBox4.Items.Add(textBox1.Text);
                    comboBox5.Items.Add(textBox1.Text);
                }
                textBox1.Enabled = false;

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;

                p++;
                c++;

                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int check = 0;
            String message = "";

            try
            {
                for(int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
                {
                    if (text[i].Text.Trim() == "")
                    {
                        if (f_k[i] != 1)
                        {
                            if (nul[i] == 0)
                            {
                                check = 1;
                                message += label[i].Text + " can not be null \r\n";
                            }
                            else
                            {
                                check += check;
                            }
                        }
                    }
                }

                for (int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
                {
                    if (combo[i].Text.Trim() == "")
                    {
                        if (f_k[i] != 0)
                        {
                            if (nul[i] == 0)
                            {
                                check = 1;
                                message += label[i].Text + " can not be null \r\n";
                            }
                            else
                            {
                                check += check;
                            }
                        }
                    }
                }

                if (check == 0)
                {
                    int p_pr_k = 0;  //position the text box that is holding primary key constraint in parent table
                    int p_b_f_k = 0; //position the column that is binding foreign key constraint in parent table

                    for (int i = t_f_c[t_p]; i <= t_l_c[t_p]; i++)
                    {
                        if (p_k[i] == 1)
                            p_pr_k = i- t_f_c[t_p];
                        //else
                        //    p_pr_k = p_pr_k;
                    }

                    for (int i = t_f_c[t_p]; i <= t_l_c[t_p]; i++)
                    {
                        if (b_f_k[i] == 1)
                            p_b_f_k = i - t_f_c[t_p];
                        //else
                        //    p_b_f_k = p_b_f_k;
                    }

                    int ii = 0;
                    DataRow dr = ds.Tables[comboBox2.SelectedIndex].NewRow();
                    for(int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
                    {
                        if (text[i].Text.Trim() == "")
                        {
                            dr[ii] = System.DBNull.Value;
                        }
                        if (f_k[i] == 1)
                        {
                            DataRow[] dtr = ds.Tables[t_p].Select(label[p_b_f_k].Text + "='" + combo[i].SelectedItem.ToString() + "'");
                            text[i].Text = dtr[0][p_pr_k].ToString();
                            dr[ii] = text[i].Text;
                        }
                        else
                        {
                            dr[ii] = text[i].Text;
                        }
                        ii++;
                    }

                    int pr_k = 0;  //position the text box that is holding primary key constraint

                    for(int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
                    {
                        if (p_k[i] == 1)
                            pr_k = i;
                        //else
                        //    pr_k = pr_k;
                    }

                    text[pr_k].Text = (int.Parse(text[pr_k].Text)+1).ToString();
                    ds.Tables[comboBox2.SelectedIndex].Rows.Add(dr);
                    for(int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
                    {
                        if (i != pr_k)
                            text[i].Text = "";
                    }
                }
                else
                {
                    MessageBox.Show(message);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int ii = 0;
            index = dataGridView1.CurrentRow.Index;
            try
            {
                for (int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
                {
                    text[i].Text = ds.Tables[comboBox2.SelectedIndex].Rows[index][ii].ToString();
                    ii++;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int check = 0;
            string message = "";
            int ii = 0;
            try
            {
                for (int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
                {
                    if (text[i].Text.Trim() == "")
                    {
                        if (nul[i] == 0)
                        {
                            check = 1;
                            message += label[i].Text + " can not be null \r\n";
                        }
                        else
                        {
                            check += check;
                        }
                    }
                }
                if (check == 0)
                {

                    int p_pr_k = 0;  //position the text box that is holding primary key constraint in parent table
                    int p_b_f_k = 0; //position the column that is binding foreign key constraint in parent table

                    for (int i = t_f_c[t_p]; i <= t_l_c[t_p]; i++)
                    {
                        if (p_k[i] == 1)
                            p_pr_k = i - t_f_c[t_p];
                        //else
                        //    p_pr_k = p_pr_k;
                    }

                    for (int i = t_f_c[t_p]; i <= t_l_c[t_p]; i++)
                    {
                        if (b_f_k[i] == 1)
                            p_b_f_k = i - t_f_c[t_p];
                        //else
                        //    p_b_f_k = p_b_f_k;
                    }
                    
                    for (int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
                    {
                        if (text[i].Text.Trim() == "")
                        {
                            ds.Tables[comboBox2.SelectedIndex].Rows[index][ii] = System.DBNull.Value;
                        }
                        if (f_k[i] == 1)
                        {
                            DataRow[] dtr = ds.Tables[t_p].Select(label[p_b_f_k].Text + "='" + combo[i].SelectedItem.ToString() + "'");
                            text[i].Text = dtr[0][p_pr_k].ToString();
                            ds.Tables[comboBox2.SelectedIndex].Rows[index][ii] = text[i].Text;
                        }
                        else
                        {
                            ds.Tables[comboBox2.SelectedIndex].Rows[index][ii] = text[i].Text;
                        }
                        ii++;
                    }
                }
                else
                {
                    MessageBox.Show(message);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ds.Tables[comboBox2.SelectedIndex].Rows.RemoveAt(index);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ii = 0;
            int check = 0;
            string message = "";
            try
            {
                for (int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
                {
                    if (text[i].Text.Trim() == "")
                    {
                        if (nul[i] == 0)
                        {
                            check = 1;
                            message += label[i].Text + " can not be null \r\n";
                        }
                        else
                        {
                            check += check;
                        }
                    }
                }
                if (check == 0)
                {
                    DataRow dr = ds.Tables[comboBox2.SelectedIndex].NewRow();
                    int p_pr_k = 0;  //position the text box that is holding primary key constraint in parent table
                    int p_b_f_k = 0; //position the column that is binding foreign key constraint in parent table

                    for (int i = t_f_c[t_p]; i <= t_l_c[t_p]; i++)
                    {
                        if (p_k[i] == 1)
                            p_pr_k = i - t_f_c[t_p];
                        //else
                        //    p_pr_k = p_pr_k;
                    }

                    for (int i = t_f_c[t_p]; i <= t_l_c[t_p]; i++)
                    {
                        if (b_f_k[i] == 1)
                            p_b_f_k = i - t_f_c[t_p];
                        //else
                        //    p_b_f_k = p_b_f_k;
                    }

                    for (int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
                    {
                        if (text[i].Text.Trim() == "")
                        {
                            dr[ii] = System.DBNull.Value;
                        }
                        if (f_k[i] == 1)
                        {
                            DataRow[] dtr = ds.Tables[t_p].Select(label[p_b_f_k].Text + "='" + combo[i].SelectedItem.ToString() + "'");
                            text[i].Text = dtr[0][p_pr_k].ToString();
                            dr[ii] = text[i].Text;
                        }
                        else
                        {
                            dr[ii] = text[i].Text;
                        }
                        ii++;
                    }
                    ds.Tables[comboBox2.SelectedIndex].Rows.InsertAt(dr, index);
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ds.Tables[p_dt-1].RejectChanges();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ds.Tables[p_dt-1].AcceptChanges();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                int ii = 0;
                DataRow[] dr = ds.Tables[comboBox2.SelectedIndex].Select(comboBox3.SelectedItem + "='" + textBox3.Text + "'");
                int p_pr_k = 0;  //position the text box that is holding primary key constraint in parent table
                int p_b_f_k = 0; //position the column that is binding foreign key constraint in parent table

                for (int i = t_f_c[t_p]; i <= t_l_c[t_p]; i++)
                {
                    if (p_k[i] == 1)
                        p_pr_k = i - t_f_c[t_p];
                    //else
                    //    p_pr_k = p_pr_k;
                }

                for (int i = t_f_c[t_p]; i <= t_l_c[t_p]; i++)
                {
                    if (b_f_k[i] == 1)
                        p_b_f_k = i - t_f_c[t_p];
                    //else
                    //    p_b_f_k = p_b_f_k;
                }

                //for (int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
                //{
                //    if (f_k[i] == 1)
                //    {   //                                                       +"='" + textBox3.Text + "'"
                //        DataRow[] dtr = ds.Tables[t_p].Select(label[p_pr_k].Text + "='" + text[i].Text + "'");
                //        combo[i].Items.Equals(dtr[0][p_b_f_k].ToString());
                //    }
                //    else
                //    {
                //        text[i].Text = dr[0][ii].ToString();
                //    }
                //    ii++;
                //}

                for (int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
                {
                    text[i].Text = dr[0][ii].ToString();
                    ii++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        int p_b_f_k = -1;    //position of the column that is defined for binding with foreign key
        int t_p = 0;    //position of table in DataSet
        int p_f_k = 0;  //position of foreign key

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < p; i++)
            {
                tableLayoutPanel1.Controls.Remove(text[i]);
                tableLayoutPanel1.Controls.Remove(label[i]);
                tableLayoutPanel1.Controls.Remove(combo[i]);
            }
            comboBox3.Items.Clear();
            tableLayoutPanel1.ColumnCount = p;
            for (int i = t_f_c[comboBox2.SelectedIndex]; i <= t_l_c[comboBox2.SelectedIndex]; i++)
            {
                tableLayoutPanel1.Controls.Add(label[i], i, 0);

                if (f_k[i] == 1)
                {
                    tableLayoutPanel1.Controls.Add(combo[i], i, 1);
                    p_f_k = i;
                }
                else
                    tableLayoutPanel1.Controls.Add(text[i], i, 1);

                comboBox3.Items.Add(label[i].Text);

                if(b_f_k[i] == 1)
                {
                    p_b_f_k = i - t_f_c[t_p];
                    t_p = comboBox2.SelectedIndex;
                }
                //else
                //{
                //    p_b_f_k = p_b_f_k;
                //}
            }

            combo[p_f_k].Items.Clear();
            if (p_b_f_k > -1)
            {
                int tr = ds.Tables[t_p].Rows.Count; //finding the number of rows in selected table
                for (int i = 0; i < tr; i++)
                    combo[p_f_k].Items.Add((ds.Tables[t_p].Rows[i][p_b_f_k]).ToString());
            }

            dataGridView1.DataSource = ds.Tables[comboBox2.SelectedIndex];
            label4.Text = comboBox2.SelectedItem.ToString();
            label6.Text = comboBox2.SelectedItem.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            checkBox1.Checked = false;
            dataGridView1.DataSource = null;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int pr_k = 0;
            int fr_k = 0;

            for (int i = t_f_c[comboBox4.SelectedIndex]; i <= t_l_c[comboBox4.SelectedIndex]; i++)
            {
                if (p_k[i] == 1)
                    pr_k = i;
                //else
                //    pr_k = pr_k;
            }

            for (int i = t_f_c[comboBox5.SelectedIndex]; i <= t_l_c[comboBox5.SelectedIndex]; i++)
            {
                if (f_k[i] == 1)
                    fr_k = i;
                //else
                //    fr_k = fr_k;
            }
            
            try
            {
                DataRelation dl = new DataRelation("tableRelation", ds.Tables[comboBox4.SelectedIndex].Columns[pr_k- t_f_c[comboBox4.SelectedIndex]], ds.Tables[comboBox5.SelectedIndex].Columns[fr_k- t_f_c[comboBox5.SelectedIndex]]);
                ds.Relations.Add(dl);
                MessageBox.Show("The Relation is succedfully created!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            DataRow dr = ds.Tables[1].Rows[i].GetParentRow("tableRelation");
            DataTable pdt = ds.Tables[0].Clone();
            pdt.ImportRow(dr); // make a parent DataTable
            dataGridView1.DataSource = pdt;
            label4.Text = ds.Tables[0].TableName;
        }

        private void button13_Click(object sender, EventArgs e)
        {
             int i = dataGridView1.CurrentRow.Index;
            DataRow[] dr = ds.Tables[0].Rows[i].GetChildRows("tableRelation");
            DataTable cdt = ds.Tables[1].Clone();

            foreach(DataRow r in dr)
                cdt.ImportRow(r); //make child DataTable

            dataGridView1.DataSource = cdt;
            label4.Text = ds.Tables[1].TableName;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
