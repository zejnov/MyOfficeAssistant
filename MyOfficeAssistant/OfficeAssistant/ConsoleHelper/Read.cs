using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeAssistant.ConsoleHelper
{
    public class Read
    {
        public static void Wait()
        {
            Console.ReadKey(true);
        }

        public static T GetData<T>(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message + ": ");
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("\nYou didnt gave anything, try again");
                }
                catch (Exception)
                {
                    Console.Write("\nSomething went wrong, try again\n");
                }
            }
        }

        public static string GetCommandFromuser(IEnumerable<string> commands)
        {
            var command = string.Empty;
            bool commandOk = false;

            do
            {
                try
                {
                    command = GetData<string>("\nPlease provide command");
                }
                catch (Exception e)
                {
                    Console.Write("Bad command, please try again.");
                }

                if (commands.Contains(command))
                {
                    commandOk = true;
                }
                else
                {
                    Console.Write("Bad command, please try again...");
                }
            } while (!commandOk);
            return command;
        }
    }
}
