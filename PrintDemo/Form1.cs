using System;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using PdfiumViewer;

namespace PrintDemo
{
    public partial class Form1 : Form
    {
        private string filePath = ""; // File path of the PDF file

        public Form1()
        {
            InitializeComponent();
        }
        //Initialize Form
        private async void Form1_Load(object sender, EventArgs e)
        {
            numCopies.Minimum = 1;
            disablePrint();
            HideProgressBar();

            // Ensure WebView2 environment is initialized
            await pdfView.EnsureCoreWebView2Async(null);

            // Hide some toolbar options of WebView2's PDF reader
            pdfView.CoreWebView2.Settings.HiddenPdfToolbarItems =
                CoreWebView2PdfToolbarItems.Print |
                CoreWebView2PdfToolbarItems.Save |
                CoreWebView2PdfToolbarItems.SaveAs |
                CoreWebView2PdfToolbarItems.MoreSettings;

            LoadInstalledPrinters();
            LoadPageSizes();
            LoadOrientations();
            LoadPageMargins();
            LoadPrintSides();
        }
        //Handle button logic when click
        //Button Selection
        private async void btnSelection_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                string fileExtension = Path.GetExtension(filePath).ToLower();

                if (fileExtension == ".pdf")
                {
                    string pdfPath = $"file:///{filePath}";
                    pdfView.Source = new Uri(pdfPath);
                    enablePrint();
                }
                else
                {
                    MessageBox.Show(
                        "The file is invalid, please try again",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    filePath = "";
                }
            }
        }
        //Button Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (comboBoxPrinters.SelectedItem != null)
            {
                PrintPdf(filePath, comboBoxPrinters.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Please select a printer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Print function
        private void PrintPdf(string filePath, string printerName)
        {
            try
            {
                using (PdfDocument document = PdfDocument.Load(filePath))
                {
                    int totalPages = document.PageCount;
                    int currentPage = 0;

                    PrintDocument printDocument = document.CreatePrintDocument();

                    printDocument.PrinterSettings.PrinterName = printerName;
                    printDocument.PrinterSettings.Copies = (short)numCopies.Value;
                    printDocument.DefaultPageSettings.Landscape = GetSelectedOrientation();
                    printDocument.DefaultPageSettings.PaperSize = GetSelectedPageSize();
                    printDocument.DefaultPageSettings.Margins = GetSelectedPageMargins();

                    // Set print side option
                    printDocument.PrinterSettings.Duplex = GetSelectedPrintSide();

                    ShowProgressBar();

                    // Subscribe to the PrintPage event to track printing progress and page number
                    printDocument.PrintPage += (sender, e) =>
                    {
                        currentPage++;
                        double progress = (double)currentPage / totalPages * 100;
                        UpdateProgressBar(progress);
                    };

                    // Print directly without showing the print dialog
                    printDocument.Print();

                    MessageBox.Show("Print succeeded", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    HideProgressBar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while printing PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Get properties
        private PaperSize GetSelectedPageSize()
        {
            switch (comboBoxPGSize.SelectedItem.ToString())
            {
                case "A4":
                    return new PaperSize("A4", 827, 1169);
                case "A3":
                    return new PaperSize("A3", 1169, 1654);
                case "Letter":
                    return new PaperSize("Letter", 850, 1100);
                case "Legal":
                    return new PaperSize("Legal", 850, 1400);
                default:
                    return new PaperSize("A4", 827, 1169); // Default to A4 if none selected
            }
        }
        private bool GetSelectedOrientation()
        {
            return comboBoxOrientation.SelectedItem.ToString() == "Landscape";
        }

        private Duplex GetSelectedPrintSide()
        {
            return comboBoxSide.SelectedIndex == 0 ? Duplex.Simplex : Duplex.Horizontal;
        }
        private Margins GetSelectedPageMargins()
        {
            switch (comboBoxMargin.SelectedItem.ToString())
            {
                case "Narrow":
                    return new Margins(10, 10, 10, 10); // 10 points on all sides
                case "Wide":
                    return new Margins(50, 50, 50, 50); // 50 points on all sides
                default: // Normal
                    return new Margins(25, 25, 25, 25); // 25 points on all sides
            }
        }
        //Combobox content loader
        private void LoadInstalledPrinters()
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
        private void LoadPageSizes()
        {
            comboBoxPGSize.Items.Clear();
            comboBoxPGSize.Items.Add("A4");
            comboBoxPGSize.Items.Add("A3");
            comboBoxPGSize.Items.Add("Letter");
            comboBoxPGSize.Items.Add("Legal");
            comboBoxPGSize.SelectedIndex = 0; // Select the first page size by default
        }

        private void LoadOrientations()
        {
            comboBoxOrientation.Items.Clear();
            comboBoxOrientation.Items.Add("Portrait");
            comboBoxOrientation.Items.Add("Landscape");
            comboBoxOrientation.SelectedIndex = 0; // Select Portrait by default
        }

        private void LoadPageMargins()
        {
            comboBoxMargin.Items.Clear();
            comboBoxMargin.Items.Add("Normal");
            comboBoxMargin.Items.Add("Narrow");
            comboBoxMargin.Items.Add("Wide");
            comboBoxMargin.SelectedIndex = 0; // Select "Normal" by default
        }

        private void LoadPrintSides()
        {
            comboBoxSide.Items.Clear();
            comboBoxSide.Items.Add("One Side");
            comboBoxSide.Items.Add("Two Sides");
            comboBoxSide.SelectedIndex = 0; // Select "One Side" by default
        }
        //Priting Progressbar Update
        private void UpdateProgressBar(double progress)
        {
            if (progress < 0)
                progress = 0;
            else if (progress > 100)
                progress = 100;

            printProgressBar.Value = (int)progress;
        }
        //Enable-Disable Buttons
        private void disablePrint()
        {
            btnPrint.Enabled = false;
            numCopies.Enabled = false;
            comboBoxOrientation.Enabled = false;
            comboBoxPGSize.Enabled = false;
            comboBoxPrinters.Enabled = false;
            comboBoxMargin.Enabled = false;
            comboBoxSide.Enabled = false;
        }

        private void enablePrint()
        {
            btnPrint.Enabled = true;
            numCopies.Enabled = true;
            comboBoxOrientation.Enabled = true;
            comboBoxPGSize.Enabled = true;
            comboBoxPrinters.Enabled = true;
            comboBoxSide.Enabled = true;
            comboBoxMargin.Enabled = true;
        }
        //Show-hide Progressbar
        private void ShowProgressBar()
        {
            lblProgress.Visible = true;
            printProgressBar.Visible = true;
        }

        private void HideProgressBar()
        {
            lblProgress.Visible = false;
            printProgressBar.Visible = false;
        }
        

    }
}

