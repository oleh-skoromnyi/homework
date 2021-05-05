using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Task
{
    public class MovieParser:IParser
    {
        public File Parse(string text) 
        {
            //В коментариях ниже разбор строки на примере
            //logan.2017.mkv(19GB);1920х1080;2h12m
            string[] parsedData = text.Split(';');
            //1920х1080
            string resolution = parsedData[1];
            //2h12m
            string length = parsedData[2];
            //logan.2017.mkv(19GB) -> logan.2017.mkv & 19GB
            string[] parsedData2 = parsedData[0].Split('(',')');
            //logan.2017.mkv
            string fileName = parsedData2[0];
            //19GB
            string size = parsedData2[1];
            MovieFile movieFile = new MovieFile(fileName, size, resolution, length);
            return movieFile;
        }
    }
}
