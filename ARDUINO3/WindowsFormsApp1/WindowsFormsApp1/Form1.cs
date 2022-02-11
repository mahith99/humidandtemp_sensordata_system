using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection Con = new SqlConnection();
        SqlCommand Cmd = new SqlCommand();
        SqlDataAdapter Dap = new SqlDataAdapter();       
        DataTable datab=new DataTable();
        DataTable datab1 = new DataTable();
       // Form2 f2 = new Form2();
       
        string r = "off",b="off",g="off",c="t",d;
        string t, h;
        public Form1()
        {
            InitializeComponent();
            Con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\ARDUNO PROJECTS\ARDUINO3\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True";
            timer1.Enabled = true;
            timer2.Enabled = false;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
               
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "ERROR");
            }
            try
            {


                Con.Open();
                string st = "SELECT * FROM TAB";
                Dap = new SqlDataAdapter(st, Con);
                Dap.Fill(datab);
                //dataGridView1.DataSource = null;
                dataGridView1.DataSource = datab;
                Con.Close();
            }
            catch (Exception ex)
            {

                Con.Close();
                MessageBox.Show(ex + "ERROR");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (r == "off")
            {
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("ron");
                    r = "on";
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "ERROR");
                }

            }
            else
            {
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("roff");
                    r = "off";
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "ERROR");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (b == "off")
            {
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("yon");
                    b = "on";
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "ERROR");
                }

            }
            else
            {
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("yoff");
                    b = "off";
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "ERROR");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (g == "off")
            {
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("gon");
                    g = "on";
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "ERROR");
                }

            }
            else
            {
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("goff");
                    g = "off";
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "ERROR");
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      private void timer1_Tick(object sender, EventArgs e)
        {
            if (c == "h")
            {
                if (comboBox1.Text != "COM1")
                {
                    try
                    {
                        serialPort1.Open();
                        serialPort1.WriteLine("gh");
                        textBox1.Text = "HUMIDITY:" + serialPort1.ReadLine() + "%";
                        serialPort1.Close();
                    }
                    catch (Exception ex)
                    {
                        //   MessageBox.Show(ex + "ERROR");
                        serialPort1.Close();
                    }
                }
                else
                {

                    textBox1.Text = "CHOSE THE SERIALPORT";

                }

            }
            else if (c == "t")
            {
                if (comboBox1.Text != "COM1")
                {

                    try
                    {
                        serialPort1.Open();
                        serialPort1.WriteLine("gt");
                        textBox1.Text = "TEMP:" + serialPort1.ReadLine() + "C";
                        serialPort1.Close();
                    }
                    catch (Exception ex)
                    {
                        // MessageBox.Show(ex + "ERROR");
                        serialPort1.Close();
                    }

                }
                else
                {
                   
                    textBox1.Text = "CHOSE THE SERIALPORT";
                 
                }
            }
           
                
        }

        private void button7_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer1.Enabled = false;
            textBox1.Text = "DATA STORAGE ";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            //f2.Show();
            Application.Restart();




        }

        private void button10_Click(object sender, EventArgs e)
        {

            try
            {
                Con.Open();
                string st = "DELETE FROM TAB";
                Cmd = new SqlCommand(st, Con);
                Cmd.ExecuteNonQuery();
                MessageBox.Show("DATA DELETED");


                Con.Close();
            }
            catch (Exception ex)
            {

                Con.Close();
                MessageBox.Show(ex + "ERROR");
            }
            //Application.Restart();
            //f2.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            d = DateTime.Now.ToLongTimeString();
            if (comboBox1.Text != "COM1")
            {
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("gh");
                    textBox3.Text =  serialPort1.ReadLine() ;
                   
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    //   MessageBox.Show(ex + "ERROR");
                    serialPort1.Close();
                }
                h = textBox3.Text;
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("gt");
                    textBox2.Text =  serialPort1.ReadLine() ;
                   
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex + "ERROR");
                    serialPort1.Close();
                }
                t = textBox2.Text;
                try
                {
                    Con.Open();
                    string st = "INSERT INTO TAB VALUES('"+d+"','"+t+"','"+h+"')";
                    Cmd = new SqlCommand(st,Con);
                    Cmd.ExecuteNonQuery();
                    Con.Close();
                }
                catch (Exception ex)
                {
                   
                    Con.Close();
                    MessageBox.Show(ex + "ERROR");
                }
              /*  try
                {
                    Con.Open();
                    string st = "SELECT * FROM TAB";
                    Dap = new SqlDataAdapter(st, Con);
                    Dap.Fill(datab);
                    dataGridView1.DataSource = datab;
                    Con.Close();
                }
                catch (Exception ex)
                {

                    Con.Close();
                    MessageBox.Show(ex + "ERROR");
                }*/
            }
            else
            {

                textBox2.Text = "CHOSE THE SERIALPORT";
                textBox3.Text = "CHOSE THE SERIALPORT";

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            c = "h";
           /* if (comboBox1.Text != "COM1")
            {
                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("gh");
                    textBox1.Text ="HUMIDITY:"+ serialPort1.ReadLine()+"%";
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                 //   MessageBox.Show(ex + "ERROR");
                    serialPort1.Close();
                }
            }*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            c = "t";
          /*  if (comboBox1.Text != "COM1")
            {

                try
                {
                    serialPort1.Open();
                    serialPort1.WriteLine("gt");
                    textBox1.Text ="TEMP:"+ serialPort1.ReadLine()+"C";
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex + "ERROR");
                    serialPort1.Close();
                }

            }*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                serialPort1.PortName = comboBox1.Text;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "ERROR");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            try
            {
                comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "ERROR");
            }
        }
    }
}
