using System;

namespace OOP.Task
{
    class Program
    {
        static void Main(string[] args)
        {
            //Добавлена дополнительная строка для проверки корректной сортировки
            String text = @"Text: file.txt(6B); Some string content
            Text: bigFile.docx(4MB); There is a lot of content
            Image: img.bmp(19MB); 1920х1080
            Text:data.txt(12B); Another string
            Text:data1.txt(7B); Yet another string
            Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";
    
            Parser parser = new Parser(text);

            parser.Parse();
            parser.Sort();
            parser.WriteToConsole();
        }
    }
}
