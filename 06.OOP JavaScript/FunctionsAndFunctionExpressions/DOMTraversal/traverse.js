function traverse(selector) {
    'use strict';

    var element = document.querySelector(selector);
    traverseElement(element, '');

    function traverseElement(element, spacing) {
        var elementAsString;

        spacing = spacing || "    ";

        elementAsString = spacing + element.nodeName.toLowerCase() + ":";

        if (element.hasAttribute('id')) {
            elementAsString += ' id="' + element.id + '"';
        }

        if (element.hasAttribute('class')) {
            elementAsString += ' class="' + element.className + '"';
        }

        console.log(elementAsString);

        [].forEach.call(element.childNodes, function (child) {
            // info about nodeType: http://www.w3schools.com/jsref/prop_node_nodetype.asp
            // Check if nodeType is element
            if (child.nodeType === 1) {
                traverseElement(child, spacing + "    ");
            }
        });
    }
}

var selector = ".birds";
traverse(selector);