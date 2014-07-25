function findYoungestPerson(persons) {
    var minAge = Number.MAX_VALUE;
    var result;

    for (var i = 0; i < persons.length; i++) {
        if (persons[i].age < minAge) {
            result = persons[i];
            minAge = persons[i].age;
        }
    }

    console.log('The youngest person is %s %s', result.firstname, result.lastname);
}

var persons = [
        { firstname: 'George', lastname: 'Kolev', age: 32 },
        { firstname: 'Bay', lastname: 'Ivan', age: 81 },
        { firstname: 'Baba', lastname: 'Ginka', age: 40 }];

findYoungestPerson(persons);