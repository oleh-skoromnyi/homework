class Shape
{
    getSquare()
    {
        console.log("Not implemented");
    }
}

class Square extends Shape
{
    constructor(side)
    {
        super();
        this.side = side;
    }
    getSquare(){
        return Math.pow(this.side,2);
    }
}

class Circle extends Shape
{
    constructor(radius)
    {
        super();
        this.radius = radius;
    }
    getSquare(){
        return Math.PI * Math.pow(this.radius,2);
    }
}

var square = new Square(5);
console.log(square.getSquare());
document.writeln("Площадь квадрата со стороной 5 :"+square.getSquare())

var circle = new Circle(5);
console.log(circle.getSquare());
document.writeln("<br/>Площадь круга с радиусом 5 :"+circle.getSquare())