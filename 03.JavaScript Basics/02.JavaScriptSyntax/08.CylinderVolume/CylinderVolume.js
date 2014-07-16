function calcCylinderVol(radius, height) {
    return (Math.PI * Math.pow(radius, 2) * height).toFixed(3);
}

console.log(calcCylinderVol(2, 4));
console.log(calcCylinderVol(5, 8));
console.log(calcCylinderVol(12, 3));