using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Data.SqlServerCe;
using System.Globalization;

namespace smart_device_winform
{
    public partial class Form1 : Form
    {
        string partnumber_kanban;
        string orderid_kanban;
        string lotsize_kanban;

        string partnumber_partpi;
        string srctr_partpi;
        string kanbanid_partpi;
        int  pi_qty;
        string dockcode_pi;

        string rs_split_tag;
        string username ;

        int rows_db = 0;
        int rows_local = 0 ;
       // int rows_up = 0;

        //int id = 0;

        /*
        string part_db;
        string srct_db;
        string dock_db;
        int pack_db = 0;
        string error_db;
        string chk_db;
        Boolean match_db;
        string user_db;
        DateTime date_db;
        string pds_db;
        string ekb_db;
        string kanban_db;
        */
        string part_number_t_tag;
        string srct_code_local_kanban;

        //m_kanban
        string srct_code_kanban;
        string customer_Code_kanban;
        string attension_point_kanban;
        string part_Number_kanban;
        string part_Name_kanban;
        string model_kanban;
        int package_kanban;
        string customer_kanban;
        string line_kanban;
        string store_Address_kanban;
        string part_Ilustration_kanban;
        string part_Ilustration_Path_kanban;
        string dock_Code_kanban;
        string location_kanban;
        int kb_running_kanban;

        //LogHanheld
        //int id_local;
        string part_local;
        string srct_local;
        string dock_local;
        int pack_local = 0;
        string error_local;
        string chk_local;
        //Boolean match_local;
        string user_local;
        DateTime date_local;
       // string pds_local;
        string ekb_local;
        string kanban_local;
        
        string temp_2;
        ArrayList al = new ArrayList();

        public Form1(string data)
        {
            InitializeComponent();

            label4.Text = data;
            username = data;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            update_data_local_to_db();
            update_db_from_local();
            //count_rows_db();
            //count_rows_local();
            //update_data_to_local();
           // update_data_to_db();
            //update_data_to_db();
            //get_t_part_tag_db();
            //get_m_kanban_from_local();
        }

        private void split_kanban()
        {
            string data_kb = txtkb.Text;
            string[] kanban_split = data_kb.Split('-');
            partnumber_kanban = kanban_split[0];
           
            MessageBox.Show(partnumber_kanban.ToString());
        }

        private void split_pi()
        {
            string data_pi = txtpi.Text;
            string[] pi_split = data_pi.Split('|');
            partnumber_partpi = pi_split[0];
            srctr_partpi = pi_split[1];
            pi_qty = System.Convert.ToInt32(pi_split[3]);
            dockcode_pi = pi_split[2];
            kanbanid_partpi = pi_split[5];
            //int taglot = Int32.Parse(dev);
            MessageBox.Show(partnumber_partpi.ToString());
        }
        private void split_tag()
        {
            string data_tag = txttag.Text;
            string[] rs_tag = data_tag.Split('P');
            rs_split_tag = rs_tag[0];
            MessageBox.Show(rs_split_tag.ToString());
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

            count_rows_local_kanban();
            count_rows_db_m_kanban();
            if (rows_db > rows_local)
            {
                MessageBox.Show("Insert Kanban Local Update");
                delete_rows_same();
                get_db_insert_kanban_local();

            }
            else if (rows_db.Equals(rows_local))
            {
                //update_db_insert_local();
                MessageBox.Show("Kanban Not Update");
            }
        }

