using System.Collections.Generic;

namespace ParsingTexts
{
    public interface IParser
    {
        KeyValuePair<string, string> ParseKeyValuePair(string line);
    }
}
