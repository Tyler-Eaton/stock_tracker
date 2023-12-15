namespace Stock_Visualizer
{
    partial class Form1_StockDisplay
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1_StockChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker1_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2_EndDate = new System.Windows.Forms.DateTimePicker();
            this.label1_StartDatePicker = new System.Windows.Forms.Label();
            this.label2_EndDatePicker = new System.Windows.Forms.Label();
            this.button1_UpdateData = new System.Windows.Forms.Button();
            this.textBox1_SelectedFile = new System.Windows.Forms.TextBox();
            this.label3_SelectedFile = new System.Windows.Forms.Label();
            this.comboBox1_SelectPattern = new System.Windows.Forms.ComboBox();
            this.button2_ClearAnnotations = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1_StockChart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1_StockChart
            // 
            this.chart1_StockChart.BackColor = System.Drawing.Color.FloralWhite;
            this.chart1_StockChart.BorderlineColor = System.Drawing.Color.Black;
            this.chart1_StockChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AlignWithChartArea = "Volume";
            chartArea1.AxisX.MinorGrid.Interval = double.NaN;
            chartArea1.AxisX.MinorGrid.IntervalOffset = double.NaN;
            chartArea1.AxisX.MinorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet;
            chartArea1.AxisX.MinorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.NotSet;
            chartArea1.AxisX.Title = "Date";
            chartArea1.AxisY.Title = "Price ($)";
            chartArea1.BackColor = System.Drawing.Color.AntiqueWhite;
            chartArea1.Name = "Price";
            chartArea2.AlignWithChartArea = "Price";
            chartArea2.AxisX.Title = "Date";
            chartArea2.AxisY.Title = "Volume";
            chartArea2.BackColor = System.Drawing.Color.AntiqueWhite;
            chartArea2.Name = "Volume";
            this.chart1_StockChart.ChartAreas.Add(chartArea1);
            this.chart1_StockChart.ChartAreas.Add(chartArea2);
            legend1.BackColor = System.Drawing.Color.FloralWhite;
            legend1.Name = "Legend1";
            this.chart1_StockChart.Legends.Add(legend1);
            this.chart1_StockChart.Location = new System.Drawing.Point(40, 58);
            this.chart1_StockChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart1_StockChart.Name = "chart1_StockChart";
            series1.ChartArea = "Price";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Green";
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Price";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "Volume";
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Volume";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            this.chart1_StockChart.Series.Add(series1);
            this.chart1_StockChart.Series.Add(series2);
            this.chart1_StockChart.Size = new System.Drawing.Size(1292, 578);
            this.chart1_StockChart.TabIndex = 1;
            this.chart1_StockChart.Text = "chart1";
            title1.Name = "ChartTitle";
            title1.Text = "Selected Stock";
            this.chart1_StockChart.Titles.Add(title1);
            // 
            // dateTimePicker1_StartDate
            // 
            this.dateTimePicker1_StartDate.Location = new System.Drawing.Point(40, 691);
            this.dateTimePicker1_StartDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1_StartDate.Name = "dateTimePicker1_StartDate";
            this.dateTimePicker1_StartDate.Size = new System.Drawing.Size(346, 26);
            this.dateTimePicker1_StartDate.TabIndex = 2;
            // 
            // dateTimePicker2_EndDate
            // 
            this.dateTimePicker2_EndDate.Location = new System.Drawing.Point(435, 691);
            this.dateTimePicker2_EndDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker2_EndDate.Name = "dateTimePicker2_EndDate";
            this.dateTimePicker2_EndDate.Size = new System.Drawing.Size(344, 26);
            this.dateTimePicker2_EndDate.TabIndex = 3;
            // 
            // label1_StartDatePicker
            // 
            this.label1_StartDatePicker.AutoSize = true;
            this.label1_StartDatePicker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1_StartDatePicker.Location = new System.Drawing.Point(40, 663);
            this.label1_StartDatePicker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1_StartDatePicker.Name = "label1_StartDatePicker";
            this.label1_StartDatePicker.Size = new System.Drawing.Size(106, 22);
            this.label1_StartDatePicker.TabIndex = 6;
            this.label1_StartDatePicker.Text = "Starting Date";
            // 
            // label2_EndDatePicker
            // 
            this.label2_EndDatePicker.AutoSize = true;
            this.label2_EndDatePicker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2_EndDatePicker.Location = new System.Drawing.Point(435, 663);
            this.label2_EndDatePicker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2_EndDatePicker.Name = "label2_EndDatePicker";
            this.label2_EndDatePicker.Size = new System.Drawing.Size(100, 22);
            this.label2_EndDatePicker.TabIndex = 7;
            this.label2_EndDatePicker.Text = "Ending Date";
            // 
            // button1_UpdateData
            // 
            this.button1_UpdateData.Location = new System.Drawing.Point(818, 686);
            this.button1_UpdateData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1_UpdateData.Name = "button1_UpdateData";
            this.button1_UpdateData.Size = new System.Drawing.Size(112, 35);
            this.button1_UpdateData.TabIndex = 8;
            this.button1_UpdateData.Text = "Update";
            this.button1_UpdateData.UseVisualStyleBackColor = true;
            this.button1_UpdateData.Click += new System.EventHandler(this.button3_UpdateData_Click);
            // 
            // textBox1_SelectedFile
            // 
            this.textBox1_SelectedFile.Location = new System.Drawing.Point(174, 18);
            this.textBox1_SelectedFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1_SelectedFile.Name = "textBox1_SelectedFile";
            this.textBox1_SelectedFile.Size = new System.Drawing.Size(354, 26);
            this.textBox1_SelectedFile.TabIndex = 9;
            // 
            // label3_SelectedFile
            // 
            this.label3_SelectedFile.AutoSize = true;
            this.label3_SelectedFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3_SelectedFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3_SelectedFile.Location = new System.Drawing.Point(40, 20);
            this.label3_SelectedFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3_SelectedFile.Name = "label3_SelectedFile";
            this.label3_SelectedFile.Size = new System.Drawing.Size(121, 24);
            this.label3_SelectedFile.TabIndex = 10;
            this.label3_SelectedFile.Text = "Selected File:";
            // 
            // comboBox1_SelectPattern
            // 
            this.comboBox1_SelectPattern.FormattingEnabled = true;
            this.comboBox1_SelectPattern.Location = new System.Drawing.Point(962, 689);
            this.comboBox1_SelectPattern.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1_SelectPattern.Name = "comboBox1_SelectPattern";
            this.comboBox1_SelectPattern.Size = new System.Drawing.Size(224, 28);
            this.comboBox1_SelectPattern.TabIndex = 11;
            this.comboBox1_SelectPattern.Text = "Select Pattern";
            this.comboBox1_SelectPattern.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectPattern_SelectionChangeCommitted);
            // 
            // button2_ClearAnnotations
            // 
            this.button2_ClearAnnotations.Location = new System.Drawing.Point(1220, 686);
            this.button2_ClearAnnotations.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2_ClearAnnotations.Name = "button2_ClearAnnotations";
            this.button2_ClearAnnotations.Size = new System.Drawing.Size(112, 35);
            this.button2_ClearAnnotations.TabIndex = 12;
            this.button2_ClearAnnotations.Text = "Clear";
            this.button2_ClearAnnotations.UseVisualStyleBackColor = true;
            this.button2_ClearAnnotations.Click += new System.EventHandler(this.button2_ClearAnnotations_Click);
            // 
            // Form1_StockDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1376, 740);
            this.Controls.Add(this.button2_ClearAnnotations);
            this.Controls.Add(this.comboBox1_SelectPattern);
            this.Controls.Add(this.label3_SelectedFile);
            this.Controls.Add(this.textBox1_SelectedFile);
            this.Controls.Add(this.button1_UpdateData);
            this.Controls.Add(this.label2_EndDatePicker);
            this.Controls.Add(this.label1_StartDatePicker);
            this.Controls.Add(this.dateTimePicker2_EndDate);
            this.Controls.Add(this.dateTimePicker1_StartDate);
            this.Controls.Add(this.chart1_StockChart);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1_StockDisplay";
            this.Text = "Stock Visualizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.chart1_StockChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1_StockChart;
        private System.Windows.Forms.DateTimePicker dateTimePicker1_StartDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker2_EndDate;
        private System.Windows.Forms.Label label1_StartDatePicker;
        private System.Windows.Forms.Label label2_EndDatePicker;
        private System.Windows.Forms.Button button1_UpdateData;
        private System.Windows.Forms.TextBox textBox1_SelectedFile;
        private System.Windows.Forms.Label label3_SelectedFile;
        private System.Windows.Forms.ComboBox comboBox1_SelectPattern;
        private System.Windows.Forms.Button button2_ClearAnnotations;
    }
}

