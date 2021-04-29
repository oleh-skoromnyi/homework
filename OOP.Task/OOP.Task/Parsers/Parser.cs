using System;
using System.Collections.Generic;
using System.Text;

namespace OOP.Task
{
    public class Parser
    {
        public string text { get; set; }
        public List<TextFile> TextList;
        public List<ImageFile> ImageList;
        public List<MovieFile> MovieList;

        public Parser(string textForParsing)
        {
            this.text = textForParsing;
            TextList = new List<TextFile>();
            ImageList = new List<ImageFile>();
            MovieList = new List<MovieFile>();
        }

        void ParseString(string text)
        {
            string[] type = text.Split(':');
            switch (type[0].Trim())
            {
                case "Text":
                    TextList.Add(TextParser.Parse(type[1]));
                    break;
                case "Image":
                    ImageList.Add(ImageParser.Parse(type[1]));
                    break;
                case "Movie":
                    MovieList.Add(MovieParser.Parse(type[1]));
                    break;
                default:
                    throw new Exception("Unsupported type");
            }
        }

        public void WriteToConsole()
        {
            Console.WriteLine("Text Files:");
            foreach(var file in TextList)
            {
                Console.WriteLine(file.ToString());
            }
            Console.WriteLine("Movies:");
            foreach (var file in MovieList)
            {
                Console.WriteLine(file.ToString());
            }
            Console.WriteLine("Images:");
            foreach (var file in ImageList)
            {
                Console.WriteLine(file.ToString());
            }
        }
        public void Parse()
        {
            string[] files = text.Split('\n');
            foreach (string file in files)
            {
                ParseString(file);
            }
        }
        public void Sort()
        {
            TextList.Sort();
            ImageList.Sort();
            MovieList.Sort();
        }
        
    }
}
