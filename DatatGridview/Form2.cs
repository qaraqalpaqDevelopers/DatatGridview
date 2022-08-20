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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;
        Data Source=C:\Users\IT Park\Desktop\for_Database\for_Database\bin\Debug\Database1.mdb";
        string table3 = "SELECT * From table3";
        int ball = 0, qate = 0, number = 0;

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        string[] s = new string[10];
        string[] ar1 = new string[10];
        string[] ar2 = new string[10];
        string[] ar3 = new string[10];
        string[] ar4 = new string[10];
        string[] j = new string[10];
        List<string> massiv = new List<string>();
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(table3, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        s[i] = ds.Tables[0].Rows[i]["soraw"].ToString();
                        ar1[i] = ds.Tables[0].Rows[i]["a"].ToString();
                        ar2[i] = ds.Tables[0].Rows[i]["b"].ToString();
                        ar3[i] = ds.Tables[0].Rows[i]["c"].ToString();
                        ar4[i] = ds.Tables[0].Rows[i]["d"].ToString();
                        j[i] = ds.Tables[0].Rows[i]["j"].ToString();
                    }
                }
            }
            foreach (string x in ar1)
            {
                if (x != "" && x != null)
                {
                    massiv.Add(x);
                }
            }
            next();
        }
        Random rand = new Random();
        int x = 0;
        private void next()
        {
            x=rand.Next(0,4);
            label1.Text=s[x].ToString();
            button1.Text=ar1[x].ToString();
            button2.Text=ar2[x].ToString();
            button3.Text=ar3[x].ToString();
            button4.Text=ar4[x].ToString();
        }


        private void tekseriw(Button btn)
        {
            if (btn.Text == j[x].ToString())
            {
                next();
                ball++;
            }
            else
            {
                MessageBox.Show($"Qate!\nid={x}");
                qate++;
            }
            if (ball > 10)
            {
                             panel1.Visible = true;
                this.chart1.Titles.Add("Total Income");
                chart1.PointToClient(new Point(ball,qate));
            }
        }

        private void aa_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tekseriw(button1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tekseriw(button3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tekseriw(button2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tekseriw(button4);
        }
    }
}
