﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Task
{
    public class MovieFile:File
    {
        //Разрешение видео
        public string Resolution { get; set; }
        //Продолжительность видео
        public string Length { get; set; }
        public MovieFile(string fileName, string size, string resolution, string length)
        {
            this.FileName = fileName.Trim();
            this.Extension = GetExtension(fileName);
            this.Size = new Size(size);
            this.Resolution = resolution.Trim();
            this.Length = length.Trim();
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = BaseOutput();
            stringBuilder.Append($"\t\tResolution: {Resolution}\r\n");
            stringBuilder.Append($"\t\tLength: {Length}");
            return stringBuilder.ToString();
        }

    }
}
