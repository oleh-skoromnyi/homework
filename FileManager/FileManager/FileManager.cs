using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace FileManager
{
    public class FileManager
    {
        DirectoryInfo currentDirectory;

        public FileManager()
        {
            currentDirectory = new DirectoryInfo(@"c:\");
        }
        public List<String> GetFilesAndDirectories()
        {
            return currentDirectory.GetDirectories().Select(x => '/' + x.Name).
                Concat(currentDirectory.GetFiles().Select(x => x.Name)).ToList();
        }
        public void GoUpper()
        {
            if (currentDirectory.Parent != null)
            {
                currentDirectory = currentDirectory.Parent;
            }
        }
        public void GoDown(string path)
        {
            try
            {
                var result = currentDirectory.GetDirectories().Where(x => x.Name == path);
                if (result.Any())
                {
                    result.First().GetDirectories();
                    currentDirectory = result.First();
                }
                else
                {
                    throw new Exception("Папка не найдена.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удалось получить доступ к папке. Причина - {e.Message}");
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
            }
        }
        public void OpenFile(string path)
        {
            var result = currentDirectory.GetFiles().Where(x => x.Name == path);
            try
            {
                if (result.Any())
                {
                    var file = result.First();
                    Console.Clear();
                    var textFileExtensions = new List<string>
                    {
                        ".txt", ".ini", ".json"
                    };
                    if (textFileExtensions.Contains(file.Extension))
                    {
                        using (var streamReader = new StreamReader(file.OpenRead()))
                        {
                            Console.WriteLine(streamReader.ReadToEnd());
                        }
                    }
                    else
                    {
                        using (var binaryReader = new BinaryReader(file.OpenRead()))
                        {
                            binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);
                            while (binaryReader.BaseStream.Length != binaryReader.BaseStream.Position)
                            {
                                var byteString = BitConverter.ToString(binaryReader.ReadBytes(1));
                                Console.Write(byteString+' ');
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Файл не найден.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не удалось открыть файл. Причина - {e.Message}");
            }
            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
        }
        public void StartConsoleFileManager()
        {
            string input = String.Empty;
            while (input != "exit")
            {
                Console.Clear();
                foreach (var item in GetFilesAndDirectories())
                {
                    Console.WriteLine(item);
                }

                input = Console.ReadLine();
                if (input.StartsWith("cd"))
                {
                    var path = input.Remove(0, 2).Trim();
                    if (path == "..")
                    {
                        GoUpper();
                    }
                    else
                    {
                        GoDown(path);
                    }
                }
                else
                {
                    if (input != "exit")
                    {
                        OpenFile(input.Trim());
                    }
                }
            }
        }
    }
}
