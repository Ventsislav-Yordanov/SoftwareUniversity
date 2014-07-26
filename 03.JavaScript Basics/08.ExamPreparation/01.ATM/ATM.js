function Solve(args) {
    var input = args[0].split(' ');

    var students = parseInt(input[0]);
    var perBox = parseInt(input[1]);
    var cost = parseFloat(input[2]);

    var ofBoxes = ((students + 1) / perBox).toFixed(0);

    console.log(Math.ceil((ofBoxes * cost) / 10) * 10);
}

Solve(["5 2 1.2"]);