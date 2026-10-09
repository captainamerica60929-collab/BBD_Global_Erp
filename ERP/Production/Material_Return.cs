using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maintanence_Printing_Tool;
using Shasun_Printing_Toll.Masters;

namespace CRM_App.Production
{
    public partial class Material_Return : Form
    {
        public Material_Return()
        {
            InitializeComponent();
        }

        private void Material_Return_Load(object sender, EventArgs e)
        {
            display();
        }
        public string IID = "";
        public string GRN_ID = "";
        private void txt_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DataTable dt = dbFunctions.getTable("pr_get_Barcode_Data1  '" + txt_Barcode.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    GRN_ID = dt.Rows[0]["ID"].ToString();
                    IID = dt.Rows[0]["IDS"].ToString();
                    textBox2.Text = dt.Rows[0]["GRN_vGRN_No"].ToString();
                    textBox3.Text = dt.Rows[0]["GRND_vLot_No"].ToString();
                    textBox6.Text = dt.Rows[0]["Mfg Date"].ToString();
                    textBox5.Text = dt.Rows[0]["Part_No"].ToString();
                    textBox4.Text = dt.Rows[0]["Grade"].ToString();
                    textBox7.Text = dt.Rows[0]["Qty"].ToString();
                    button1.Enabled = true;

                }
                else
                {
                    txt_Barcode.Text = "";
                    txt_Barcode.Focus();
                    MessageBox.Show("Invalid Barcode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1.Enabled = false;
                }

            }
 
        }
        public void print_QC_Lable()
        {

            DialogResult result = MessageBox.Show("Do You Want to Lable Print, Press YES", "Alcove", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        string PrinterName = dbFunctions.Printer_Name;
                        string text = System.IO.File.ReadAllText(@"D:\Lable.prn");

                        string ReplaceText1 = text.Replace("@Format@", dataGridView1.SelectedRows[0].Cells["CS_Lable_Format"].Value.ToString());
                        string ReplaceText2 = ReplaceText1.Replace("@PartNo@", dataGridView1.SelectedRows[0].Cells["CS_Part_No"].Value.ToString());
                        string ReplaceText3 = ReplaceText2.Replace("@PartName@", dataGridView1.SelectedRows[0].Cells["CS_Part_Name"].Value.ToString());
                        string ReplaceText4 = ReplaceText3.Replace("@PartGrade@", dataGridView1.SelectedRows[0].Cells["CS_Part_No"].Value.ToString());
                        string ReplaceText5 = ReplaceText4.Replace("@GRNNo@", dataGridView1.SelectedRows[0].Cells["CS_Lable_Format"].Value.ToString());
                        string ReplaceText6 = ReplaceText5.Replace("@GRNDate@", dataGridView1.SelectedRows[0].Cells["CS_Lot_Date"].Value.ToString());
                        string ReplaceText7 = ReplaceText6.Replace("@Lot@", dataGridView1.SelectedRows[0].Cells["CS_Lot_No"].Value.ToString());
                        string ReplaceText8 = ReplaceText7.Replace("@PackQty@", dataGridView1.SelectedRows[0].Cells["Qty"].Value.ToString());
                        string ReplaceText9 = ReplaceText8.Replace("@Rec_Date@", dataGridView1.SelectedRows[0].Cells["CS_Lot_Date"].Value.ToString());
                        string ReplaceText10 = ReplaceText9.Replace("@Mfg_Date@", dataGridView1.SelectedRows[0].Cells["CS_Lot_Date"].Value.ToString());
                        string ReplaceText11 = ReplaceText10.Replace("@Exp_Date@", dataGridView1.SelectedRows[0].Cells["CS_Lot_Date"].Value.ToString());
                        string ReplaceText12 = ReplaceText11.Replace("@Approve_By@", dataGridView1.SelectedRows[0].Cells["CS_Part_Name"].Value.ToString());
                        string ReplaceText13 = ReplaceText12.Replace("@Approve_Date@", dataGridView1.SelectedRows[0].Cells["CS_Lot_Date"].Value.ToString());
                        string ReplaceText14 = ReplaceText13.Replace("@Year@", System.DateTime.Now.ToString("MMM yyyy"));
                        string ReplaceText15 = ReplaceText14.Replace("@Barcode@", dataGridView1.SelectedRows[0].Cells["CS_Barcode"].Value.ToString());
                        RawPrinterHelper.SendStringToPrinter(PrinterName, ReplaceText15);


                    }
                    else
                    {
                        MessageBox.Show("Select atleast 1 row for Re-Print", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }



        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //DataTable dt = dbFunctions.getTable("pr_Generate_Label_Return " + GRN_ID + "," + textBox8.Text + ",'" + txt_Barcode.Text + "'");
                DataTable dt = dbFunctions.getTable("pr_Update_Stock " + IID + "," + textBox8.Text +",'"+dbFunctions.username+"'");

                MessageBox.Show("Material Retuned Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();
                print_QC_Lable();
                clear();

            }
            catch { }
        }

        public void display()
        {
            DataTable dd = dbFunctions.getTable("pr_get_Barcode_Detail");
            dataGridView1.DataSource = dd;
            dbFunctions.DGVStyle(dataGridView1);
        }

        void clear()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            txt_Barcode.Text = "";
            textBox8.Text = "";
            Su_Name.Text = "";


        }

