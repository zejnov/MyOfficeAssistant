using System;

namespace InteractiveGraphicMenu.Helpers
{
    public class ArrowsHandling
    {
        public Tuple<int, int> GetValidHighligthMove(int horizontal, int vertical, int width, int height, out bool isExecution)
        {
            var arrowKey = ReadArrowDirection();
            arrowKey = Validate(arrowKey,horizontal,vertical,width,height);
            var result = ExecuteArrowKey(horizontal, vertical, arrowKey, out isExecution);

            return new Tuple<int, int>(result.Item1, result.Item2);
        }

        public static AssistantEnums.ArrowDirections Validate(AssistantEnums.ArrowDirections arrowDirection, int horizontal, int vertical, int width, int height)
        {
            switch (arrowDirection)
            {
                case AssistantEnums.ArrowDirections.None:
                case AssistantEnums.ArrowDirections.Execute:
                    break;
                case AssistantEnums.ArrowDirections.Left:
                    if (horizontal <= 0)
                        return AssistantEnums.ArrowDirections.None;
                    break;
                case AssistantEnums.ArrowDirections.Right:
                    if (horizontal >= width - 1)
                        return AssistantEnums.ArrowDirections.None;
                    break;
                case AssistantEnums.ArrowDirections.Up:
                    if (vertical <= 0)
                        return AssistantEnums.ArrowDirections.None;
                    break;
                case AssistantEnums.ArrowDirections.Down:
                    if (vertical >= height - 1)
                        return AssistantEnums.ArrowDirections.None;
                    break;
                default:
                    return AssistantEnums.ArrowDirections.None;
            }
            return arrowDirection;
        }

        private Tuple<int, int> ExecuteArrowKey(int horizontal, int vertical, AssistantEnums.ArrowDirections arrowKey, out bool isExecution)
        {
            isExecution = false;
            switch (arrowKey)
            {
                case AssistantEnums.ArrowDirections.None:
                    break;
                case AssistantEnums.ArrowDirections.Left:
                    horizontal--;
                    break;
                case AssistantEnums.ArrowDirections.Right:
                    horizontal++;
                    break;
                case AssistantEnums.ArrowDirections.Up:
                    vertical--;
                    break;
                case AssistantEnums.ArrowDirections.Down:
                    vertical++;
                    break;
                case AssistantEnums.ArrowDirections.Execute:
                    isExecution = true;
                    break;
            }
            return new Tuple<int, int>(horizontal, vertical);
        }

        private static AssistantEnums.ArrowDirections ReadArrowDirection()
        {
            var key = Console.ReadKey(false);
            
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    return AssistantEnums.ArrowDirections.Left;

                case ConsoleKey.RightArrow:
                    return AssistantEnums.ArrowDirections.Right;
                    
                case ConsoleKey.UpArrow:
                    return AssistantEnums.ArrowDirections.Up;

                case ConsoleKey.DownArrow:
                    return AssistantEnums.ArrowDirections.Down;

                case ConsoleKey.Enter:
                    return AssistantEnums.ArrowDirections.Execute;
            }
            return AssistantEnums.ArrowDirections.None;
        }
    }
}
