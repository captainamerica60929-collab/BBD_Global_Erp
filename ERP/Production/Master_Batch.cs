using Maintanence_Printing_Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM_App.Production
{
    public partial class Master_Batch : Form
    {
        public Master_Batch()
        {
            InitializeComponent();
        }

        private void Master_Batch_Load(object sender, EventArgs e)
        {
           
            LoadPendingProdRQ();

        }
        string Part_ID = "";

        public void Edit()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataTable dt = dbFunctions.getTable("pr_get_Production_Request_Master_Batch  '" + dataGridView2.SelectedRows[0].Cells["ID"].Value.ToString() + "'");
                //ID = dt.Rows[0]["Pq_iid"].ToString();
                //Route_Card_ID = dataGridView2.SelectedRows[0].Cells["ID"].Value.ToString();
                txtRCNo.Text = dt.Rows[0]["Pq_Route_Card_No"].ToString();
                txtPartNo.Text = dt.Rows[0]["Pq_vPart_No"].ToString();
                txtPartName.Text = dt.Rows[0]["Pq_vPart_Name"].ToString();
                txtModel.Text = dt.Rows[0]["Pq_vModel"].ToString();
                txtxplanQty.Text = dt.Rows[0]["Pq_RM_Plan_Qty"].ToString();
                cmbRMSpec.Text = dt.Rows[0]["Pq_RM_Spec"].ToString();
                txtRMGrade.Text = dt.Rows[0]["Pq_RM_Grade"].ToString();
                txtReqQty.Text = dt.Rows[0]["pq_RM_Req_Qty"].ToString();
                Machine_No.Text = dt.Rows[0]["Pq_Machine_Name"].ToString();
                txtUOM.Text = "KG";
                // Part_ID = dt.Rows[0]["Pq_iPart_ID"].ToString();
                //txtStockQty.Text = dt.Rows[0]["Stock"].ToString();
                // display_Scanned_Details();
                 Part_ID = dt.Rows[0]["Pq_iPart_ID"].ToString();

                try
                {
                    DataTable dtx = dbFunctions.getTable("pr_getBOMDetailsAll '" + dt.Rows[0]["Pq_iPart_ID"].ToString() + "'");
                    cmbRMSpec.DataSource = dtx;
                    cmbRMSpec.DisplayMember = "IM_PartNo";
                    cmbRMSpec.ValueMember = "IM_ID";
                    cmbRMSpec.SelectedIndex = 0;
                    //isRMSpec_Load = true;
                   
                }
                catch
                {
                }
               // get_all_ScanQty();

            }
            else
            {
                MessageBox.Show("Please Select Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      

        public void LoadPendingProdRQ()
        {
            DataTable dt = dbFunctions.getTable("pr_Display_Production_Request_Details");
            dataGridView2.DataSource = dt;
            dbFunctions.DGVStyle(dataGridView2);
           
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Edit();
        }

        private void txt_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txt_Barcode.Text.Trim();
                string machineNo = Machine_No.Text.Trim();

                if (string.IsNullOrEmpty(barcode) || string.IsNullOrEmpty(machineNo))
                {
                    btnSubmitt.Enabled = false;
                    return;
                }

                if (barcode == machineNo)
                {
                    btnSubmitt.Enabled = true;
                    lblResult.Text = "Machine No Verified";
                    lblResult.ForeColor = Color.Green;
                }
                else
                {
                    btnSubmitt.Enabled = false;
                    lblResult.Text = "Machine No Not Matched, check Machine No";
                    lblResult.ForeColor = Color.Red;
                    //MessageBox.Show("Master Batch Not Maching Pls Try New Machine ",
                    //                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSubmitt_Click(object sender, EventArgs e)
        {
            string Route_Card_ID = dataGridView2.CurrentRow.Cells["Route CardNo"].Value?.ToString();
            DataTable dt = dbFunctions.getTable("pr_update_Material_Issued_Details_Batch  " + Route_Card_ID);
            MessageBox.Show("Material Issued Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadPendingProdRQ();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
