using ParsingTexts.Enums;
using ParsingTexts.KeyValueParsers;
using System.Collections.Generic;

namespace ParsingTexts
{
    public class ParserService
    {
        private InputType inputType;

        IParser parser;

        public ParserService(InputType inputType)
        {
            this.inputType = inputType;
        }


        public KeyValuePair<string, string> ParseKeyValuePair(string line)
        {
            if (inputType.Equals(InputType.XML))
            {
                parser = new XmlParser();
            }
            else if (inputType.Equals(InputType.JSON))
            {
                parser = new JsonParser();
            }
            else if (inputType.Equals(StringInputType.Parathesis))
            {
                parser = new ParenthesesParser();
            }
            return parser.ParseKeyValuePair(line);
        }
    }
}
