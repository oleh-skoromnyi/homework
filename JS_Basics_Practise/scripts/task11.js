function onClickButton()
{
    document.getElementById('resultString').innerText = deleteDublicate(
        document.getElementById('text').value
        .split(']')[0].split('[')[1].split(','));
}

function deleteDublicate (array)
{
    var result = new Array();
    for(index in array)
    {
        if(!result.includes(array[index]))
        { 
            result.push(array[index]);
        }
    }
    return result;
}