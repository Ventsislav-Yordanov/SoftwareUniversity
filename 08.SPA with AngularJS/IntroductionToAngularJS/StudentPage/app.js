(function(){
    var student = { "name": "Pesho",
        "photo": "http://www.nakov.com/wp-content/uploads/2014/05/SoftUni-Logo.png",
        "grade": 5,
        "school": "High School of Mathematics",
        "teacher": "Gichka Pesheva"
    };
    var app = angular.module('appModule', []);
    app.controller('StudentController', function(){
        this.student = student;
    });
})();