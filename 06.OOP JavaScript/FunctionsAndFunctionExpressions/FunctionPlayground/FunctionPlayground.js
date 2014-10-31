function playground() {
    console.log("Number of arguments:" + arguments.length);
    for (var i = 0; i < arguments.length; i++) {
        // console.log(i + ".Argument" + ": Value:" + arguments[i] + ", type:" + typeof arguments[i]);
        // info abouts placeholders : http://stravid.com/en/improve-your-javascript-console-log-friendship/
        console.log("%s.Argument: Value:%s, Type:%s",i, arguments[i], typeof arguments[i]);
    }

    console.log();
}

var myArray = [1, 2, 3];

playground("Venci", 20, myArray);
playground("Mitko", "Pesho");
playground("Venci", 20);

// http://stackoverflow.com/questions/1986896/what-is-the-difference-between-call-and-apply
playground.call(null, "example", 69);
playground.apply(null, ["Papoi", "funny"]);