function convertKWtoHP(kw) {
    var hp = kw / 0.746;
    return hp.toFixed(2); /* example for toFixed -> http://www.w3schools.com/jsref/jsref_tofixed.asp */
}

console.log(convertKWtoHP(75));
console.log(convertKWtoHP(150));
console.log(convertKWtoHP(1000));