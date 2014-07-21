function MostFrequentNumber(inputArray) {
    var frequency = 0;
    var bestFrequency = 0;
    var element;

    for (var i = 0; i < inputArray.length; i++) {
        frequency = 0;

        for (var j = 0; j < inputArray.length; j++) {

            if (inputArray[i] === inputArray[j]) {
                frequency++;

                if (frequency > bestFrequency) {
                    bestFrequency = frequency;
                    element = inputArray[i];
                }
            }
        }
    }
    return element + " (" + bestFrequency + " times)";
}

console.log(MostFrequentNumber([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]));
console.log(MostFrequentNumber([2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1]));
console.log(MostFrequentNumber([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]));