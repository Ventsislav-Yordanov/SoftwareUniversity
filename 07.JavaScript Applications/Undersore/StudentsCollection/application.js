(function () {

    //check if running on Node.js
    if (typeof require !== 'undefined') {
        //load underscore if on Node.js
        _ = require('node_modules/underscore/underscore.js');
    }

    var students = [
        { "gender": "Male", "firstName": "Joe", "lastName": "Riley", "age": 22, "country": "Russia" },
        { "gender": "Female", "firstName": "Lois", "lastName": "Morgan", "age": 41, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Roy", "lastName": "Wood", "age": 33, "country": "Russia" },
        { "gender": "Female", "firstName": "Diana", "lastName": "Freeman", "age": 40, "country": "Argentina" },
        { "gender": "Female", "firstName": "Bonnie", "lastName": "Hunter", "age": 23, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Joe", "lastName": "Young", "age": 16, "country": "Bulgaria" },
        { "gender": "Female", "firstName": "Kathryn", "lastName": "Murray", "age": 22, "country": "Indonesia" },
        { "gender": "Male", "firstName": "Dennis", "lastName": "Woods", "age": 37, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Billy", "lastName": "Patterson", "age": 24, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Willie", "lastName": "Gray", "age": 42, "country": "China" },
        { "gender": "Male", "firstName": "Justin", "lastName": "Lawson", "age": 38, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Ryan", "lastName": "Foster", "age": 24, "country": "Indonesia" },
        { "gender": "Male", "firstName": "Eugene", "lastName": "Morris", "age": 37, "country": "Bulgaria" },
        { "gender": "Male", "firstName": "Eugene", "lastName": "Rivera", "age": 45, "country": "Philippines" },
        { "gender": "Female", "firstName": "Kathleen", "lastName": "Hunter", "age": 28, "country": "Bulgaria" }
    ];

    // ---------- •	Get all students with age between 18 and 24 ----------
    var studentsWithAgeBetween18And24 = _.filter(students, function (student) {
        return student.age >= 18 && student.age <= 24;
    });

    console.log('---------- All students with age between 18 and 24 ----------');
    _.each(studentsWithAgeBetween18And24, function (student) {
        console.log(student);
    });

    // ---------- •	Get all students whose first name is alphabetically before their last name ----------
    var alphabeticallyStudents = _.filter(students, function (student) {
        return student.firstName < student.lastName;
    });

    console.log('---------- All students whose first name is alphabetically before their last name ----------');
    _.each(alphabeticallyStudents, function (student) {
        console.log(student);
    });

    // ---------- •	Get only the names of all students from Bulgaria ----------
    var studentsFromBulgaria = _.map(
        _.where(students, { country: "Bulgaria" }),
        function (student) {
            return { firstName: student.firstName, lastName: student.lastName };
        }
    );

    console.log('---------- All students whose first name is alphabetically before their last name ----------');
    _.each(studentsFromBulgaria, function (student) {
        console.log(student);
    });

    // ---------- •	Get the last five students ----------
    var lastFiveStudents = _.last(students, 5);

    console.log('---------- The last five students ----------');
    _.each(lastFiveStudents, function (student) {
        console.log(student);
    });

    // ---------- •	Get the first three students who are not from Bulgaria and are male ----------
    var specialStudents = _.filter(students, function (student) {
        return student.country != 'Bulgaria' && student.gender == 'Male';
    });

    specialStudents = _.first(specialStudents, 3);

    console.log('---------- The first three students who are not from Bulgaria and are male ----------');
    _.each(specialStudents, function (student) {
        console.log(student);
    });

}());