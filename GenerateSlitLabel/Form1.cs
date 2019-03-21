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

        string[] slitIDs;
        string[] slitLabels;
        string color, front_color, back_color;
        string type;
        int pageNumber = 0;
        PaperSize paperSize = new PaperSize("papersize", 800, 250);//set the paper size

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

                //BarcodeDraw bdraw = BarcodeDrawFactory.GetSymbology(BarcodeSymbology.Code128);
                //System.Drawing.Image barcodeImage = bdraw.Draw(slitLabels[pageNumber], 100);
                //RectangleF barcodeRect = new RectangleF(350.0F, 40.0F, 430.0F, 110.0F);
                //g.DrawImage(barcodeImage, barcodeRect);

                // Create string to draw.
                String drawString = slitLabels[pageNumber];

                // center the text in a specified rectangle.
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                // Create font and brush.
                SolidBrush drawBrush = new SolidBrush(Color.White);
                System.Drawing.Font colorFont2 = new System.Drawing.Font("Ariel", 50, FontStyle.Bold);
                g.FillRectangle(new SolidBrush(Color.Black), 450, 40, 300, 80);

                RectangleF colorRect2 = new RectangleF(450.0F, 40.0F, 300.0F, 80.0F);
                g.DrawString(back_color, colorFont2, drawBrush, colorRect2, sf);

                drawBrush = new SolidBrush(Color.Black);

                System.Drawing.Font colorFont = new System.Drawing.Font("Ariel", 50, FontStyle.Bold);
                RectangleF colorRect = new RectangleF(160.0F, 40.0F, 300.0F, 80.0F);
                g.DrawString(front_color, colorFont, drawBrush, colorRect, sf);

                System.Drawing.Font typeFont = new System.Drawing.Font("Ariel", 30, FontStyle.Bold);
                RectangleF typeRect = new RectangleF(170.0F, 100.0F, 180.0F, 70.0F);
                g.DrawString(type, typeFont, drawBrush, typeRect, sf);

                string month_year = DateTime.Now.ToString("MMM").ToUpper() + "_" + DateTime.Now.ToString("yy");
                System.Drawing.Font timeFont = new System.Drawing.Font("Ariel", 20, FontStyle.Bold);
                RectangleF timeRect = new RectangleF(170.0F, 140.0F, 180.0F, 70.0F);
                g.DrawString(month_year, timeFont, drawBrush, timeRect, sf);

                System.Drawing.Font drawFont = new System.Drawing.Font("Ariel", 16);

                // Create point for upper-left corner of drawing.
                float x = 345.0F;
                float y = 160.0F;
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
            // remember to set global variable pageNumber to 0 everytime you press the button. Reset the page number count.
            pageNumber = 0;
            ErrMsg.Text = "";
            char[] delimiters = { ' ', ',' };
            string COILID, TYPE = "", COLOR, GAUGE;
            int WEIGHT, WIDTH, slitNumber = 0, slitWidth = 0;
            if (textBox1.Text.Length < 9)
            {
                ErrMsg.Text = "Please enter correct COIL ID.";
                return;
            }

            COILID = textBox1.Text.Substring(0, 9);

            if ((System.IO.File.Exists(@"C:\Coil Master.csv")) == true)
            {
                foreach (string line in System.IO.File.ReadAllLines(@"C:\Coil Master.csv"))
                {
                    if (COILID.Equals(line.Substring(0,9)))
                    {
                        try
                        {
                            string[] inputArray = line.Split(delimiters); // split the input string by using the delimiter ','

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

                        // if double colors, split them and add the third letter to each color
                        if (color.Length == 4)
                        {
                            front_color = color.Substring(0, 2);
                            back_color = color.Substring(2, 2);
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
                            //case "IS":
                            //    slitNumber = 8;
                            //    slitWidth = 116;
                            //    break;
                            case "LA":
                                slitNumber = 8;
                                slitWidth = 116;
                                break;
                            case "GS":
                                slitNumber = 11;
                                slitWidth = 84;
                                break;
                            default:
                                ErrMsg.Text = "Type not exist.";
                                break;
                        }

                        if (slitNumber > 0)
                        {
                            slitIDs = new string[slitNumber];
                            slitLabels = new string[slitNumber];
                            for (int i = 1; i < slitIDs.Length + 1; i = i + 2)
                            {
                                slitIDs[i - 1] = COILID + "_" + i;
                                slitLabels[i - 1] = COILID + "_" + i + "&" + (i + 1) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / slitNumber) + "+" + GAUGE + "+" + slitWidth;
                            }
                            printDocument1.DefaultPageSettings.PaperSize = paperSize;
                            printPreviewDialog1.ShowDialog();
                            break;
                        }

                        // only for type SM
                        if (slitNumber == -1)
                        {
                            slitNumber = Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text) + Int32.Parse(textBox6.Text);
                            slitIDs = new string[slitNumber];
                            slitLabels = new string[slitNumber];

                            // fill in label information for each diffferent width
                            for (int i = 1; i < Int32.Parse(textBox2.Text) + 1; i++)
                            {
                                slitWidth = 51;
                                slitIDs[i - 1] = COILID + "_" + i;
                                slitLabels[i - 1] = COILID + "_" + i + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                            }

                            for (int i = 1; i < Int32.Parse(textBox3.Text) + 1; i++)
                            {
                                slitWidth = 67;
                                slitIDs[i - 1 + Int32.Parse(textBox2.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text));
                                slitLabels[i - 1 + Int32.Parse(textBox2.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                            }

                            for (int i = 1; i < Int32.Parse(textBox4.Text) + 1; i++)
                            {
                                slitWidth = 83;
                                slitIDs[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text));
                                slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                            }

                            for (int i = 1; i < Int32.Parse(textBox5.Text) + 1; i++)
                            {
                                slitWidth = 92;
                                slitIDs[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text));
                                slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                            }

                            for (int i = 1; i < Int32.Parse(textBox6.Text) + 1; i++)
                            {
                                slitWidth = 108;
                                slitIDs[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text));
                                slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                            }

                            printDocument1.DefaultPageSettings.PaperSize = paperSize;
                            printPreviewDialog1.ShowDialog();
                            break;
                        }
                    }
                }
                if (slitLabels == null) ErrMsg.Text = "Coil not found.";
            }

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

        private void printBtn_Click(object sender, EventArgs e)
        {
            // remember to set global variable pageNumber to 0 everytime you press the button. Reset the page number count.
            pageNumber = 0;
            ErrMsg.Text = "";
            char[] delimiters = { ' ', ',' };
            string COILID, TYPE = "", COLOR, GAUGE;
            int WEIGHT, WIDTH, slitNumber = 0, slitWidth = 0;
            if (textBox1.Text.Length < 9)
            {
                ErrMsg.Text = "Please enter correct COIL ID.";
                return;
            }

            COILID = textBox1.Text.Substring(0, 9);

            if ((System.IO.File.Exists(@"C:\Coil Master.csv")) == true)
            {
                foreach (string line in System.IO.File.ReadAllLines(@"C:\Coil Master.csv"))
                {
                    if (COILID.Equals(line.Substring(0, 9)))
                    {
                        try
                        {
                            string[] inputArray = line.Split(delimiters); // split the input string by using the delimiter '+'

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
                            case "LA":
                                slitNumber = 8;
                                slitWidth = 116;
                                break;
                            case "GS":
                                slitNumber = 11;
                                slitWidth = 84;
                                break;
                            //case "IS":
                            //    slitNumber = 8;
                            //    slitWidth = 116;
                            //    break;
                            default:
                                ErrMsg.Text = "Type not exist.";
                                break;
                        }

                        if (slitNumber > 0)
                        {
                            slitIDs = new string[slitNumber];
                            slitLabels = new string[slitNumber];
                            for (int i = 1; i < slitIDs.Length + 1; i = i + 2)
                            {
                                slitIDs[i - 1] = COILID + "_" + i;
                                slitLabels[i - 1] = COILID + "_" + i + "&" + (i + 1) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / slitNumber) + "+" + GAUGE + "+" + slitWidth;
                            }
                            break;
                        }

                        // only for type SM
                        if (slitNumber == -1)
                        {
                            slitNumber = Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text) + Int32.Parse(textBox6.Text);
                            slitIDs = new string[slitNumber];
                            slitLabels = new string[slitNumber];

                            // fill in label information for each diffferent width
                            for (int i = 1; i < Int32.Parse(textBox2.Text) + 1; i++)
                            {
                                slitWidth = 51;
                                slitIDs[i - 1] = COILID + "_" + i;
                                slitLabels[i - 1] = COILID + "_" + i + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                            }

                            for (int i = 1; i < Int32.Parse(textBox3.Text) + 1; i++)
                            {
                                slitWidth = 67;
                                slitIDs[i - 1 + Int32.Parse(textBox2.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text));
                                slitLabels[i - 1 + Int32.Parse(textBox2.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                            }

                            for (int i = 1; i < Int32.Parse(textBox4.Text) + 1; i++)
                            {
                                slitWidth = 83;
                                slitIDs[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text));
                                slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                            }

                            for (int i = 1; i < Int32.Parse(textBox5.Text) + 1; i++)
                            {
                                slitWidth = 92;
                                slitIDs[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text));
                                slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                            }

                            for (int i = 1; i < Int32.Parse(textBox6.Text) + 1; i++)
                            {
                                slitWidth = 108;
                                slitIDs[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text));
                                slitLabels[i - 1 + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)] = COILID + "_" + (i + Int32.Parse(textBox2.Text) + Int32.Parse(textBox3.Text) + Int32.Parse(textBox4.Text) + Int32.Parse(textBox5.Text)) + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / WIDTH * slitWidth) + "+" + GAUGE + "+" + slitWidth;
                            }
                            break;
                        }
                    }
                }
                if (slitLabels == null) ErrMsg.Text = "Coil not found.";
            }
            if (slitLabels != null)
            {
                int numberOfCopy = 2;
                if (TYPE == "SM") numberOfCopy = 1;
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
            string path = @"C:\coilSlitTime.csv";
            if (COILID != "")
            {
                TextWriter txt = new StreamWriter(path, true); // true means text will be appended to the file.
                DateTime now = DateTime.Now;
                txt.WriteLine(COILID + "," + now);
                txt.Close();
            }
        }
    }
}
