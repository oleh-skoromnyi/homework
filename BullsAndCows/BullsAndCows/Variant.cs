using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows
{
    public class Variant
    {
        public string Name { get; set; }
        public int Perspectivity { get; set; }

        public Variant(string name, int perspectivity)
        {
            Name = name;
            Perspectivity = perspectivity;
        }
    }
}
