function onClickButton()
{
    document.getElementById('resultArray').innerText = getLastNElements(
        document.getElementById('text').value
        .split(']')[0].split('[')[1].split(',')
        ,document.getElementById('count').value);
}

function getLastNElements (array,n)
{
    var counter = n;
    if(!isNaN(n))
    {
        if(counter > array.length)
        {
            counter = array.length;
        }
        else
        {
            counter = n;  
        }
    }
    else
    {
        counter = 0;
    }
    var result = new Array();
    while(counter !== 0)
    {
        result.push(array[array.length-counter]);
        counter--;
    }
    console.log(result);
    return result;
}