function calcSupply(age, MaxAge, foodPerDay) {
    return ((MaxAge - age) * 365) * foodPerDay + "kg of chocolate would be enough until I am " + MaxAge + " years old.";
}

console.log(calcSupply(38, 118, 0.5));
console.log(calcSupply(20, 87, 2));
console.log(calcSupply(16, 102, 1.1));