(function()
{
    let startYear = 2014
    let endYear = 2050;
    let tempYear = startYear;
    while(tempYear !== endYear)
    {
        let currentYear = new Date(tempYear,1,1);
        if(currentYear.getDay() === 6)
        {
            console.log(currentYear.getFullYear())
        }
        tempYear++
    }
})()