using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.Core.Entities
{
    public class VideoFile : File
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
