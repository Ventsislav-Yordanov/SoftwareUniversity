function findCardFrequency(value) {
    value = value.replace(/♣/g, "");
    value = value.replace(/♥/g, "");
    value = value.replace(/♦/g, "");
    value = value.replace(/♠/g, "");

    value = value.split(" ");

    var map = {};
    var total = 0;

    for (var i = 0; i < value.length; i++) {
        var count = 0;
        var key = value[i];

        for (var j = 0; j < value.length; j++) {
            if (value[i] === value[j]) {
                count++;
            }
        }
        map[value[i]] = count;
    }

    for (var key in map) {
        total += map[key];
    }

    for (var key in map) {
        console.log(key + " -> " + ((map[key] / total) * 100).toFixed(2) + "%");
    }
}

findCardFrequency('8♥ 2♣ 4♦ 10♦ J♥ A♠ K♦ 10♥ K♠ K♦');
console.log("\n");
findCardFrequency('J♥ 2♣ 2♦ 2♥ 2♦ 2♠ 2♦ J♥ 2♠');
console.log("\n");
findCardFrequency('10♣ 10♥');