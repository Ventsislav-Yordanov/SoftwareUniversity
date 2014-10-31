var domModule = function () {
    var appendChildElement = function (parentElement, childElement) {
        var parentElement = document.querySelector(parentElement);
        var newElement = document.createElement(childElement);
        parentElement.appendChild(newElement);
    };

    var removeElement = function (parentSelector, childeSelector) {
        var parent = document.querySelector(parentSelector);
        var child = document.querySelector(childeSelector);
        parent.removeChild(child);
    };

    var addHandler = function (selector, eventName, callbackFunction) {
        //var elemenent = document.querySelector(selector);
        //elemenent.addEventListener(eventName, callbackFunction);
        var elements = document.querySelectorAll(selector);
        for (var i = 0; i < elements.length; i++) {
            elements[i].addEventListener(eventName, callbackFunction);
        }
    };

    var retrieveAllElements = function (selector) {
        var elements = document.querySelectorAll(selector);
        return elements;
    }

    return {
        appendChildElement: appendChildElement,
        removeElement: removeElement,
        addHandler: addHandler,
        retrieveAllElements: retrieveAllElements
    }
}();


function alertLi(){
    alert("I'm a li!");
}
domModule.appendChildElement('body', 'div');
domModule.appendChildElement('body', 'textarea');
domModule.appendChildElement('body', 'textarea');
domModule.removeElement('body', 'header');
domModule.addHandler("li", 'click', alertLi);
console.log(domModule.retrieveAllElements('textarea'));