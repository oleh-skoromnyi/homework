function GetObjectKeyValuePairArray(obj)
{
    return Object.entries(obj)
}

class People
{
    constructor(id,name,surname)
    {
        this.id = id;
        this.name = name;
        this.surname = surname;
    }
    getName = function() {
        return this.name;
    }
    getFullName = function() {
        return this.name+' '+this.surname;
    }
}

var people = new People(1,'Oleh','Scoromnyi');

console.log(GetObjectKeyValuePairArray(people));