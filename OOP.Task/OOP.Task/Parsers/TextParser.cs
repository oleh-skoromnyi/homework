using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Task
{
    public class TextParser:IParser
    {
        public File Parse(string text)
        {
            //В коментариях ниже разбор строки на примере
            //file.txt(6B);Some string content
            string[] parsedData = text.Split(';');
            //Some string content
            string content = parsedData[1];
            //file.txt(6B) -> file.txt & 6B
            string[] parsedData2 = parsedData[0].Split('(',')');
            //file.txt
            string fileName = parsedData2[0];
            //6B
            string size = parsedData2[1];
            TextFile textFile = new TextFile(fileName, size, content);
            return textFile;
        }
    }
}
