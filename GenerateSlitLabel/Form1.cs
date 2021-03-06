﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zen.Barcode;

namespace GenerateSlitLabel
{
    public partial class GenerateSlitLabel : Form
    {

        public GenerateSlitLabel()
        {
            InitializeComponent();
        }

        // declare all global variables here
        string[] slitLabels;
        string COILID, TYPE, COLOR, GAUGE, front_color, back_color;
        int WEIGHT, WIDTH, slitNumber = 0, slitWidth = 0, pageNumber = 0;
        PaperSize paperSize = new PaperSize("papersize", 250, 800); //set the paper size
        int labelCreatedFlag = 0;

        private void TypeText_TextChanged(object sender, EventArgs e)
        {
            canCreateLabel();
        }

        private void ColorText_TextChanged(object sender, EventArgs e)
        {
            canCreateLabel();

        }

        private void WeightText_TextChanged(object sender, EventArgs e)
        {
            canCreateLabel();

        }

        private void GaugeText_TextChanged(object sender, EventArgs e)
        {
            canCreateLabel();

        }

        private void WidthText_TextChanged(object sender, EventArgs e)
        {
            canCreateLabel();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int placeHolder;
            if (width51Qty.Text != "" && int.TryParse(width51Qty.Text, out placeHolder))
            {
                canCreateLabel();
            }
            else ErrMsg.Text = "width can only be numbers";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int placeHolder;
            if (width67Qty.Text != "" && int.TryParse(width67Qty.Text, out placeHolder))
            {
                canCreateLabel();
            }
            else ErrMsg.Text = "width can only be numbers";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int placeHolder;
            if (width83Qty.Text != "" && int.TryParse(width83Qty.Text, out placeHolder))
            {
                canCreateLabel();
            }
            else ErrMsg.Text = "width can only be numbers";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int placeHolder;
            if (width92Qty.Text != "" && int.TryParse(width92Qty.Text, out placeHolder))
            {
                canCreateLabel();
            }
            else ErrMsg.Text = "width can only be numbers";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int placeHolder;
            if (width108Qty.Text != "" && int.TryParse(width108Qty.Text, out placeHolder))
            {
                canCreateLabel();
            }
            else ErrMsg.Text = "width can only be numbers";
        }

        private void SMFrontColorText_TextChanged(object sender, EventArgs e)
        {
            canCreateLabel();
        }

        private void SMBackColorText_TextChanged(object sender, EventArgs e)
        {
            canCreateLabel();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                labelCreatedFlag = 0;
                dataGridView1.Rows.Clear();
                ErrMsg.Text = "";
                width51Qty.Text = "3";
                width67Qty.Text = "4";
                width83Qty.Text = "3";
                width92Qty.Text = "2";
                width108Qty.Text = "2";
                slitLabels = null;

                //if (textBox1.Text.Length < 9)
                //{
                //    ErrMsg.Text = "Please enter correct COIL ID.";
                //    return;
                //}

                COILID = textBox1.Text.Split('+','_')[0].ToUpper();

                if ((System.IO.File.Exists(@"C:\GenerateSlitLabelsFile\COIL_MASTER_20190408.csv")) == true)
                {
                    foreach (string line in System.IO.File.ReadAllLines(@"C:\GenerateSlitLabelsFile\COIL_MASTER_20190408.csv"))
                    {
                        if (COILID.Equals(line.Substring(0, 9))) // found coil in the file
                        {
                            string[] inputArray = line.Split(','); // split the input string by using the delimiter ','

                            TypeText.Text = inputArray[1];
                            ColorText.Text = inputArray[2];
                            WeightText.Text = inputArray[3];
                            GaugeText.Text = inputArray[4];
                            WidthText.Text = inputArray[5];
                            SMFrontColorText.Text = inputArray[21];
                            SMBackColorText.Text = inputArray[22];
                            COILID = inputArray[0];

                            if (TypeText.Text != "" && ColorText.Text != "" && GaugeText.Text != "" && Int32.TryParse(WeightText.Text, out WEIGHT) && Int32.TryParse(WidthText.Text, out WIDTH))
                            {

                                createLabels();

                            }
                            else
                            {
                                // please fill the necessary infromation and then click button
                                ErrMsg.Text = "Please fill required information.";
                            }
                            break;
                        }
                    }
                    if (slitLabels == null && ErrMsg.Text == "") // manually enter information
                    {
                        ErrMsg.Text = "Coil not found, please fill required information.";
                        canCreateLabel();
                    }
                    if (slitNumber == -2 && ErrMsg.Text == "") ErrMsg.Text = "Type IS is not supported.";
                }
            }
        }

