using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputNumbersSeparatedWithComma(10,41);
            OutputNumbersDivisibleOnThreeSeparatedWithComma(10,41);
            OutputWordTenTimes("Linq");
            OutputWordsThatConsistsA("aaa; abb; ccc; dap");
            OutputAmountOfLetterAInWords("aaa; abb; ccc; dap");
            HasWordInString("abb", "aaa; xabbx; abb; ccc; dap");
            LongestWordInString("aaa; xabbx; abb; ccc; dap");
            AverageLenghtOfWordsInString("aaa; xabbx; abb; ccc; dap");
            ReversedShortestWordInString("aaa; xabbx; abb; ccc; dap; zh");
            FirstWordWithAAinBeginningHasOnlyBAfterIt("baaa; aabb; aaa; xabbx; abb; ccc; dap; zh");
            LastWordAfterTwoElementsEndsWithBB("baaa; aabb; aaa; xabbx; abb; ccc; dap; zh");

            var data = new List<object> {
                "Hello",
                new Article { Author = "Hilgendorf", Name = "Punitive law and criminal law doctrine.", Pages = 44 },
                new List<int> {45, 9, 8, 3},
                new string[] {"Hello inside array"},
                new Film { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                    new Actor { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                    new Actor { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                }},
                new Film { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                    new Actor { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                }},
                new Article { Author = "Basov", Name="Classification and content of restrictive administrative measures applied in the case of emergency", Pages = 35},
                "Leonardo DiCaprio"
            };
            OutputActorsNames(data);
            OutputAmountOfActorsBornInSelectedMonth(data,8);
            OutputTwoOldestActorsNames(data);
            AmountOfArticleOfEachAuthor(data);
            AmountOfArtObjectOfEachAuthor(data);
            AmountOfDifferentLettersInActorsNames(data);
            OutputNamesOfArticlesSortedByAuthorsAndNumberOfPages(data);
            OutputActorAndAllFilmsWithHim(data);
            OutputSumOfPagesAndValuesOfIntSequence(data);
            var articleDictionary = GetDictionaryOfArticlesWrittenByAuthor(data);
        }
        public static void OutputNumbersSeparatedWithComma(int start, int count)
        {
            Console.WriteLine(String.Join(',',Enumerable.Range(start, count).ToArray()));
        }
        public static void OutputNumbersDivisibleOnThreeSeparatedWithComma(int start, int count)
        {
            Console.WriteLine(String.Join(',', Enumerable.Range(start, count).Where(x=> x%3 == 0).ToArray()));
        }
        public static void OutputWordTenTimes(string word)
        {
            Console.WriteLine(String.Join(',', Enumerable.Repeat(word, 10).ToArray()));
        }
        public static void OutputWordsThatConsistsA(string text)
        {
            Console.WriteLine(String.Join(',', text.Split("; ").Where(x => x.Contains('a'))));
        }
        public static void OutputAmountOfLetterAInWords(string text)
        {
            Console.WriteLine(String.Join(',', text.Split("; ").Where(x => x.Contains('a')).Select(x=>x.Where(u=>u == 'a').Count())));
        }
        public static void HasWordInString(string word, string text)
        {
            Console.WriteLine(text.Split("; ").Contains(word));
        }
        public static void LongestWordInString(string text)
        {
            Console.WriteLine(text.Split("; ").Where(x=>x.Length == text.Split("; ").Max(x=>x.Length)).FirstOrDefault());
        }
        public static void AverageLenghtOfWordsInString(string text)
        {
            Console.WriteLine(text.Split("; ").Average(x=>x.Length));
        }
        public static void ReversedShortestWordInString(string text)
        {
            Console.WriteLine(new String(text.Split("; ").
                Where(x => x.Length == text.Split("; ").Min(x => x.Length)).FirstOrDefault().Reverse().ToArray()));
        }
        public static void FirstWordWithAAinBeginningHasOnlyBAfterIt(string text)
        {
            Console.WriteLine(text.Split("; ").First(x=>x.StartsWith("aa")).Skip(2).All(x=>x == 'b'));
        }
        public static void LastWordAfterTwoElementsEndsWithBB(string text)
        {
            Console.WriteLine(text.Split("; ").Except(text.Split("; ").
                Where(x=>x.EndsWith("bb")).Take(2)).LastOrDefault());
        }
        public static void OutputActorsNames(List<object> data)
        {
            Console.WriteLine(String.Join(',',data.Where(x=>x is Film).
                SelectMany(x=>((Film)x).Actors).Select(x=>x.Name).Distinct()));
        }
        public static void OutputAmountOfActorsBornInSelectedMonth(List<object> data, int month)
        {
            Console.WriteLine(data.Where(x => x is Film).SelectMany(x => ((Film)x).Actors).
                Select(x=>x.Birthdate).Distinct().Where(x=>x.Month == month).Count());
        }
        public static void OutputTwoOldestActorsNames(List<object> data)
        {
            Console.WriteLine(String.Join(',', data.Where(x => x is Film).
                SelectMany(x => ((Film)x).Actors).OrderBy(x=>x.Birthdate).Select(x => x.Name).Distinct().Take(2)));
        }
        public static void AmountOfArticleOfEachAuthor(List<object> data)
        {
            Console.WriteLine(String.Join(',', data.Where(x => x is Article).
                Select(x => (Article)x).GroupBy(x => x.Author).Select(x=>$"{ x.Key} - {x.Count()}")));
        }
        public static void AmountOfArtObjectOfEachAuthor(List<object> data)
        {
            Console.WriteLine(String.Join(',', data.Where(x => x is ArtObject).
                Select(x => (ArtObject)x).GroupBy(x => x.Author).Select(x => $"{ x.Key} - {x.Count()}")));
        }
        public static void AmountOfDifferentLettersInActorsNames(List<object> data)
        {
            Console.WriteLine(data.Where(x => x is Film).SelectMany(x => ((Film)x).Actors).
                Select(x => x.Name.Replace(" ","")).Distinct().SelectMany(x=>x.ToLower().ToCharArray()).Distinct().Count());
        }
        public static void OutputNamesOfArticlesSortedByAuthorsAndNumberOfPages(List<object> data)
        {
            Console.WriteLine(String.Join(',', data.Where(x => x is Article).Select(x => (Article)x).
                OrderBy(x=>x.Author).ThenBy(x=>x.Pages).Select(x=>x.Name)));
        }
        public static void OutputActorAndAllFilmsWithHim(List<object> data)
        {
            Console.WriteLine(String.Join('\n', data.Where(x => x is Film).
                SelectMany(x => ((Film)x).Actors).Select(x => x.Name).Distinct().Select(
                x=> x + ": " + String.Join(',', data.Where(x => x is Film).Select(x => ((Film)x)).
                Where(u=>u.Actors.Any(u=>u.Name == x)).Select(u=>u.Name)))));
        }
        public static void OutputSumOfPagesAndValuesOfIntSequence(List<object> data)
        {
            Console.WriteLine( data.Where(x => x is Article).Select(x => (Article)x)
                .Sum(x => x.Pages) + data.Where(x => x is List<int>).SelectMany(x => (List<int>)x).Sum(x => x));
        }
        public static Dictionary<string,List<Article>> GetDictionaryOfArticlesWrittenByAuthor(List<object> data)
        {
            return data.Where(x => x is Article).Select(x => (Article)x).
                ToDictionary(x => x.Author, x => data.Where(x => x is Article).
                Select(x => (Article)x).Where(u => u.Author == x.Author).ToList());
        }
    }
}
