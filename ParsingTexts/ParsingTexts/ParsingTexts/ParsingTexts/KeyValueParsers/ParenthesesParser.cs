using System.Collections.Generic;

namespace ParsingTexts.KeyValueParsers
{
    class ParenthesesParser : IStringParser
    {
        public KeyValuePair<string, string> ParseKeyValuePair(string line)
        {
            var splitLine = line.Split(')');
            return new KeyValuePair<string, string>(splitLine[0].Replace("(", "").Trim(), splitLine[1].Trim());
        }
    }
}
