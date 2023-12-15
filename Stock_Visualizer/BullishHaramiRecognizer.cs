using System.Collections.Generic;

namespace Stock_Visualizer
{
    internal class BullishHaramiRecognizer : Recognizer
    {
        // concrete class constructor calls the Recognizer constructor to set ptn type and size
        public BullishHaramiRecognizer(string ptn_type, int ptn_size) : base(ptn_type, ptn_size) { }

        public override bool RecognizePattern(List<SmartCandleStick> subList)
        {
            SmartCandleStick cs1 = subList[0];
            SmartCandleStick cs2 = subList[1];
            return cs1.isBearish() && cs2.isBullish() && cs1.Range > cs2.Range;
        }
    }
}
