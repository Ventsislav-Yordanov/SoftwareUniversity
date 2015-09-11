using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class PersonCollection : IPersonCollection
{
    private Dictionary<string, Person> personsByEmail = new Dictionary<string, Person>();
    private Dictionary<string, SortedSet<Person>> personsByEmailDomain = new Dictionary<string, SortedSet<Person>>();
    private Dictionary<Tuple<string, string>, SortedSet<Person>> personsByNameAndTown =
        new Dictionary<Tuple<string, string>, SortedSet<Person>>();
    private OrderedDictionary<int, SortedSet<Person>> personByAge = new OrderedDictionary<int, SortedSet<Person>>();
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personByTown =
        new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();


    public bool AddPerson(string email, string name, int age, string town)
    {
        if (!this.personsByEmail.ContainsKey(email))
        {
            var person = new Person(email, name, age, town);

            this.personsByEmail.Add(email, person);

            string domain = this.ExtractEmailDomain(email);
            this.personsByEmailDomain.AppendValueToKey(domain, person);

            var nameAndTownTuple = this.GenerateNameAndTownKey(name, town);
            this.personsByNameAndTown.AppendValueToKey(nameAndTownTuple, person);

            this.personByAge.AppendValueToKey(age, person);

            this.personByTown.EnsureKeyExists(town);
            this.personByTown[town].EnsureKeyExists(age);
            this.personByTown[town][age].Add(person);

            return true;
        }

        return false;
    }

    public int Count
    {
        get
        {
            return this.personsByEmail.Count;
        }
    }

    public Person FindPerson(string email)
    {
        Person person;
        this.personsByEmail.TryGetValue(email, out person);
        return person;
    }

    public bool DeletePerson(string email)
    {
        if (this.personsByEmail.ContainsKey(email))
        {
            var person = this.personsByEmail[email];
            this.personsByEmail.Remove(email);
            this.personByAge[person.Age].Remove(person);
            this.personByTown[person.Town][person.Age].Remove(person);
            string emailDomain = this.ExtractEmailDomain(person.Email);
            this.personsByEmailDomain[emailDomain].Remove(person);
            var nameAndTownTuple = this.GenerateNameAndTownKey(person.Name, person.Town);
            this.personsByNameAndTown.Remove(nameAndTownTuple);

            return true;
        }

        return false;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        var persons = this.personsByEmailDomain.GetValuesForKey(emailDomain);
        return persons;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        var nameAndTownTuple = this.GenerateNameAndTownKey(name, town);
        var persons = this.personsByNameAndTown.GetValuesForKey(nameAndTownTuple);
        return persons;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        var personsInRange = this.personByAge.Range(startAge, true, endAge, true);
        foreach (var personInRange in personsInRange)
        {
            foreach (var person in personInRange.Value)
            {
                yield return person;
            }
        }
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
    {
        if (this.personByTown.ContainsKey(town))
        {
            var personsInRange = this.personByTown[town].Range(startAge, true, endAge, true);
            foreach (var personInRange in personsInRange)
            {
                foreach (var person in personInRange.Value)
                {
                    yield return person;
                }
            }
        }
    }

    private Tuple<string, string> GenerateNameAndTownKey(string name, string town)
    {
        var tuple = new Tuple<string, string>(name, town);
        return tuple;
    }

    private string ExtractEmailDomain(string email)
    {
        var emailParts = email.Split('@');
        string domain = emailParts[1];
        return domain;
    }
}
