function solve(args) {
    var count = 0;
    var map = {};

    for (var i = 0; i < args.length - 1 ; i++) {

        var couple = args[i] + " " + args[i + 1];

        for (var j = 0; j < args.length - 1; j++) {
            var testCouple = args[j] + " " + args[j + 1];
            if (couple === testCouple) {
                count++;
            }
        }
        map[couple] = count;
        count = 0;
    }

    var sortableArr = [];
    for (var item in map) {
        sortableArr.push([item, map[item]]); // вкараваме array в array
    }
    sortableArr.sort(function (a, b) { return b[1] - a[1] }); //
    var d = 1.0;
    for (var i = 0; i < sortableArr.length; i++) {
        var o = sortableArr[i];
        console.log("%s -> %s%", o[0], (o[1] / (args.length - 1) * 100).toPrecision(4));

    }
}

solve([3, 4, 2, 3, 4, 2, 1, 12, 2, 3, 4]);