function ShowObjectMethodsAndFields(obj)
{
    for(var key in obj)
    {
        console.log(key);
    }
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

ShowObjectMethodsAndFields(people);