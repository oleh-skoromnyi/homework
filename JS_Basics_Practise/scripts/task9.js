function onClickButton()
{
    document.getElementById('resultString').innerText = combine(
        document.getElementById('text').value
        .split(']')[0].split('[')[1].split(',')
        ,document.getElementById('separator').value);
}

function combine (array,separator)
{
    return array.join(separator);
}