
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ParsingTexts
{
    public class RunProgram
    {
        private ParserService parserService;

        public RunProgram(ParserService parserService)
        {
            this.parserService = parserService;
        }

        public void ParseText(string input)
        {
            foreach (var person in ParsePeople(input))
            {
                WritePerson(person);
            }
        }

        private IEnumerable<Person> ParsePeople(string input)
        {
            var person = new Person();
            using (StringReader reader = new StringReader(input))
            {
                string line;
                int linesPerPerson = 0;
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
                        yield return person;
                        linesPerPerson = 0;
                    }
                }
            }
        }

        private void WritePerson(Person person)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format("{0} [{1}{2}]", person.Name, person.Age != null ? person.Age + ", " : "", person.Gender));
            stringBuilder.AppendLine(string.Format("\tCity\t: {0}", person.City));
            stringBuilder.AppendLine(string.Format("\tState\t: {0}", person.State));
            stringBuilder.AppendLine(string.Format("\tStudent\t: {0}", person.IsStudent));
            stringBuilder.AppendLine(string.Format("\tEmployee: {0}", person.IsEmployee));
            Console.Write(stringBuilder);
        }

        private void AddPersonAttributeToPerson(KeyValuePair<string, string> keyValuePair, Person person)
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

        private void AsignCityState(string cityState, Person person)
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

        private void AssignFlagsToPerson(string flags, Person person)
        {
            var flagSplit = flags.ToCharArray();
            person.Gender = flagSplit[0] == 'Y' ? "Female" : "Male";
            person.IsStudent = flagSplit[1] == 'Y' ? "Yes" : "No";
            person.IsEmployee = flagSplit[2] == 'Y' ? "Yes" : "No";
        }
    }
}
