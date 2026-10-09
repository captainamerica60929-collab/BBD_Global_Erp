
namespace CRM_App.Production
{
    partial class Master_Batch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Master_Batch));
            this.BM_Type = new System.Windows.Forms.Label();
            this.btnSubmitt = new System.Windows.Forms.Button();
            this.txt_Barcode = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label20 = new System.Windows.Forms.Label();
            this.txtReqQty = new System.Windows.Forms.TextBox();
            this.txtUOM = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtxplanQty = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRMGrade = new System.Windows.Forms.TextBox();
            this.cmbRMSpec = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRCNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtPartName = new System.Windows.Forms.TextBox();
            this.txtPartNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Machine_No = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // BM_Type
            // 
            this.BM_Type.AutoSize = true;
            this.BM_Type.ForeColor = System.Drawing.Color.Black;
            this.BM_Type.Location = new System.Drawing.Point(329, 198);
            this.BM_Type.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BM_Type.Name = "BM_Type";
            this.BM_Type.Size = new System.Drawing.Size(10, 13);
            this.BM_Type.TabIndex = 313;
            this.BM_Type.Text = "-";
            // 
            // btnSubmitt
            // 
            this.btnSubmitt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitt.BackColor = System.Drawing.Color.LightGreen;
            this.btnSubmitt.Enabled = false;
            this.btnSubmitt.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmitt.Location = new System.Drawing.Point(895, 280);
            this.btnSubmitt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSubmitt.Name = "btnSubmitt";
            this.btnSubmitt.Size = new System.Drawing.Size(128, 27);
            this.btnSubmitt.TabIndex = 311;
            this.btnSubmitt.Text = "Load Material";
            this.btnSubmitt.UseVisualStyleBackColor = false;
            this.btnSubmitt.Click += new System.EventHandler(this.btnSubmitt_Click);
            // 
            // txt_Barcode
            // 
            // 
            // 
            // 
            this.txt_Barcode.Border.Class = "TextBoxBorder";
            this.txt_Barcode.Font = new System.Drawing.Font("Book Antiqua", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Barcode.Location = new System.Drawing.Point(115, 289);
            this.txt_Barcode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new System.Drawing.Size(224, 30);
            this.txt_Barcode.TabIndex = 301;
            this.txt_Barcode.WatermarkColor = System.Drawing.Color.Gray;
            this.txt_Barcode.WatermarkText = "Waiting .....";
            this.txt_Barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Barcode_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 296);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 15);
            this.label4.TabIndex = 294;
            this.label4.Text = "Machine Barcode :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView2);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(346, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(678, 235);
            this.groupBox1.TabIndex = 293;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pending Production Request";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(2, 18);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(674, 215);
            this.dataGridView2.TabIndex = 292;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(8, 231);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 15);
            this.label20.TabIndex = 290;
            this.label20.Text = "Req Qty :";
            // 
            // txtReqQty
            // 
            this.txtReqQty.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtReqQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReqQty.Enabled = false;
            this.txtReqQty.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReqQty.Location = new System.Drawing.Point(101, 223);
            this.txtReqQty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReqQty.Name = "txtReqQty";
            this.txtReqQty.Size = new System.Drawing.Size(96, 26);
            this.txtReqQty.TabIndex = 289;
            // 
            // txtUOM
            // 
            this.txtUOM.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtUOM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUOM.Enabled = false;
            this.txtUOM.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUOM.Location = new System.Drawing.Point(243, 223);
            this.txtUOM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUOM.Name = "txtUOM";
            this.txtUOM.Size = new System.Drawing.Size(82, 26);
            this.txtUOM.TabIndex = 285;
            this.txtUOM.Text = "KG";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(201, 226);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 13);
            this.label18.TabIndex = 284;
            this.label18.Text = "UOM :";
            // 
            // txtxplanQty
            // 
            this.txtxplanQty.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtxplanQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtxplanQty.Enabled = false;
            this.txtxplanQty.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtxplanQty.Location = new System.Drawing.Point(102, 137);
            this.txtxplanQty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtxplanQty.Name = "txtxplanQty";
            this.txtxplanQty.Size = new System.Drawing.Size(223, 26);
            this.txtxplanQty.TabIndex = 279;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(8, 143);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 15);
            this.label15.TabIndex = 280;
            this.label15.Text = "Plan Qty :";
            // 
            // txtRMGrade
            // 
            this.txtRMGrade.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtRMGrade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRMGrade.Enabled = false;
            this.txtRMGrade.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRMGrade.Location = new System.Drawing.Point(102, 192);
            this.txtRMGrade.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRMGrade.Name = "txtRMGrade";
            this.txtRMGrade.Size = new System.Drawing.Size(223, 26);
            this.txtRMGrade.TabIndex = 272;
            // 
            // cmbRMSpec
            // 
            this.cmbRMSpec.BackColor = System.Drawing.Color.White;
            this.cmbRMSpec.FormattingEnabled = true;
            this.cmbRMSpec.Location = new System.Drawing.Point(102, 164);
            this.cmbRMSpec.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbRMSpec.Name = "cmbRMSpec";
            this.cmbRMSpec.Size = new System.Drawing.Size(224, 21);
            this.cmbRMSpec.TabIndex = 273;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(8, 170);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 15);
            this.label10.TabIndex = 274;
            this.label10.Text = "RM NO :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(8, 197);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 275;
            this.label11.Text = "RM Grade :";
            // 
            // txtRCNo
            // 
            this.txtRCNo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtRCNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRCNo.Enabled = false;
            this.txtRCNo.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRCNo.Location = new System.Drawing.Point(101, 32);
            this.txtRCNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRCNo.Name = "txtRCNo";
            this.txtRCNo.Size = new System.Drawing.Size(224, 26);
            this.txtRCNo.TabIndex = 261;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 262;
            this.label2.Text = "Route Card No :";
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModel.Enabled = false;
            this.txtModel.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModel.Location = new System.Drawing.Point(102, 110);
            this.txtModel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(223, 26);
            this.txtModel.TabIndex = 252;
            // 
            // txtPartName
            // 
            this.txtPartName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPartName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPartName.Enabled = false;
            this.txtPartName.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartName.Location = new System.Drawing.Point(102, 84);
            this.txtPartName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPartName.Name = "txtPartName";
            this.txtPartName.Size = new System.Drawing.Size(223, 26);
            this.txtPartName.TabIndex = 253;
            // 
            // txtPartNo
            // 
            this.txtPartNo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPartNo.Enabled = false;
            this.txtPartNo.FormattingEnabled = true;
            this.txtPartNo.Location = new System.Drawing.Point(102, 60);
            this.txtPartNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.Size = new System.Drawing.Size(224, 21);
            this.txtPartNo.TabIndex = 254;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 255;
            this.label1.Text = "Part Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 256;
            this.label3.Text = "Part No :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(8, 117);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 257;
            this.label8.Text = "Model :";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Firebrick;
            this.panel7.Location = new System.Drawing.Point(7, 8);
            this.panel7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(9, 11);
            this.panel7.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(17, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Master Batch Scan";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel8.Location = new System.Drawing.Point(4, 25);
            this.panel8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1020, 2);
            this.panel8.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.lblResult);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.Machine_No);
            this.panel6.Controls.Add(this.BM_Type);
            this.panel6.Controls.Add(this.btnSubmitt);
            this.panel6.Controls.Add(this.txt_Barcode);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.groupBox1);
            this.panel6.Controls.Add(this.label20);
            this.panel6.Controls.Add(this.txtReqQty);
            this.panel6.Controls.Add(this.txtUOM);
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.txtxplanQty);
            this.panel6.Controls.Add(this.label15);
            this.panel6.Controls.Add(this.txtRMGrade);
            this.panel6.Controls.Add(this.cmbRMSpec);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.txtRCNo);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.txtModel);
            this.panel6.Controls.Add(this.txtPartName);
            this.panel6.Controls.Add(this.txtPartNo);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.button10);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1028, 414);
            this.panel6.TabIndex = 4;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Location = new System.Drawing.Point(347, 280);
            this.lblResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(28, 37);
            this.lblResult.TabIndex = 316;
            this.lblResult.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 262);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 315;
            this.label6.Text = "Machine No :";
            // 
            // Machine_No
            // 
            this.Machine_No.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Machine_No.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Machine_No.Enabled = false;
            this.Machine_No.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Machine_No.Location = new System.Drawing.Point(101, 255);
            this.Machine_No.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Machine_No.Name = "Machine_No";
            this.Machine_No.Size = new System.Drawing.Size(224, 26);
            this.Machine_No.TabIndex = 314;
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.Location = new System.Drawing.Point(957, -1);
            this.button10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(67, 24);
            this.button10.TabIndex = 118;
            this.button10.Text = "Close";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Master_Batch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 414);
            this.Controls.Add(this.panel6);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Master_Batch";
            this.Text = "Master_Batch";
            this.Load += new System.EventHandler(this.Master_Batch_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label BM_Type;
        private System.Windows.Forms.Button btnSubmitt;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_Barcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtReqQty;
        private System.Windows.Forms.TextBox txtUOM;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtxplanQty;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRMGrade;
        private System.Windows.Forms.ComboBox cmbRMSpec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRCNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtPartName;
        private System.Windows.Forms.ComboBox txtPartNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Machine_No;
        private System.Windows.Forms.Label lblResult;
    }
}