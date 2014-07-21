function findMaxSequence(sequence) {
    var currSequence = [sequence[0]];
    var maxSequence = [sequence[0]];

    for (var i = 1; i < sequence.length; i += 1) {
        var currentElement = sequence[i];
        var previousElement = sequence[i - 1];

        if (currentElement === previousElement) {
            currSequence.push(currentElement);
            if (i === sequence.length - 1 && maxSequence.length <= currSequence.length) {
                maxSequence = currSequence;
            }
        } else {

            if (maxSequence.length <= currSequence.length) {
                maxSequence = currSequence;
            }
            currSequence = [currentElement];
        }
    }
    console.log(maxSequence);
}

findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
findMaxSequence(['happy']);
findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']);