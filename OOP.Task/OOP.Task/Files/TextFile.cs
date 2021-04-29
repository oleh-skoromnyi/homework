using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Task
{
    public class TextFile:File
    {
        public string Content { get; set; }
        public TextFile(string fileName, string size, string content) 
        {
            this.FileName = fileName.Trim();
            this.Extension = GetExtension(fileName);
            this.Size = new Size(size);
            this.Content = content.Trim();
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = BaseOutput();
            stringBuilder.Append($"\t\tContent: \"{Content}\" ");
            return stringBuilder.ToString();
        }
    }
}
