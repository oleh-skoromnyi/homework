using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OOP.Task
{
    public class Size : IComparable<Size>
    {
        public enum BytePrefix {B,KB,MB,GB};
        public int Value { get; set; }
        public BytePrefix CurrentBytePrefix { get; set; }

        public Size(string text)
        {
            Regex re = new Regex(@"(\d+)([a-zA-Z]+)");
            Match result = re.Match(text);

            Value = Int32.Parse(result.Groups[1].Value);
            CurrentBytePrefix = (BytePrefix)Enum.Parse(typeof(BytePrefix), result.Groups[2].Value);
        }

        public int CompareTo(Size size)
        {
            if (this.CurrentBytePrefix != size.CurrentBytePrefix)
                return this.CurrentBytePrefix - size.CurrentBytePrefix;
            else
                return this.Value - size.Value;
        }

        public override string ToString()
        {
            return $"{Value}{Enum.GetName(typeof(BytePrefix), CurrentBytePrefix)}";
        }
    }
}
