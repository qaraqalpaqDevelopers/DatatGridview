using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DatatGridview
{
    public partial class Form1 : Form
    {
        string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;
        Data Source=C:\Users\IT Park\Desktop\for_Database\for_Database\bin\Debug\Database1.mdb";
        string table1 = "SELECT * From table1";
        string table2 = "SELECT * From table2";

        public Form1()
        {
            InitializeComponent();
            janalaw(table1);
        }
        private void janalaw(string zp)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(zp, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text == "")
            {
                janalaw(table1);
            }
            else
            {
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter($"Select * from table1 where ang like '%{guna2TextBox1.Text}%'", conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                }
         
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter($"Delete * from table1 where ang='{guna2TextBox1.Text}'", conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                  //  dataGridView1.DataSource = ds.Tables[0];
                }
            }
            janalaw(table1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            janalaw(table1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter($"Insert into table1(id,ang,qq) values('{textBox3.Text}','{textBox1.Text}','{textBox2.Text}')", conn))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        //  dataGridView1.DataSource = ds.Tables[0];
                    }
                }
                janalaw(table1);
            }
            catch
            {
                MessageBox.Show("Bar bolgan ID kiritildi\nBasqa ID jazin!","Qatelik");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ff = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            this.Text = ff;
            using (OleDbConnection conn = new OleDbConnection(connStr))
             {
                 using (OleDbDataAdapter adapter = new OleDbDataAdapter($"Delete * from table1 where ang='{ff}'", conn))
                 {
                     DataSet ds = new DataSet();
                     adapter.Fill(ds);
                     //  dataGridView1.DataSource = ds.Tables[0];
                 }
             }
            janalaw(table1);
        }

        private void table1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void table2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            janalaw(table2);
        }
        string[] ar1 =new string [100];
        List<string> ar2 = new List<string>();
        private void button5_Click(object sender, EventArgs e)
        {
           
             using (OleDbConnection conn = new OleDbConnection(connStr))
              {
                  using (OleDbDataAdapter adapter = new OleDbDataAdapter(table1, conn))
                  {
                      DataSet ds = new DataSet();
                      adapter.Fill(ds);
                     for (int i=0; i<ds.Tables[0].Rows.Count;i++)
                      {
                          ar1[i] = ds.Tables[0].Rows[i]["ang"].ToString();
                      }
                  }
              }
             foreach (string x in ar1)
            {
                if (x != "" && x != null)
                {
                    ar2.Add(x);
                }
            }
            listBox1.Visible = true;
            listBox1.Items.AddRange(ar2.ToArray());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form aa=new Form2();
            aa.ShowDialog();
            this.SendToBack();
        }
    }
    
   
}
