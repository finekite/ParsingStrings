
using ParsingTexts.KeyValueParsers;

namespace ParsingTexts.Enums
{
    public class InputType : Enumeration
    {
        protected InputType(int id, string displayValue) : base(id, displayValue)
        {
        }

        public static readonly InputType XML = new InputType(1, "XML");

        public static readonly InputType JSON = new InputType(2, "JSON");

        public static readonly InputType STRING = new InputType(3, "STRING");

        public static readonly InputType BADINPUT = new InputType(4, "BADINPUT");
    }
}