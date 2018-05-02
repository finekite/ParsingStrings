using System;

namespace ParsingTexts
{
    static class Program
    {
        static void Main(string[] args)
        {
            string input = @"(Name)John Doe
                                    (Age)20
                                    (City)Ashtabula, OH
                                    (Flags)NYN

                                    (Name)Jane Doe
                                    (Flags)YNY
                                    (City)N Kingsville, OH

                                    (Name)Sally Jones
                                    (Age)25
                                    (City)Paris
                                    (Flags)YYY";

            var inputType = InputTypeDeterminator.DetermineInputType(input[0]);
            var parserService = new ParserService(inputType);
            var program = new RunProgram(parserService);
            program.ParseText(input);
            Console.ReadLine();
        }
    }
}
