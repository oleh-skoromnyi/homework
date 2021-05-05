using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Task
{
    public class ImageParser:IParser
    {
        public File Parse(string text)
        {
            //В коментариях ниже разбор строки на примере
            //img.bmp(19MB);1920х1080
            string[] parsedData = text.Split(';');
            //1920х1080
            string resolution = parsedData[1];
            //img.bmp(19MB) -> img.bmp & 19MB
            string[] parsedData2 = parsedData[0].Split('(', ')');
            //img.bmp
            string fileName = parsedData2[0];
            //19MB
            string size = parsedData2[1];
            ImageFile imageFile = new ImageFile(fileName, size, resolution);
            return imageFile;
        }
    }
}
