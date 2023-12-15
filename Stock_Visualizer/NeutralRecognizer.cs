﻿using System.Collections.Generic;

namespace Stock_Visualizer
{
    internal class NeutralRecognizer : Recognizer
    {
        // concrete class constructor calls the Recognizer constructor to set ptn type and size
        public NeutralRecognizer(string ptn_type, int ptn_size) : base(ptn_type, ptn_size) { }

        public override bool RecognizePattern(List<SmartCandleStick> subList)
        {
            SmartCandleStick selectedCs = subList[0];
            return selectedCs.isNeutral();
        }
    }
}
