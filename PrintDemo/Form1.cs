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
        private PdfDocument document;

        public Form1()
        {
            InitializeComponent();
        }

        // Initialize Form
        private async void Form1_Load(object sender, EventArgs e)
        {
            numCopies.Minimum = 1;
            SetPrintControlsState(false);
            HideProgressBar();
            HideCustomSizeControls();

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

        // Handle button logic when clicked
        private async void btnSelection_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                if (Path.GetExtension(filePath).ToLower() == ".pdf")
                {
                    string pdfPath = $"file:///{filePath}";
                    pdfView.Source = new Uri(pdfPath);
                    SetPrintControlsState(true);
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

        // Button Print
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

        // Print function
        private void PrintPdf(string filePath, string printerName)
        {
            try
            {
                using (document = PdfDocument.Load(filePath))
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
                    SetPrintControlsState(false);

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
                    SetPrintControlsState(true);
                    HideProgressBar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while printing PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Get selected page size
        private PaperSize GetSelectedPageSize()
        {
            PaperSize selectedSize = null;

            switch (comboBoxPGSize.SelectedItem.ToString())
            {
                case "A4":
                    selectedSize = new PaperSize("A4", 827, 1169); // 210 mm x 297 mm converted to 1/100 inches
                    break;
                case "A3":
                    selectedSize = new PaperSize("A3", 1169, 1654); // 297 mm x 420 mm converted to 1/100 inches
                    break;
                case "Letter":
                    selectedSize = new PaperSize("Letter", 850, 1100); // 8.5 in x 11 in converted to 1/100 inches
                    break;
                case "Legal":
                    selectedSize = new PaperSize("Legal", 850, 1400); // 8.5 in x 14 in converted to 1/100 inches
                    break;
                case "Custom":
                    int width = ParseMm(Int32.Parse(txtCustomWidth.Text));
                    int height = ParseMm(Int32.Parse(txtCustomHeight.Text));
                    selectedSize = new PaperSize("Custom", width, height);
                    break;
                default:
                    selectedSize = new PaperSize("A4", 827, 1169); // Default to A4 if none selected
                    break;
            }

            return selectedSize;
        }


        // Parse mm to points
        private int ParseMm(int mm)
        {
            double inches = mm / 25.4; // Convert mm to inches
            return (int)Math.Ceiling(inches * 100); // Convert inches to 1/100 of an inch
        }


        // Get selected orientation
        private bool GetSelectedOrientation()
        {
            return comboBoxOrientation.SelectedItem.ToString() == "Landscape";
        }

        // Get selected print side
        private Duplex GetSelectedPrintSide()
        {
            return comboBoxSide.SelectedIndex == 0 ? Duplex.Simplex : Duplex.Horizontal;
        }

        // Get selected page margins
        private Margins GetSelectedPageMargins()
        {
            return comboBoxMargin.SelectedItem.ToString() switch
            {
                "Narrow" => new Margins(10, 10, 10, 10), // 10 points on all sides
                "Wide" => new Margins(50, 50, 50, 50), // 50 points on all sides
                "No Margin" => new Margins(0, 0, 0, 0),
                _ => new Margins(25, 25, 25, 25), // Normal (25 points on all sides)
            };
        }
        // Get printer DPI
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
        private void SetPrinterDPI(int dpi)
        {
            if (comboBoxPrinters.SelectedItem == null)
            {
                MessageBox.Show("No printer selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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



        // Load installed printers
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

        // Load page sizes
        private void LoadPageSizes()
        {
            comboBoxPGSize.Items.Clear();
            comboBoxPGSize.Items.Add("A4");
            comboBoxPGSize.Items.Add("A3");
            comboBoxPGSize.Items.Add("Letter");
            comboBoxPGSize.Items.Add("Legal");
            comboBoxPGSize.Items.Add("Custom");
            comboBoxPGSize.SelectedIndex = 0; // Select the first page size by default
        }

        // Load orientations
        private void LoadOrientations()
        {
            comboBoxOrientation.Items.Clear();
            comboBoxOrientation.Items.Add("Portrait");
            comboBoxOrientation.Items.Add("Landscape");
            comboBoxOrientation.SelectedIndex = 0; // Select Portrait by default
        }

        // Load page margins
        private void LoadPageMargins()
        {
            comboBoxMargin.Items.Clear();
            comboBoxMargin.Items.Add("Normal");
            comboBoxMargin.Items.Add("Narrow");
            comboBoxMargin.Items.Add("Wide");
            comboBoxMargin.Items.Add("No Margin");
            comboBoxMargin.SelectedIndex = 0; // Select "Normal" by default
        }

        // Load print sides
        private void LoadPrintSides()
        {
            comboBoxSide.Items.Clear();
            comboBoxSide.Items.Add("One Side");
            comboBoxSide.Items.Add("Two Sides");
            comboBoxSide.SelectedIndex = 0; // Select "One Side" by default
        }

        // Update the progress bar during printing
        private void UpdateProgressBar(double progress)
        {
            progress = Math.Clamp(progress, 0, 100);
            printProgressBar.Value = (int)progress;
        }

        // Set print controls state
        private void SetPrintControlsState(bool isEnabled)
        {
            btnPrint.Enabled = isEnabled;
            numCopies.Enabled = isEnabled;
            comboBoxOrientation.Enabled = isEnabled;
            comboBoxPGSize.Enabled = isEnabled;
            comboBoxPrinters.Enabled = isEnabled;
            comboBoxMargin.Enabled = isEnabled;
            comboBoxSide.Enabled = isEnabled;
            txtDPI.Enabled = isEnabled;
            txtCustomHeight.Enabled = isEnabled;
            txtCustomWidth.Enabled = isEnabled;
        }

        // Hide custom size controls
        private void HideCustomSizeControls()
        {
            label9.Visible = false;
            txtCustomWidth.Visible = false;
            label10.Visible = false;
            txtCustomHeight.Visible = false;
        }

        // Show custom size controls
        private void ShowCustomSizeControls()
        {
            label9.Visible = true;
            txtCustomWidth.Visible = true;
            label10.Visible = true;
            txtCustomHeight.Visible = true;
        }

        // Show the progress bar
        private void ShowProgressBar()
        {
            lblProgress.Visible = true;
            printProgressBar.Visible = true;
        }

        // Hide the progress bar
        private void HideProgressBar()
        {
            lblProgress.Visible = false;
            printProgressBar.Visible = false;
        }

        // Handle page size selection change
        private void comboBoxPGSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPGSize.SelectedItem.ToString() == "Custom")
            {
                ShowCustomSizeControls();
            }
            else
            {
                HideCustomSizeControls();
            }
        }

        private void comboBoxPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            int dpi = GetPrinterDPI();
            if (dpi != -1) // Check if a valid DPI was returned
            {
                txtDPI.Text = dpi.ToString();
            }
        }

        private void txtDPI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the beep sound on Enter key press

                if (int.TryParse(txtDPI.Text, out int dpi))
                {
                    SetPrinterDPI(dpi);
                }
                else
                {
                    MessageBox.Show("Please enter a valid DPI value.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
