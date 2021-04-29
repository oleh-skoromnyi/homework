using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Task
{
    public class ImageFile:File
    {
        //Разрешение изображения
        public string Resolution { get; set; }
        public ImageFile(string fileName, string size, string resolution)
        {
            this.FileName = fileName.Trim();
            this.Extension = GetExtension(fileName);
            this.Size = new Size(size);
            this.Resolution = resolution.Trim();
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = BaseOutput();
            stringBuilder.Append($"\t\tResolution: {Resolution}");
            return stringBuilder.ToString();
        }

    }
}