        private void createLabels()
        {
            TYPE = TypeText.Text;
            COLOR = ColorText.Text.ToUpper();
            Int32.TryParse(WeightText.Text, out WEIGHT);
            GAUGE = GaugeText.Text;
            Int32.TryParse(WidthText.Text, out WIDTH);
            dataGridView1.Rows.Clear();

            switch (TYPE.ToUpper())
            {
                case "RA":
                    slitNumber = 6;
                    slitWidth = 170;
                    break;
                case "SM":
                    slitNumber = -1;
                    break;
                case "PO":
                    slitNumber = 8;
                    slitWidth = 135;
                    break;
                case "PL":
                    slitNumber = 4;
                    slitWidth = 255;
                    break;
                case "IS":
                    slitNumber = -2;
                    ErrMsg.Text = "Type 'IS' is not supported.";
                    break;
                case "LA":
                    slitNumber = 8;
                    slitWidth = 116;
                    break;
                case "GS":
                    slitNumber = 11;
                    slitWidth = 84;
                    break;
                default:
                    slitNumber = -2;
                    ErrMsg.Text = "Type not exist.";
                    break;
            }

            if (slitNumber > 0)
            {
                slitLabels = new string[slitNumber];
                for (int i = 1; i < slitLabels.Length + 1; i = i + 2)
                {
                    slitLabels[i - 1] = COILID + "_" + i + "&" + (i + 1) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT * slitWidth / WIDTH * 2) + "+" + GAUGE + "+" + slitWidth;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[(i - 1) / 2].Cells[0].Value = slitLabels[i - 1].Split('+')[0];
                    dataGridView1.Rows[(i - 1) / 2].Cells[1].Value = (int)(WEIGHT * slitWidth / WIDTH * 2);
                }
            }

            // only for type SM
            if (slitNumber == -1)
            {
                slitNumber = Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text) + Int32.Parse(width92Qty.Text) + Int32.Parse(width108Qty.Text);
                slitLabels = new string[slitNumber];
                for (int i = 0; i < slitNumber; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = COILID + "_" + (i + 1);
                }

                // fill in label information for each diffferent width
                for (int i = 1; i < Int32.Parse(width51Qty.Text) + 1; i++)
                {
                    slitWidth = 51;
                    slitLabels[i - 1] = COILID + "_" + i + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                    dataGridView1.Rows[i - 1].Cells[0].Value += " (" + slitWidth + ")";
                    dataGridView1.Rows[i - 1].Cells[1].Value = (int)(WEIGHT / WIDTH * slitWidth);
                }

                for (int i = 1; i < Int32.Parse(width67Qty.Text) + 1; i++)
                {
                    slitWidth = 67;
                    slitLabels[i - 1 + Int32.Parse(width51Qty.Text)] = COILID + "_" + (i + Int32.Parse(width51Qty.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                    dataGridView1.Rows[i - 1 + Int32.Parse(width51Qty.Text)].Cells[0].Value += " (" + slitWidth + ")";
                    dataGridView1.Rows[i - 1 + Int32.Parse(width51Qty.Text)].Cells[1].Value = (int)(WEIGHT / WIDTH * slitWidth);
                }

                for (int i = 1; i < Int32.Parse(width83Qty.Text) + 1; i++)
                {
                    slitWidth = 83;
                    slitLabels[i - 1 + Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text)] = COILID + "_" + (i + Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                    dataGridView1.Rows[i - 1 + Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text)].Cells[0].Value += " (" + slitWidth + ")";
                    dataGridView1.Rows[i - 1 + Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text)].Cells[1].Value = (int)(WEIGHT / WIDTH * slitWidth);
                }

