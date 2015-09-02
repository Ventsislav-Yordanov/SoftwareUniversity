using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

// TODO: rename persons to people
public class PersonCollection : IPersonCollection
{

    private Dictionary<string, Person> personsByEmail = new Dictionary<string, Person>();

    private Dictionary<string, SortedSet<Person>> personsByEmailDomain = new Dictionary<string, SortedSet<Person>>();

    private Dictionary<string, SortedSet<Person>> personsByNameAndTown = new Dictionary<string, SortedSet<Person>>();

    private OrderedDictionary<int, SortedSet<Person>> personsByAge = new OrderedDictionary<int, SortedSet<Person>>();
    
    private Dictionary<string, OrderedDictionary<int, SortedSet<Person>>> personsByTownAndAge =
        new Dictionary<string, OrderedDictionary<int, SortedSet<Person>>>();


    public bool AddPerson(string email, string name, int age, string town)
    {
        var personUsingCurrentEmail = this.FindPerson(email);
        if (personUsingCurrentEmail != null)
        {
            return false;
        }

        var person = new Person(email, name, age, town);

        // Add to personsByEmail
        this.personsByEmail.Add(email, person);

        // Add to personsByEmailDomain
        string emailDomain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain.AppendValueToKey(emailDomain, person);

        // Add to personsByNameAndTown
        string nameAndTownKey = this.CombineNameAndTown(name, town);
        this.personsByNameAndTown.AppendValueToKey(nameAndTownKey, person);

        // Add to personsByAge
        this.personsByAge.AppendValueToKey(person.Age, person);

        // Add to personsByTownAndAge
        this.personsByTownAndAge.EnsureKeyExists(person.Town);
        this.personsByTownAndAge[person.Town].AppendValueToKey(person.Age, person);

        return true;
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
        var person = this.FindPerson(email);
        if (person == null)
        {
            return false;
        }

        // Remove from personsByEmail
        this.personsByEmail.Remove(email);

        // Remove from personsByEmailDomain
        string emailDomain = this.ExtractEmailDomain(email);
        this.personsByEmailDomain[emailDomain].Remove(person);

        // Remove from personsByNameAndTown
        string nameAndTownKey = this.CombineNameAndTown(person.Name, person.Town);
        this.personsByNameAndTown[nameAndTownKey].Remove(person);

        // Remove from personsByAge
        this.personsByAge[person.Age].Remove(person);

        // Remove from personsByTownAndAge
        this.personsByTownAndAge[person.Town][person.Age].Remove(person);

        return true;
    }

    public IEnumerable<Person> FindPersons(string emailDomain)
    {
        var persons = this.personsByEmailDomain.GetValuesForKey(emailDomain);
        return persons;
    }

    public IEnumerable<Person> FindPersons(string name, string town)
    {
        string key = this.CombineNameAndTown(name, town);
        var persons = this.personsByNameAndTown.GetValuesForKey(key);

        return persons;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge)
    {
        // TODO: Check performance
        var persons = this.personsByAge
            .Range(startAge, true, endAge, true)
            .Values
            .SelectMany(subrange => subrange.Select(person => person));

        return persons;
    }

    public IEnumerable<Person> FindPersons(int startAge, int endAge, string town)
    {
        if (!this.personsByTownAndAge.ContainsKey(town))
        {
            return Enumerable.Empty<Person>();
        }

        var persons = this.personsByTownAndAge[town]
            .Range(startAge, true, endAge, true)
            .Values
            .SelectMany(subrange => subrange.Select(person => person));

        return persons;
    }

    private string CombineNameAndTown(string name, string town)
    {
        return name + "|!|" + town;
    }

    private string ExtractEmailDomain(string email)
    {
        var emailParts = email.Split('@');
        var domain = emailParts[1];

        return domain;
    }
}
