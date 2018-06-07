using ParsingTexts.Enums;
using ParsingTexts.KeyValueParsers;
using System.Collections.Generic;

namespace ParsingTexts
{
    public class ParserService
    {
        private IParser parser;

        public ParserService(IParser parser)
        {
            this.parser = parser;
        }

        public KeyValuePair<string, string> ParseKeyValuePair(string line)
        {
            return parser.ParseKeyValuePair(line);
        }
    }
}
