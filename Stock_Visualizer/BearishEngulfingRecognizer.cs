using System.Collections.Generic;

namespace Stock_Visualizer
{
    internal class BearishEngulfingRecognizer : Recognizer
    {
        // concrete class constructor calls the Recognizer constructor to set ptn type and size
        public BearishEngulfingRecognizer(string ptn_type, int ptn_size) : base(ptn_type, ptn_size) { }

        public override bool RecognizePattern(List<SmartCandleStick> subList)
        {
            SmartCandleStick cs1 = subList[0];
            SmartCandleStick cs2 = subList[1];
            return cs1.isBullish() && cs2.isBearish() && cs2.Close < cs1.Open && cs2.Open > cs1.Close && 
                   cs2.TopTail > cs1.TopTail - (cs2.Open - cs1.Close) && 
                   cs2.BottomTail > cs1.BottomTail - (cs1.Open - cs2.Close);
        }
    }
}
