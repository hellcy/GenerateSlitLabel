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
            int rowIndex = dataGridView1.Rows.Add();
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            row.Cells[0].Value = 1;
            row.Cells[1].Value = 2;
        }

        string[] slitLabels;
        string color, front_color, back_color;
        string COILID, TYPE = "", COLOR, GAUGE;
        int WEIGHT, WIDTH, slitNumber = 0, slitWidth = 0;
        string type;
        int pageNumber = 0;
        bool canPressButton = false;
        PaperSize paperSize = new PaperSize("papersize", 800, 250); //set the paper size

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
                String drawString = slitLabels[pageNumber];

                // center the text in a specified rectangle.
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                // Back color
                SolidBrush drawBrush = new SolidBrush(Color.White);
                System.Drawing.Font colorFont2 = new System.Drawing.Font("Ariel", 40, FontStyle.Bold);
                g.FillRectangle(new SolidBrush(Color.Black), 190, 125, 130, 60);

                RectangleF colorRect2 = new RectangleF(180.0F, 120.0F, 150.0F, 80.0F);
                g.DrawString(back_color, colorFont2, drawBrush, colorRect2, sf);

                // front color
                drawBrush = new SolidBrush(Color.Black);

                System.Drawing.Font colorFont = new System.Drawing.Font("Arial Black", 50, FontStyle.Bold);
                RectangleF colorRect = new RectangleF(150.0F, 40.0F, 200.0F, 80.0F);
                g.DrawString(front_color, colorFont, drawBrush, colorRect, sf);

                // type
                System.Drawing.Font typeFont = new System.Drawing.Font("Ariel", 30, FontStyle.Bold);
                RectangleF typeRect = new RectangleF(400.0F, 15.0F, 100.0F, 60.0F);
                g.DrawString(type, typeFont, drawBrush, typeRect, sf);

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

                if (type == "SM") pageNumber++;
                else pageNumber += 2;

                if (pageNumber < slitLabels.Length)
                {
                    e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                }
                return;
            }
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            if (canPressButton)
            {
                pageNumber = 0;
                printDocument1.DefaultPageSettings.PaperSize = paperSize;
                printPreviewDialog1.ShowDialog();
            }



            //// remember to set global variable pageNumber to 0 everytime you press the button. Reset the page number count.
            //pageNumber = 0;
            //ErrMsg.Text = "";
            //char[] delimiters = { ' ', ',' };
            //string COILID, TYPE = "", COLOR, GAUGE;
            //int WEIGHT, WIDTH, slitNumber = 0, slitWidth = 0;
            //if (textBox1.Text.Length < 9)
            //{
            //    ErrMsg.Text = "Please enter correct COIL ID.";
            //    return;
            //}

            //COILID = textBox1.Text.Substring(0, 9);

            //if ((System.IO.File.Exists(@"C:\Coil Master.csv")) == true)
            //{
            //    foreach (string line in System.IO.File.ReadAllLines(@"C:\Coil Master.csv"))
            //    {
            //        if (COILID.Equals(line.Substring(0,9)))
            //        {
            //            try
            //            {
            //                string[] inputArray = line.Split(delimiters); // split the input string by using the delimiter ','

            //                COILID = inputArray[0];
            //                TYPE = inputArray[1];
            //                COLOR = inputArray[2];
            //                WEIGHT = Int32.Parse(inputArray[3]);
            //                GAUGE = inputArray[4];
            //                WIDTH = Int32.Parse(inputArray[5]);
            //                color = COLOR;
            //                type = TYPE;
            //                front_color = inputArray[21];
            //                back_color = inputArray[22];
            //            }
            //            catch (Exception ex)
            //            {
            //                COILID = null;
            //                TYPE = null;
            //                COLOR = null;
            //                WEIGHT = 0;
            //                GAUGE = null;
            //                WIDTH = 0;
            //                front_color = null;
            //                back_color = null;
            //                ErrMsg.Text = "Data format is not correct, check Coil Master file.";
            //                return;
            //            }

            //            switch (TYPE)
            //            {
            //                case "RA":
            //                    slitNumber = 6;
            //                    slitWidth = 170;
            //                    break;
            //                case "SM":
            //                    slitNumber = -1;
            //                    break;
            //                case "PO":
            //                    slitNumber = 8;
            //                    slitWidth = 135;
            //                    break;
            //                case "PL":
            //                    slitNumber = 4;
            //                    slitWidth = 255;
            //                    break;
            //                case "IS":
            //                    slitNumber = -2;
            //                    ErrMsg.Text = "Type 'IS' is not supported.";
            //                    break;
            //                case "LA":
            //                    slitNumber = 8;
            //                    slitWidth = 116;
            //                    break;
            //                case "GS":
            //                    slitNumber = 11;
            //                    slitWidth = 84;
            //                    break;
            //                default:
            //                    slitNumber = -2;
            //                    ErrMsg.Text = "Type not exist.";
            //                    break;
            //            }

            //            if (slitNumber > 0)
            //            {
            //                slitLabels = new string[slitNumber];
            //                for (int i = 1; i < slitLabels.Length + 1; i = i + 2)
            //                {
            //                    slitLabels[i - 1] = COILID + "_" + i + "&" + (i + 1) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / slitNumber) + "+" + GAUGE + "+" + slitWidth;
            //                }
            //                printDocument1.DefaultPageSettings.PaperSize = paperSize;
            //                printPreviewDialog1.ShowDialog();
            //                break;
            //            }

            //            // only for type SM
            //            if (slitNumber == -1)
            //            {
            //                slitNumber = Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text) + Int32.Parse(textBox6.Text);
            //                slitLabels = new string[slitNumber];

            //                // fill in label information for each diffferent width
            //                for (int i = 1; i < Int32.Parse(textBox2.Text) + 1; i++)
            //                {
            //                    slitWidth = 51;
            //                    slitLabels[i - 1] = COILID + "_" + i + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
            //                }

            //                for (int i = 1; i < Int32.Parse(textBox3.Text) + 1; i++)
            //                {
            //                    slitWidth = 67;
            //                    slitLabels[i - 1 + Int32.Parse(textBox2.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
            //                }

            //                for (int i = 1; i < Int32.Parse(textBox4.Text) + 1; i++)
            //                {
            //                    slitWidth = 83;
            //                    slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
            //                }

            //                for (int i = 1; i < Int32.Parse(textBox5.Text) + 1; i++)
            //                {
            //                    slitWidth = 92;
            //                    slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
            //                }

            //                for (int i = 1; i < Int32.Parse(textBox6.Text) + 1; i++)
            //                {
            //                    slitWidth = 108;
            //                    slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
            //                }

            //                printDocument1.DefaultPageSettings.PaperSize = paperSize;
            //                printPreviewDialog1.ShowDialog();
            //                break;
            //            }
            //            break;
            //        }
            //    }
            //    if (slitLabels == null && ErrMsg.Text == "") ErrMsg.Text = "Coil not found.";
            //}

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            canPressButton = false;
            if (e.KeyCode == Keys.Enter)
            {
                ErrMsg.Text = "";

                if (textBox1.Text.Length < 9)
                {
                    ErrMsg.Text = "Please enter correct COIL ID.";
                    return;
                }

                COILID = textBox1.Text.Substring(0, 9);

                if ((System.IO.File.Exists(@"C:\GenerateSlitLabelsFile\Coil Master.csv")) == true)
                {
                    foreach (string line in System.IO.File.ReadAllLines(@"C:\GenerateSlitLabelsFile\Coil Master.csv"))
                    {
                        if (COILID.Equals(line.Substring(0, 9)))
                        {
                            try
                            {
                                string[] inputArray = line.Split(','); // split the input string by using the delimiter ','

                                COILID = inputArray[0];
                                TYPE = inputArray[1];
                                COLOR = inputArray[2];
                                WEIGHT = Int32.Parse(inputArray[3]);
                                GAUGE = inputArray[4];
                                WIDTH = Int32.Parse(inputArray[5]);
                                color = COLOR;
                                type = TYPE;
                                front_color = inputArray[21];
                                back_color = inputArray[22];
                            }
                            catch (Exception ex)
                            {
                                COILID = null;
                                TYPE = null;
                                COLOR = null;
                                WEIGHT = 0;
                                GAUGE = null;
                                WIDTH = 0;
                                front_color = null;
                                back_color = null;
                                ErrMsg.Text = "Data format is not correct, check Coil Master file.";
                                return;
                            }

                            switch (TYPE)
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
                                    slitLabels[i - 1] = COILID + "_" + i + "&" + (i + 1) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / slitNumber) + "+" + GAUGE + "+" + slitWidth;
                                }
                                break;
                            }

                            // only for type SM
                            if (slitNumber == -1)
                            {
                                slitNumber = Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text) + Int32.Parse(textBox6.Text);
                                slitLabels = new string[slitNumber];

                                // fill in label information for each diffferent width
                                for (int i = 1; i < Int32.Parse(textBox2.Text) + 1; i++)
                                {
                                    slitWidth = 51;
                                    slitLabels[i - 1] = COILID + "_" + i + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                                }

                                for (int i = 1; i < Int32.Parse(textBox3.Text) + 1; i++)
                                {
                                    slitWidth = 67;
                                    slitLabels[i - 1 + Int32.Parse(textBox2.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                                }

                                for (int i = 1; i < Int32.Parse(textBox4.Text) + 1; i++)
                                {
                                    slitWidth = 83;
                                    slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                                }

                                for (int i = 1; i < Int32.Parse(textBox5.Text) + 1; i++)
                                {
                                    slitWidth = 92;
                                    slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                                }

                                for (int i = 1; i < Int32.Parse(textBox6.Text) + 1; i++)
                                {
                                    slitWidth = 108;
                                    slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                                }
                                break;
                            }
                            break;
                        }
                    }
                    if (slitLabels == null && ErrMsg.Text == "") ErrMsg.Text = "Coil not found.";
                    if (slitNumber == -2 && ErrMsg.Text == "") ErrMsg.Text = "Type IS is not supported.";
                }
                if (slitLabels != null) canPressButton = true;
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            //if (slitLabels != null)
            //{
            //    int numberOfCopy = 2;
            //    if (TYPE == "SM") numberOfCopy = 1;
            //    printDocument1.DefaultPageSettings.PaperSize = paperSize;
            //    ErrMsg.Text = "";
            //    string printer = "ZDesigner S4M-203dpi ZPL";
            //    Printing(printer, numberOfCopy);
            //}
            //else
            //{
            //    ErrMsg.Text = "Please Scan an ID.";
            //    ErrMsg.ForeColor = Color.Red;
            //    ErrMsg.Font = new System.Drawing.Font("Ariel", 20);
            //}

            // add timestamp and coil ID to a new file.
            string path = @"C:\GenerateSlitLabelsFile\coilSlitTime.csv";
            if (slitLabels != null)
            {
                TextWriter txt = new StreamWriter(path, true); // true means text will be appended to the file.
                DateTime now = DateTime.Now;
                txt.WriteLine(COILID + "," + now);
                txt.Close();
            }


            //// remember to set global variable pageNumber to 0 everytime you press the button. Reset the page number count.
            //pageNumber = 0;
            //ErrMsg.Text = "";
            //char[] delimiters = { ' ', ',' };
            //string COILID, TYPE = "", COLOR, GAUGE;
            //int WEIGHT, WIDTH, slitNumber = 0, slitWidth = 0;
            //if (textBox1.Text.Length < 9)
            //{
            //    ErrMsg.Text = "Please enter correct COIL ID.";
            //    return;
            //}

            //COILID = textBox1.Text.Substring(0, 9);

            //if ((System.IO.File.Exists(@"C:\Coil Master.csv")) == true)
            //{
            //    foreach (string line in System.IO.File.ReadAllLines(@"C:\Coil Master.csv"))
            //    {
            //        if (COILID.Equals(line.Substring(0, 9)))
            //        {
            //            try
            //            {
            //                string[] inputArray = line.Split(delimiters); // split the input string by using the delimiter '+'

            //                COILID = inputArray[0];
            //                TYPE = inputArray[1];
            //                COLOR = inputArray[2];
            //                WEIGHT = Int32.Parse(inputArray[3]);
            //                GAUGE = inputArray[4];
            //                WIDTH = Int32.Parse(inputArray[5]);
            //                color = COLOR;
            //                type = TYPE;
            //                front_color = inputArray[21];
            //                back_color = inputArray[22];
            //            }
            //            catch (Exception ex)
            //            {
            //                COILID = null;
            //                TYPE = null;
            //                COLOR = null;
            //                WEIGHT = 0;
            //                GAUGE = null;
            //                WIDTH = 0;
            //                front_color = null;
            //                back_color = null;
            //                ErrMsg.Text = "Data format is not correct, check Coil Master file.";
            //                return;
            //            }

            //            switch (TYPE)
            //            {
            //                case "RA":
            //                    slitNumber = 6;
            //                    slitWidth = 170;
            //                    break;
            //                case "SM":
            //                    slitNumber = -1;
            //                    break;
            //                case "PO":
            //                    slitNumber = 8;
            //                    slitWidth = 135;
            //                    break;
            //                case "PL":
            //                    slitNumber = 4;
            //                    slitWidth = 255;
            //                    break;
            //                case "LA":
            //                    slitNumber = 8;
            //                    slitWidth = 116;
            //                    break;
            //                case "GS":
            //                    slitNumber = 11;
            //                    slitWidth = 84;
            //                    break;
            //                case "IS":
            //                    slitNumber = -2;
            //                    ErrMsg.Text = "Type 'IS' is not supported.";
            //                    break;
            //                default:
            //                    slitNumber = -2;
            //                    ErrMsg.Text = "Type not exist.";
            //                    break;
            //            }

            //            if (slitNumber > 0)
            //            {
            //                slitLabels = new string[slitNumber];
            //                for (int i = 1; i < slitLabels.Length + 1; i = i + 2)
            //                {
            //                    slitLabels[i - 1] = COILID + "_" + i + "&" + (i + 1) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / slitNumber) + "+" + GAUGE + "+" + slitWidth;
            //                }
            //                break;
            //            }

            //            // only for type SM
            //            if (slitNumber == -1)
            //            {
            //                slitNumber = Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text) + Int32.Parse(textBox6.Text);
            //                slitLabels = new string[slitNumber];

            //                // fill in label information for each diffferent width
            //                for (int i = 1; i < Int32.Parse(textBox2.Text) + 1; i++)
            //                {
            //                    slitWidth = 51;
            //                    slitLabels[i - 1] = COILID + "_" + i + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
            //                }

            //                for (int i = 1; i < Int32.Parse(textBox3.Text) + 1; i++)
            //                {
            //                    slitWidth = 67;
            //                    slitLabels[i - 1 + Int32.Parse(textBox2.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
            //                }

            //                for (int i = 1; i < Int32.Parse(textBox4.Text) + 1; i++)
            //                {
            //                    slitWidth = 83;
            //                    slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
            //                }

            //                for (int i = 1; i < Int32.Parse(textBox5.Text) + 1; i++)
            //                {
            //                    slitWidth = 92;
            //                    slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
            //                }

            //                for (int i = 1; i < Int32.Parse(textBox6.Text) + 1; i++)
            //                {
            //                    slitWidth = 108;
            //                    slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
            //                }
            //                break;
            //            }
            //            break;
            //        }
            //    }
            //    if (slitLabels == null) ErrMsg.Text = "Coil not found.";
            //    if (slitNumber == -2 && ErrMsg.Text == "") ErrMsg.Text = "Type IS is not supported.";
            //}
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
    }
}
