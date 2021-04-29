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

        File ParseString(string text)
        {
            string[] type = text.Split(':');
            switch (type[0].Trim())
            {
                case "Text":
                    return TextParser.Parse(type[1]);
                case "Image":
                    return ImageParser.Parse(type[1]);
                case "Movie":
                    return MovieParser.Parse(type[1]);
            }
            throw new Exception("Unsupported type");
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
            List<TextFile> textList = new List<TextFile>();
            List<ImageFile> imageList = new List<ImageFile>();
            List<MovieFile> movieList = new List<MovieFile>();
            foreach (string file in files)
            {
                File parsedFile = ParseString(file);
                switch (parsedFile)
                {
                    case TextFile text:
                        TextList.Add((TextFile)parsedFile);
                        break;
                    case ImageFile image:
                        ImageList.Add((ImageFile)parsedFile);
                        break;
                    case MovieFile movie:
                        MovieList.Add((MovieFile)parsedFile);
                        break;
                }
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
