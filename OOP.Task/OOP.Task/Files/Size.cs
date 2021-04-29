using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OOP.Task
{
    public class Size : IComparable<Size>
    {
        public enum Types {B,KB,MB,GB};
        public int Value { get; set; }
        public Types Type { get; set; }

        public Size(string text)
        {
            Regex re = new Regex(@"(\d+)([a-zA-Z]+)");
            Match result = re.Match(text);

            Value = Int32.Parse(result.Groups[1].Value);
            Type = (Types)Enum.Parse(typeof(Types), result.Groups[2].Value);
        }

        public int CompareTo(Size size)
        {
            if (this.Type != size.Type)
                return this.Type - size.Type;
            else
                return this.Value - size.Value;
        }

        public override string ToString()
        {
            return $"{Value}{Enum.GetName(typeof(Types), Type)}";
        }
    }
}
