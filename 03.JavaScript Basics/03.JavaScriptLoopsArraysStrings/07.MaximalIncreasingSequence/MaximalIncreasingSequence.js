function findMaxSequence(inputArray) {
    var length = 1;
    var bestLength = 0;
    var ednIndex = 0;
    
    // main logic
    for (var i = 0; i < inputArray.length - 1; i++) {

        if (inputArray[i] < inputArray[i + 1]) {
            length++;

        } else {

            if (length > bestLength) {
                bestLength = length;
                ednIndex = i;
            }
            length = 1;
        }
    }
    
    // checking a special last case
    if (length > bestLength) {
        bestLength = length;
        ednIndex = inputArray.length - 1;
    }
    
    // output
    if (bestLength < 2) { 
        console.log("No");
    } else { 
        var outputArray = [];
        for (i = ednIndex - bestLength + 1; i < ednIndex + 1; i++) {
            outputArray.push(inputArray[i]);
        }
        console.log(outputArray);
    }
}

findMaxSequence([3, 2, 3, 4, 2, 2, 4]);
findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]);
findMaxSequence([3, 2, 1]);