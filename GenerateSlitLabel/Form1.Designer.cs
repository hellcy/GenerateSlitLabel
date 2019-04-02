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
            this.SmartSlatLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CoilWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
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
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(331, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // previewBtn
            // 
            this.previewBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewBtn.Location = new System.Drawing.Point(362, 31);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(74, 47);
            this.previewBtn.TabIndex = 2;
            this.previewBtn.Text = "Preview";
            this.previewBtn.UseVisualStyleBackColor = true;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.Location = new System.Drawing.Point(454, 31);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(74, 47);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // ErrMsg
            // 
            this.ErrMsg.AutoSize = true;
            this.ErrMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrMsg.ForeColor = System.Drawing.Color.Red;
            this.ErrMsg.Location = new System.Drawing.Point(272, 104);
            this.ErrMsg.Name = "ErrMsg";
            this.ErrMsg.Size = new System.Drawing.Size(0, 20);
            this.ErrMsg.TabIndex = 4;
            // 
            // ScanLabel
            // 
            this.ScanLabel.AutoSize = true;
            this.ScanLabel.Location = new System.Drawing.Point(13, 26);
            this.ScanLabel.Name = "ScanLabel";
            this.ScanLabel.Size = new System.Drawing.Size(70, 13);
            this.ScanLabel.TabIndex = 5;
            this.ScanLabel.Text = "Please Scan:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(37, 68);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(20, 22);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "3";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBox3.Location = new System.Drawing.Point(78, 68);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(20, 22);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "4";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBox4.Location = new System.Drawing.Point(124, 68);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(20, 22);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "3";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBox5.Location = new System.Drawing.Point(169, 68);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(20, 22);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "2";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBox6.Location = new System.Drawing.Point(218, 68);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(20, 22);
            this.textBox6.TabIndex = 10;
            this.textBox6.Text = "2";
            // 
            // size_51
            // 
            this.size_51.AutoSize = true;
            this.size_51.Location = new System.Drawing.Point(38, 43);
            this.size_51.Name = "size_51";
            this.size_51.Size = new System.Drawing.Size(19, 13);
            this.size_51.TabIndex = 11;
            this.size_51.Text = "51";
            // 
            // size_67
            // 
            this.size_67.AutoSize = true;
            this.size_67.Location = new System.Drawing.Point(79, 43);
            this.size_67.Name = "size_67";
            this.size_67.Size = new System.Drawing.Size(19, 13);
            this.size_67.TabIndex = 12;
            this.size_67.Text = "67";
            // 
            // size_83
            // 
            this.size_83.AutoSize = true;
            this.size_83.Location = new System.Drawing.Point(125, 43);
            this.size_83.Name = "size_83";
            this.size_83.Size = new System.Drawing.Size(19, 13);
            this.size_83.TabIndex = 13;
            this.size_83.Text = "83";
            // 
            // size_92
            // 
            this.size_92.AutoSize = true;
            this.size_92.Location = new System.Drawing.Point(170, 43);
            this.size_92.Name = "size_92";
            this.size_92.Size = new System.Drawing.Size(19, 13);
            this.size_92.TabIndex = 14;
            this.size_92.Text = "92";
            // 
            // size_108
            // 
            this.size_108.AutoSize = true;
            this.size_108.Location = new System.Drawing.Point(213, 43);
            this.size_108.Name = "size_108";
            this.size_108.Size = new System.Drawing.Size(25, 13);
            this.size_108.TabIndex = 15;
            this.size_108.Text = "108";
            // 
            // Qty
            // 
            this.Qty.AutoSize = true;
            this.Qty.Location = new System.Drawing.Point(3, 73);
            this.Qty.Name = "Qty";
            this.Qty.Size = new System.Drawing.Size(23, 13);
            this.Qty.TabIndex = 16;
            this.Qty.Text = "Qty";
            // 
            // Width
            // 
            this.Width.AutoSize = true;
            this.Width.Location = new System.Drawing.Point(3, 43);
            this.Width.Name = "Width";
            this.Width.Size = new System.Drawing.Size(35, 13);
            this.Width.TabIndex = 17;
            this.Width.Text = "Width";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 100);
            this.panel1.TabIndex = 18;
            // 
            // SmartSlatLabel
            // 
            this.SmartSlatLabel.AutoSize = true;
            this.SmartSlatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmartSlatLabel.Location = new System.Drawing.Point(70, 9);
            this.SmartSlatLabel.Name = "SmartSlatLabel";
            this.SmartSlatLabel.Size = new System.Drawing.Size(119, 16);
            this.SmartSlatLabel.TabIndex = 18;
            this.SmartSlatLabel.Text = "For SmartSlat Only";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoilWidth,
            this.Weight});
            this.dataGridView1.Location = new System.Drawing.Point(301, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 19;
            // 
            // CoilWidth
            // 
            this.CoilWidth.HeaderText = "Width";
            this.CoilWidth.Name = "CoilWidth";
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GenerateSlitLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 334);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoilWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private Button button1;
    }
}

