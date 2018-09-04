using System;
using InteractiveGraphicMenu.Interfaces;
using Tool.ToDoList;

namespace OfficeAssistant.Commands.MainMenu
{
    internal class ToDo : IMainMenuCommand
    {
        public string DisplayName => "ToDoList";
        public int Ordinal => 1;
        public string Command => "todo";
        public string HelpInfo => "In memory ToDo List";
        public bool IsSelected { get; set; }

        public void Execute()
        {
            Console.Clear();
            new ToDoList().Run();
            Console.ReadLine();
        }
    }
}