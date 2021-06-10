using System;
using System.Collections.Generic;
using System.Text;

namespace EFPractice.Core.Entities
{
    public class AudioFile : File
    {
        public string Bitrate { get; set; }
        public string SampleRate { get; set; }
        public int ChannelCount { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
