
namespace ParsingTexts.Enums
{
    public class Enumeration
    {
        private readonly int id;

        private readonly string displayValue;

        protected Enumeration(int id, string displayValue)
        {
            this.id = id;
            this.displayValue = displayValue;
        }
    }
}
