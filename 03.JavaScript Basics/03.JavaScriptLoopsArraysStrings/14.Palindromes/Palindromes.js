function findPalindromes(input) {
    input = input.toLowerCase();
    input = input.replace(".", "");
    input = input.split(" ");

    var palindromes = [];

    for (var i = 0; i < input.length; i++) {
        var reversed = input[i].split("").reverse().join("");
        if (input[i] === reversed) {
            palindromes.push(input[i]);
        }
    }

    return palindromes;
}

console.log(findPalindromes('There is a man, his name was Bob.'));
console.log(findPalindromes('ABBA were a Swedish pop group formed in Stockholm in 1972, comprising Agnetha Fältskog, Björn Ulvaeus, Benny Andersson, and Anni-Frid Lyngstad.'));