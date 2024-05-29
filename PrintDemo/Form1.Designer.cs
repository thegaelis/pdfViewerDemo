namespace PrintDemo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnSelection = new Button();
            label2 = new Label();
            btnPrint = new Button();
            pdfView = new Microsoft.Web.WebView2.WinForms.WebView2();
            printProgressBar = new ProgressBar();
            lblProgress = new Label();
            comboBoxPrinters = new ComboBox();
            label3 = new Label();
            comboBoxPGSize = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            comboBoxOrientation = new ComboBox();
            label6 = new Label();
            numCopies = new NumericUpDown();
            label7 = new Label();
            comboBoxMargin = new ComboBox();
            label8 = new Label();
            comboBoxSide = new ComboBox();
            txtCustomWidth = new TextBox();
            txtCustomHeight = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtDPI = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pdfView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCopies).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.8301888F);
            label1.Location = new Point(74, 67);
            label1.Name = "label1";
            label1.Size = new Size(272, 42);
            label1.TabIndex = 0;
            label1.Text = "Print Dialog Demo";
            // 
            // btnSelection
            // 
            btnSelection.AutoSize = true;
            btnSelection.Font = new Font("Segoe UI", 15.8301888F);
            btnSelection.ForeColor = Color.Black;
            btnSelection.Location = new Point(99, 200);
            btnSelection.Name = "btnSelection";
            btnSelection.Size = new Size(218, 50);
            btnSelection.TabIndex = 1;
            btnSelection.Text = "Choose File";
            btnSelection.UseVisualStyleBackColor = true;
            btnSelection.Click += btnSelection_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12.8301888F);
            label2.Location = new Point(74, 120);
            label2.Name = "label2";
            label2.Size = new Size(265, 25);
            label2.TabIndex = 2;
            label2.Text = "Choose PDF/Word File to view";
            // 
            // btnPrint
            // 
            btnPrint.Font = new Font("Segoe UI", 15.8301888F);
            btnPrint.Location = new Point(99, 799);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(218, 50);
            btnPrint.TabIndex = 6;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // pdfView
            // 
            pdfView.AllowExternalDrop = true;
            pdfView.CreationProperties = null;
            pdfView.DefaultBackgroundColor = Color.White;
            pdfView.Location = new Point(421, 6);
            pdfView.Name = "pdfView";
            pdfView.Size = new Size(831, 926);
            pdfView.TabIndex = 11;
            pdfView.ZoomFactor = 1D;
            // 
            // printProgressBar
            // 
            printProgressBar.Location = new Point(174, 871);
            printProgressBar.Name = "printProgressBar";
            printProgressBar.Size = new Size(216, 25);
            printProgressBar.TabIndex = 13;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Segoe UI", 11.8301888F);
            lblProgress.Location = new Point(30, 871);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(122, 25);
            lblProgress.TabIndex = 14;
            lblProgress.Text = "Print Progress";
            // 
            // comboBoxPrinters
            // 
            comboBoxPrinters.FormattingEnabled = true;
            comboBoxPrinters.Location = new Point(159, 364);
            comboBoxPrinters.Name = "comboBoxPrinters";
            comboBoxPrinters.Size = new Size(231, 25);
            comboBoxPrinters.TabIndex = 15;
            comboBoxPrinters.SelectedIndexChanged += comboBoxPrinters_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12.8301888F);
            label3.Location = new Point(30, 364);
            label3.Name = "label3";
            label3.Size = new Size(77, 25);
            label3.TabIndex = 16;
            label3.Text = "Printers";
            // 
            // comboBoxPGSize
            // 
            comboBoxPGSize.FormattingEnabled = true;
            comboBoxPGSize.Location = new Point(159, 465);
            comboBoxPGSize.Name = "comboBoxPGSize";
            comboBoxPGSize.Size = new Size(231, 25);
            comboBoxPGSize.TabIndex = 17;
            comboBoxPGSize.SelectedIndexChanged += comboBoxPGSize_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12.8301888F);
            label4.Location = new Point(30, 465);
            label4.Name = "label4";
            label4.Size = new Size(92, 25);
            label4.TabIndex = 18;
            label4.Text = "Page Size";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12.8301888F);
            label5.Location = new Point(30, 511);
            label5.Name = "label5";
            label5.Size = new Size(108, 25);
            label5.TabIndex = 20;
            label5.Text = "Orientation";
            // 
            // comboBoxOrientation
            // 
            comboBoxOrientation.FormattingEnabled = true;
            comboBoxOrientation.Location = new Point(159, 511);
            comboBoxOrientation.Name = "comboBoxOrientation";
            comboBoxOrientation.Size = new Size(231, 25);
            comboBoxOrientation.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12.8301888F);
            label6.Location = new Point(30, 302);
            label6.Name = "label6";
            label6.Size = new Size(165, 25);
            label6.TabIndex = 21;
            label6.Text = "Number of Copies";
            // 
            // numCopies
            // 
            numCopies.Location = new Point(258, 302);
            numCopies.Name = "numCopies";
            numCopies.Size = new Size(132, 25);
            numCopies.TabIndex = 22;
            numCopies.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12.8301888F);
            label7.Location = new Point(30, 559);
            label7.Name = "label7";
            label7.Size = new Size(73, 25);
            label7.TabIndex = 24;
            label7.Text = "Margin";
            // 
            // comboBoxMargin
            // 
            comboBoxMargin.FormattingEnabled = true;
            comboBoxMargin.Location = new Point(159, 559);
            comboBoxMargin.Name = "comboBoxMargin";
            comboBoxMargin.Size = new Size(231, 25);
            comboBoxMargin.TabIndex = 23;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12.8301888F);
            label8.Location = new Point(30, 604);
            label8.Name = "label8";
            label8.Size = new Size(120, 25);
            label8.TabIndex = 26;
            label8.Text = "Side Printing";
            // 
            // comboBoxSide
            // 
            comboBoxSide.FormattingEnabled = true;
            comboBoxSide.Location = new Point(159, 604);
            comboBoxSide.Name = "comboBoxSide";
            comboBoxSide.Size = new Size(231, 25);
            comboBoxSide.TabIndex = 25;
            // 
            // txtCustomWidth
            // 
            txtCustomWidth.Location = new Point(218, 661);
            txtCustomWidth.Name = "txtCustomWidth";
            txtCustomWidth.Size = new Size(172, 25);
            txtCustomWidth.TabIndex = 27;
            // 
            // txtCustomHeight
            // 
            txtCustomHeight.Location = new Point(218, 713);
            txtCustomHeight.Name = "txtCustomHeight";
            txtCustomHeight.Size = new Size(172, 25);
            txtCustomHeight.TabIndex = 28;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12.8301888F);
            label9.Location = new Point(30, 661);
            label9.Name = "label9";
            label9.Size = new Size(132, 25);
            label9.TabIndex = 29;
            label9.Text = "Custom Width";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12.8301888F);
            label10.Location = new Point(32, 713);
            label10.Name = "label10";
            label10.Size = new Size(137, 25);
            label10.TabIndex = 30;
            label10.Text = "Custom Height";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12.8301888F);
            label11.Location = new Point(32, 415);
            label11.Name = "label11";
            label11.Size = new Size(103, 25);
            label11.TabIndex = 31;
            label11.Text = "Printer DPI";
            // 
            // txtDPI
            // 
            txtDPI.Location = new Point(159, 415);
            txtDPI.Name = "txtDPI";
            txtDPI.Size = new Size(231, 25);
            txtDPI.TabIndex = 32;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 929);
            Controls.Add(txtDPI);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(txtCustomHeight);
            Controls.Add(txtCustomWidth);
            Controls.Add(label8);
            Controls.Add(comboBoxSide);
            Controls.Add(label7);
            Controls.Add(comboBoxMargin);
            Controls.Add(numCopies);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboBoxOrientation);
            Controls.Add(label4);
            Controls.Add(comboBoxPGSize);
            Controls.Add(label3);
            Controls.Add(comboBoxPrinters);
            Controls.Add(lblProgress);
            Controls.Add(printProgressBar);
            Controls.Add(pdfView);
            Controls.Add(label1);
            Controls.Add(btnPrint);
            Controls.Add(label2);
            Controls.Add(btnSelection);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pdfView).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCopies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSelection;
        private Label label2;
        private Button btnPrint;
        private Microsoft.Web.WebView2.WinForms.WebView2 pdfView;
        private ProgressBar printProgressBar;
        private Label lblProgress;
        private ComboBox comboBoxPrinters;
        private Label label3;
        private ComboBox comboBoxPGSize;
        private Label label4;
        private Label label5;
        private ComboBox comboBoxOrientation;
        private Label label6;
        private NumericUpDown numCopies;
        private Label label7;
        private ComboBox comboBoxMargin;
        private Label label8;
        private ComboBox comboBoxSide;
        private TextBox txtCustomWidth;
        private TextBox txtCustomHeight;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtDPI;
    }
}
