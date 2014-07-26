function Solve(args) {
    var map = {};

    for (var i = 0; i < args.length; i++) {
        var inputHolder = args[i].split(/[^a-zA-Z0-9]+/);

        inputHolder = inputHolder.filter(function (n) {
            return n != '';
        });

        var score = inputHolder[2];
        var name = inputHolder[0] + " " + inputHolder[1];
        var mark = parseFloat(inputHolder[3]);

        if (!(score in map)) {
            map[score] = [mark, []];
            map[score][1].push(name);
        } else {
            map[score][0] += mark;
            if (map[score][1].indexOf(name) == -1) {
                map[score][1].push(name);
            }
        }
    }

    for (var key in map) {
        map[key][1].sort();
        var result = key + " -> " + map[key][1].join(", ") + "; avg=" + (map[key][0] / map[key][1].length).toFixed(2);
        console.log(result);
    }
}

Solve(["| George Ivanov       | 306        | 5.26  |",
"| George Stefanov     | 120        | 3.12  |",
"| Petya Koleva        | 400        | 6.00  |",
"| Aleksandar Stoyanov | 300        | 5.00  |",
"| Diana Kirova        | 120        | 3.23  |",
"| Ivan Ivanov         | 0          | 2.00  |",
"| Kalin Petrov        | 300        | 5.40  |",
"| Stoyan Kotsev       | 400        | 5.00  |",
"| Krasimir Mihaylov   | 400        | 5.98  |"]);