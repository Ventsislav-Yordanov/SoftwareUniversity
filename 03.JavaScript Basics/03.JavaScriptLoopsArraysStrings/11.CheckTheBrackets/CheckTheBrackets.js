function checkBrackets(input) {
    input = input.toString();
    var leftBracket = input.match(/\(/g);
    var rightBracket = input.match(/\)/g);
    var result;

    if (leftBracket.length !== rightBracket.length) {
        result = "Incorrect!";
    } else {
        result = "Correct!";
    }

    if (input.indexOf(")") < input.indexOf("(")) {
        result = "Incorrect!";
    }
    return result;
}

console.log(checkBrackets('( ( a + b ) / 5 – d )'));
console.log(checkBrackets(') ( a + b ) )'));
console.log(checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )'));
console.log(checkBrackets(')(( ( a + b ) / 5 – d )'));