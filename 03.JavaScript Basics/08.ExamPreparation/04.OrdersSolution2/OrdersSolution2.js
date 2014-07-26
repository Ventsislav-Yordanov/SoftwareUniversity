function Solve(args) {
    var orders = [];
    for (var i = 1; i < args.length; i++) {
        orders.push(args[i].split(' '));
    }
    
    var assArr = {};
    for (var j = 0; j < orders.length; j++) {
        var product = orders[j][2];
        var customer = orders[j][0];
        var amount = Number(orders[j][1]);
        if (!(product in assArr)) {
            assArr[product] = {};
            assArr[product][customer] = amount;
        } else if (product in assArr && !(customer in assArr[product])) {
            assArr[product][customer] = amount;
        } else {
            assArr[product][customer] += amount;
        }
    }
    
    var output = "";
    for (var prod in assArr) {
        output += prod + ": ";
        var array = [];
        for (var key in assArr[prod]) {
            var string = key + " " + assArr[prod][key];
            array.push(string);
        }
        output += array.sort().join(', ') + "\n";
    }
    
    return output;
}

console.log(Solve(['8', "steve 8 apples", "maria 3 bananas", "kiro 3 bananas", "kiro 9 apples", "maria 2 apples", "steve 4 apples",
    "kiro 1 bananas", "kiro 1 apples"
]));

console.log(Solve(['7', "bob 3 whiskeys", "kiro 1 beers", "mimi 2 beers", "alex 4 beers", "alex 1 beers", "kiro 1 vodkas",
    "bob 10 beers"
]));