Object.prototype.extends = function (parent) {
    // for old browsers version
    if (!Object.create) {
        Object.prototype.create = function (proto) {
            function F() { };
            F.prototype = proto;
            return new F;
        };
    };

    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

// ----------Shape----------
var Shape = (function () {

    var Shape = function (x, y, color) {
        this._x = x;
        this._y = y;
        this._color = color;
    };

    Shape.prototype = {
        toString: function () {
            var shapeInfo = "X:" + this._x + ", Y:" + this._y + ", Color in hexadecimal format:" + this._color;
            return shapeInfo;
        },
        canvas: function () {
            var canvas = {
                element: document.getElementById("shapesConteiner").getContext("2d")
            };
            return canvas;
        }
    };

    return Shape;

}());

// ----------Circle----------
var Circle = (function () {

    var Circle = function (x, y, color, radius) {
        Shape.call(this, x, y, color);
        this._radius = radius;
    };

    Circle.extends(Shape);

    // -----draw-----
    Circle.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.arc(this._x, this._y, this._radius, 0, 2 * Math.PI, false);
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.fill();
        this.canvas().element.stroke();
    };
    
    Circle.prototype.toString = function () {
        return Shape.prototype.toString.call(this) +
            ", Radius:" + this._radius;
    };

    return Circle;
}());

// ----------Rectangle----------
var Rectangle = (function () {

    var Rectangle = function (x, y, color, width, height) {
        Shape.call(this, x, y, color);
        this._width = width;
        this._height = height;
    };

    Rectangle.extends(Shape);

    // -----draw-----
    Rectangle.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.fillRect(this._x, this._y, this._width, this._height);
    };

    Rectangle.prototype.toString = function () {
        return Shape.prototype.toString.call(this) +
            ", Width:" + this._width +
            ", Height:" + this._height;
    };

    return Rectangle;
}());

// ----------Triangle----------
var Triangle = (function () {

    var Triangle = function (x, y, color, x2, y2, x3, y3) {
        Shape.call(this, x, y, color);
        this._x2 = x2;
        this._y2 = y2;
        this._x3 = x3;
        this._y3 = y3;
    };

    Triangle.extends(Shape);

    // -----draw-----
    Triangle.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.moveTo(this._x, this._y);
        this.canvas().element.lineTo(this._x2 + this._x, this._y2 + this._y);
        this.canvas().element.lineTo(this._x3 + this._x, this._y3 + this._y);
        this.canvas().element.fill();
    };

    Triangle.prototype.toString = function () {
        return Shape.prototype.toString.call(this) +
            ", x2:" + this._x2 +
            ", y2:" + this._y2 +
            ", x3:" + this._x3 +
            ", y3:" + this._y3;
    };

    return Triangle;
}());

// ----------Segment----------
var Segment = (function () {

    var Segment = function (x, y, color, x2, y2) {
        Shape.call(this, x, y, color);
        this._x2 = x2;
        this._y2 = y2;
    };

    Segment.extends(Shape);

    // -----draw-----
    Segment.prototype.draw = function () {
        this.canvas().element.beginPath();
        this.canvas().element.moveTo(this._x, this._y);
        this.canvas().element.lineTo(this._x2 + this._x, this._x2 + this._y);
        this.canvas().element.strokeStyle = this._color;
        this.canvas().element.stroke();
    };

    Segment.prototype.toString = function () {
        return Shape.prototype.toString.call(this) +
            ", x2:" + this._x2 +
            ", y2:" + this._y2;
    };

    return Segment;
}());

// ----------Point----------
var Point = (function () {

    var Point = function (x, y, color) {
        Shape.call(this, x, y, color);
    };

    Point.extends(Shape);

    // -----draw-----
    Point.prototype.draw = function myfunction() {
        this.canvas().element.beginPath();
        this.canvas().element.fillStyle = this._color;
        this.canvas().element.fillRect(this._x, this._y, 3, 3);
    };

    Point.prototype.toString = function () {
        return Shape.prototype.toString.call(this);
    };

    return Point;
}());

//var circle = new Circle(5, 10, "#F94", 30);
//var rectangle = new Rectangle(5, 4, "#FFF", 10, 12);
//var triangle = new Triangle(6, 4, "#F54", 7, 17, 11, 25);
//var segment = new Segment(2, 3, "#001", 5, 16);
//var point = new Point(4, 5, "#ff9");

//console.log(circle.toString());
//console.log(rectangle.toString());
//console.log(triangle.toString());
//console.log(segment.toString());
//console.log(point.toString());