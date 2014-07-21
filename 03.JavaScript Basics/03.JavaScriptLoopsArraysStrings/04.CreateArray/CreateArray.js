function createArray() {
    var myArray = new Array(20);
    for (var i = 0; i < myArray.length; i++) {
        myArray[i] = i * 5;
    }
    myArray.join(",");
    console.log(myArray);
}

createArray();