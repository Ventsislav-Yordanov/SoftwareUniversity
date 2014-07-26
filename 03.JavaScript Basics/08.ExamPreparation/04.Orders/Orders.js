function Solve(args) {
    var map = {};

    var n = parseInt(args[0]);
    Array.prototype.toString = function () { // тази функция ще посочи как да се дисплейне масива в общият случай
        return this.join(' ');
    }

    for (var i = 0; i < n; i++) {
        var splitHolder = args[i + 1].split(' '); // раздробяваме стринга на 3 елемента

        if (!(splitHolder[2] in map)) { // проверяваме дали има item с такъв key - ако няма - влизаме в този IFS
            map[splitHolder[2]] = []; // създаваме глобален масив, който ще държи всички [имена и стойности]
                                      // т.е. ще имаме "apples" = [[maria, 9][alben, 10][gonzo, 11]];
            map[splitHolder[2]][0] = []; // създаваме масив за всеки отделен човек
            map[splitHolder[2]][0].toString = function () { // конкретно за тези които са във map[splitHolder[2]][0],
                return this.join(', '); // т.е. свързването между отделните масиви в глобалният масив
            }
            var temp = []; // този масив ще използвам за да push-на 2те properties
            temp.push(splitHolder[0]);
            temp.push(parseInt(splitHolder[1]));

            map[splitHolder[2]][0].push(temp); // и след това pushвам масива temp в глобалният като отделен "order"
        }
        else { // ако имаме вече такъв ключ
            var found = false;

            // използвам този цикъл за да проверя всеки масив в глобалният по име и да увелича стойноста на плодовете
            for (var j = 0; j < map[splitHolder[2]][0].length; j++) {
                if (map[splitHolder[2]][0][j][0] == splitHolder[0]) { // ако намерим такова име
                    // увеличаваме вроя на плодовете , като към предната стойност добавяме новата
                    map[splitHolder[2]][0][j][1] += parseInt(splitHolder[1]);
                    found = true; // добавяме флаг за да знаме дали да добавим нов "order"
                }
            }

            if (!found) { // ако не е намерен "not found" такъв "order" от цикълът горе, добавяме
                var temp = []; // същата процедура като в първият IF
                temp.push(splitHolder[0]);
                temp.push(parseInt(splitHolder[1]));

                map[splitHolder[2]][0].push(temp);
            }

            // сортирам с помощта на "override" на compare  за да мога да взема стойност на първият елемент
            // т.е. на името и по него сравнявам
            map[splitHolder[2]][0].sort(compare);
        }
    }
    
    for (var key in map) {
        console.log("%s: %s", key, map[key]); // принриам готовият резултат
    }

    function compare(a, b) {
        // а и b са масиви , функцията sort иползва a и b за да подрежда елементите в зависимост от каква стойност връщат
        // ако името на b е по-голямо се връща -1 , т.е. представете си го така : ако лявата страна е по-малка връща : -1
        // както е в кординатната система "а" е отляво и ако е по-малко се връща -1 
        // ако b е по-малко, гледаме дясната страна на кординатната и връща 1
        // ако са равни връща 0 , така като са масиви, можем да надникнем в имента с индекса "0"
        if(a[0] < b[0]) {
            return -1;
        }
        if (b[0] < a[0]) {
            return 1;
        }

        return 0;
    }
}