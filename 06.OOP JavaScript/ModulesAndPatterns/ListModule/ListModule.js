"use strict";

var ListModule = (function () {

    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    Object.prototype.validateNonEmptyString = function (value, variableName) {
        if (typeof (value) != 'string' || !value) {
            throw new Error(variableName + " should be non-empty string!");
        }
    }

    // ----------ListModuleElement----------
    var ListModuleElement = (function () {
        var ListModuleElement = function (title) {
            this.setTitle(title);
        }

        ListModuleElement.prototype.getTitle = function () {
            return this._title;
        };

        ListModuleElement.prototype.setTitle = function (title) {
            this.validateNonEmptyString(title, "title");
            this._title = title;

            // info about "return this" : 
            // http://stackoverflow.com/questions/8300844/what-does-return-this-do-within-a-javascript-function
            return this;
        };

        return ListModuleElement;
    }());

    // ----------Container----------
    var Container = (function () {
        var Container = function (title, sections) {
            ListModuleElement.call(this, title);
            this.setSections(sections);
        };

        Container.extends(ListModuleElement);

        Container.prototype.getSections = function () {
            return this._sections;
        };

        Container.prototype.setSections = function (sections) {
            this._sections = sections;
            return this;
        };

        Container.prototype.addSection = function (section) {
            this._sections.push(section);
        };

        Container.prototype.addToDOM = function () {
            var target = document.getElementById("wrapper");
            var newElement = document.createElement("DIV");
            newElement.innerHTML = 
                '<div id="container">' +
                '<h1>' + this.getTitle() + '</h1>' +
                '<div id="sectionContainer">' + '</div>' +
                '<input type="text" id="newSectionField" placeholder="Title..." />' +
                '<button class="addNewSection" onclick="addNewSection()">New Section</a>' +
                '</div>';
            target.appendChild(newElement);
        };

        return Container;
    }());

    // ----------Section----------
    var Section = (function () {
        var counter = 0;
        var Section = function (title, items) {
            ListModuleElement.call(this, title);
            this.setItems(items);
            counter++;
        };

        Section.extends(ListModuleElement);

        Section.prototype.getItems = function () {
            return this._items;
        };

        Section.prototype.setItems = function (items) {
            this._items = items;
            return this;
        };

        Section.prototype.addItem = function (item) {
            this._items.push(item);
        };

        Section.prototype.addToDOM = function () {
            var target = document.getElementById("sectionContainer");
            var newElement = document.createElement("DIV");
            newElement.innerHTML =
                '<section class="clearfix" id="section' + counter + '">' +
                '<h2>' + this.getTitle() + '</h2>' +
                '</section>' +
                '<div class="addItem clearfix">' +
                '<input type="text" id="newitemfield' + counter + '" placeholder="Add item..." />' +
                '<button href="#" class="addNewItem" onclick="addNewItem(\'section' + counter + '\', \'newitemfield' + counter + '\')" >+</button>' +
                '</div>';
            target.appendChild(newElement);
        };

        return Section;
    }());

    // ----------Item----------
    var Item = (function () {
        var counter = 0;

        var Item = function (title) {
            ListModuleElement.call(this, title);
            counter++;
        };

        Item.extends(ListModuleElement);

        Item.prototype.addToDOM = function (target) {
            var target = document.getElementById(target);
            var newElement = document.createElement("DIV");
            newElement.innerHTML =
                '<div class="contentBox">' +
                '<input onclick="changeStatus(content' + counter + ')" type="checkbox"  />' +
                '<div class="content" id="content' + counter + '">' + this.getTitle() + '</div>' +
                '</div>';
            target.appendChild(newElement);
        };

        return Item;
    }());

    return {
        ListModuleElement: ListModuleElement,
        Container: Container,
        Section: Section,
        Item : Item
    };

}());