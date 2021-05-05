using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Task
{
    public interface IParser
    {
        abstract File Parse(string text);
    }
}
