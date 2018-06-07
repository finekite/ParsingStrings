
using ParsingTexts.Mappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ParsingTexts
{
    public class RunProgram
    {
        private PersonMapper mapper;

        private ParserService parserService;

        public RunProgram(PersonMapper mapper, ParserService parserService)
        {
            this.mapper = mapper;
            this.parserService = parserService;
        }

        public void ParseText(string input)
        {
            foreach (var person in ParsePeople(input))
            {
                mapper.WritePerson(person);
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
                        mapper.AddPersonAttributeToPerson(keyValue, person);
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
    }
}
