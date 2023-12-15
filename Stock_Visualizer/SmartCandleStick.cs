using System;

namespace Stock_Visualizer
{
    // SmartCandleStick inherits from CandleStick to have those properties
    public class SmartCandleStick : CandleStick
    {
        // these are all of the additional properties associate with smart candlesticks
        // includes the properties already defined in CandleStick
        public decimal BodyRange { get; set; }
        public decimal Range { get; set; }
        public decimal TopPrice { get; set; }
        public decimal TopTail {  get; set; }
        public decimal BottomPrice { get; set; }
        public decimal BottomTail { get; set; }
        // threshold for calculations
        public static decimal threshold = 0.05M;

        // Constructor to set the values of the additional properties based on the given properties from CandleStick
        // takes a candlestick as a parameter and sets values to attributes
        public SmartCandleStick(CandleStick initialCandleStick) 
        {
            Open = initialCandleStick.Open;
            High = initialCandleStick.High;
            Low = initialCandleStick.Low;
            Close = initialCandleStick.Close;
            Volume = initialCandleStick.Volume;
            Date = initialCandleStick.Date;

            BodyRange = Math.Abs(Open - Close);
            Range = High - Low;
            TopPrice = Math.Max(Open, Close);
            TopTail = Math.Abs(High - TopPrice);
            BottomPrice = Math.Min(Open, Close);
            BottomTail = Math.Abs(Low - BottomPrice);
        }

        // return true if candlestick is up at least threshold
        public bool isBullish()
        {
            return (Close - Open) / Open >= threshold;
        }
        
        // return true if candlestick is down at least threshold
        public bool isBearish()
        {
            return (Close - Open) / Open <= -threshold;
        }

        // return true if candlestick stayed within threshold of its open
        public bool isNeutral()
        {
            return !isBearish() && !isBullish();
        }

        // return true if body range is within threshold of the range
        public bool isMarubozu()
        {
            return BodyRange >= (1 - threshold) * Range;
        }
        // return true if body range is less than threshold of range 
        public bool isDoji()
        {
            return BodyRange <= threshold * Range;
        }

        // return true if candlestick is a doji and the lower shadow makes up at least 70% of the total range
        public bool isDragonFlyDoji()
        {
            return isDoji() && BottomTail >= 0.7M * Range;
        }

        // return true if candlestick is a doji and the upper shadow makes up least 70% of the total range 
        public bool isGraveStoneDoji()
        {
            return isDoji() && TopTail >= 0.7M * Range;
        }

        // return true if bodyrange is between 10% and 25% of total range and the bottom tail is at least double the size of the body range and the top tail is less than 10% of total range
        public bool isHammer()
        {
            return BodyRange >= 0.1M * Range && BodyRange <= 0.25M * Range && BottomTail >= BodyRange * 2 && TopTail <= 0.1M * Range;
        }

        // return true if body range is between 10% and 25% of total range and top tail is at least double the size of the body range and the bottom tail is less than 10% of the total range
        public bool isInvertedHammer()
        {
            return BodyRange >= 0.1M * Range && BodyRange <= 0.25M * Range && TopTail >= BodyRange * 2 && BottomTail <= 0.1M * Range;
        }

    }
}
