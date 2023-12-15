using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

// made by Tyler Eaton

namespace Stock_Visualizer
{
    public partial class Form2_StockLoader : Form
    {
        public Form2_StockLoader()
        {
            InitializeComponent();
        }

        private void button1_LoadStock_Click(object sender, EventArgs e)
        {
            // show the open file dialog box
            openFileDialog1_FileLoader.ShowDialog();
            // set the initial directory by getting the path the application is started in and appending the folder
            try
            {
                openFileDialog1_FileLoader.InitialDirectory = Application.StartupPath.Substring(0, Application.StartupPath.IndexOf("repos")) + @"repos\Stock Data\";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Could not find repos folder: {ex.Message}");
            }
        }

        // event for when use selects OK on openfiledialog
        // reads the files line by line to get a list of candlesticks using csvhelper and creates a new form
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            String headerText = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";
            string[] filePaths = openFileDialog1_FileLoader.FileNames;

            try
            {
                // iterate through list of filepaths
                foreach (string filePath in filePaths) 
                { 
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // read the header and make sure they match expected
                        StreamReader header = new StreamReader(filePath);

                        if (header.ReadLine() != headerText)
                        {
                            throw new Exception("Wrong File type.");
                        }
                        using (CsvReader csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                        {
                            // provide the class map for csv helper to use
                            csv.Context.RegisterClassMap<CandleStickMap>(); // Register the custom mapping
                            List<CandleStick> records = new List<CandleStick>();

                            while (csv.Read())
                            {
                                CandleStick record = csv.GetRecord<CandleStick>();
                                records.Add(record);
                            }
                            
                            // reverse the list to get the correct order
                            records.Reverse();
                            string selectedFile = filePath.Substring(filePath.LastIndexOf(@"\") + 1);
                            Form1_StockDisplay stockDisplay = new Form1_StockDisplay(dateTimePicker1_StartingDate.Value, dateTimePicker2_EndingDate.Value, records, selectedFile);
                            stockDisplay.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading the file: {ex.Message}");
            }
        }

        // when the form loads, remove the initial focus off of the starting datetimepicker
        private void Form2_StockLoader_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1_StartingDate;
        }
    }
}
