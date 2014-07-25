function findNthDigit(arr) {
    var number = arr[1].toString();
    number = number.replace('.', '').replace('-', '');
    var n = arr[0];

    if (number.length < n) {
        return "The number doesn't have " + n + " digits";
    }

    number = Number(number);
    
    for (var i = 0; i < n - 1; i++) {
        number = Math.floor(number / 10);
    }

    return number % 10;
}

console.log(findNthDigit([1, 6]));
console.log(findNthDigit([2, -55]));
console.log(findNthDigit([6, 923456]));
console.log(findNthDigit([3, 1451.78]));
console.log(findNthDigit([6, 888.88]));