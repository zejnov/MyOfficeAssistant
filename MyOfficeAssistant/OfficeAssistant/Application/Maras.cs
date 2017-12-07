using System;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant.Application
{
    public class Maras
    {
        public void Run()
        {
            Console.Clear();

            var x = 4;
            var y = 17;
            var myResult = Solution(x, y);
            Console.Write($"Result is {myResult}");
              
            Read.Wait();
        }

        public int Solution(int a, int b)
        {
            var result = 0;
            //validate number range
            for (var i = a; i <= b; i++)
            {
                if (IsWholeSquare(i))
                {
                    result++;
                }
            }
            return result;
        }

        private bool IsWholeSquare(int i)
        {
            var myNum = Math.Sqrt(i);
            return myNum%1 == 0;
        }
    }
}
