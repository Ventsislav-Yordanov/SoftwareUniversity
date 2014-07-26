function solve(input) {
    var numbers = input.splice(1); // delete first element
    numbers = numbers.map(Number); // parse to Int
    var count = 1;

    for (var i = 1; i < numbers.length; i++) {
        if (numbers[i - 1] > numbers[i]) { // if previous > next
            count++;
        }
    }

    return count;
}

console.log(solve([7, 1, 2, -3, 4, 4, 0, 1]));
console.log(solve([6, 1, 3, -5, 8, 7, -6]));
console.log(solve([9, 1, 8, 8, 7, 6, 5, 7, 7, 6]));