namespace PrintDemo
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            button1 = new Button();
            button2 = new Button();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewControl1 = new PrintPreviewControl();
            label1 = new Label();
            button3 = new Button();
            comboBoxPrinters = new ComboBox();
            label10 = new Label();
            label9 = new Label();
            txtCustomHeight = new TextBox();
            txtCustomWidth = new TextBox();
            button4 = new Button();
            label2 = new Label();
            txtDPI = new TextBox();
            button5 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(23, 22);
            button1.Name = "button1";
            button1.Size = new Size(83, 25);
            button1.TabIndex = 0;
            button1.Text = "load image";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(21, 501);
            button2.Name = "button2";
            button2.Size = new Size(93, 45);
            button2.TabIndex = 0;
            button2.Text = "print preview";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewControl1
            // 
            printPreviewControl1.AutoZoom = false;
            printPreviewControl1.Document = printDocument1;
            printPreviewControl1.Location = new Point(303, 29);
            printPreviewControl1.Name = "printPreviewControl1";
            printPreviewControl1.Size = new Size(516, 454);
            printPreviewControl1.TabIndex = 1;
            printPreviewControl1.Zoom = 0.36818181818181817D;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 115);
            label1.Name = "label1";
            label1.Size = new Size(69, 17);
            label1.TabIndex = 2;
            label1.Text = "Set printer";
            // 
            // button3
            // 
            button3.Location = new Point(20, 453);
            button3.Name = "button3";
            button3.Size = new Size(93, 45);
            button3.TabIndex = 3;
            button3.Text = "set active printer";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBoxPrinters
            // 
            comboBoxPrinters.FormattingEnabled = true;
            comboBoxPrinters.Location = new Point(21, 147);
            comboBoxPrinters.Name = "comboBoxPrinters";
            comboBoxPrinters.Size = new Size(228, 25);
            comboBoxPrinters.TabIndex = 4;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8.830189F);
            label10.Location = new Point(23, 246);
            label10.Name = "label10";
            label10.Size = new Size(94, 17);
            label10.TabIndex = 34;
            label10.Text = "Custom Height";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 8.830189F);
            label9.Location = new Point(20, 186);
            label9.Name = "label9";
            label9.Size = new Size(90, 17);
            label9.TabIndex = 33;
            label9.Text = "Custom Width";
            // 
            // txtCustomHeight
            // 
            txtCustomHeight.Location = new Point(20, 277);
            txtCustomHeight.Name = "txtCustomHeight";
            txtCustomHeight.Size = new Size(226, 25);
            txtCustomHeight.TabIndex = 32;
            // 
            // txtCustomWidth
            // 
            txtCustomWidth.Location = new Point(20, 206);
            txtCustomWidth.Name = "txtCustomWidth";
            txtCustomWidth.Size = new Size(226, 25);
            txtCustomWidth.TabIndex = 31;
            // 
            // button4
            // 
            button4.Location = new Point(119, 453);
            button4.Name = "button4";
            button4.Size = new Size(83, 44);
            button4.TabIndex = 35;
            button4.Text = "set size";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 8.830189F);
            label2.Location = new Point(23, 321);
            label2.Name = "label2";
            label2.Size = new Size(27, 17);
            label2.TabIndex = 37;
            label2.Text = "DPI";
            // 
            // txtDPI
            // 
            txtDPI.Location = new Point(20, 352);
            txtDPI.Name = "txtDPI";
            txtDPI.Size = new Size(226, 25);
            txtDPI.TabIndex = 36;
            // 
            // button5
            // 
            button5.Location = new Point(208, 454);
            button5.Name = "button5";
            button5.Size = new Size(83, 44);
            button5.TabIndex = 38;
            button5.Text = "set dpi";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 558);
            Controls.Add(button5);
            Controls.Add(label2);
            Controls.Add(txtDPI);
            Controls.Add(button4);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(txtCustomHeight);
            Controls.Add(txtCustomWidth);
            Controls.Add(comboBoxPrinters);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(printPreviewControl1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewControl printPreviewControl1;
        private Label label1;
        private Button button3;
        private ComboBox comboBoxPrinters;
        private Label label10;
        private Label label9;
        private TextBox txtCustomHeight;
        private TextBox txtCustomWidth;
        private Button button4;
        private Label label2;
        private TextBox txtDPI;
        private Button button5;
    }
}