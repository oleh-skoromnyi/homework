using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP.Task
{
    public class Parser
    {
        public string text { get; set; }
        public List<File> FileList;
        public Dictionary<string, IParser> Parsers;

        public Parser(string textForParsing)
        {
            this.text = textForParsing;
            FileList = new List<File>();
            Parsers = new Dictionary<string, IParser>();
            AddParsers();
        }

        void ParseString(string text)
        {
            string[] type = text.Split(':');
            FileList.Add(Parsers[type[0].Trim()].Parse(type[1]));
        }

        public void WriteToConsole()
        {
            string type = "";
            foreach(var file in FileList)
            {
                if (type != file.Type)
                { 
                    type = file.Type;
                    Console.WriteLine($"{type}s:");
                }
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
        public void GroupAndSort()
        {
            var res = (from item in FileList
                       orderby item.Size
                       group item by item.Type).ToList();
            var newList = new List<File>();
            foreach (var group in res)
            {
                foreach(File file in group)
                {
                    newList.Add(file);
                }
            }
            FileList = newList;
        }
        
        private void AddParsers()
        {
            Parsers.Add("Text", new TextParser());
            Parsers.Add("Image", new ImageParser());
            Parsers.Add("Movie", new MovieParser());
        }

    }
}
