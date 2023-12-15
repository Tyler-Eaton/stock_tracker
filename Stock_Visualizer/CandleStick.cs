using System;
using CsvHelper.Configuration;

namespace Stock_Visualizer
{
    // this is the candlestick class and has all of the necessary attributes and allows them to be retrieved and set
    public class CandleStick
    {
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }


    }

    // Define a custom mapping class to specify the mapping between CSV columns and object properties.
    public class CandleStickMap : ClassMap<CandleStick>
    {
        public CandleStickMap()
        {
            Map(m => m.Date).Name("Date");
            Map(m => m.Open).Name("Open");
            Map(m => m.High).Name("High");
            Map(m => m.Low).Name("Low");
            Map(m => m.Close).Name("Close");
            Map(m => m.Volume).Name("Volume");
        }
    }
}
