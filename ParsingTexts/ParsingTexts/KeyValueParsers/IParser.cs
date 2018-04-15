using System.Collections.Generic;

namespace ParsingTexts
{
    interface IParser
    {
        KeyValuePair<string, string> ParseKeyValuePair(string line);
    }
}
