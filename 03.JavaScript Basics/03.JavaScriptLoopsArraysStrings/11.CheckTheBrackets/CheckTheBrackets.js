function checkBrackets(value) {
    var brackets = 0;

    for (var character in value) {
        if (value[character] === "(") {
            brackets++;
        } else if (value[character] === ")") {
            brackets--;
        }
    }

    if (brackets === 0) {
        return "correct";
    } else {
        return "incorrect";
    }
}

console.log(checkBrackets('( ( a + b ) / 5 – d )'));
console.log(checkBrackets(') ( a + b ) )'));
console.log(checkBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )'));