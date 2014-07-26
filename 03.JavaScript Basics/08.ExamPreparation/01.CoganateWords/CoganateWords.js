function Solve(args) {
    var allWords = args[0].split(/[^A-Za-z]/);
    var uniqueMatches = [];
    
    for (var i = 0; i < allWords.length; i++) {
        for (var j = 0; j < allWords.length; j++) {
            if (allWords[i] !== '' && allWords[j] !== '') {
                var currWord = allWords[i] + allWords[j];
                for (var k = 0; k < allWords.length; k++) {
                    if (i !== j) {
                        if (currWord === allWords[k]) {
                            var result = allWords[i] + "|" + allWords[j] + "=" + allWords[k];
                            if (uniqueMatches.indexOf(result) === -1) {
                                uniqueMatches.push(result);
                            }
                        }
                    }
                }
            }
        }
    }
    if (uniqueMatches.length > 0) {
        var res = uniqueMatches.join('\n');
        console.log(res);
       //return res;
    }else {
        console.log("No");
        //return "No";
    }
}

Solve(['java..?|basics/*-+=javabasics']);