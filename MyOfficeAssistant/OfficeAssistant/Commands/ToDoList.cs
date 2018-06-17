using System;
using InteractiveGraphicMenu.Interfaces;

namespace OfficeAssistant.Commands
{
    internal class ToDoList : IMainMenuCommand
    {
        public string DisplayName => "ToDoList";
        public int Ordinal => 1;
        public string Command => "todo";
        public string HelpInfo => "In memory ToDo List";
        public bool IsSelected { get; set; }

        public void Execute()
        {
            Console.Clear();
            Console.Write("todo");
            Console.ReadLine();
        }
    }
}