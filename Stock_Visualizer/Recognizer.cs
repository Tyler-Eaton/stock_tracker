using System.Collections.Generic;
using System.ComponentModel;

namespace Stock_Visualizer
{
    public abstract class Recognizer
    {
        public int ptn_size { get; set; }
        public string ptn_type { get; set; }

        public Recognizer(string pattern_type, int pattern_size)
        {
            ptn_size = pattern_size;
            ptn_type = pattern_type;
        }

        // override string representation and return pattern name
        public override string ToString()
        {
            return ptn_type;
        }
        // takes in a list of smart candlesticks and returns list of indexes where patters are found
        public List<int> Recognize(BindingList<SmartCandleStick> LCS)
        {
            List<int> result = new List<int>();
            List<SmartCandleStick> subList = new List<SmartCandleStick>();
            // iterate through list of candlesticks
            for (int i = 0; i < LCS.Count; i++)
            {
                // create sublist based on pattern size
                for(int j = 0; j < ptn_size; j++)
                {
                    // get global index of each candlestick
                    int globalIdx = i + j;
                    // check that index is in range of list
                    if(globalIdx >= LCS.Count)
                    {
                        break;
                    }
                    subList.Add(LCS[globalIdx]);
                }
                // check that sublist count is expected size
                if (subList.Count == ptn_size)
                {
                    if (RecognizePattern(subList))
                    {
                        // add the first global index of candlestick to results
                        result.Add(i);
                    }
                }
                // clear sublist each time to add new elements
                subList.Clear();
            }
            return result;
        }

        // abstract function to be implemented by each specific recognizer
        public abstract bool RecognizePattern(List<SmartCandleStick> subList);
    }
}
