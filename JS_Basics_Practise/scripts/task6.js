function countLetters()
{
    document.getElementById('numberCount').innerText = count(document.getElementById('text').value);
}

function count (str)
{
    let counter = 0;
    let countLetters = new Array('a', 'e', 'i', 'o', 'u', 'y');
    for(letter in str)
    {
        if(countLetters.includes(str[letter].toLowerCase()))
        {
            counter++;
        }
    }
    return counter;
}