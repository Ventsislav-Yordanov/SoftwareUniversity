function Solve(args) {
    var litersPerGallon = 3;
    var millilitersPerGallon = 785;

    var gallons = parseInt(args);
    console.log((gallons * litersPerGallon + Math.floor(((millilitersPerGallon * gallons) / 1000))) + " " +
                        (millilitersPerGallon * gallons) % 1000);
}

Solve("2");
Solve("5");