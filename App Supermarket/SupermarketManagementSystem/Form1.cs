using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SupermarketManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string Sellername = "";
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PassTb.Text = "";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(UnameTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Enter Username and Password");
            }
            else
            {
                if(RoleCb.SelectedIndex > -1)
                {
                    if(RoleCb.SelectedItem.ToString() == "Admin")
                    {
                        if (UnameTb.Text == "Admin" && PassTb.Text == "Admin")
                        {
                            ProductForm prod = new ProductForm();
                            prod.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If You are the Admin, Enter Correct Username and Password");
                        }
                    }
                    else
                    {
                        Con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("select count(8) from SellerTbl where SellerName='"+UnameTb.Text+"' and SellerPass='"+PassTb.Text+"'", Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if(dt.Rows[0][0].ToString() == "1")
                        {
                            Sellername = UnameTb.Text;
                            SellingForm sell = new SellingForm();
                            sell.Show();
                            this.Hide();
                            Con.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password");
                        }
                        Con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select A Role");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
