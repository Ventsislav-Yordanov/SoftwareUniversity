// "SELECTION SORT" ALGORITHM
function sortArray(arr) {
    var helper;
    
    for (var i = 0; i < arr.length; i++) {
        for (var j = i; j < arr.length; j++) {
            if (arr[j] < arr[i]) {
                helper = arr[i];
                arr[i] = arr[j];
                arr[j] = helper;
            }
        }
    }
    return arr;
}

console.log(sortArray([5, 4, 3, 2, 1]));
console.log(sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]));



/*function sortArray(numbers) {
    function orderBy(a, b) {  //info : http://stackoverflow.com/questions/1063007/arr-sort-does-not-sort-integers-correctly
        return a - b;
    }

    numbers.sort(orderBy);
    return numbers;
}

console.log(sortArray([5, 4, 3, 2, 1]));
console.log(sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]));*/