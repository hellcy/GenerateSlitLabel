using System.Windows.Forms;

namespace GenerateSlitLabel
{
    partial class GenerateSlitLabel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateSlitLabel));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.previewBtn = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.ErrMsg = new System.Windows.Forms.Label();
            this.ScanLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.size_51 = new System.Windows.Forms.Label();
            this.size_67 = new System.Windows.Forms.Label();
            this.size_83 = new System.Windows.Forms.Label();
            this.size_92 = new System.Windows.Forms.Label();
            this.size_108 = new System.Windows.Forms.Label();
            this.Qty = new System.Windows.Forms.Label();
            this.Width = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SMBackColorText = new System.Windows.Forms.TextBox();
            this.SMFrontColorText = new System.Windows.Forms.TextBox();
            this.SMBackColorLabel = new System.Windows.Forms.Label();
            this.SMFrontColorLabel = new System.Windows.Forms.Label();
            this.SmartSlatLabel = new System.Windows.Forms.Label();
            this.CoilWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.GaugeLabel = new System.Windows.Forms.Label();
            this.TypeText = new System.Windows.Forms.TextBox();
            this.ColorText = new System.Windows.Forms.TextBox();
            this.WidthText = new System.Windows.Forms.TextBox();
            this.GaugeText = new System.Windows.Forms.TextBox();
            this.WeightLabel = new System.Windows.Forms.Label();
            this.WeightText = new System.Windows.Forms.TextBox();
            this.CoilWidth2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoilWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(411, 31);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // previewBtn
            // 
            this.previewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewBtn.Location = new System.Drawing.Point(435, 107);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(139, 62);
            this.previewBtn.TabIndex = 2;
            this.previewBtn.Text = "Preview";
            this.previewBtn.UseVisualStyleBackColor = true;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.Location = new System.Drawing.Point(435, 206);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(139, 62);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // ErrMsg
            // 
            this.ErrMsg.AutoSize = true;
            this.ErrMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrMsg.ForeColor = System.Drawing.Color.Red;
            this.ErrMsg.Location = new System.Drawing.Point(116, 9);
            this.ErrMsg.Name = "ErrMsg";
            this.ErrMsg.Size = new System.Drawing.Size(0, 25);
            this.ErrMsg.TabIndex = 4;
            // 
            // ScanLabel
            // 
            this.ScanLabel.AutoSize = true;
            this.ScanLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScanLabel.Location = new System.Drawing.Point(8, 9);
            this.ScanLabel.Name = "ScanLabel";
            this.ScanLabel.Size = new System.Drawing.Size(139, 25);
            this.ScanLabel.TabIndex = 5;
            this.ScanLabel.Text = "Please Scan:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(80, 160);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(26, 29);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "3";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(142, 160);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(26, 29);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "4";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(203, 160);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(26, 29);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "3";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(265, 160);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(26, 29);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "2";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(323, 160);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(25, 29);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "2";
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // size_51
            // 
            this.size_51.AutoSize = true;
            this.size_51.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size_51.Location = new System.Drawing.Point(76, 121);
            this.size_51.Name = "size_51";
            this.size_51.Size = new System.Drawing.Size(30, 24);
            this.size_51.TabIndex = 11;
            this.size_51.Text = "51";
            // 
            // size_67
            // 
            this.size_67.AutoSize = true;
            this.size_67.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size_67.Location = new System.Drawing.Point(138, 121);
            this.size_67.Name = "size_67";
            this.size_67.Size = new System.Drawing.Size(30, 24);
            this.size_67.TabIndex = 12;
            this.size_67.Text = "67";
            // 
            // size_83
            // 
            this.size_83.AutoSize = true;
            this.size_83.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size_83.Location = new System.Drawing.Point(199, 121);
            this.size_83.Name = "size_83";
            this.size_83.Size = new System.Drawing.Size(30, 24);
            this.size_83.TabIndex = 13;
            this.size_83.Text = "83";
            // 
            // size_92
            // 
            this.size_92.AutoSize = true;
            this.size_92.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size_92.Location = new System.Drawing.Point(261, 121);
            this.size_92.Name = "size_92";
            this.size_92.Size = new System.Drawing.Size(30, 24);
            this.size_92.TabIndex = 14;
            this.size_92.Text = "92";
            // 
            // size_108
            // 
            this.size_108.AutoSize = true;
            this.size_108.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.size_108.Location = new System.Drawing.Point(319, 121);
            this.size_108.Name = "size_108";
            this.size_108.Size = new System.Drawing.Size(40, 24);
            this.size_108.TabIndex = 15;
            this.size_108.Text = "108";
            // 
            // Qty
            // 
            this.Qty.AutoSize = true;
            this.Qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Qty.Location = new System.Drawing.Point(12, 163);
            this.Qty.Name = "Qty";
            this.Qty.Size = new System.Drawing.Size(38, 24);
            this.Qty.TabIndex = 16;
            this.Qty.Text = "Qty";
            // 
            // Width
            // 
            this.Width.AutoSize = true;
            this.Width.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Width.Location = new System.Drawing.Point(12, 121);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(58, 24);
            this.Width.TabIndex = 17;
            this.Width.Text = "Width";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.SMBackColorText);
            this.panel1.Controls.Add(this.SMFrontColorText);
            this.panel1.Controls.Add(this.SMBackColorLabel);
            this.panel1.Controls.Add(this.SMFrontColorLabel);
            this.panel1.Controls.Add(this.SmartSlatLabel);
            this.panel1.Controls.Add(this.Width);
            this.panel1.Controls.Add(this.size_108);
            this.panel1.Controls.Add(this.Qty);
            this.panel1.Controls.Add(this.size_92);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.size_83);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.size_67);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.size_51);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Location = new System.Drawing.Point(23, 303);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 215);
            this.panel1.TabIndex = 18;
            // 
            // SMBackColorText
            // 
            this.SMBackColorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SMBackColorText.Location = new System.Drawing.Point(332, 47);
            this.SMBackColorText.Name = "SMBackColorText";
            this.SMBackColorText.Size = new System.Drawing.Size(67, 29);
            this.SMBackColorText.TabIndex = 22;
            this.SMBackColorText.TextChanged += new System.EventHandler(this.SMBackColorText_TextChanged);
            // 
            // SMFrontColorText
            // 
            this.SMFrontColorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SMFrontColorText.Location = new System.Drawing.Point(118, 47);
            this.SMFrontColorText.Name = "SMFrontColorText";
            this.SMFrontColorText.Size = new System.Drawing.Size(80, 29);
            this.SMFrontColorText.TabIndex = 21;
            this.SMFrontColorText.TextChanged += new System.EventHandler(this.SMFrontColorText_TextChanged);
            // 
            // SMBackColorLabel
            // 
            this.SMBackColorLabel.AutoSize = true;
            this.SMBackColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SMBackColorLabel.Location = new System.Drawing.Point(220, 50);
            this.SMBackColorLabel.Name = "SMBackColorLabel";
            this.SMBackColorLabel.Size = new System.Drawing.Size(106, 24);
            this.SMBackColorLabel.TabIndex = 20;
            this.SMBackColorLabel.Text = "Back Color:";
            // 
            // SMFrontColorLabel
            // 
            this.SMFrontColorLabel.AutoSize = true;
            this.SMFrontColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SMFrontColorLabel.Location = new System.Drawing.Point(5, 50);
            this.SMFrontColorLabel.Name = "SMFrontColorLabel";
            this.SMFrontColorLabel.Size = new System.Drawing.Size(109, 24);
            this.SMFrontColorLabel.TabIndex = 19;
            this.SMFrontColorLabel.Text = "Front Color:";
            // 
            // SmartSlatLabel
            // 
            this.SmartSlatLabel.AutoSize = true;
            this.SmartSlatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmartSlatLabel.Location = new System.Drawing.Point(114, 15);
            this.SmartSlatLabel.Name = "SmartSlatLabel";
            this.SmartSlatLabel.Size = new System.Drawing.Size(166, 24);
            this.SmartSlatLabel.TabIndex = 18;
            this.SmartSlatLabel.Text = "For SmartSlat Only";
            // 
            // CoilWidth
            // 
            this.CoilWidth.Name = "CoilWidth";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoilWidth2,
            this.CoilWeight});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(590, 32);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(369, 486);
            this.dataGridView1.TabIndex = 19;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeLabel.Location = new System.Drawing.Point(8, 84);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(66, 25);
            this.TypeLabel.TabIndex = 20;
            this.TypeLabel.Text = "Type:";
            // 
            // ColorLabel
            // 
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorLabel.Location = new System.Drawing.Point(8, 126);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(69, 25);
            this.ColorLabel.TabIndex = 21;
            this.ColorLabel.Text = "Color:";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WidthLabel.Location = new System.Drawing.Point(8, 251);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(73, 25);
            this.WidthLabel.TabIndex = 22;
            this.WidthLabel.Text = "Width:";
            // 
            // GaugeLabel
            // 
            this.GaugeLabel.AutoSize = true;
            this.GaugeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GaugeLabel.Location = new System.Drawing.Point(8, 206);
            this.GaugeLabel.Name = "GaugeLabel";
            this.GaugeLabel.Size = new System.Drawing.Size(82, 25);
            this.GaugeLabel.TabIndex = 23;
            this.GaugeLabel.Text = "Gauge:";
            // 
            // TypeText
            // 
            this.TypeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeText.Location = new System.Drawing.Point(142, 81);
            this.TypeText.Name = "TypeText";
            this.TypeText.Size = new System.Drawing.Size(100, 31);
            this.TypeText.TabIndex = 25;
            this.TypeText.TextChanged += new System.EventHandler(this.TypeText_TextChanged);
            // 
            // ColorText
            // 
            this.ColorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorText.Location = new System.Drawing.Point(142, 123);
            this.ColorText.Name = "ColorText";
            this.ColorText.Size = new System.Drawing.Size(100, 31);
            this.ColorText.TabIndex = 26;
            this.ColorText.TextChanged += new System.EventHandler(this.ColorText_TextChanged);
            // 
            // WidthText
            // 
            this.WidthText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WidthText.Location = new System.Drawing.Point(142, 248);
            this.WidthText.Name = "WidthText";
            this.WidthText.Size = new System.Drawing.Size(100, 31);
            this.WidthText.TabIndex = 27;
            this.WidthText.TextChanged += new System.EventHandler(this.WidthText_TextChanged);
            // 
            // GaugeText
            // 
            this.GaugeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GaugeText.Location = new System.Drawing.Point(142, 203);
            this.GaugeText.Name = "GaugeText";
            this.GaugeText.Size = new System.Drawing.Size(100, 31);
            this.GaugeText.TabIndex = 28;
            this.GaugeText.TextChanged += new System.EventHandler(this.GaugeText_TextChanged);
            // 
            // WeightLabel
            // 
            this.WeightLabel.AutoSize = true;
            this.WeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeightLabel.Location = new System.Drawing.Point(8, 163);
            this.WeightLabel.Name = "WeightLabel";
            this.WeightLabel.Size = new System.Drawing.Size(85, 25);
            this.WeightLabel.TabIndex = 29;
            this.WeightLabel.Text = "Weight:";
            // 
            // WeightText
            // 
            this.WeightText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeightText.Location = new System.Drawing.Point(142, 160);
            this.WeightText.Name = "WeightText";
            this.WeightText.Size = new System.Drawing.Size(100, 31);
            this.WeightText.TabIndex = 30;
            this.WeightText.TextChanged += new System.EventHandler(this.WeightText_TextChanged);
            // 
            // CoilWidth2
            // 
            this.CoilWidth2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoilWidth2.DefaultCellStyle = dataGridViewCellStyle2;
            this.CoilWidth2.HeaderText = "Coil ID";
            this.CoilWidth2.Name = "CoilWidth2";
            this.CoilWidth2.ReadOnly = true;
            // 
            // CoilWeight
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoilWeight.DefaultCellStyle = dataGridViewCellStyle3;
            this.CoilWeight.HeaderText = "Weight(kg)";
            this.CoilWeight.Name = "CoilWeight";
            this.CoilWeight.Width = 130;
            // 
            // GenerateSlitLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 530);
            this.Controls.Add(this.WeightText);
            this.Controls.Add(this.WeightLabel);
            this.Controls.Add(this.GaugeText);
            this.Controls.Add(this.WidthText);
            this.Controls.Add(this.ColorText);
            this.Controls.Add(this.TypeText);
            this.Controls.Add(this.GaugeLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.ColorLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ScanLabel);
            this.Controls.Add(this.ErrMsg);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.previewBtn);
            this.Controls.Add(this.textBox1);
            this.Name = "GenerateSlitLabel";
            this.Text = "GenerateSlitLabel";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button previewBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Label ErrMsg;
        private System.Windows.Forms.Label ScanLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label size_51;
        private System.Windows.Forms.Label size_67;
        private System.Windows.Forms.Label size_83;
        private System.Windows.Forms.Label size_92;
        private System.Windows.Forms.Label size_108;
        private System.Windows.Forms.Label Qty;
        private System.Windows.Forms.Label Width;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SmartSlatLabel;
        private DataGridViewTextBoxColumn CoilWidth;
        private DataGridView dataGridView1;
        private Label TypeLabel;
        private Label ColorLabel;
        private Label WidthLabel;
        private Label GaugeLabel;
        private TextBox TypeText;
        private TextBox ColorText;
        private TextBox WidthText;
        private TextBox GaugeText;
        private Label WeightLabel;
        private TextBox WeightText;
        private TextBox SMBackColorText;
        private TextBox SMFrontColorText;
        private Label SMBackColorLabel;
        private Label SMFrontColorLabel;
        private DataGridViewTextBoxColumn CoilWidth2;
        private DataGridViewTextBoxColumn CoilWeight;
    }
}

