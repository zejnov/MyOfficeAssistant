using System;
using System.Collections.Generic;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant.Application
{
    public class Maras2
    {
        private List<int> Results = new List<int>();

        public void Run()
        {
            Console.Clear();

            var x = 53;
            var y = 1253352;
            var myResult = Solution(x, y);
            Console.Write($"Result is {myResult}");

            Results.ForEach(Console.WriteLine);

            Read.Wait();
        }

        public int Solution(int a, int b)
        {
            var stringA = a.ToString();
            var stringB = b.ToString();

            return StringContainsAinB(stringA,stringB, out var position) ? position : position;
        }

        private bool StringContainsAinB(string stringA, string stringB, out int postion)
        {
            var increment = 0;
            for(var i=0; i<stringB.Length ;i++)
            {
                if (stringB[i] == stringA[increment])
                {
                    if (increment >= stringA.Length-1)
                    {
                        postion = i-increment;
                        return true;
                    }
                    increment++;
                }
                else
                {
                    increment = 0;
                }
            }
            postion = -1;
            return false;
        }
    }
}
