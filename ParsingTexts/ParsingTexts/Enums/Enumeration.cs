
namespace ParsingTexts.Enums
{
    public class Enumeration
    {
        public readonly int id;

        public readonly string displayValue;

        protected Enumeration(int id, string displayValue)
        {
            this.id = id;
            this.displayValue = displayValue;
        }
    }
}
