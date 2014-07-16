function soothsayer(work, language, city, car) {
    var randomWork = work[Math.floor(Math.random() * work.length)];
    var randomLanguage = language[Math.floor(Math.random() * language.length)];
    var randomCity = city[Math.floor(Math.random() * city.length)];
    var randomCar = car[Math.floor(Math.random() * car.length)];

    return "You will work " + randomWork + " years on " + randomLanguage +
        ".\nYou will live in " + randomCity + " and drive " + randomCar + ".";
}

console.log(soothsayer([3, 5, 2, 7, 9], ["Java", "Python", "C#", "JavaScript", "Ruby"],
    ["Silicon Valley", "London", "Las Vegas", "Paris", "Sofia"], ["BMW", "Audi", "Lada", "Skoda", "Opel"]));