                for (int i = 1; i < Int32.Parse(width92Qty.Text) + 1; i++)
                {
                    slitWidth = 92;
                    slitLabels[i - 1 + Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text)] = COILID + "_" + (i + Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                    dataGridView1.Rows[i - 1 + Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text)].Cells[0].Value += " (" + slitWidth + ")";
                    dataGridView1.Rows[i - 1 + Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text)].Cells[1].Value = (int)(WEIGHT / WIDTH * slitWidth);
                }

                for (int i = 1; i < Int32.Parse(width108Qty.Text) + 1; i++)
                {
                    slitWidth = 108;
                    slitLabels[i - 1 + Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text) + Int32.Parse(width92Qty.Text)] = COILID + "_" + (i + Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text) + Int32.Parse(width92Qty.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                    dataGridView1.Rows[i - 1 + Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text) + Int32.Parse(width92Qty.Text)].Cells[0].Value += " (" + slitWidth + ")";
                    dataGridView1.Rows[i - 1 + Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text) + Int32.Parse(width92Qty.Text)].Cells[1].Value = (int)(WEIGHT / WIDTH * slitWidth);
                }
            }
            labelCreatedFlag = 1;
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            if (canPressButton())
            {
                pageNumber = 0;
                weightOverride();

                printDocument1.DefaultPageSettings.PaperSize = paperSize;
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            if (canPressButton())
            {
                pageNumber = 0;
                weightOverride();

                if (slitLabels != null)
                {
                    int numberOfCopy = 1;
                    //if (TYPE.ToUpper() == "SM") numberOfCopy = 1;
                    printDocument1.DefaultPageSettings.PaperSize = paperSize;
                    ErrMsg.Text = "";
                    string printer = "ZDesigner S4M-203dpi ZPL";
                    Printing(printer, numberOfCopy);
                }
                else
                {
                    ErrMsg.Text = "Please Scan an ID.";
                    ErrMsg.ForeColor = Color.Red;
                    ErrMsg.Font = new System.Drawing.Font("Ariel", 20);
                }

                // add timestamp and coil ID to a new file.
                string path = @"C:\GenerateSlitLabelsFile\coilSlitTime.csv";
                if (slitLabels != null)
                {
                    TextWriter txt = new StreamWriter(path, true); // true means text will be appended to the file.
                    DateTime now = DateTime.Now;
                    for (int i = 0; i < slitLabels.Length; i++)
                    {
                        string[] tempArray = slitLabels[i].Split('+');
                        txt.WriteLine(tempArray[0] + "," + tempArray[1] + "," + tempArray[2] + "," + tempArray[3] + "," + tempArray[4] + "," + tempArray[5] + "," + now);
                    }
                    txt.Close();
                }
            }
        }

        private bool canPressButton()
        {
            if (TypeText.Text.ToUpper() == "SM")
                return slitLabels != null && TypeText.Text != "" && ColorText.Text != "" && GaugeText.Text != "" && Int32.TryParse(WeightText.Text, out WEIGHT) && Int32.TryParse(WidthText.Text, out WIDTH) && SMFrontColorText.Text != "" && SMBackColorText.Text != "";
            else return slitLabels != null && TypeText.Text != "" && ColorText.Text != "" && GaugeText.Text != "" && Int32.TryParse(WeightText.Text, out WEIGHT) && Int32.TryParse(WidthText.Text, out WIDTH);
        }

        private void canCreateLabel()
        {
            if (TypeText.Text != "" && ColorText.Text != "" && GaugeText.Text != "" && Int32.TryParse(WeightText.Text, out WEIGHT) && Int32.TryParse(WidthText.Text, out WIDTH))
            {
                if (TypeText.Text.ToUpper() == "SM" && (SMFrontColorText.Text == "" || SMBackColorText.Text == ""))
                {
                    ErrMsg.Text = "Please enter front or back color.";
                }
                //else if (textBox1.Text.Length < 9) ErrMsg.Text = "Please enter correct Coil ID.";
                else
                {
                    COILID = textBox1.Text.Split('+','_')[0];
                    ErrMsg.Text = "";
                    createLabels();
                }
            }
            else ErrMsg.Text = "Please fill the correct information.";
        }

        public void Printing(string printer, int numberOfCopy)
        {

            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                //pd.PrinterSettings.PrinterName = printer;
                pd.PrinterSettings.Copies = (short)numberOfCopy; // set number of copies for each page
                if (pd.PrinterSettings.IsValid)
                {
                    textBox1.Text = "";
                    pd.Print();
                }
                else
                {
                    MessageBox.Show("Printer is invalid.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            while (pageNumber < slitLabels.Length)
            {
                Graphics g = e.Graphics;

                CodeQrBarcodeDraw QRcode = BarcodeDrawFactory.CodeQr; // to generate QR code
                System.Drawing.Image QRcodeImage = QRcode.Draw(slitLabels[pageNumber], 100);
                // RectangleF(The coordinates of the upper-left corner of the rectangle, width, height)
                RectangleF QRcodeRect = new RectangleF(20.0F, 40.0F, 150.0F, 150.0F);
                g.DrawImage(QRcodeImage, QRcodeRect);

                BarcodeDraw bdraw = BarcodeDrawFactory.GetSymbology(BarcodeSymbology.Code128);
                System.Drawing.Image barcodeImage = bdraw.Draw(slitLabels[pageNumber], 100);
                RectangleF barcodeRect = new RectangleF(350.0F, 60.0F, 430.0F, 110.0F);
                g.DrawImage(barcodeImage, barcodeRect);

                // Create string to draw.
                String drawString = slitLabels[pageNumber].ToUpper();

                // center the text in a specified rectangle.
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                SolidBrush drawBrush;

                // Back color
                if (TYPE.ToUpper() == "SM")
                {
                    COLOR = SMFrontColorText.Text;
                    drawBrush = new SolidBrush(Color.White);
                    System.Drawing.Font colorFont2 = new System.Drawing.Font("Ariel", 40, FontStyle.Bold);
                    g.FillRectangle(new SolidBrush(Color.Black), 170, 125, 170, 60);

                    RectangleF colorRect2 = new RectangleF(160.0F, 120.0F, 180.0F, 80.0F);
                    g.DrawString(SMBackColorText.Text.ToUpper(), colorFont2, drawBrush, colorRect2, sf);
                }

                // front color
                drawBrush = new SolidBrush(Color.Black);

                System.Drawing.Font colorFont = new System.Drawing.Font("Arial Black", 50, FontStyle.Bold);
                RectangleF colorRect = new RectangleF(150.0F, 40.0F, 220.0F, 80.0F);
                g.DrawString(COLOR.ToUpper(), colorFont, drawBrush, colorRect, sf);

                // type
                System.Drawing.Font typeFont = new System.Drawing.Font("Ariel", 30, FontStyle.Bold);
                RectangleF typeRect = new RectangleF(400.0F, 15.0F, 100.0F, 60.0F);
                g.DrawString(TYPE.ToUpper(), typeFont, drawBrush, typeRect, sf);

                // date
                string month_year = DateTime.Now.ToString("MMM").ToUpper() + "_" + DateTime.Now.ToString("yy");
                System.Drawing.Font timeFont = new System.Drawing.Font("Ariel", 20, FontStyle.Bold);
                RectangleF timeRect = new RectangleF(550.0F, 15.0F, 150.0F, 60.0F);
                g.DrawString(month_year, timeFont, drawBrush, timeRect, sf);

                // width
                string width = slitLabels[pageNumber].Split('+')[5];
                System.Drawing.Font widthFont = new System.Drawing.Font("Ariel", 30, FontStyle.Bold);
                RectangleF widthRect = new RectangleF(700.0F, 15.0F, 100.0F, 60.0F);
                g.DrawString(width, widthFont, drawBrush, widthRect, sf);

                // Coil ID
                System.Drawing.Font drawFont = new System.Drawing.Font("Ariel", 16);

                // Create point for upper-left corner of drawing.
                float x = 345.0F;
                float y = 170.0F;
                g.DrawString(drawString, drawFont, drawBrush, x, y);

                if (TYPE.ToUpper() == "SM") pageNumber++;
                else pageNumber += 2;

                if (pageNumber < slitLabels.Length)
                {
                    e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                }
                return;
            }
        }

        public void weightOverride()
        {
            // overwrite the weights from datatable to labels
            string[] tempLabelArray;
            if (TYPE.ToUpper() == "SM")
            {
                for (int j = 0; j < slitLabels.Length; j++)
                {
                    string tempLabel = "";

                    tempLabelArray = slitLabels[j].Split('+');
                    tempLabelArray[3] = dataGridView1.Rows[j].Cells[1].Value.ToString();
                    for (int i = 0; i < tempLabelArray.Length; i++)
                    {
                        if (i == tempLabelArray.Length - 1) tempLabel = tempLabel + tempLabelArray[i];
                        else tempLabel = tempLabel + tempLabelArray[i] + "+";
                    }
                    slitLabels[j] = tempLabel;
                }
            }
            else
            {
                for (int j = 0; j < slitLabels.Length; j = j + 2)
                {
                    string tempLabel = "";

                    tempLabelArray = slitLabels[j].Split('+');
                    tempLabelArray[3] = dataGridView1.Rows[j/2].Cells[1].Value.ToString();
                    for (int i = 0; i < tempLabelArray.Length; i++)
                    {
                        if (i == tempLabelArray.Length - 1) tempLabel = tempLabel + tempLabelArray[i];
                        else tempLabel = tempLabel + tempLabelArray[i] + "+";
                    }
                    slitLabels[j] = tempLabel;
                }
            }
        }

        // for auto changing weights
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string changedValue;
            if (labelCreatedFlag == 1 && e.ColumnIndex == 1)
            {
                changedValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (TypeText.Text.ToUpper() != "SM")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Cells[e.ColumnIndex].Value = changedValue;
                    }
                }
                else
                {
                    if (e.RowIndex < Int32.Parse(width51Qty.Text))
                    {
                        for(int i = 0; i < Int32.Parse(width51Qty.Text); i++)
                        {
                            dataGridView1.Rows[i].Cells[e.ColumnIndex].Value = changedValue;
                        }
                    }
                    else if (e.RowIndex < Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text))
                    {
                        for (int i = Int32.Parse(width51Qty.Text); i < Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text); i++)
                        {
                            dataGridView1.Rows[i].Cells[e.ColumnIndex].Value = changedValue;
                        }
                    }
                    else if (e.RowIndex < Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text))
                    {
                        for (int i = Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text); i < Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text); i++)
                        {
                            dataGridView1.Rows[i].Cells[e.ColumnIndex].Value = changedValue;
                        }
                    }
                    else if (e.RowIndex < Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text) + Int32.Parse(width92Qty.Text))
                    {
                        for (int i = Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text); i < Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text) + Int32.Parse(width92Qty.Text); i++)
                        {
                            dataGridView1.Rows[i].Cells[e.ColumnIndex].Value = changedValue;
                        }
                    }
                    else if (e.RowIndex < Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text) + Int32.Parse(width92Qty.Text) + Int32.Parse(width108Qty.Text))
                    {
                        for (int i = Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text) + Int32.Parse(width92Qty.Text); i < Int32.Parse(width51Qty.Text) + Int32.Parse(width67Qty.Text) + Int32.Parse(width83Qty.Text) + Int32.Parse(width92Qty.Text) + Int32.Parse(width108Qty.Text); i++)
                        {
                            dataGridView1.Rows[i].Cells[e.ColumnIndex].Value = changedValue;
                        }
                    }
                }
            }
        }
    }
}
