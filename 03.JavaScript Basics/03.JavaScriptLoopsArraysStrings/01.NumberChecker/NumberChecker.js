function printNumbers(number) {
    var result = [];
    for (var i = 1; i < number; i++) {
        if ((i % 4 === 0) || (i % 5 === 0)) {
            continue;
        } else {
            result.push(i);
        }
    }
    result.join(",");
    if (number <= 0) {
        return "no";
    } else {
        return result;
    }
}

console.log(printNumbers(20));
console.log(printNumbers(-5));
console.log(printNumbers(13));