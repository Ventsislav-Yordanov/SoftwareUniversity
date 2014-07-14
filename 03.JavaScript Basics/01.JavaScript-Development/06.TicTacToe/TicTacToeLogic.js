//Global Variables
var painted;
var content;
var winningCombinations;
var turn = 0;
var theCanvas;
var c;
var cxt;
var squaresFilled = 0;
var w;
var y;

//Instanciate Arrays
window.onload = function () {

    painted = new Array();
    content = new Array();
    winningCombinations = [[0, 1, 2], [3, 4, 5], [6, 7, 8], [0, 3, 6], [1, 4, 7], [2, 5, 8], [0, 4, 8], [2, 4, 6]];

    for (var l = 0; l <= 8; l++) {
        painted[l] = false;
        content[l] = '';
    }
}

//GAME METHODS
function canvasClicked(canvasNumber) {
    theCanvas = "canvas" + canvasNumber;
    c = document.getElementById(theCanvas);
    cxt = c.getContext("2d");

    if (painted[canvasNumber - 1] == false) {
        if (turn % 2 == 0) {
            cxt.beginPath();
            cxt.strokeStyle = '#ff0000';
            cxt.lineWidth = 5;
            cxt.moveTo(10, 10);
            cxt.lineTo(40, 40);
            cxt.moveTo(40, 10);
            cxt.lineTo(10, 40);
            cxt.stroke();
            cxt.closePath();
            content[canvasNumber - 1] = 'X';
        }
        else {
            cxt.beginPath();
            cxt.strokeStyle = '#fff';
            cxt.lineWidth = 5;
            cxt.arc(25, 25, 18, 0, Math.PI * 2, true);
            cxt.stroke();
            cxt.closePath();
            content[canvasNumber - 1] = 'O';
        }

        turn++;
        painted[canvasNumber - 1] = true;
        squaresFilled++;
        checkForWinners(content[canvasNumber - 1]);

        if (squaresFilled == 9) {
            alert("THE GAME IS OVER");
            location.reload(true);
        }
    }
    else {
        alert("THAT SPACE IS ALREADY OCCUPIED WITH YOUR HEART!");
    }
}

function checkForWinners(symbol) {
    for (var a = 0; a < winningCombinations.length; a++) {
        if (content[winningCombinations[a][0]] == symbol &&
            content[winningCombinations[a][1]] == symbol &&
            content[winningCombinations[a][2]] == symbol) {
            alert("Player with " + symbol + " symbol is WINNER");
            playAgain();
        }
    }
}

function playAgain() {
    y = confirm("PLAY AGAIN ?");
    if (y == true) {
        location.reload(true);
    }
    else {
        alert("SO LONG, SUCKER!");
    }
}