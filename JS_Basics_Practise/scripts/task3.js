(function()
{
    let winNumber = Math.floor((Math.random()*19)+1);
    let win = 0;
    let input;
    while(win === 0)
    {
        input = +prompt("input number from 1 to 20")
        if(!isNaN(input))
        {
            if(input === winNumber)
            {
                win = 1
            }
            else
            {
                if(input > winNumber)
                {
                    alert("Your number is bigger");
                }
                else
                {
                    alert("Your number is lesser");
                }
            }
        }
    }   
    alert("You win")
})()