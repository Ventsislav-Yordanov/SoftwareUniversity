var currentDate = new Date();
var hours = currentDate.getHours();
var mins = currentDate.getMinutes();

if (mins < 10) {
    console.log(hours + ":0" + mins);
} else {
    console.log(hours + ":" + mins);
}