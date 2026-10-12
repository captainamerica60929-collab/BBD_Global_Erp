using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maintanence_Printing_Tool;

namespace CRM_App.Reports
{
    public partial class Part_Traceability : Form
    {
        public Part_Traceability()
        {
            InitializeComponent();
        }

        private void aci_vCardNo1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt1 = dbFunctions.getTable("select * from fg_barcode_details where fg_bar_Barcode = '" + aci_vCardNo1.Text + "' ");
                if (dt1.Rows.Count > 0)
                {

                    DataTable db = dbFunctions.getTable("select * from PROD_Barcode_Details PBD Left join Production_Request PR on PBD.PROD_Routecardid=PR.Pq_iid left join Current_Stock CS on CS.CS_RouteCardNo=PR.Pq_iid where PBD.PROD_Routecardid='" + dt1.Rows[0]["fg_Routecardid"].ToString() + "'");
                    if (db.Rows.Count > 0)
                    {
                        Routecardno.Text = db.Rows[0]["Pq_Route_Card_No"].ToString();
                        lotno.Text = db.Rows[0]["CS_Lot_No"].ToString();
                        Location.Text = db.Rows[0]["CS_Location"].ToString();
                        issuedate.Text = db.Rows[0]["CS_CreatedDate"].ToString();
                        rmpartname.Text = db.Rows[0]["CS_Part_No"].ToString();
                        rmpartno.Text = db.Rows[0]["CS_Part_Name"].ToString();
                        WIPQTY.Text = dt1.Rows[0]["PROD_nQty"].ToString();
                        fgprtno.Text = dt1.Rows[0]["PROD_iItemId"].ToString();
                        fgpartname.Text = dt1.Rows[0]["PROD_vLotNo"].ToString();
                        DataTable machine = dbFunctions.getTable("select MM_Machine_tons from machine_master where MM_MachineCode='" + db.Rows[0]["Pq_Machine_Name"].ToString() + "'");
                        if (machine.Rows.Count > 0)
                        {
                            Tons.Text = machine.Rows[0]["MM_Machine_tons"].ToString();
                        }
                        Machineno.Text = db.Rows[0]["Pq_Machine_Name"].ToString();
                        //Location.Text = db.Rows[0][""]
                        object result = db.Compute("SUM(CS_Qty)", string.Empty);
                        decimal total = (result == DBNull.Value) ? 0 : Math.Abs(Convert.ToDecimal(result));

                        Scan_qty.Text = total.ToString();

                        Scan_qty.Text = total.ToString();
                        Issuedbrcd.Text = string.Join(Environment.NewLine,
db.AsEnumerable()
.Select(r => r["CS_Barcode"].ToString())
.Where(s => !string.IsNullOrWhiteSpace(s)));

                    }

                }
                else
                {
                    MessageBox.Show("Invalid Barcode", "warning");
                }
            }
        }

        private void aci_vCardNo1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt1 = dbFunctions.getTable("select * from fg_barcode_details where fg_bar_Barcode = '" + aci_vCardNo1.Text + "' ");
                if (dt1.Rows.Count > 0)
                {
                    
                    DataTable db = dbFunctions.getTable("select * from PROD_Barcode_Details PBD Left join Production_Request PR on PBD.PROD_Routecardid=PR.Pq_iid left join Current_Stock CS on CS.CS_RouteCardNo=PR.Pq_iid where PBD.PROD_Routecardid='" + dt1.Rows[0]["fg_Routecardid"].ToString() + "'");
                    if (db.Rows.Count > 0)
                    {
                        Routecardno.Text = db.Rows[0]["Pq_Route_Card_No"].ToString();
                        lotno.Text = db.Rows[0]["CS_Lot_No"].ToString();
                        Location.Text = db.Rows[0]["CS_Location"].ToString();
                        issuedate.Text = db.Rows[0]["CS_CreatedDate"].ToString();
                        rmpartname.Text = db.Rows[0]["CS_Part_No"].ToString();
                        rmpartno.Text = db.Rows[0]["CS_Part_Name"].ToString();
                        WIPQTY.Text = dt1.Rows[0]["PROD_nQty"].ToString();
                        fgprtno.Text = dt1.Rows[0]["PROD_iItemId"].ToString();
                        fgpartname.Text = dt1.Rows[0]["PROD_vLotNo"].ToString();
                        DataTable machine = dbFunctions.getTable("select MM_Machine_tons from machine_master where MM_MachineCode='" + db.Rows[0]["Pq_Machine_Name"].ToString() + "'");
                        if (machine.Rows.Count > 0)
                        {
                            Tons.Text = machine.Rows[0]["MM_Machine_tons"].ToString();
                        }
                        Machineno.Text = db.Rows[0]["Pq_Machine_Name"].ToString();
                        //Location.Text = db.Rows[0][""]
                        object result = db.Compute("SUM(CS_Qty)", string.Empty);
                        decimal total = (result == DBNull.Value) ? 0 : Math.Abs(Convert.ToDecimal(result));

                        Scan_qty.Text = total.ToString();

                        Scan_qty.Text = total.ToString();
                        Issuedbrcd.Text = string.Join(Environment.NewLine,
db.AsEnumerable()
.Select(r => r["CS_Barcode"].ToString())
.Where(s => !string.IsNullOrWhiteSpace(s)));

                    }

                }
                else
                {
                    MessageBox.Show("Invalid Barcode", "warning");
                }
            }
        }

        private void aci_vCardNo1_KeyUp_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt1 = dbFunctions.getTable("select * from fg_barcode_details where fg_bar_Barcode = '" + aci_vCardNo1.Text + "' ");
                if (dt1.Rows.Count > 0)
                {

                    DataTable db = dbFunctions.getTable("select * from PROD_Barcode_Details PBD Left join Production_Request PR on PBD.PROD_Routecardid=PR.Pq_iid left join Current_Stock CS on CS.CS_RouteCardNo=PR.Pq_iid where PBD.PROD_Routecardid='" + dt1.Rows[0]["fg_Routecardid"].ToString() + "'");
                    if (db.Rows.Count > 0)
                    {
                        Routecardno.Text = db.Rows[0]["Pq_Route_Card_No"].ToString();
                        lotno.Text = db.Rows[0]["CS_Lot_No"].ToString();
                        Location.Text = db.Rows[0]["CS_Location"].ToString();
                        issuedate.Text = db.Rows[0]["CS_CreatedDate"].ToString();
                        rmpartname.Text = db.Rows[0]["CS_Part_No"].ToString();
                        rmpartno.Text = db.Rows[0]["CS_Part_Name"].ToString();
                        WIPQTY.Text = db.Rows[0]["PROD_nQty"].ToString();
                        fgprtno.Text = db.Rows[0]["PROD_iItemId"].ToString();
                        fgpartname.Text = db.Rows[0]["PROD_vLotNo"].ToString();
                        DataTable machine = dbFunctions.getTable("select MM_Machine_tons from machine_master where MM_MachineCode='" + db.Rows[0]["Pq_Machine_Name"].ToString() + "'");
                        if (machine.Rows.Count > 0)
                        {
                            Tons.Text = machine.Rows[0]["MM_Machine_tons"].ToString();
                        }
                        Machineno.Text = db.Rows[0]["Pq_Machine_Name"].ToString();
                        //Location.Text = db.Rows[0][""]
                        object result = db.Compute("SUM(CS_Qty)", string.Empty);
                        decimal total = (result == DBNull.Value) ? 0 : Math.Abs(Convert.ToDecimal(result));

                        Scan_qty.Text = total.ToString();

                        Scan_qty.Text = total.ToString();
                        Issuedbrcd.Text = string.Join(Environment.NewLine,
db.AsEnumerable()
.Select(r => r["CS_Barcode"].ToString())
.Where(s => !string.IsNullOrWhiteSpace(s)));

                    }

                }
                else
                {
                    MessageBox.Show("Invalid Barcode", "warning");
                }
            }
        }
    }
}
