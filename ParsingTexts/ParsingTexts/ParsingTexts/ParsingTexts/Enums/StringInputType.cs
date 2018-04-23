
namespace ParsingTexts.Enums
{
    public class StringInputType : InputType
    {
        protected StringInputType(int id, string displayValue, string description) : base(id, displayValue)
        {
        }

        public static StringInputType Parathesis = new StringInputType(1, ")", "Parentheses");

        public static StringInputType Colon = new StringInputType(2, ":", "Colon");

        public static StringInputType SemiColon = new StringInputType(3, ";", "SemiColon");

        public static StringInputType Dash = new StringInputType(4, "-", "Dash");
    }
}
