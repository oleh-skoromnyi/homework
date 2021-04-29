using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Task
{
    public abstract class File:IComparable<File>
    {
        //Имя файла
        public string FileName { get; set; }
        //Расширение файла
        public string Extension { get; set; }
        //Размер файла
        public Size Size { get; set; }
        public int CompareTo(File file)
        {
            return this.Size.CompareTo(file.Size);
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
        public string GetExtension(string fileName)
        {
           var temp = fileName.Split('.');
           return temp[temp.Length - 1];
        }
    }
}
