using System.Collections.Generic;

public interface IPersonCollection
{
    int Count { get; }

    bool AddPerson(string email, string name, int age, string town);

    Person FindPerson(string email);

    bool DeletePerson(string email);

    IEnumerable<Person> FindPersons(string emailDomain);

    IEnumerable<Person> FindPersons(string name, string town);

    IEnumerable<Person> FindPersons(int startAge, int endAge);

    IEnumerable<Person> FindPersons(int startAge, int endAge, string town);
}
