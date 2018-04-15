
using ParsingTexts.Enums;

namespace ParsingTexts
{
    public class InputTypeDeterminator
    {
        public static InputType DetermineInputType(char firstCharacter)
        {
            switch (firstCharacter)
            {
                case '<':
                    return InputType.XML;
                case '{':
                    return InputType.JSON;
               case ':':
                    return StringInputType.Colon;
               case ';':
                    return StringInputType.SemiColon;
               case '-':
                    return StringInputType.Dash;
               case '(':
                    return StringInputType.Parathesis;
               default:
                    return InputType.BADINPUT;
            }
        }
    }
}
