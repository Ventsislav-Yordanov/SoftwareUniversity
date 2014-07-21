function FindMinAndMax(value) {
    var min = Number.MAX_VALUE;
    var max = Number.MIN_VALUE;

    for (var i = 0; i < value.length; i++) {
        if (value[i] > max) {
            max = value[i];
        }
        if (value[i] < min) {
            min = value[i];
        }
    }

    return "min -> " + min + "\nmax -> " + max + "\n";
}

console.log(FindMinAndMax([1, 2, 1, 15, 20, 5, 7, 31]));
console.log(FindMinAndMax([2, 2, 2, 2, 2]));
console.log(FindMinAndMax([500, 1, -23, 0, -300, 28, 35, 12]));