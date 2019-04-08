using System;
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
        PaperSize paperSize = new PaperSize("papersize", 800, 250); //set the paper size

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
            if (textBox2.Text == "") textBox2.Text = "0";
            if (int.TryParse(textBox2.Text, out placeHolder))
            {
                canCreateLabel();
            }
            else ErrMsg.Text = "width can only be numbers";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int placeHolder;
            if (textBox3.Text == "") textBox3.Text = "0";
            if (int.TryParse(textBox3.Text, out placeHolder))
            {
                canCreateLabel();
            }
            else ErrMsg.Text = "width can only be numbers";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int placeHolder;
            if (textBox4.Text == "") textBox4.Text = "0";
            if (int.TryParse(textBox4.Text, out placeHolder))
            {
                canCreateLabel();
            }
            else ErrMsg.Text = "width can only be numbers";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int placeHolder;
            if (textBox5.Text == "") textBox5.Text = "0";
            if (int.TryParse(textBox5.Text, out placeHolder))
            {
                canCreateLabel();
            }
            else ErrMsg.Text = "width can only be numbers";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int placeHolder;
            if (textBox6.Text == "") textBox6.Text = "0";
            if (int.TryParse(textBox6.Text, out placeHolder))
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
                dataGridView1.Rows.Clear();
                ErrMsg.Text = "";
                textBox2.Text = "2";
                textBox2.Text = "4";
                textBox2.Text = "3";
                textBox2.Text = "2";
                textBox2.Text = "2";
                slitLabels = null;

                if (textBox1.Text.Length < 9)
                {
                    ErrMsg.Text = "Please enter correct COIL ID.";
                    return;
                }

                COILID = textBox1.Text.Substring(0, 9);

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
                                textBox1.Text = "";

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
                slitNumber = Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text) + Int32.Parse(textBox6.Text);
                slitLabels = new string[slitNumber];
                for (int i = 0; i < slitNumber; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = COILID + "_" + (i + 1);
                }

                // fill in label information for each diffferent width
                for (int i = 1; i < Int32.Parse(textBox2.Text) + 1; i++)
                {
                    slitWidth = 51;
                    slitLabels[i - 1] = COILID + "_" + i + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                    dataGridView1.Rows[i - 1].Cells[1].Value = (int)(WEIGHT / WIDTH * slitWidth);
                }

                for (int i = 1; i < Int32.Parse(textBox3.Text) + 1; i++)
                {
                    slitWidth = 67;
                    slitLabels[i - 1 + Int32.Parse(textBox2.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                    dataGridView1.Rows[i - 1 + Int32.Parse(textBox2.Text)].Cells[1].Value = (int)(WEIGHT / WIDTH * slitWidth);
                }

                for (int i = 1; i < Int32.Parse(textBox4.Text) + 1; i++)
                {
                    slitWidth = 83;
                    slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                    dataGridView1.Rows[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)].Cells[1].Value = (int)(WEIGHT / WIDTH * slitWidth);
                }

                for (int i = 1; i < Int32.Parse(textBox5.Text) + 1; i++)
                {
                    slitWidth = 92;
                    slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                    dataGridView1.Rows[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)].Cells[1].Value = (int)(WEIGHT / WIDTH * slitWidth);
                }

                for (int i = 1; i < Int32.Parse(textBox6.Text) + 1; i++)
                {
                    slitWidth = 108;
                    slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                    dataGridView1.Rows[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)].Cells[1].Value = (int)(WEIGHT / WIDTH * slitWidth);
                }
            }
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
                weightOverride();

                if (slitLabels != null)
                {
                    int numberOfCopy = 2;
                    if (TYPE.ToUpper() == "SM") numberOfCopy = 1;
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
                    txt.WriteLine(COILID + "," + now);
                    txt.Close();
                }
            }
        }

        private bool canPressButton()
        {
            return slitLabels != null && TypeText.Text != "" && ColorText.Text != "" && GaugeText.Text != "" && Int32.TryParse(WeightText.Text, out WEIGHT) && Int32.TryParse(WidthText.Text, out WIDTH);
        }

        private void canCreateLabel()
        {
            if (textBox1.Text != "" && TypeText.Text != "" && ColorText.Text != "" && GaugeText.Text != "" && Int32.TryParse(WeightText.Text, out WEIGHT) && Int32.TryParse(WidthText.Text, out WIDTH))
            {
                if (TypeText.Text.ToUpper() == "SM" && (SMFrontColorText.Text == "" || SMBackColorText.Text == ""))
                {
                    ErrMsg.Text = "Please enter front or back color.";
                }
                else if (textBox1.Text.Length < 9) ErrMsg.Text = "Please enter correct Coil ID.";
                else
                {
                    COILID = textBox1.Text.Substring(0, 9);
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
                pd.PrinterSettings.PrinterName = printer;
                pd.PrinterSettings.Copies = (short)numberOfCopy; // set number of copies for each page
                if (pd.PrinterSettings.IsValid)
                {
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
                    g.FillRectangle(new SolidBrush(Color.Black), 190, 125, 130, 60);

                    RectangleF colorRect2 = new RectangleF(180.0F, 120.0F, 150.0F, 80.0F);
                    g.DrawString(SMBackColorText.Text.ToUpper(), colorFont2, drawBrush, colorRect2, sf);
                }

                // front color
                drawBrush = new SolidBrush(Color.Black);

                System.Drawing.Font colorFont = new System.Drawing.Font("Arial Black", 50, FontStyle.Bold);
                RectangleF colorRect = new RectangleF(150.0F, 40.0F, 210.0F, 80.0F);
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
    }
}
