(function () 
{
    var div = document.createElement("div");
    div.setAttribute("id","clock");
    let date = new Date();
    div.append(date.getDate()+"-"+date.getUTCMonth()+"-"+date.getFullYear()+
    " "+date.getHours()+":"+date.getMinutes()+":"+date.getSeconds());
    document.body.append(div);
    setInterval(updateDate,1000);
})()

function updateDate()
{
    let date = new Date();
    document.getElementById("clock").innerText = date.getDate()+"-"+date.getUTCMonth()+"-"+date.getFullYear()+
        " "+date.getHours()+":"+date.getMinutes()+":"+date.getSeconds() 
}
