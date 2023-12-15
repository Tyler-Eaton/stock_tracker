namespace Stock_Visualizer
{
    partial class Form2_StockLoader
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
            this.dateTimePicker1_StartingDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2_EndingDate = new System.Windows.Forms.DateTimePicker();
            this.button1_LoadStock = new System.Windows.Forms.Button();
            this.label1_StartingDate = new System.Windows.Forms.Label();
            this.label2_EndingDate = new System.Windows.Forms.Label();
            this.openFileDialog1_FileLoader = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // dateTimePicker1_StartingDate
            // 
            this.dateTimePicker1_StartingDate.Location = new System.Drawing.Point(24, 71);
            this.dateTimePicker1_StartingDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1_StartingDate.Name = "dateTimePicker1_StartingDate";
            this.dateTimePicker1_StartingDate.Size = new System.Drawing.Size(295, 26);
            this.dateTimePicker1_StartingDate.TabIndex = 0;
            this.dateTimePicker1_StartingDate.Value = new System.DateTime(2021, 1, 1, 13, 40, 0, 0);
            // 
            // dateTimePicker2_EndingDate
            // 
            this.dateTimePicker2_EndingDate.Location = new System.Drawing.Point(596, 71);
            this.dateTimePicker2_EndingDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker2_EndingDate.Name = "dateTimePicker2_EndingDate";
            this.dateTimePicker2_EndingDate.Size = new System.Drawing.Size(300, 26);
            this.dateTimePicker2_EndingDate.TabIndex = 1;
            // 
            // button1_LoadStock
            // 
            this.button1_LoadStock.BackColor = System.Drawing.SystemColors.Control;
            this.button1_LoadStock.Location = new System.Drawing.Point(398, 71);
            this.button1_LoadStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1_LoadStock.Name = "button1_LoadStock";
            this.button1_LoadStock.Size = new System.Drawing.Size(112, 35);
            this.button1_LoadStock.TabIndex = 2;
            this.button1_LoadStock.Text = "Load";
            this.button1_LoadStock.UseVisualStyleBackColor = false;
            this.button1_LoadStock.Click += new System.EventHandler(this.button1_LoadStock_Click);
            // 
            // label1_StartingDate
            // 
            this.label1_StartingDate.AutoSize = true;
            this.label1_StartingDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1_StartingDate.Location = new System.Drawing.Point(24, 42);
            this.label1_StartingDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1_StartingDate.Name = "label1_StartingDate";
            this.label1_StartingDate.Size = new System.Drawing.Size(106, 22);
            this.label1_StartingDate.TabIndex = 3;
            this.label1_StartingDate.Text = "Starting Date";
            // 
            // label2_EndingDate
            // 
            this.label2_EndingDate.AutoSize = true;
            this.label2_EndingDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2_EndingDate.Location = new System.Drawing.Point(596, 42);
            this.label2_EndingDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2_EndingDate.Name = "label2_EndingDate";
            this.label2_EndingDate.Size = new System.Drawing.Size(100, 22);
            this.label2_EndingDate.TabIndex = 4;
            this.label2_EndingDate.Text = "Ending Date";
            // 
            // openFileDialog1_FileLoader
            // 
            this.openFileDialog1_FileLoader.Filter = "\"All Files (*.*)|*.*|Month |*-Month.*|Week |*-Week.*|Day |*-Day.*\"";
            this.openFileDialog1_FileLoader.Multiselect = true;
            this.openFileDialog1_FileLoader.Title = " Open Stock File";
            this.openFileDialog1_FileLoader.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form2_StockLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 134);
            this.Controls.Add(this.label2_EndingDate);
            this.Controls.Add(this.label1_StartingDate);
            this.Controls.Add(this.button1_LoadStock);
            this.Controls.Add(this.dateTimePicker2_EndingDate);
            this.Controls.Add(this.dateTimePicker1_StartingDate);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2_StockLoader";
            this.Text = "Stock Loader";
            this.Load += new System.EventHandler(this.Form2_StockLoader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1_StartingDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker2_EndingDate;
        private System.Windows.Forms.Button button1_LoadStock;
        private System.Windows.Forms.Label label1_StartingDate;
        private System.Windows.Forms.Label label2_EndingDate;
        private System.Windows.Forms.OpenFileDialog openFileDialog1_FileLoader;
    }
}