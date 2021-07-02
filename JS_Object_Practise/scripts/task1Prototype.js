function Shape() {}
Shape.prototype.getSquare = function()
{
        console.log("Not implemented");
}

function Square(side)
{
    this.side = side;
}
Square.prototype = new Shape();
Square.prototype.getSquare = function()
{
    return Math.pow(this.side,2);
}

function Circle(radius)
{
    this.radius = radius;
}
Circle.prototype = new Shape();
Circle.prototype.getSquare = function()
{
    return Math.PI * Math.pow(this.radius,2); 
}


var square = new Square(5);
console.log(square.getSquare());
document.writeln("Площадь квадрата со стороной 5 :"+square.getSquare())

var circle = new Circle(5);
console.log(circle.getSquare());
document.writeln("<br/>Площадь круга с радиусом 5 :"+circle.getSquare())