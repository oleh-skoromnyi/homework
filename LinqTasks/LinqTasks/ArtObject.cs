using System;
using System.Collections.Generic;
using System.Text;

namespace LinqTasks
{
    public abstract class ArtObject
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }

    public class Film : ArtObject
    {

        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }

    public class Actor
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    public class Article : ArtObject
    {
        public int Pages { get; set; }
    }

}
