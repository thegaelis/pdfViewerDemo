using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintDemo
{
    public partial class Form2 : Form
    {
        private string printerName = "";
        private int printSizeWidth = 830;
        private int printSizeHeight = 1170;
        //initialize form
        public Form2()
        {
            InitializeComponent();
            loadSelectedPrinter();
            loadSize();
            txtDPI.Text = GetPrinterDPI().ToString();
        }

        //button load image
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //load print diaglog
        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }


        //print page with setting
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //set active printer
            if (printerName == "")
            {
                printerName = "CutePDF Writer";
            }

            Graphics g = e.Graphics;
            Rectangle drawArea = new Rectangle(0, 0, 800, 7200);
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, drawArea);
            Rectangle rect = new Rectangle(10, 10, 780, 7180);
            Pen apen = new Pen(Color.Black, 1f);
            g.DrawRectangle(apen, rect);
            printDocument1.PrinterSettings.PrinterName = printerName;
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", printSizeWidth, printSizeHeight);

        }

        //button set printer
        private void button3_Click(object sender, EventArgs e)
        {
            printerName = getSelectedPrinter();
            txtDPI.Text = GetPrinterDPI().ToString();
            MessageBox.Show("Printer Selected", "Info", MessageBoxButtons.OK);
        }

        //get selected printer function
        private string getSelectedPrinter()
        {
            return comboBoxPrinters.SelectedIndex.ToString();
        }

        //function to load printer
        private void loadSelectedPrinter()
        {
            comboBoxPrinters.Items.Clear();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                comboBoxPrinters.Items.Add(printer);
            }

            if (comboBoxPrinters.Items.Count > 0)
            {
                comboBoxPrinters.SelectedIndex = 0; // Select the first printer by default
            }
        }

        //load size to textbox
        private void loadSize()
        {
            txtCustomHeight.Text = printSizeHeight.ToString();
            txtCustomWidth.Text = printSizeWidth.ToString();
        }
        
        //set custom size
        private void setSize()
        {
            printSizeHeight = Int32.Parse(txtCustomHeight.Text);
            printSizeWidth = Int32.Parse(txtCustomWidth.Text);
        }

        //button set size
        private void button4_Click(object sender, EventArgs e)
        {
            setSize();
            MessageBox.Show("Size Set", "Info", MessageBoxButtons.OK);

        }

        //get printer dpi
        private int GetPrinterDPI()
        {
            if (comboBoxPrinters.SelectedItem == null)
            {
                MessageBox.Show("No printer selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            PrinterSettings printerSettings = new PrinterSettings
            {
                PrinterName = comboBoxPrinters.SelectedItem.ToString()
            };

            return printerSettings.DefaultPageSettings.PrinterResolution.X;
        }

        //set the printer dpi function
        private void SetPrinterDPI(int dpi)
        {
            //check if the printer is null
            if (comboBoxPrinters.SelectedItem == null)
            {
                MessageBox.Show("No printer selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //load printer setting and custom the size
            PrinterSettings printerSettings = new PrinterSettings
            {
                PrinterName = comboBoxPrinters.SelectedItem.ToString()
            };

            PrinterResolution customResolution = new PrinterResolution
            {
                Kind = PrinterResolutionKind.Custom,
                X = dpi,
                Y = dpi
            };


            //check if the entered dpi is supported
            bool resolutionSupported = false;
            foreach (PrinterResolution resolution in printerSettings.PrinterResolutions)
            {
                if (resolution.Kind == PrinterResolutionKind.Custom &&
                    resolution.X == dpi && resolution.Y == dpi)
                {
                    resolutionSupported = true;
                    break;
                }
            }

            if (resolutionSupported)
            {
                printerSettings.DefaultPageSettings.PrinterResolution = customResolution;
                MessageBox.Show($"DPI set to {dpi}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"The specified DPI ({dpi}) is not supported by the selected printer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //button to call set the printer's dpi function
        private void button5_Click(object sender, EventArgs e)
        {
            int dpi = Int32.Parse(txtDPI.Text);
            SetPrinterDPI(dpi);
        }
    }
}
