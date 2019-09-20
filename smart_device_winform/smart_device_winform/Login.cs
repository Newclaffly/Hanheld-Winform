using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace smart_device_winform
{
    public partial class Login : Form
    {
        //string connecting = @"Data Source=DESKTOP-IUTHPCG\SQLEXPRESS;Initial Catalog=bds_pp_srct;Integrated Security=true;"; //sql connection
        string username_s;
        string password_s;
        string qrcode;
        //string get_username;
        //int rows_db = 0;
        public Login()
        {
            InitializeComponent();
        }

       
          private void checklogin()//update_data_to_db();
        {
            qrcode = user.Text;
            //password_s = pass.Text;
            WebReference.WebService_kanban mytagdata = new WebReference.WebService_kanban();
            DataTable dt = mytagdata.login(this.qrcode);
            string qr_db = (string)dt.Rows[0]["QRCode"];
            string name = (string)dt.Rows[0]["Username"];
            Form1 f1 = new Form1(qrcode); //ตั้งชื่อเพื่อเรียกใช้ฟอร์ม1 พร้อมส่งข้อความ (data)
            MessageBox.Show(qrcode);
            if (dt.Rows.Count > 0)
            {
                if (qrcode == qr_db)
                {
                    MessageBox.Show("เข้าสู่ระบบสำเร็จ ยินดีต้อนรับ : '" + name + "' ");
                    user.Text = name;
                    this.Hide();
                    f1.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("ไม่สามรถเข้าระบบได้");
                }
                //MessageBox.Show(get_username);
            }
        }
        /*
        private void checklogin()
        {
            try
            {
                string username = user.Text;
                string password = pass.Text;
                using (SqlConnection conn = new SqlConnection(connecting))
                {
                    
                    SqlDataAdapter dtaddAdapter;
                    DataTable dt = new DataTable();
                    string add = "SELECT Username,Password,EmployeeName,Department From s_user WHERE Username='" + username + "' AND Password = '" + password + "' ";
                    dtaddAdapter = new SqlDataAdapter(add, conn);
                    dtaddAdapter.Fill(dt);
                    string dpt = dt.Rows[0]["EmployeeName"].ToString();
                    string data = dpt;
                    Form1 f1 = new Form1(data); //ตั้งชื่อเพื่อเรียกใช้ฟอร์ม1 พร้อมส่งข้อความ (data)
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("เข้าสู่ระบบสำเร็จ ยินดีต้อนรับ : '" + username + "' ");
                        this.Hide();
                        f1.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("เข้าสู่ระบบไม่ถูกต้องโปรดตรวจสอบ Username และ Password");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */
        private void log_Click_1(object sender, EventArgs e)
        {
            checklogin();
        }

        private void close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
