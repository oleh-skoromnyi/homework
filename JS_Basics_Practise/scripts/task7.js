function onClickButton()
{
    document.getElementById('hasOneAtConer').innerText = hasOneAtConer(document.getElementById('text').value
        .split(']')[0].split('[')[1].split(','));
}

function hasOneAtConer (array)
{
    if(+array[0] === 1 || +array[array.length - 1] === 1)
    {
        return true; 
    }
    return false;
}