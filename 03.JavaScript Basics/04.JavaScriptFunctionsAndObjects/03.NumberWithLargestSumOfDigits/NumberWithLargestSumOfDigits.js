function findLargestBySumOfDigits(nums) {
    if (arguments.length < 1) { // It should return undefined when 0 arguments are passed
        return undefined;
    }

    var maxSum = 0;
    var result;

    for (var i = 0; i < nums.length; i++) {
        if (parseInt(nums[i]) !== nums[i]) { // or when some of the arguments is not an integer number
            return undefined;
        }

        var curretNumber = Math.abs(nums[i]).toString();
        var currentSum = 0;

        for (var j = 0; j < curretNumber.length; j++) {
            currentSum += Number(curretNumber[j]);
        }

        if (currentSum >= maxSum) {
            result = nums[i];
            maxSum = currentSum;
        }
    }
    return result;
}

console.log(findLargestBySumOfDigits([5, 10, 15, 111]));
console.log(findLargestBySumOfDigits([33, 44, -99, 0, 20]));
console.log(findLargestBySumOfDigits(['hello']));
console.log(findLargestBySumOfDigits([5, 3.3]));