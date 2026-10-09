using Maintanence_Printing_Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_App.Production
{
    public partial class Trail_Entry : Form
    {
        public Trail_Entry()
        {
            InitializeComponent();
        }
        public string IID = "";
        public string GRN_ID = "";
        private void txt_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DataTable dt = dbFunctions.getTable("pr_get_Barcode_Data11  '" + txt_Barcode.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    GRN_ID = dt.Rows[0]["ID"].ToString();
                    IID = dt.Rows[0]["IDS"].ToString();
                    textBox9.Text = dt.Rows[0]["GRN_vGRN_No"].ToString();
                    textBox3.Text = dt.Rows[0]["GRND_vLot_No"].ToString();
                    textBox6.Text = dt.Rows[0]["Mfg Date"].ToString();
                    textBox5.Text = dt.Rows[0]["Part_No"].ToString();
                    textBox4.Text = dt.Rows[0]["Grade"].ToString();
                    Scan_qty.Text = dt.Rows[0]["Qty"].ToString();
                    btnSubmitt.Enabled = true;

                }
                else
                {
                    txt_Barcode.Text = "";
                    txt_Barcode.Focus();
                    MessageBox.Show("Invalid Barcode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSubmitt.Enabled = false;
                }

            }
        }
        public void LoadMachineNo()
        {
            try
            {
                DataTable dt = dbFunctions.getTable("pr_LoadMachinex");
                IM_MachineNo.DataSource = dt;
                IM_MachineNo.DisplayMember = "MM_MachineName";
                IM_MachineNo.ValueMember = "MM_ID";
                IM_MachineNo.SelectedIndex = -1;
                //isMoldLoadAssy = true;
            }
            catch
            {
            }
        }
        private void Trail_Entry_Load(object sender, EventArgs e)
        {
            LoadMachineNo();
            Display();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmitt_Click(object sender, EventArgs e)
        {


            DataTable dt = dbFunctions.getTable("pr_get_Barcode_details_By_ID  '" + txt_Barcode.Text + "' ");
            SqlConnection con = new SqlConnection(dbFunctions.connectionstring);
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "Pr_Insert_Current_Stock_Trail";
                com.Parameters.Add("@CS_Barcode", SqlDbType.VarChar).Value = txt_Barcode.Text.ToString();
                com.Parameters.Add("@CS_Type", SqlDbType.VarChar).Value = dt.Rows[0]["CS_Type"].ToString();
                com.Parameters.Add("@CS_Item_ID", SqlDbType.VarChar).Value = dt.Rows[0]["CS_Item_ID"].ToString();
                com.Parameters.Add("@CS_Part_No", SqlDbType.VarChar).Value = dt.Rows[0]["CS_Part_No"].ToString();
                com.Parameters.Add("@CS_Part_Name", SqlDbType.VarChar).Value = dt.Rows[0]["CS_Part_Name"].ToString();
                com.Parameters.Add("@CS_Lot_No", SqlDbType.VarChar).Value = dt.Rows[0]["CS_Lot_No"].ToString();
                com.Parameters.Add("@CS_Lot_Date", SqlDbType.VarChar).Value = dt.Rows[0]["CS_Lot_Date"].ToString();
                com.Parameters.Add("@CS_Qty", SqlDbType.VarChar).Value = "-" + Scan_qty.Text.ToString();
                com.Parameters.Add("@CS_UOM", SqlDbType.VarChar).Value = dt.Rows[0]["CS_UOM"].ToString();
                com.Parameters.Add("@CS_Issued_By", SqlDbType.VarChar).Value = dbFunctions.username;
                com.ExecuteNonQuery();
                com.Connection.Close();
                Scan_qty.Text = "";
                Clear();
                Display();
            }
            catch (Exception Ex)
            {
                dbFunctions.Logs(Ex.Message, dbFunctions.username);
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Display()
        {
            DataTable dt = dbFunctions.getTable("pr_getCurrent_Stock_table_Trial");
            dataGridView1.DataSource = dt;
            dbFunctions.DGVStyle(dataGridView1);


        }
        private void Clear()
        {

            textBox9.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            Scan_qty.Text = "";



        }
    }
}
