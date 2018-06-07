using Ninject;
using ParsingTexts.Enums;
using ParsingTexts.KeyValueParsers;
using ParsingTexts.Mappers;
using System;

namespace ParsingTexts
{
    static class Program
    {
        static IKernel kernel;

        static string input = @"(Name)John Doe
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

        static void Main(string[] args)
        {
            ConfigureConatiner(input);
            var program = kernel.Get<RunProgram>();
            program.ParseText(input);
            Console.ReadLine();
        }

        static void ConfigureConatiner(string input)
        {
            kernel = new StandardKernel();
            var inputType = InputTypeDeterminator.DetermineInputType(input[0]);
            BindParserInstance(kernel, inputType);
            BindMapper();
        }

        private static void BindMapper()
        {
            kernel.Bind<IMapper>().To<PersonMapper>();
        }

        static void BindParserInstance(IKernel kernel, InputType inputType)
        {
            if (inputType.Equals(InputType.XML))
            {
                kernel.Bind<IParser>().To<XmlParser>().InSingletonScope();
            }
            else if (inputType.Equals(InputType.JSON))
            {
                kernel.Bind<IParser>().To<JsonParser>().InSingletonScope();
            }
            else if (inputType.Equals(StringInputType.Parathesis))
            {
                kernel.Bind<IParser>().To<ParenthesesParser>().InSingletonScope();
            }
        }
    }
}
