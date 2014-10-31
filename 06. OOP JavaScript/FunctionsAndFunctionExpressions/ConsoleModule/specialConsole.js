var specialConsole = (function () {
    'use strict';

    function writeLine() {
        var stringToPrint = arguments[0];

        if (arguments.length > 1) {
            // info about "how work Array.prototype.slice.call(arguments);"
            // http://stackoverflow.com/questions/7056925/how-does-array-prototype-slice-call-work
            var args = Array.prototype.slice.call(arguments);
            var replacements = args.slice(1, args.length);

            replacements.forEach(function (message, index) {
                stringToPrint = stringToPrint.replace('{' + index + '}', message);
            });

            console.log(stringToPrint);
        } else {
            console.log(arguments[0].toString());
        }
    }

        return {
            // TODO : for error : print with console.error, for warningn with console.warn
            writeLine: writeLine,
            writeError: writeLine,
            writeWarning: writeLine
        };
})();

specialConsole.writeLine("I hate OOP in JavaScript");
specialConsole.writeLine("My age: {0}", 20);
specialConsole.writeLine("My age: {0}, my name: {1}", 20, "Pesho");