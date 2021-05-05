using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OOP.Task
{
   public class Resolution
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Resolution(string resolution)
        {
            Regex re = new Regex(@"(\D+)");
            Match result = re.Match(resolution);

            string[] parsedResolution = resolution.Split(result.Groups[0].Value[0]);
            Width = Int32.Parse(parsedResolution[0]);
            Height = Int32.Parse(parsedResolution[1]);
        }

        public override string ToString()
        {
            return $"{Width}x{Height}";
        }
    }
}
