function countSubstringOccur(input) {
    var substr = input[0];
    var str = input[1];
    var strToLower = str.toLowerCase();
    
    var myRegex = new RegExp(substr, 'g'); //create a regex to match
    var count = strToLower.match(myRegex);
    
    return count.length;
}

console.log(countSubstringOccur(["in", "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days."]));
console.log(countSubstringOccur(["your", "No one heard a single word you said. They should have seen it in your eyes. What was going around your head."]));
console.log(countSubstringOccur(["but", "But you were living in another world tryin' to get your message through."]));