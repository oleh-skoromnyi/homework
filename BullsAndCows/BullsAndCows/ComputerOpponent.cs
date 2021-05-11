using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BullsAndCows
{
    public class ComputerOpponent
    {
        private List<string> variants;
        private int lenght;
        private string prediction;

        public ComputerOpponent(int lenght)
        {
            this.lenght = lenght;
            variants = new List<string>();
            prediction = String.Empty;
        }

        public string Start()
        {
            variants.Clear(); 
            var possible = (int)Math.Pow(10, lenght);
            for (int i = 0; i < possible; ++i)
            {
                var variantBuilder = new StringBuilder();

                for (int j = lenght; j > 0; --j)
                {

                    variantBuilder.Append(j == 1 ? i % (int)Math.Pow(10, j) : (i % (int)Math.Pow(10, j)) / (int)Math.Pow(10, j - 1));
                }

                variants.Add(variantBuilder.ToString());
            }

            StringBuilder firstPredictionBuilder = new StringBuilder();


            for (int i = 0; i < lenght; ++i)
            {
                    firstPredictionBuilder.Append(i);
            }


            prediction = firstPredictionBuilder.ToString();
            return prediction;
        }

        public string Prediction(int bulls, int cows)
        {
            if (cows == 0 && bulls == 0)
            {

                variants.RemoveAll(x =>
                {
                    foreach (char symbol in prediction)
                    {
                        if (x.Contains(symbol))
                        {
                            return true;
                        }
                    }
                    return false;
                });
            }
            else
            {
                variants.RemoveAll(x => IsReadyToRemove(x, this.prediction, bulls, cows));
            }

            Random rand = new Random();
            Console.WriteLine($"Possible variants: {variants.Count()}");
            //Try another method to get new prediction
            /*string tempNewPrediction = String.Empty;
            double removed = 0;
            foreach (var variant in variants)
            {
                var tempResult = AverageRemovedCounter(variant);
                if (tempResult > removed)
                {
                    removed = tempResult;
                    tempNewPrediction = variant;
                }
            }*/
            var position = rand.Next(variants.Count());
            prediction = /*tempNewPrediction*/variants.ElementAt(position);
            return prediction;
        }

        private double AverageRemovedCounter(string newPrediction)
        {
            int sum = 0;
            int count = 0;
            double result = 0;
            for (int bulls = 0; bulls <= lenght; ++bulls)
            {
                for (int cows = 0; cows <= lenght - bulls; ++cows)
                {
                    ++count;
                    sum += variants.Count(x => IsReadyToRemove(x, newPrediction, bulls, cows));
                }
            }
            result = sum / count;
            return result;
        }

        private bool IsReadyToRemove(string source, string prediction, int bulls, int cows)
        {
            int bullCounter = 0;
            int cowCounter = 0;
            List<char> partOfPrediction = prediction.ToList();
            List<char> partOfSource = source.ToList();
            List<int> indexToDelete = new List<int>();
            for (int i = 0; i < lenght; ++i)
            {
                if (source[i] == prediction[i])
                {
                    ++bullCounter;
                    indexToDelete.Add(i);
                }
            }
            indexToDelete.Sort();
            indexToDelete.Reverse();
            foreach (int index in indexToDelete)
            {
                partOfPrediction.RemoveAt(index);
                partOfSource.RemoveAt(index);
            }

            foreach (char symbol in partOfSource)
            {
                if (partOfPrediction.Contains(symbol))
                {
                    ++cowCounter;
                    partOfPrediction.Remove(symbol);
                }
            }

            return !(cowCounter == cows && bullCounter == bulls);
        }
    }    
}
