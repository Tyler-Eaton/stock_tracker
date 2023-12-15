using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stock_Visualizer
{
    public partial class Form1_StockDisplay : Form
    {
        // These variables hold the initial values of the forms location and size along with the components used
        private Rectangle originalFormSize;
        private List<Rectangle> controlPositions = new List<Rectangle>();

        // store the list of records from the file and create a new binding list to bind the data to the chart and 
        // data grid view
        private List<CandleStick> records = new List<CandleStick>();
        private BindingList<SmartCandleStick> candleSticks = new BindingList<SmartCandleStick>();
        private string selectedFile;

        // list of recognizers to recognize the different patterns
        private List<Recognizer> recognizers = new List<Recognizer> {
            new BullishRecognizer("Bullish", 1),
            new BearishRecognizer("Bearish", 1),
            new NeutralRecognizer("Neutral", 1),
            new MarubozuRecognizer("Marubozu", 1),
            new DojiRecognizer("Doji", 1),
            new DragonFlyDojiRecognizer("DragonFly Doji", 1),
            new GraveStoneDojiRecognizer("GraveStone Doji", 1),
            new HammerRecognizer("Hammer", 1),
            new InvertedHammerRecognizer("Inverted Hammer", 1),
            new BullishEngulfingRecognizer("Bullish Engulfing", 2),
            new BearishEngulfingRecognizer("Bearish Engulfing", 2),
            new BullishHaramiRecognizer("Bullish Harami", 2),
            new BearishHaramiRecognizer("Bearish Harami", 2),
            new PeakRecognizer("Peak", 3),
            new ValleyRecognizer("Valley", 3)
        };

        // create the form and pass in data from the stock loader form
        public Form1_StockDisplay(DateTime startingDate, DateTime endingDate, List<CandleStick> records, string selectedFile)
        {
            InitializeComponent();
            dateTimePicker1_StartDate.Value = startingDate;
            dateTimePicker2_EndDate.Value = endingDate;
            this.records = records;
            this.selectedFile = selectedFile;
            textBox1_SelectedFile.Text = selectedFile;
            UpdateData();
        }

        // method for creating the annotation around the specific candlestick
        public RectangleAnnotation createAnotation(double w, double h, DataPoint candlestick, Recognizer recognizer, int index)
        {
            RectangleAnnotation rectangleAnnotation = new RectangleAnnotation();
            rectangleAnnotation.AxisX = chart1_StockChart.ChartAreas[0].AxisX;
            rectangleAnnotation.AxisY = chart1_StockChart.ChartAreas[0].AxisY;
            rectangleAnnotation.Width = w;
            rectangleAnnotation.Height = h;
            rectangleAnnotation.LineDashStyle = ChartDashStyle.Solid;
            rectangleAnnotation.LineWidth = 3;
            rectangleAnnotation.LineColor = Color.Purple;
            rectangleAnnotation.BackColor = Color.FromArgb(100, Color.FromName("Orange"));
            rectangleAnnotation.Font = new Font("Calibri", 12);
            rectangleAnnotation.ForeColor = Color.Black;
            if (w > 0.4 && h > 2) { rectangleAnnotation.Text = recognizer.ptn_type; }

            rectangleAnnotation.TextStyle = TextStyle.Shadow;

            if (recognizer.ptn_size < 3)
            {
                rectangleAnnotation.AnchorDataPoint = candlestick;
            }
            else
            {
                rectangleAnnotation.AnchorDataPoint = chart1_StockChart.Series["Price"].Points[index + 1];
            }
            rectangleAnnotation.AnchorAlignment = ContentAlignment.TopCenter;
            if (recognizer.ptn_type == "Valley") { rectangleAnnotation.AnchorAlignment = ContentAlignment.MiddleCenter; }
            if (recognizer.ptn_size == 2)
            {
                rectangleAnnotation.AnchorOffsetX = w / 4;
            }

            return rectangleAnnotation;
        }

        // method to filter the candlesticks by date
        public void filterCandleSticks()
        {
            // add the correct candlesticks based on the date range
            foreach (CandleStick record in records)
            {
                if (record.Date >= dateTimePicker2_EndDate.Value)
                {
                    break;
                }
                else if (record.Date >= dateTimePicker1_StartDate.Value)
                {
                    // create a new smart candlestick and pass in original candlestick to calculate properties
                    SmartCandleStick smartCandleStick = new SmartCandleStick(record);
                    candleSticks.Add(smartCandleStick);
                }
            }
        }

        // method to calculate annotation width
        public double calculateAnnotationWidth(Recognizer recognizer)
        {
            try
            {
                // get the distance between first 2 points and get pixel position
                double pos1 = chart1_StockChart.ChartAreas[0].AxisX.ValueToPixelPosition(chart1_StockChart.Series["Price"].Points[0].XValue);
                double pos2 = chart1_StockChart.ChartAreas[0].AxisX.ValueToPixelPosition(chart1_StockChart.Series["Price"].Points[1].XValue);
                // subtract pixel positions and divide by form width and coefficient to get dynamic width for each annotation
                double divisor = 0;
                if (selectedFile.Contains("Month"))
                {
                    divisor = this.Width / 3.11;
                }
                else if (selectedFile.Contains("Week"))
                {
                    divisor = (this.Width / (3.11 * 4));
                }
                else
                {
                    divisor = (this.Width / (3.11 * 30));
                }
                // calculate the width based on form width and candlestick count and ptn size
                double w = (((pos2 - pos1) * recognizer.ptn_size) + (this.Width / candleSticks.Count * (recognizer.ptn_size - 1) * 4)) / divisor;
                return w;
            }
            catch (Exception)
            {
                // set static width if not enough candlesticks
                double w = 1;
                return w;
            }
        }

        // method for calculating the height for each candlestick
        public double calculateAnnotationHeight(DataPoint candlestick, Recognizer recognizer, int index)
        {
            double maxHigh = candlestick.YValues[0];
            double minLow = candlestick.YValues[1];

            // find max high and min low in sublist of candlesticks to use to calculate height of annotations
            for (int j = 1; j < recognizer.ptn_size; j++)
            {
                DataPoint curcandlestick = chart1_StockChart.Series["Price"].Points[index + j];
                double curHigh = curcandlestick.YValues[0];
                double curLow = curcandlestick.YValues[1];
                if (curHigh > maxHigh)
                {
                    maxHigh = curHigh;
                }
                if (curLow < minLow)
                {
                    minLow = curLow;
                }
            }
            double h1 = chart1_StockChart.ChartAreas[0].AxisY.ValueToPixelPosition(maxHigh);
            double h2 = chart1_StockChart.ChartAreas[0].AxisY.ValueToPixelPosition(minLow);
            double h = Math.Abs(h1 - h2) / (this.Height / 130);
            return h;
        }
        // method to find y axis bounds
        public void calculateChartMinMax()
        {
            // this is to set min and max y axis values on chart to get a more zoomed in look
            try
            {
                // set min and max to first candlesticks high and low
                double desiredMin = chart1_StockChart.Series["Price"].Points[0].YValues[1];
                double desiredMax = chart1_StockChart.Series["Price"].Points[0].YValues[0];
                foreach (DataPoint point in chart1_StockChart.Series["Price"].Points)
                {
                    if (point.YValues[0] > desiredMax)
                    {
                        desiredMax = point.YValues[0];
                    }

                    if (point.YValues[1] < desiredMin)
                    {
                        desiredMin = point.YValues[1];
                    }
                }

                // Set the Y-axis range
                chart1_StockChart.ChartAreas[0].AxisY.Minimum = desiredMin / 1.1;
                chart1_StockChart.ChartAreas[0].AxisY.Maximum = desiredMax * 1.1;
            }
            catch (Exception)
            {
                Debug.WriteLine("No Candlesticks to set min and max");
            }
        }

        // when the form loads add all of the initial positions and sizes to a list which can be used to resize later
        private void Form1_Load(object sender, EventArgs e)
        {
            // when the form is loaded store the inital data in the variables
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);

            // for all the controls on the form, add its initial data into the list
            foreach (Control c in Controls)
            {
                controlPositions.Add(new Rectangle(c.Location.X, c.Location.Y, c.Size.Width, c.Size.Height));
            }
            
            // set the datasource of combobox to list of recognizers
            comboBox1_SelectPattern.DataSource = recognizers;
        }
        // iteratively calculate and resize all of the components as the form is being resized
        private void Form1_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < controlPositions.Count; i++)
            {
               ResizeControl(controlPositions[i], Controls[i]);
            }
        }

        // update the data if the date range was changed
        private void button3_UpdateData_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        // return the new width and height of the control
        private void ResizeControl(Rectangle r, Control c)
        {
            // get the x and y ratio of the original location and size with the original form data 
            float xRatio = (float)(this.Width) / (float)(originalFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalFormSize.Height);

            // multiply new location and size by the ratio to get the new values
            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            // adjust the location to the new calculated one and adjust the size
            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        // update and display data based on the date range
        private void UpdateData()
        {
            // clear the candlesticks if there is any data in the list
            candleSticks.Clear();
            chart1_StockChart.Annotations.Clear();
            chart1_StockChart.DataSource = null;
            filterCandleSticks();

            // bind the data to the chart setting the series and other properties
            chart1_StockChart.DataSource = candleSticks;
            chart1_StockChart.Titles[0].Text = selectedFile.Substring(0, selectedFile.IndexOf("."));
            chart1_StockChart.Series["Price"].XValueMember = "Date";
            chart1_StockChart.Series["Price"].XValueType = ChartValueType.Date;
            chart1_StockChart.Series["Price"].YValueMembers = "High,Low,Open,Close";
            chart1_StockChart.Series["Price"]["ShowOpenClose"] = "Both";

            // add the volume section 
            chart1_StockChart.Series["Volume"].XValueMember = "Date";
            chart1_StockChart.Series["Volume"].XValueType = ChartValueType.Date;
            chart1_StockChart.Series["Volume"].YValueMembers = "Volume";
            chart1_StockChart.DataBind();
            calculateChartMinMax();

        }
        // detect which recognizer to use and get list of patterns and add annotations to those points on chart
        private void comboBox1_SelectPattern_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // clear annotations before adding new ones
            chart1_StockChart.Annotations.Clear();
            int selectedIndex = comboBox1_SelectPattern.SelectedIndex;
            // select appropriate recognizer
            Recognizer recognizer = recognizers[selectedIndex];
            List<int> arrayOfIndexes = recognizer.Recognize(candleSticks);

            // calculate width each candlestick should be
            double w = calculateAnnotationWidth(recognizer);

            // iterate through the indexes and select point in chart with that index and add an annotation
            for (int i = 0; i < arrayOfIndexes.Count; i++)
            {
                int index = arrayOfIndexes[i];
                DataPoint candlestick = chart1_StockChart.Series["Price"].Points[index];
                double h = calculateAnnotationHeight(candlestick, recognizer, index);
                // create the annotation and add to chart to display
                RectangleAnnotation rectangleAnnotation = createAnotation(w, h, candlestick, recognizer, index);
                chart1_StockChart.Annotations.Add(rectangleAnnotation);
            }
        }
        // clear current annotations
        private void button2_ClearAnnotations_Click(object sender, EventArgs e)
        {
            // clear the annotations
            chart1_StockChart.Annotations.Clear();
        }
    }
}
