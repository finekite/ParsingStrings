using ParsingTexts.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ParsingTexts
{
    static class Program
    {
        static void Main(string[] args)
        {
            string currentFormat =  //Console.ReadLine();
            "(Name)John Doe\n(Age)20\n(City)Ashtabula, OH\n(Flags)NYN\n\n(Name)Jane Doe\n(Flags)YNY\n(City)N Kingsville, OH\n\n(Name)Sally Jones\n(Age)25\n(City)Paris\n(Flags)YYY";
            var inputType = InputTypeDeterminator.DetermineInputType(currentFormat[0]);
            ReformatString(new Person(), currentFormat, inputType);
            Console.ReadLine();
        }

        static void ReformatString(Person person, string currentFormat, InputType type)
        {
            using (StringReader reader = new StringReader(currentFormat))
            {
                string line;
                int linesPerPerson = 0;
                var parserService = new ParserService(type);
                while ((line = reader.ReadLine()) != null || linesPerPerson > 0)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var keyValue = parserService.ParseKeyValuePair(line);
                        AddPersonAttributeToPerson(keyValue, person);
                        linesPerPerson++;
                    }
                    else
                    {
                        FormatAndPrintPerson(person);
                        person = new Person();
                        linesPerPerson = 0;
                    }
                }
            }
        }

        static void AddPersonAttributeToPerson(KeyValuePair<string, string> keyValuePair, Person person)
        {
            string key = keyValuePair.Key;
            switch (key)
            {
                case "Name":
                    person.Name = keyValuePair.Value;
                    break;
                case "Age":
                    person.Age = keyValuePair.Value;
                    break;
                case "City":
                    AsignCityState(keyValuePair.Value, person);
                    break;
                case "Flags":
                    AssignFlagsToPerson(keyValuePair.Value, person);
                    break;
                default:
                    break;
            }
        }

        static void AsignCityState(string cityState, Person person)
        {
            if (cityState.Contains(","))
            {
                var cityStateSplit = cityState.Split(',');
                person.City = cityStateSplit[0].Trim();
                person.State = cityStateSplit[1].Trim();
            }
            else
            {
                person.City = cityState;
                person.State = "N\\A";
            }
        }

        static void AssignFlagsToPerson(string flags, Person person)
        {
            var flagSplit = flags.ToCharArray();
            person.Gender = flagSplit[0] == 'Y' ? "Female" : "Male";
            person.IsStudent = flagSplit[1] == 'Y' ? "Yes" : "No";
            person.IsEmployee = flagSplit[2] == 'Y' ? "Yes" : "No";
        }

        static void FormatAndPrintPerson(Person person)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format("{0} [{1}{2}]", person.Name, person.Age != null ? person.Age + ", " : "", person.Gender));
            stringBuilder.AppendLine(string.Format("\tCity\t: {0}", person.City));
            stringBuilder.AppendLine(string.Format("\tState\t: {0}", person.State));
            stringBuilder.AppendLine(string.Format("\tStudent\t: {0}", person.IsStudent));
            stringBuilder.AppendLine(string.Format("\tEmployee: {0}", person.IsEmployee));
            Console.WriteLine(stringBuilder);
        }
    }
}
