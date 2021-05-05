using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Task
{
    public abstract class File:IComparable<File>
    {
        public string Type { get; protected set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public Size Size { get; set; }
        public int CompareTo(File file)
        {
            int temp = this.Size.CompareTo(file.Size);
            if (temp != 0)
                return temp;
            else
                return FileName.CompareTo(file.FileName);
        }
        //Общая часть вывода файла в строку
        public StringBuilder BaseOutput()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"\t{FileName}\r\n");
            stringBuilder.Append($"\t\tExtension: {Extension}\r\n");
            stringBuilder.Append($"\t\tSize: {Size.ToString()}\r\n");
            return stringBuilder;
        }
        //Получение расширения файла
        protected string GetExtension(string fileName)
        {
           return fileName.Split('.').LastOrDefault();
        }
    }
}
