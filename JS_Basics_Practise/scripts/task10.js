function onClickButton()
{
    document.getElementById('resultString').innerText = maxMultiple(
        document.getElementById('text').value
        .split(']')[0].split('[')[1].split(','));
}

function maxMultiple (array)
{
    var counter = array.length-1;
    var maxMultiple = 0;
    while(counter > 0)
    {
        let temp = (+array[counter])*(+array[counter-1]);
        if(temp > maxMultiple)
        {
            maxMultiple = temp;
        }
        counter--;
    }
    return maxMultiple;
}