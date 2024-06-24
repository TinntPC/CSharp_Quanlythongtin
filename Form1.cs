using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace CSharp_Quanlythongtin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=LAB1-MAY32\MISASME2022;Initial Catalog=Quanlythongtin;Integrated Security=True");
        private void opencon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();

            }
        }
        private void closecon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private Boolean Exe(String cmd)
        {
            opencon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception)
            {
                check = false;
            }
            closecon();
            return check;
        }
        private DataTable Red(String cmd)
        {
            opencon();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (Exception)
            {
                dt = null; 
                throw;
            }
            closecon();
            return dt;
        }
        private void load()
        {
            DataTable dt = Red("SELECT * FROM Quanlythongtin");
            if(dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maTT.ResetText();
            hoTen.ResetText();
            namSinh.ResetText();
            queQuan.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Exe("INSERT INTO Quanlythongtin(maTT, hoTen, namSinh, queQuan) VALUES(N'" + maTT.Text + "',N'" + hoTen.Text + "',N'" + namSinh.Text + "',N'" + queQuan.Text + "')");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            load();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Exe("UPDATE Quanlythongtin SET maTen = N'" + maTT.Text + "',hoTen = N'" + hoTen.Text + "',namSinh = N'" + namSinh.Text + "',queQuan = N'" + queQuan.Text + "' WHERE maTT = '" + maTT.Text +  "' ");
        }
    }
}
