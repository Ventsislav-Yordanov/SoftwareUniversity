function calcCircleArea () {
    var radius = document.getElementById('inputRadius').value;
    document.body.innerHTML += "r = " + radius + "; area = " + (Math.PI * Math.pow(radius, 2)).toFixed(14) + "<br />";
}