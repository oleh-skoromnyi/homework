using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Task
{
    public class ImageFile:File
    {
        public Resolution Resolution { get; private set; }
        public ImageFile(string fileName, string size, string resolution)
        {
            this.Type = "Image";
            this.FileName = fileName.Trim();
            this.Extension = GetExtension(fileName);
            this.Size = new Size(size);
            this.Resolution = new Resolution(resolution.Trim());
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = BaseOutput();
            stringBuilder.Append($"\t\tResolution: {Resolution}");
            return stringBuilder.ToString();
        }

    }
}
