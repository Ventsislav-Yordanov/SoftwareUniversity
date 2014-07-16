function checkDigit(value) {
    value /= 100;
    var digit = Math.floor(value % 10);
    var check = digit === 3;
    return check;
}

console.log(checkDigit(1235));
console.log(checkDigit(25368));
console.log(checkDigit(123456));