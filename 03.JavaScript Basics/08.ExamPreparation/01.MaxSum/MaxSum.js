function Solve(params) {
    var n = parseInt(params[0]);
    var numbers = [];
    for (var i = 1; i <= n; i++) {
        numbers[i] = parseInt(params[i]);
    }

    var maxSum = -2000000000;

    for (var i = 1; i <= n; i++) {
        for (var j = i; j <= n; j++) {
            var localSum = 0;
            for (var k = i; k <= j; k++) {
                localSum += numbers[k];
            }
            if (localSum > maxSum) {
                maxSum = localSum;
            }
        }
    }

    // There is a smarter solution using prefix sums
    // Prefix sums will remove the need of the most inner loop
    // More information on prefix sums: http://en.wikipedia.org/wiki/Prefix_sum

    return maxSum;
}

console.log(Solve([8, 1, 6, -9, 4, 4, -2, 10, -1]));
console.log(Solve([6, 1, 3, -5, 8, 7, -6]));
console.log(Solve([9, -9, -8, -8, -7, -6, -5, -1, -7, -6]));