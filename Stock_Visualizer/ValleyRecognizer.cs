using System.Collections.Generic;

namespace Stock_Visualizer
{
    internal class ValleyRecognizer : Recognizer
    {
        // concrete class constructor calls the Recognizer constructor to set ptn type and size
        public ValleyRecognizer(string ptn_type, int ptn_size) : base(ptn_type, ptn_size) { }

        public override bool RecognizePattern(List<SmartCandleStick> subList)
        {
            SmartCandleStick cs1 = subList[0];
            SmartCandleStick cs2 = subList[1];
            SmartCandleStick cs3 = subList[2];
            return cs2.Low < cs1.Low && cs2.Low < cs3.Low;
        }
    }
}
