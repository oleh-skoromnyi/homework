function onClickButton()
{
    document.getElementById('resultString').innerText = getSquare(
        document.getElementById('text').value);
}

function getSquare (n)
{
    var side = 0;
    if(n>1)
    {
        side = 2*n-1    
    }
    else
    {
        side = n;
    }
    var result = Math.pow(side,2);
    var except = 0;
    var counter = n-1;
    while(counter>0)
    {
        except = except + counter;
        counter--;
    }
    return result - 4*except;
}