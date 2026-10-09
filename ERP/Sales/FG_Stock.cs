using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;
using Maintanence_Printing_Tool;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace GenuineHR.Reports
{
    public partial class FG_Stock : Form
    {
        public FG_Stock()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = dbFunctions.getTable("pr_gettodayStatus_all '" + dtpFrom.Value.ToString("yyyyMMdd") + "',1");//+ shift.SelectedValue);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["Code"].Width = 800;
            dataGridView1.Columns["Name"].Width = 180;
            dataGridView1.Columns["Designation"].Width = 180;
            dataGridView1.Columns["Category"].Width = 120;

            int ab = 0, late = 0, present = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Status"].Equals("Absent"))
                {
                    ab++;
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }

                if (dt.Rows[i]["Status"].Equals("Late"))
                {
                    late++;
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                }

                if (dt.Rows[i]["Status"].Equals("Present"))
                {
                    present++;
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                }

            }
            //txt_Absent.Text = ab.ToString();
            //txtPresent.Text = (present + late).ToString();
            //txtLate.Text = late.ToString();
            //txtTotal.Text = dt.Rows.Count.ToString();
            //txt_early.Text = present.ToString();

                 }

        void getdata()
        {
            DataTable dt = dbFunctions.getTable("pr_get_FG_Stock  '" + dtpFrom.Value.ToString("yyyyMMdd") + "','" + todate.Value.ToString("yyyyMMdd") + "'");
            dataGridView1.DataSource = dt;
            dbFunctions.DGVStyle(dataGridView1);
            //dataGridView1.Columns[0].Visible = true;
            //dataGridView1.Columns[0].Width = 150;
            //txt_Rows.Text = dbFunctions.getRows(dataGridView1);
            txt_Rows.Text = "Total Rows Count :" + (dataGridView1.Rows.Count).ToString();
            // dataGridView1.Columns["FG QTY"].DefaultCellStyle.ForeColor = Color.Green;

          //  DATAVALUE();
            //calc();
        }

        private void DATAVALUE()
        {
            string fromDate = dtpFrom.Value.ToString("yyyyMMdd");
            string toDate = todate.Value.ToString("yyyyMMdd");
            string previousDate = dtpFrom.Value.AddDays(-1).ToString("yyyyMMdd");

            DataTable dt1 = dbFunctions.getTable1(@"select '' as ok,SD_Part_No as [Part No],	SD_Part_Name as [Part Name],sum(SD_Qty) as [Qty] from Sales_Invoice_Details
where  SD_Status = 'A' and Convert(date, SD_Created_Date, 112) Between  '" + fromDate + "' and '" + toDate + "'  group by SD_Part_No, SD_Part_Name");

            DataTable dt = dbFunctions.getTable(@"
    SELECT                               
        IM_ID AS ID,                              
        ROW_NUMBER() OVER (ORDER BY IM_ID) AS [S.No],                        
        IM_PartNo AS [Part No],                              
        IM_PartName AS [Part Name],                              
        IM_Sales_Price AS [Sales Price],            

        CAST(ISNULL((
            SELECT SUM(wor_Qty)  
            FROM Work_Order_Receive_Details  
            WHERE wor_status = 'A' AND wor_MaterialType = 'FG' 
                AND WOR_PID = IM_ID  
                AND CONVERT(DATE, wor_Date, 113) BETWEEN '" + fromDate + @"' AND '" + toDate + @"'
        ), 0) AS INT) AS [DC QTY],      

        dbo.fget_Production_Qty('20140801', '" + previousDate + @"', IM_ID) 
        + CAST(ISNULL((
            SELECT SUM(fe_ok) 
            FROM [CHE_SRUTHY_PLASTIC].[final_entry]  
            WHERE fe_partid = IM_ID 
                AND CONVERT(DATE, fe_Date, 113) < '" + fromDate + @"'
        ), 0) AS INT)   
        + CAST(ISNULL((
            SELECT SUM(wor_Qty)  
            FROM Work_Order_Receive_Details  
            WHERE wor_status = 'A' AND wor_MaterialType = 'FG' 
                AND WOR_PID = IM_ID  
                AND CONVERT(DATE, wor_Date, 113) < '" + fromDate + @"'
        ), 0) AS INT)  
        - dbo.fget_Invoice_Qty('20140801', '" + previousDate + @"', IM_ID) AS [Openning Qty],     

        CAST(ISNULL((
            SELECT SUM(fe_ok) 
            FROM [CHE_SRUTHY_PLASTIC].[final_entry]  
            WHERE fe_partid = IM_ID   
                AND CONVERT(DATE, fe_Date, 113) BETWEEN '" + fromDate + @"' AND '" + toDate + @"'
        ), 0) AS DECIMAL(18,2)) AS [FG QTY],     

        dbo.fget_Invoice_Qty('" + fromDate + @"', '" + toDate + @"', IM_ID) AS [Invoice Qty],                

        IM_MinStock AS [Min],                                  
        IM_MaxStock AS [Max],      

        (
            CAST(ISNULL((
                SELECT SUM(wor_Qty)  
                FROM Work_Order_Receive_Details  
                WHERE wor_status = 'A' AND wor_MaterialType = 'FG' 
                    AND WOR_PID = IM_ID  
                    AND CONVERT(DATE, wor_Date, 113) BETWEEN '" + fromDate + @"' AND '" + toDate + @"'
            ), 0) AS INT)    
            + dbo.fget_Production_Qty('20140801', '" + previousDate + @"', IM_ID) 
            + CAST(ISNULL((
                SELECT SUM(fe_ok) 
                FROM [CHE_SRUTHY_PLASTIC].[final_entry]  
                WHERE fe_partid = IM_ID 
                    AND CONVERT(DATE, fe_Date, 113) < '" + fromDate + @"'
            ), 0) AS INT)   
            + CAST(ISNULL((
                SELECT SUM(wor_Qty)  
                FROM Work_Order_Receive_Details  
                WHERE wor_status = 'A' AND wor_MaterialType = 'FG' 
                    AND WOR_PID = IM_ID  
                    AND CONVERT(DATE, wor_Date, 113) < '" + fromDate + @"'
            ), 0) AS INT)  
            - dbo.fget_Invoice_Qty('20140801', '" + previousDate + @"', IM_ID)    
            + CAST(ISNULL((
                SELECT SUM(fe_ok) 
                FROM [CHE_SRUTHY_PLASTIC].[final_entry]  
                WHERE fe_partid = IM_ID   
                    AND CONVERT(DATE, fe_Date, 113) BETWEEN '" + fromDate + @"' AND '" + toDate + @"'
            ), 0) AS DECIMAL(18,2))
        ) AS [Closing Qty],      

        '' AS [Remarks]      
    FROM Item_Master                               
    WHERE IM_Status = 'A'                           
      AND IM_Type = 1                            
    ORDER BY IM_ID
");


            dataGridView1.DataSource = dt;
            dbFunctions.DGVStyle(dataGridView1);
        }

        void calc()
        {
            int total = 0;
            int present = 0;
            int absent = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                total += int.Parse(dataGridView1.Rows[i].Cells["Total Employee"].Value.ToString());
                present += int.Parse(dataGridView1.Rows[i].Cells["Present"].Value.ToString());
                absent += int.Parse(dataGridView1.Rows[i].Cells["Absent"].Value.ToString());

            }
            label5.Text = total.ToString();
            label7.Text = present.ToString();
            label9.Text = absent.ToString();
        }

        private void shift_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdata();
        }

        private void ToadayStatus_Load(object sender, EventArgs e)
        {
            getdata();
          //  DATAVALUE2();



        }

        private void ToadayStatus_Activated(object sender, EventArgs e)
        {
            getdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getdata();
           

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dbFunctions.ExportExcel(dataGridView1);
            Cursor.Current = Cursors.Default;

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(textBoxX1.Text))
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Part No] like '%{0}%' or [Part Name] like '%{0}%'", textBoxX1.Text);
                }

               
            }
            catch (Exception ex)
            {
               
            }
            //calc();
            txt_Rows.Text = dbFunctions.getRows(dataGridView1);
        }

        private void textBoxX1_Enter(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
             //dbFunctions.isclose = true; this.Close(); 
            DialogResult result = MessageBox.Show("Are You Sure Want to Exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {

                this.Close();

            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            getdata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            getdata();
            //DATAVALUE();
            //DATAVALUE1();
            // DATAVALUE2();

        }

        private void DATAVALUE2()
        {
            string fromDate = dtpFrom.Value.ToString("yyyyMMdd");
            string toDate = todate.Value.ToString("yyyyMMdd");
            string previousDate = dtpFrom.Value.AddDays(-1).ToString("yyyyMMdd");

            // Load DT1: Sales Invoice Details
            DataTable dt1 = dbFunctions.getTable1(@"
                    SELECT 
                        SD_Part_No, 
                        SUM(SD_Qty) AS Qty 
                    FROM dbo.Sales_Invoice_Details
                    WHERE SD_Status = 'A' 
                      AND CONVERT(DATE, SD_Created_Date, 112) 
                          BETWEEN '" + fromDate + @"' AND '" + toDate + @"' 
                    GROUP BY SD_Part_No");

                            // Load DT: Item Master Data
                            DataTable dt = dbFunctions.getTable(@"
                SELECT                               
                    IM_ID AS ID,                              
                    ROW_NUMBER() OVER(ORDER BY IM_ID) AS [S.No],                        
                    IM_PartNo AS [Part No],                              
                    IM_PartName AS [Part Name],                              
                    IM_Sales_Price AS [Sales Price],            

                    CAST(ISNULL((SELECT SUM(wor_Qty)  
                        FROM Work_Order_Receive_Details  
                        WHERE wor_status = 'A' 
                          AND wor_MaterialType = 'FG' 
                          AND WOR_PID = IM_ID  
                          AND CONVERT(DATE, wor_Date, 112) 
                              BETWEEN '" + fromDate + @"' AND '" + toDate + @"'), 0) AS INT) AS [DC QTY],

                    CAST(ISNULL((SELECT SUM(AS_Qty)  
                        FROM Assembly_Details  
                        WHERE AS_Status = 'A' 
                          AND AS_Part_ID = IM_ID  
                          AND CONVERT(DATE, AS_Date, 112) 
                              BETWEEN '" + fromDate + @"' AND '" + toDate + @"'), 0) AS INT) AS [AS QTY],

                    CAST(
                        ISNULL(dbo.fget_Production_Qty('" + fromDate + @"', '" + previousDate + @"', IM_ID), 0)
                        + CAST(ISNULL((
                            SELECT SUM(fe_ok) 
                            FROM [CHE_SRUTHY_PLASTIC].[final_entry]  
                            WHERE fe_partid = IM_ID AND CONVERT(Date, fe_Date, 113) < '" + fromDate + @"'
                        ), 0) AS INT)
                        +
                CAST(ISNULL((SELECT SUM(AS_Qty)  
                                        FROM Assembly_Details  
                                        WHERE AS_Status = 'A' 
                                          AND AS_Part_ID = IM_ID  
                                          AND CONVERT(DATE, AS_Date, 112) 
                                              < '" + fromDate + @"'), 0) AS INT)
                        
                        + CAST(ISNULL((
                            SELECT SUM(wor_Qty)  
                            FROM Work_Order_Receive_Details  
                            WHERE wor_status = 'A' 
                              AND wor_MaterialType = 'FG' 
                              AND WOR_PID = IM_ID  
                              AND CONVERT(Date, wor_Date, 113) < '" + fromDate + @"'
                        ), 0) AS INT)
                        - ISNULL(dbo.fget_Invoice_Qty('" + fromDate + @"', '" + previousDate + @"', IM_ID), 0)
                    AS INT) AS [Openning Qty],

                    CAST(ISNULL((SELECT SUM(fe_ok) 
                        FROM [CHE_SRUTHY_PLASTIC].[final_entry]  
                        WHERE fe_partid = IM_ID 
                          AND CONVERT(DATE, fe_Date, 112) 
                              BETWEEN '" + fromDate + @"' AND '" + toDate + @"'), 0) AS DECIMAL(18,2)) AS [FG QTY],

                    CAST(
                        CAST(ISNULL((
                            SELECT SUM(wor_Qty)  
                            FROM Work_Order_Receive_Details  
                            WHERE wor_status = 'A' 
                              AND wor_MaterialType = 'FG' 
                              AND WOR_PID = IM_ID  
                              AND CONVERT(Date, wor_Date, 113) 
                                  BETWEEN '" + fromDate + @"' AND '" + toDate + @"'
                        ), 0) AS INT)
                        + (
                            ISNULL(dbo.fget_Production_Qty('20140801', '" + previousDate + @"', IM_ID), 0)
                            + CAST(ISNULL((
                                SELECT SUM(fe_ok) 
                                FROM [CHE_SRUTHY_PLASTIC].[final_entry]  
                                WHERE fe_partid = IM_ID AND CONVERT(Date, fe_Date, 113) < '" + fromDate + @"'
                            ), 0) AS INT)
                            + CAST(ISNULL((
                                SELECT SUM(wor_Qty)  
                                FROM Work_Order_Receive_Details  
                                WHERE wor_status = 'A' 
                                  AND wor_MaterialType = 'FG' 
                                  AND WOR_PID = IM_ID  
                                  AND CONVERT(Date, wor_Date, 113) < '" + fromDate + @"'
                            ), 0) AS INT)
                            - ISNULL(dbo.fget_Invoice_Qty('20140801', '" + previousDate + @"', IM_ID), 0)
                        )
                        + CAST(ISNULL((
                            SELECT SUM(fe_ok) 
                            FROM [CHE_SRUTHY_PLASTIC].[final_entry]  
                            WHERE fe_partid = IM_ID AND CONVERT(Date, fe_Date, 113) 
                                  BETWEEN '" + fromDate + @"' AND '" + toDate + @"'
                        ), 0) AS DECIMAL(18,2))
                    AS DECIMAL(18,2)) AS [Closing Qty1],

                 --   IM_MinStock AS [Min],                                  
                  --  IM_MaxStock AS [Max],  
                    0 AS [Invoice Qty], -- Placeholder
                    0 AS [Closing Qty],      -- New Balance column
                    '' AS [Remarks]
                FROM Item_Master                               
                WHERE IM_Status = 'A' AND IM_Type = 1                             
                ORDER BY IM_ID");

            // Update "Invoice Qty" from dt1 into dt
            foreach (DataRow dr in dt.Rows)
            {
                string partNo = dr["Part No"].ToString();
                DataRow[] match = dt1.Select("[SD_Part_No] = '" + partNo + "'");
                if (match.Length > 0)
                {
                    dr["Invoice Qty"] = match[0]["Qty"];
                }
                else
                {
                    dr["Invoice Qty"] = 0;
                }
            }

            // Compute "Balance" = "Closing Qty" - "Invoice Qty"
            foreach (DataRow dr in dt.Rows)
            {
                decimal closingQty = Convert.ToDecimal(dr["Closing Qty1"]);
                decimal invoiceQty = Convert.ToDecimal(dr["Invoice Qty"]);
                dr["Closing Qty"] = closingQty - invoiceQty;
            }

            dataGridView1.DataSource = dt;
            dbFunctions.DGVStyle(dataGridView1);
            dataGridView1.Columns["Closing Qty1"].Visible = false;


        }

        private void DATAVALUE1()
        {
            string fromDate = dtpFrom.Value.ToString("yyyyMMdd");
            string toDate = todate.Value.ToString("yyyyMMdd");
            string previousDate = dtpFrom.Value.AddDays(-1).ToString("yyyyMMdd");

            // Load DT1: Sales Invoice Details
            DataTable dt1 = dbFunctions.getTable1(@"
                        SELECT 
                            SD_Part_No, 
                            SUM(SD_Qty) AS Qty 
                        FROM dbo.Sales_Invoice_Details
                        WHERE SD_Status = 'A' 
                          AND CONVERT(DATE, SD_Created_Date, 112) 
                              BETWEEN '" + fromDate + @"' AND '" + toDate + @"' 
                        GROUP BY SD_Part_No");

            // Load DT: Item Master Data
            DataTable dt = dbFunctions.getTable(@"
    SELECT                               
        IM_ID AS ID,                              
        ROW_NUMBER() OVER(ORDER BY IM_ID) AS [S.No],                        
        IM_PartNo AS [Part No],                              
        IM_PartName AS [Part Name],                              
        IM_Sales_Price AS [Sales Price],            

        CAST(ISNULL((SELECT SUM(wor_Qty)  
            FROM Work_Order_Receive_Details  
            WHERE wor_status = 'A' 
              AND wor_MaterialType = 'FG' 
              AND WOR_PID = IM_ID  
              AND CONVERT(DATE, wor_Date, 112) 
                  BETWEEN '" + fromDate + @"' AND '" + toDate + @"'), 0) AS INT) AS [DC QTY],

        CAST(
            ISNULL(dbo.fget_Production_Qty('" + fromDate + @"', '" + previousDate + @"', IM_ID), 0)
            + CAST(ISNULL((
                SELECT SUM(fe_ok) 
                FROM [CHE_SRUTHY_PLASTIC].[final_entry]  
                WHERE fe_partid = IM_ID AND CONVERT(Date, fe_Date, 113) < '" + fromDate + @"'
            ), 0) AS INT)
            + CAST(ISNULL((
                SELECT SUM(wor_Qty)  
                FROM Work_Order_Receive_Details  
                WHERE wor_status = 'A' 
                  AND wor_MaterialType = 'FG' 
                  AND WOR_PID = IM_ID  
                  AND CONVERT(Date, wor_Date, 113) < '" + fromDate + @"'
            ), 0) AS INT)
            - ISNULL(dbo.fget_Invoice_Qty('" + fromDate + @"', '" + previousDate + @"', IM_ID), 0)
        AS INT) AS [Openning Qty],

        CAST(ISNULL((SELECT SUM(fe_ok) 
            FROM [CHE_SRUTHY_PLASTIC].[final_entry]  
            WHERE fe_partid = IM_ID 
              AND CONVERT(DATE, fe_Date, 112) 
                  BETWEEN '" + fromDate + @"' AND '" + toDate + @"'), 0) AS DECIMAL(18,2)) AS [FG QTY],

        CAST(
            CAST(ISNULL((
                SELECT SUM(wor_Qty)  
                FROM Work_Order_Receive_Details  
                WHERE wor_status = 'A' 
                  AND wor_MaterialType = 'FG' 
                  AND WOR_PID = IM_ID  
                  AND CONVERT(Date, wor_Date, 113) 
                      BETWEEN '" + fromDate + @"' AND '" + toDate + @"'
            ), 0) AS INT)
            + (
                ISNULL(dbo.fget_Production_Qty('20140801', '" + previousDate + @"', IM_ID), 0)
                + CAST(ISNULL((
                    SELECT SUM(fe_ok) 
                    FROM [CHE_SRUTHY_PLASTIC].[final_entry]  
                    WHERE fe_partid = IM_ID AND CONVERT(Date, fe_Date, 113) < '" + fromDate + @"'
                ), 0) AS INT)
                + CAST(ISNULL((
                    SELECT SUM(wor_Qty)  
                    FROM Work_Order_Receive_Details  
                    WHERE wor_status = 'A' 
                      AND wor_MaterialType = 'FG' 
                      AND WOR_PID = IM_ID  
                      AND CONVERT(Date, wor_Date, 113) < '" + fromDate + @"'
                ), 0) AS INT)
                - ISNULL(dbo.fget_Invoice_Qty('20140801', '" + previousDate + @"', IM_ID), 0)
            )
            + CAST(ISNULL((
                SELECT SUM(fe_ok) 
                FROM [CHE_SRUTHY_PLASTIC].[final_entry]  
                WHERE fe_partid = IM_ID AND CONVERT(Date, fe_Date, 113) 
                      BETWEEN '" + fromDate + @"' AND '" + toDate + @"'
            ), 0) AS DECIMAL(18,2))
        AS DECIMAL(18,2)) AS [Closing Qty],

        IM_MinStock AS [Min],                                  
        IM_MaxStock AS [Max],  
        0 AS [Invoice Qty], -- Placeholder
        '' AS [Remarks]
    FROM Item_Master                               
    WHERE IM_Status = 'A' AND IM_Type = 1                             
    ORDER BY IM_ID");



            // Add Invoice Qty from dt1 to dt
            foreach (DataRow dr in dt.Rows)
                                {
                                    string partNo = dr["Part No"].ToString();
                                    DataRow[] match = dt1.Select("[SD_Part_No] = '" + partNo + "'");
                                    if (match.Length > 0)
                                    {
                                        dr["Invoice Qty"] = match[0]["Qty"];
                                    }
                                    else
                                    {
                                        dr["Invoice Qty"] = 0;
                                    }
                                }



            dataGridView1.DataSource = dt;
            dbFunctions.DGVStyle(dataGridView1);

        }

        private void todate_ValueChanged(object sender, EventArgs e)
        {
           // DATAVALUE2();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            //DATAVALUE2();
        }

        private SpeechRecognitionEngine recognizer;
        private bool isListening = false;

        private void InitializeVoiceRecognition()
        {
            try
            {
                if (recognizer == null)
                {
                    recognizer = new SpeechRecognitionEngine();
                    recognizer.SetInputToDefaultAudioDevice();

                    // Speed Optimization: Short timeouts for near-instant response
                    recognizer.BabbleTimeout = TimeSpan.FromSeconds(1.5);
                    recognizer.InitialSilenceTimeout = TimeSpan.FromSeconds(2);
                    recognizer.EndSilenceTimeout = TimeSpan.FromMilliseconds(300);
                    recognizer.EndSilenceTimeoutAmbiguous = TimeSpan.FromMilliseconds(350);

                    // Speed Optimization: Restricted digits-only grammar
                    System.Speech.Recognition.SrgsGrammar.SrgsDocument srgsDoc = new System.Speech.Recognition.SrgsGrammar.SrgsDocument();
                    System.Speech.Recognition.SrgsGrammar.SrgsRule rootRule = new System.Speech.Recognition.SrgsGrammar.SrgsRule("digits");
                    srgsDoc.Rules.Add(rootRule);
                    srgsDoc.Root = rootRule;

                    System.Speech.Recognition.SrgsGrammar.SrgsOneOf oneOf = new System.Speech.Recognition.SrgsGrammar.SrgsOneOf(
                        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                        "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
                    );

                    System.Speech.Recognition.SrgsGrammar.SrgsItem item = new System.Speech.Recognition.SrgsGrammar.SrgsItem(1, 20, oneOf);
                    rootRule.Elements.Add(item);

                    Grammar g = new Grammar(srgsDoc);
                    recognizer.LoadGrammarAsync(g);

                    recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
                    recognizer.SpeechRecognitionRejected += Recognizer_SpeechRecognitionRejected;
                    recognizer.RecognizeCompleted += Recognizer_RecognizeCompleted;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Voice recognition initialization failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoiceSearch_Click(object sender, EventArgs e)
        {
            if (!isListening)
            {
                if (recognizer == null)
                {
                    InitializeVoiceRecognition();
                }

                if (recognizer != null)
                {
                    try
                    {
                        recognizer.RecognizeAsync(RecognizeMode.Single);
                        isListening = true;
                        lblVoiceStatus.Text = "Listening...";
                        lblVoiceStatus.ForeColor = Color.Red;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error starting recognition: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                StopListening();
            }
        }

        private void StopListening()
        {
            if (recognizer != null && isListening)
            {
                recognizer.RecognizeAsyncStop();
                isListening = false;
                lblVoiceStatus.Text = "Not Listening";
                lblVoiceStatus.ForeColor = Color.Gray;
            }
        }

        private string ConvertSpokenToDigits(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return "";

            var map = new System.Collections.Generic.Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"zero",0},{"one",1},{"two",2},{"three",3},{"four",4},{"five",5},{"six",6},{"seven",7},{"eight",8},{"nine",9},
                {"ten",10},{"eleven",11},{"twelve",12},{"thirteen",13},{"fourteen",14},{"fifteen",15},{"sixteen",16},{"seventeen",17},{"eighteen",18},{"nineteen",19},
                {"twenty",20},{"thirty",30},{"forty",40},{"fifty",50},{"sixty",60},{"seventy",70},{"eighty",80},{"ninety",90}
            };
            
            var multipliers = new System.Collections.Generic.Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"hundred", 100}, {"thousand", 1000}, {"million", 1000000}
            };

            string[] tokens = text.Split(new[] { ' ', '-', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder finalResult = new StringBuilder();

            long totalNumber = 0;
            long currentNumber = 0;
            bool inNumber = false;
            bool lastWasSingleDigit = false;

            foreach (string rawToken in tokens)
            {
                StringBuilder cleanTokenBuilder = new StringBuilder();
                foreach(char c in rawToken) if (char.IsLetterOrDigit(c)) cleanTokenBuilder.Append(c);
                string token = cleanTokenBuilder.ToString();
                
                if (string.IsNullOrEmpty(token)) continue;
                
                bool isAllDigits = true;
                foreach(char c in token) if (!char.IsDigit(c)) { isAllDigits = false; break; }

                if (isAllDigits)
                {
                    if (inNumber)
                    {
                        finalResult.Append((totalNumber + currentNumber).ToString());
                        totalNumber = 0;
                        currentNumber = 0;
                        inNumber = false;
                    }
                    finalResult.Append(token);
                    lastWasSingleDigit = false;
                }
                else if (map.ContainsKey(token))
                {
                    int val = map[token];
                    if (val < 10)
                    {
                        if (lastWasSingleDigit)
                        {
                            if (inNumber) finalResult.Append((totalNumber + currentNumber).ToString());
                            finalResult.Append(val.ToString());
                            totalNumber = 0;
                            currentNumber = 0;
                            inNumber = false;
                            lastWasSingleDigit = true;
                        }
                        else
                        {
                            inNumber = true;
                            currentNumber += val;
                            lastWasSingleDigit = true;
                        }
                    }
                    else
                    {
                        inNumber = true;
                        currentNumber += val;
                        lastWasSingleDigit = false;
                    }
                }
                else if (multipliers.ContainsKey(token))
                {
                    if (!inNumber) currentNumber = 1; 
                    currentNumber *= multipliers[token];
                    if (multipliers[token] >= 1000)
                    {
                        totalNumber += currentNumber;
                        currentNumber = 0;
                    }
                    inNumber = true;
                    lastWasSingleDigit = false;
                }
                else
                {
                    if (inNumber)
                    {
                        finalResult.Append((totalNumber + currentNumber).ToString());
                        totalNumber = 0;
                        currentNumber = 0;
                        inNumber = false;
                    }
                    lastWasSingleDigit = false;
                }
            }

            if (inNumber)
            {
                finalResult.Append((totalNumber + currentNumber).ToString());
            }

            return finalResult.ToString();
        }

        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result == null || string.IsNullOrWhiteSpace(e.Result.Text))
                return;

            string voiceText = ConvertSpokenToDigits(e.Result.Text);

            if (string.IsNullOrWhiteSpace(voiceText))
                return;

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
                {
                    textBoxX1.Text = voiceText;
                }));
                return;
            }

            textBoxX1.Text = voiceText;
        }

        private void Recognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                lblVoiceStatus.Text = "Not recognized";
                lblVoiceStatus.ForeColor = Color.Orange;
            }));
        }

        private void Recognizer_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                isListening = false;
                if (lblVoiceStatus.Text == "Listening...") 
                {
                    lblVoiceStatus.Text = "Not Listening";
                    lblVoiceStatus.ForeColor = Color.Gray;
                }
            }));
        }
    }
}
