function changeString()
{
    document.getElementById('text').value = addPy(document.getElementById('text').value);
}

function addPy (str)
{
    if(!str.startsWith('Py') && str !== "")
    {
        return 'Py'+str;
    }
}