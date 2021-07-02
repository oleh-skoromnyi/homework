class Validator
{
    isValid(string)
    {
        console.log("Not implemented");
    }
}

class EmailValidator extends Validator
{
    expression = "^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
    isValid(emailString)
    {
        return emailString.match(this.expression) != null;        
    }
}

class PhoneValidator extends Validator
{
    expression = "^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
    isValid(phoneString)
    {
        return phoneString.match(this.expression) != null;        
    }
}

var emailValidator = new EmailValidator();
var phoneValidator = new PhoneValidator();
console.log(emailValidator.isValid("email@address.ua"));
console.log(emailValidator.isValid("email_address.ua"));
console.log(phoneValidator.isValid("+380951234567"));
console.log(phoneValidator.isValid("email_address.ua"));
console.log(phoneValidator.isValid("+38095123456799999"));
