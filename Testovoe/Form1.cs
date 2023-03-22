using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Testovoe.Read;
using static Testovoe.workDoc;

namespace Testovoe
{
    public partial class Form1 : Form
    {
        public static DateTime time = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            label1.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            button1.Visible = false;

            DbConnect db = new DbConnect();
            db.ConnectSql();
            db.sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM [Table]", db.sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void Start_Click(object sender, EventArgs e)
        {
            var sw = new Stopwatch();
            sw.Start();
            Db_CMD cMD = new Db_CMD();
            cMD.clearTable();
            Read read = new Read();
            string path1 = "/Users/Sakurych/Desktop/Тестовое задание/Тестовое задание - РКК.txt";
            string path2 = "/Users/Sakurych/Desktop/Тестовое задание/Тестовое задание - Обращения.txt";
            read.readRKK(path1);
            read.readObr(path2);
            cMD.setSum();
            sw.Stop();
            textBox2.Text = path1;
            textBox3.Text = path2;

            textBox1.Text = sw.Elapsed.ToString();

            textBox1.Visible=true;
            Start.Visible= false;
            dataGridView1.Visible = true;
            label1.Visible= true;
            comboBox1.Visible= true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            button1.Visible = true;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    (dataGridView1.DataSource as DataTable).DefaultView.Sort = $"Otv DESC";
                        break;


                case 1:
                    (dataGridView1.DataSource as DataTable).DefaultView.Sort = $"RKK DESC, Obrach DESC";
                    break;


                case 2:
                    (dataGridView1.DataSource as DataTable).DefaultView.Sort = $"Obrach DESC, RKK DESC";
                    break;


                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.Sort = $"Kolvo DESC, RKK DESC";
                    break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Otv LIKE '%{textBox1.Text}%'";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.Sort = $"Kolvo DESC, RKK DESC";
            workDoc work = new workDoc();
            work.work(dataGridView1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