        private void txtkb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    split_kanban();
                    get_t_part_tag_db();//5743A219
                    get_m_kanban_from_local();// 5743A219-> AS -... 
                    txtpi.Focus();
                    
                }catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
               
            }
        }

        private void txtpi_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)13)
                {
                    split_pi();
                    if (srctr_partpi == srct_code_local_kanban)
                    {
                        temp_2 = txtpi.Text;
                        txttag.Focus();
                        MessageBox.Show("srctr_partpi == part_number_t_tag");
                    }
                    else
                    {
                        MessageBox.Show("srctr_partpi != part_number_t_tag");
                    }
                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void txttag_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    split_tag();
                    if (srct_code_local_kanban == srctr_partpi && srctr_partpi == rs_split_tag)
                    {
                        if (!check_dupicate(temp_2))
                        {
                            al.Add(temp_2);
                            temp_2 = null;
                            // save_data_to_database();

                            MessageBox.Show("OK");
                            error_local = "Complete";
                            insert_data_hanheld();
                            txtkb.Focus();
                            txtkb.Clear();
                            txtpi.Clear();
                            txttag.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Dupicate");
                           // error_local = partnumber_kanban + "|" + partnumber_partpi + "|" + srctr_partpi;
                        }
                    }
                    else
                    {
                        //MessageBox.Show("SRCTCODE PI AND SRCTCODE KANBAN INCORRECT");
                        error_local = partnumber_kanban + "|" + partnumber_partpi + "|" + srctr_partpi;
                        insert_data_hanheld();
                      //  MessageBox.Show(error_local);

                    }
                    
                    
                     
                    
                }catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private bool check_dupicate(string text)//Check value Kanban Dupicate ?
        {
            if (al.Contains(text)) //if search al(arraylist) == Parameter(input)
            {
                return true;
            }
            else
            {
                return false;
            }
        }// end method check_dupicate(Parameter)


        // ========== Count Rows From DB ==========//
        private void count_rows_db_m_kanban()
        { 
            try
            {
                WebReference.WebService_kanban mytagdata = new WebReference.WebService_kanban();
                DataTable dt = mytagdata.get_m_kanban();
                rows_db = dt.Rows.Count;
                MessageBox.Show("rows DB :" +rows_db.ToString());
                /*
                if (dt.Rows.Count > 0)
                {

                }
                 * */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void count_rows_local_kanban()
        {
            string connection = ("Data Source=C:\\Users\\SRCT\\Desktop\\job\\smartdevice\\smart_device_winform\\smart_device_winform\\m_kanban_local.sdf;Persist Security Info=False;");
            using (SqlCeConnection conn = new SqlCeConnection(connection))
            {
                //** Data Table **//
                SqlCeDataAdapter CountAdapter;
                DataTable ds = new DataTable();
                string count_rows = "SELECT * FROM m_kanban_db";
                CountAdapter = new SqlCeDataAdapter(count_rows, conn);
                CountAdapter.Fill(ds);
                conn.Close();
                rows_local = ds.Rows.Count;
                MessageBox.Show("ROWS LOCAL: " + rows_local.ToString());
            }
        }

        /*
        // ========== Count Rows From Local ==========//
        private void count_rows_local()
        {
            string connection = ("Data Source=C:\\Users\\SRCT\\Desktop\\job\\smartdevice\\smart_device_winform\\smart_device_winform\\localdata.sdf;Persist Security Info=False;");
            using (SqlCeConnection conn = new SqlCeConnection(connection))
            {
               
                SqlCeDataAdapter CountAdapter;
                DataTable ds = new DataTable();
                string count_rows = "SELECT * FROM LogHendheld";
                CountAdapter = new SqlCeDataAdapter(count_rows, conn);
                CountAdapter.Fill(ds);
                conn.Close();
                rows_local = ds.Rows.Count;
                MessageBox.Show(rows_local.ToString());
            }
        }
         * */
        // ========================================//

        
        private void insert_data_hanheld()//insert new data
        {
            SqlCeConnection connection = new SqlCeConnection("Data Source=C:\\Users\\SRCT\\Desktop\\job\\smartdevice\\smart_device_winform\\smart_device_winform\\localdata.sdf;Persist Security Info=False;");
            connection.Open();
            SqlCeCommand sCommand = new SqlCeCommand(@"INSERT INTO LogHendheld (Part_Number,SRCT_Code,Dock_Code,Package,Error_Code,Chk_Type,IsMatch,LogUser,LogDate,Kanban_ID) VALUES ('" + partnumber_partpi + "','" + srctr_partpi + "','" + dockcode_pi + "','" + lotsize_kanban + "','" + error_local + "','','','" + username + "','" + DateTime.Now + "','" + kanbanid_partpi + "')", connection);
            sCommand.ExecuteNonQuery();
            MessageBox.Show("Row inserted !! ");
            connection.Close();
        }

        private void delete_rows_same()//Delete same rows
        {
            SqlCeConnection connection = new SqlCeConnection("Data Source=C:\\Users\\SRCT\\Desktop\\job\\smartdevice\\smart_device_winform\\smart_device_winform\\localdata.sdf;Persist Security Info=False;");
            connection.Open();
            SqlCeCommand sCommand = new SqlCeCommand(@"DELETE FROM m_kanban_db", connection);
            sCommand.ExecuteNonQuery();
            MessageBox.Show("Row Kanban Local Delete !! ");
            connection.Close();
        }

        
        private void update_data_local_to_db()
        {
            string connection = ("Data Source=C:\\Users\\SRCT\\Desktop\\job\\smartdevice\\smart_device_winform\\smart_device_winform\\localdata.sdf;Persist Security Info=False;");
            using (SqlCeConnection conn = new SqlCeConnection(connection))
            {
               
                SqlCeDataAdapter CountAdapter;
                DataTable ds = new DataTable();
                string count_rows = "SELECT * FROM LogHendheld";
                CountAdapter = new SqlCeDataAdapter(count_rows, conn);
                CountAdapter.Fill(ds);
                conn.Close();
                rows_local = ds.Rows.Count;
                if (ds.Rows.Count > 0)
                {
                   
                    
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        part_local = (string)ds.Rows[i]["Part_Number"].ToString();
                        srct_local = (string)ds.Rows[i]["SRCT_Code"];
                        dock_local = (string)ds.Rows[i]["Dock_Code"];
                        pack_local = (int)ds.Rows[i]["Package"];
                        error_local = (string)ds.Rows[i]["Error_Code"];
                        chk_local = (string)ds.Rows[i]["Chk_Type"];
                       // match_local = (Boolean)ds.Rows[i]["IsMatch"];
                        user_local = (string)ds.Rows[i]["LogUser"];
                        date_local = (DateTime)ds.Rows[i]["LogDate"];
                        //pds_local = (string)ds.Rows[i]["PDS_number"];
                        ekb_local = (string)ds.Rows[i]["ekb_order_no"];
                        kanban_local = (string)ds.Rows[i]["Kanban_ID"];
                      // update_db_from_local();
                       
                    }
                     update_db_from_local();
                   
                }
                MessageBox.Show(part_local.ToString());
            }
        }

        private void update_db_from_local()//update_data_to_db();
        {
            try
            { 
                WebReference.WebService_kanban mytagdata = new WebReference.WebService_kanban();
                DataTable dt = mytagdata.insert_data_to_db_from_local(this.part_local, this.srct_local, this.dock_local, this.pack_local, this.error_local, this.chk_local, this.user_local, this.date_local, this.ekb_local, this.kanban_local);
                //DataTable dt = mytagdata.insert_data_to_db_from_local(this.part_local, this.srct_local, this.dock_local, this.pack_local);
                rows_db = dt.Rows.Count;
                //MessageBox.Show("rows DB :" + rows_db.ToString());
                
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }
       
        // ============= KANBAN ==================//
        private void get_db_insert_kanban_local()
        {
            WebReference.WebService_kanban mytagdata = new WebReference.WebService_kanban();
            DataTable dt = mytagdata.get_m_kanban();
            rows_db = dt.Rows.Count;
            // MessageBox.Show(rows_db.ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    srct_code_kanban = (string)dt.Rows[i]["SRCT_Code"];
                    customer_Code_kanban = (string)dt.Rows[i]["Customer_Code"];
                    attension_point_kanban = (string)dt.Rows[i]["Attension_point"];
                    part_Number_kanban = (string)dt.Rows[i]["Part_Number"];
                    part_Name_kanban = (string)dt.Rows[i]["Part_Name"];
                    model_kanban = (string)dt.Rows[i]["Model"];
                    package_kanban = (int)dt.Rows[i]["Package"];
                    customer_kanban = (string)dt.Rows[i]["Customer"];
                    line_kanban = (string)dt.Rows[i]["Line"];
                    store_Address_kanban = (string)dt.Rows[i]["Store_Address"];
                    part_Ilustration_kanban = (string)dt.Rows[i]["Part_Ilustration"];
                    part_Ilustration_Path_kanban = (string)dt.Rows[i]["Part_Ilustration_Path"];
                    dock_Code_kanban = (string)dt.Rows[i]["Dock_Code"];
                    location_kanban = (string)dt.Rows[i]["Location"];
                    kb_running_kanban = (int)dt.Rows[i]["KB_running"];
                    insert_data_kanban_to_local();
                }
            }
        }

        private void insert_data_kanban_to_local()//include get_db_insert_kanban_local();
        {
            try
            {
                SqlCeConnection connection = new SqlCeConnection("Data Source=C:\\Users\\SRCT\\Desktop\\job\\smartdevice\\smart_device_winform\\smart_device_winform\\m_kanban_local.sdf");
                connection.Open(); //Error_Code LogDate
                SqlCeCommand sCommand = new SqlCeCommand(@"INSERT INTO m_kanban_db (SRCT_Code,Customer_Code,Attension_point,Part_Number,Part_Name,Model,Package,Customer,Line,Store_Address,Part_Ilustration,Part_Ilustration_Path,Dock_Code,Location,KB_running) VALUES ('" + srct_code_kanban + "','" + customer_Code_kanban + "','" + attension_point_kanban + "','" + part_Number_kanban + "','" + part_Name_kanban + "','" + model_kanban + "','" + package_kanban + "','" + customer_kanban + "','" + line_kanban + "','" + store_Address_kanban + "','" + part_Ilustration_kanban + "','" + part_Ilustration_Path_kanban + "','" + dock_Code_kanban + "','" + location_kanban + "','" + kb_running_kanban + "')", connection);
                sCommand.ExecuteNonQuery();
                //MessageBox.Show("Row from db !! ");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // ============ END ===========//

        /*
        private void get_db_insert_local()
        {
            WebReference.WebService_kanban mytagdata = new WebReference.WebService_kanban();
            DataTable dt = mytagdata.count_rows_db();
            rows_db = dt.Rows.Count;
            // MessageBox.Show(rows_db.ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    part_db = (string)dt.Rows[i]["Part_Number"];
                    srct_db = (string)dt.Rows[i]["SRCT_Code"];
                    dock_db = (string)dt.Rows[i]["Dock_Code"];
                    pack_db = (int)dt.Rows[i]["Package"];
                    error_db = (string)dt.Rows[i]["Error_Code"];
                    chk_db = (string)dt.Rows[i]["Chk_Type"];
                    match_db = (Boolean)dt.Rows[i]["IsMatch"];
                    user_db = (string)dt.Rows[i]["LogUser"];
                    date_db = (DateTime)dt.Rows[i]["LogDate"];
                    pds_db = (string)dt.Rows[i]["PDS_number"];
                    ekb_db = (string)dt.Rows[i]["ekb_order_no"];
                    kanban_db = (string)dt.Rows[i]["Kanban_ID"];
                    insert_data_to_local();
                }
            }

        }


        private void insert_data_to_local()//include get_db_insert_local();
        {
            try
            {
                SqlCeConnection connection = new SqlCeConnection("Data Source=C:\\Users\\SRCT\\Desktop\\job\\smartdevice\\smart_device_winform\\smart_device_winform\\localdata.sdf;Persist Security Info=False;");
                connection.Open(); //Error_Code LogDate
                SqlCeCommand sCommand = new SqlCeCommand(@"INSERT INTO LogHendheld (Part_Number,SRCT_Code,Dock_Code,Package,Error_Code,Chk_Type,IsMatch,LogUser,LogDate,PDS_number,ekb_order_no,Kanban_ID) VALUES ('" + part_db + "','" + srct_db + "','" + dock_db + "','" + pack_db + "','" + error_db + "','" + chk_db + "','" + match_db + "','" + user_db + "','" + date_db + "','" + pds_db + "','" + ekb_db + "','" + kanban_db + "')", connection);
                sCommand.ExecuteNonQuery();
                //MessageBox.Show("Row from db !! ");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */

        // ============ Service t_part_tag =============//
        private void get_t_part_tag_db()
        {
            try
            {
                WebReference.WebService_kanban mytagdata = new WebReference.WebService_kanban();
                DataTable dt = mytagdata.get_part_tag(this.partnumber_kanban);
                if (dt.Rows.Count > 0)
                {

                    part_number_t_tag = (string)dt.Rows[0]["PartNumber"];

                    MessageBox.Show(part_number_t_tag);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void get_m_kanban_from_local()
        {
            try
            {
                string connection = ("Data Source=C:\\Users\\SRCT\\Desktop\\job\\smartdevice\\smart_device_winform\\smart_device_winform\\m_kanban_local.sdf;Persist Security Info=False;");
                using (SqlCeConnection conn = new SqlCeConnection(connection))
                {
                    //** Data Table **//
                    SqlCeDataAdapter CountAdapter;
                    DataTable ds = new DataTable();
                    string count_rows = "SELECT * FROM m_kanban_db WHERE Part_Number='" + part_number_t_tag + "'";
                    CountAdapter = new SqlCeDataAdapter(count_rows, conn);
                    CountAdapter.Fill(ds);
                    conn.Close();
                    if (ds.Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Rows.Count; i++)
                        {
                            srct_code_local_kanban = (string)ds.Rows[i]["SRCT_Code"];
                        }
                        MessageBox.Show(srct_code_local_kanban);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ============= END =========//

        private void clear_Click(object sender, EventArgs e)
        {
            txtkb.Clear();
            txtpi.Clear();
            txttag.Clear();
            txtkb.Focus();
            MessageBox.Show("Reset Data Sucessfuly");
        }

        private void exit_Click(object sender, EventArgs e)
        {
           // update_data_local_to_db();
            //update_db_from_local();
            update_data_local_to_db();
           // update_db_from_local();
            this.Close();
           
        }

      

    }
}
