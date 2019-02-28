﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;

namespace GenerateSlitLabel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] slitIDs;
        string[] slitLabels;
        string color;
        string type;
        int pageNumber = 0;
        PaperSize paperSize = new PaperSize("papersize", 800, 300);//set the paper size

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            while (pageNumber < slitLabels.Length)
            {
                Graphics g = e.Graphics;

                CodeQrBarcodeDraw QRcode = BarcodeDrawFactory.CodeQr; // to generate QR code
                System.Drawing.Image QRcodeImage = QRcode.Draw(textBox1.Text, 100);
                // RectangleF(The coordinates of the upper-left corner of the rectangle, width, height)
                RectangleF QRcodeRect = new RectangleF(20.0F, 40.0F, 150.0F, 150.0F);
                g.DrawImage(QRcodeImage, QRcodeRect);

                BarcodeDraw bdraw = BarcodeDrawFactory.GetSymbology(BarcodeSymbology.Code128);
                System.Drawing.Image barcodeImage = bdraw.Draw(textBox1.Text, 100);
                RectangleF barcodeRect = new RectangleF(350.0F, 40.0F, 430.0F, 110.0F);
                g.DrawImage(barcodeImage, barcodeRect);

                // Create string to draw.
                String drawString = textBox1.Text;

                // Create font and brush.
                System.Drawing.Font colorFont = new System.Drawing.Font("Ariel", 40, FontStyle.Bold);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                float x = 160.0F;
                float y = 50.0F;
                g.DrawString(color, colorFont, drawBrush, x, y);

                System.Drawing.Font typeFont = new System.Drawing.Font("Ariel", 30, FontStyle.Bold);
                x = 170.0F;
                y = 120.0F;
                g.DrawString(type, typeFont, drawBrush, x, y);

                System.Drawing.Font drawFont = new System.Drawing.Font("Ariel", 16);

                // Create point for upper-left corner of drawing.
                x = 360.0F;
                y = 150.0F;
                g.DrawString(drawString, drawFont, drawBrush, x, y);
                pageNumber++;
                e.HasMorePages = true; //e.HasMorePages raised the PrintPage event once per page .
                return;
            }
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            char[] delimiters = { ' ', '+' };
            string COILID, TYPE = "", COLOR, GAUGE, WIDTH;
            int WEIGHT, slitNumber = 0, slitWidth = 0;
            if (textBox1.Text.Length < 9)
            {
                ErrMsg.Text = "Please enter correct COIL ID.";
                return;
            }

            COILID = textBox1.Text.Substring(0, 9);

            if ((System.IO.File.Exists(@"C:\FEB_19(A).csv")) == true)
            {
                foreach (string line in System.IO.File.ReadLines(@"C:\FEB_19(A).csv"))
                {
                    if (COILID.Equals(line.Substring(0,9)))
                    {
                        try
                        {
                            string[] inputArray = line.Split(delimiters); // split the input string by using the delimiter '+'

                            COILID = inputArray[0];
                            TYPE = inputArray[1];
                            COLOR = inputArray[2];
                            WEIGHT = Int32.Parse(inputArray[3]);
                            GAUGE = inputArray[4];
                            WIDTH = inputArray[5];
                            color = COLOR;
                            type = TYPE;
                        }
                        catch (Exception ex)
                        {
                            ErrMsg.Text = "Input format is not corrent!";
                            COILID = null;
                            TYPE = null;
                            COLOR = null;
                            WEIGHT = 0;
                            GAUGE = null;
                            WIDTH = null;
                            return;
                        }

                        switch (TYPE)
                        {
                            case "RA":
                                slitNumber = 6;
                                slitWidth = 170;
                                break;
                            case "SM":
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
                            default:
                                ErrMsg.Text = "Type not exist.";
                                break;
                        }

                        if (slitNumber > 0)
                        {
                            slitIDs = new string[slitNumber];
                            slitLabels = new string[slitNumber];
                            for (int i = 1; i < slitIDs.Length + 1; i++)
                            {
                                slitIDs[i - 1] = COILID + "_" + i;
                                slitLabels[i - 1] = COILID + "_" + i + "+" + TYPE + "+" + COLOR + "+" + (int)(WEIGHT / slitNumber) + "+" + GAUGE + "+" + slitWidth;
                            }
                            printDocument1.DefaultPageSettings.PaperSize = paperSize;
                            printPreviewDialog1.ShowDialog();
                        }
                    }
                }
            }
        
        }

        public void Printing(string printer)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                pd.PrinterSettings.PrinterName = printer;
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
            if (textBox1.Text != "" && color != null)
            {
                ErrMsg.Text = "";
                string printer = "ZDesigner S4M-203dpi ZPL";
                Printing(printer);
            }
            else
            {
                ErrMsg.Text = "Please Scan an ID.";
                ErrMsg.ForeColor = Color.Red;
                ErrMsg.Font = new System.Drawing.Font("Ariel", 20);
            }
        }
    }
}