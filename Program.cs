using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace CodingChallenge
{
    class Program
    {
        static readonly object _object = new object();

        static void Main(string[] args)
        {
            var personList = new List<Person>();
            string personRecords = "(Name)John Doe\n(Age)20\n(City)Ashtabula, OH\n(Flags)NYN\n\n(Name)Jane Doe\n(Flags)YNY\n(City)N Kingsville, OH\n\n(Name)Sally Jones\n(Age)25\n(City)Paris\n(Flags)YYY";
            var result = Regex.Split(personRecords, "\r\n|\r|\n");
            var person = new Person();
            foreach (var line in result)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    if (line.ToLower().Contains("name"))
                    {
                        person.Name = line.Substring(line.IndexOf(")") + 1).Trim();
                    }
                    else if (line.ToLower().Contains("age"))
                    {
                        person.Age = line.Substring(line.IndexOf(")") + 1).Trim();
                    }
                    else if (line.ToLower().Contains("city"))
                    {
                        if (line.Contains(","))
                        {
                            var cityState = line.Split(',');
                            person.City = cityState[0].Substring(cityState[0].IndexOf(")") + 1).Trim();
                            person.State = cityState[1].Trim();
                        }
                        else
                        {
                            person.City = line.Substring(line.IndexOf(")") + 1).Trim();
                        }
                    }
                    else if (line.ToLower().Contains("flag"))
                    {
                        var flagSplit = line.Substring(line.IndexOf(")") + 1).Trim().ToCharArray();
                        person.Gender = flagSplit[0] == 'Y' ? "Female" : "Male";
                        person.IsStudent = flagSplit[1] == 'Y' ? "Yes" : "No";
                        person.IsEmployee = flagSplit[2] == 'Y' ? "Yes" : "No";
                    }
                }
                else
                {
                    personList.Add(person);
                    person = new Person();
                }
            }
            personList.Add(person);
            string newFormat = string.Empty;
            foreach (var personAdded in personList)
            {
                personAdded.State = personAdded.State ?? "N\\A";
                personAdded.Age = personAdded.Age != null ? personAdded.Age + ", " : "";
                newFormat += personAdded.Name + " [" + personAdded.Age + personAdded.Gender + "]\n\t" + "City\t : " + personAdded.City + "\n\t" + "State\t : " + personAdded.State + "\n\t" + "Student\t : " + personAdded.IsStudent + "\n" + "\tEmployee : " + personAdded.IsEmployee + "\n";
            }

            Console.WriteLine(newFormat);
            Console.ReadLine();
        }

        public class Person
        {
            public string Name { get; set; }

            public string Age { get; set; }

            public string City { get; set; }

            public string Gender { get; set; }

            public string State { get; set; }

            public string IsStudent { get; set; }

            public string IsEmployee { get; set; }
        }
    }
}