        private void Txt_Barcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do You Want to Lable Print, Press YES", "Alcove", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        string PrinterName = dbFunctions.Printer_Name;
                        string text = System.IO.File.ReadAllText(@"D:\Mreturn.prn");

                        string ReplaceText1 = text.Replace("@Format@", dataGridView1.SelectedRows[0].Cells["CS_Lable_Format"].Value.ToString());
                        string ReplaceText2 = ReplaceText1.Replace("@PartNo@", dataGridView1.SelectedRows[0].Cells["CS_Part_No"].Value.ToString());
                        string ReplaceText3 = ReplaceText2.Replace("@PartName@", dataGridView1.SelectedRows[0].Cells["CS_Part_Name"].Value.ToString());
                        string ReplaceText4 = ReplaceText3.Replace("@PartGrade@", dataGridView1.SelectedRows[0].Cells["CS_Part_No"].Value.ToString());
                        string ReplaceText5 = ReplaceText4.Replace("@GRNNo@", dataGridView1.SelectedRows[0].Cells["CS_Lable_Format"].Value.ToString());
                        string ReplaceText6 = ReplaceText5.Replace("@GRNDate@", dataGridView1.SelectedRows[0].Cells["CS_Lot_Date"].Value.ToString());
                        string ReplaceText7 = ReplaceText6.Replace("@Lot@", dataGridView1.SelectedRows[0].Cells["CS_Lot_No"].Value.ToString());
                        string ReplaceText8 = ReplaceText7.Replace("@PackQty@", dataGridView1.SelectedRows[0].Cells["Qty"].Value.ToString());
                        string ReplaceText9 = ReplaceText8.Replace("@Rec_Date@", dataGridView1.SelectedRows[0].Cells["CS_Lot_Date"].Value.ToString());
                        string ReplaceText10 = ReplaceText9.Replace("@Mfg_Date@", dataGridView1.SelectedRows[0].Cells["CS_Lot_Date"].Value.ToString());
                        string ReplaceText11 = ReplaceText10.Replace("@Exp_Date@", dataGridView1.SelectedRows[0].Cells["CS_Lot_Date"].Value.ToString());
                        string ReplaceText12 = ReplaceText11.Replace("@Approve_By@", dataGridView1.SelectedRows[0].Cells["CS_Part_Name"].Value.ToString());
                        string ReplaceText13 = ReplaceText12.Replace("@Approve_Date@", dataGridView1.SelectedRows[0].Cells["CS_Lot_Date"].Value.ToString());
                        string ReplaceText14 = ReplaceText13.Replace("@Year@", System.DateTime.Now.ToString("MMM yyyy"));
                        string ReplaceText15 = ReplaceText14.Replace("@barcode@", dataGridView1.SelectedRows[0].Cells["Barcode"].Value.ToString());
                        string ReplaceText16 = ReplaceText15.Replace("@RetDate@", dataGridView1.SelectedRows[0].Cells["CS_Return_Date"].Value.ToString());
                        string ReplaceText17 = ReplaceText16.Replace("@User1@", Su_Name.Text);
                        RawPrinterHelper.SendStringToPrinter(PrinterName, ReplaceText17);

                    }
                    else
                    {
                        MessageBox.Show("Select atleast 1 row for Re-Print", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    clear();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are You Sure Want to Delete Press YES", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    DataTable dt = dbFunctions.getTable("pr_Delete_Stock_Return " + IID + "," + textBox8.Text + ",'" + dbFunctions.username + "'");
                    MessageBox.Show("Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    display();
                }
            }
            else
            {
                MessageBox.Show("Please Select Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
