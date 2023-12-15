using System.Collections.Generic;

namespace Stock_Visualizer
{
    internal class PeakRecognizer : Recognizer
    {
        // concrete class constructor calls the Recognizer constructor to set ptn type and size
        public PeakRecognizer(string ptn_type, int ptn_size) : base(ptn_type, ptn_size) { }

        public override bool RecognizePattern(List<SmartCandleStick> subList)
        {
            SmartCandleStick cs1 = subList[0];
            SmartCandleStick cs2 = subList[1];
            SmartCandleStick cs3 = subList[2];
            return cs2.High > cs1.High && cs2.High > cs3.High;
        }
    }
}
