using System.Collections.Generic;

namespace APLTools.Models
{
    public class MetaDataExtend : MetaData
    {
        public int limit { get; set; } = -1;
        public int guessTotal { get; set; } = -1;
        public int offset { get; set; } = -1;
        public string nodename { get; set; }
        public Dictionary<string, string> universal { get; set; }
    }
}
