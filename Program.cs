using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodingChallenge
{
    static class Program
    {
        static void Main(string[] args)
        { 
            string currentFormat = "(Name)John Doe\n(Age)20\n(City)Ashtabula, OH\n(Flags)NYN\n\n(Name)Jane Doe\n(Flags)YNY\n(City)N Kingsville, OH\n\n(Name)Sally Jones\n(Age)25\n(City)Paris\n(Flags)YYY";
            ReformatString(currentFormat, new Person());
            Console.ReadLine();
        }

        static void ReformatString(string currentFormat, Person person)
        {
            using (StringReader reader = new StringReader(currentFormat))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var keyValue = ParseLineToKeyValue(line);
                        AddPersonAttributeToPerson(keyValue, person);
                    }
                    else
                    {
                        FormatAndPrintPerson(person);
                        person = new Person();
                    }
                }
            }
            FormatAndPrintPerson(person);
        }


        static KeyValuePair<string, string> ParseLineToKeyValue(string line)
        {
            var splitLine = line.Split(')');
            var keyValuePair = new KeyValuePair<string, string>(splitLine[0].Replace("(", "").Trim(), splitLine[1].Trim());
            return keyValuePair;
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

        static void AssignFlagsToPerson(string flags, Person person)
        {
            var flagSplit = flags.ToCharArray();
            person.Gender = flagSplit[0] == 'Y' ? "Female" : "Male";
            person.IsStudent = flagSplit[1] == 'Y' ? "Yes" : "No";
            person.IsEmployee = flagSplit[2] == 'Y' ? "Yes" : "No";
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
    }
}
