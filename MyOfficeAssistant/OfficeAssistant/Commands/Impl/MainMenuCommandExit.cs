using System;
using InteractiveGraphicMenu.Interfaces;
using OfficeAssistant.Domain;

namespace OfficeAssistant.Commands.Impl
{
    internal class MainMenuCommandExit : IMainMenuCommand
    {
        public string Name => "Exit";
        public int Ordinal => 999;
        public string Command => Name;
        public string HelpInfo => "Exit application";
        public bool IsHighlighted{get; set; }

        public void Execute()
        {
            ApplicationState.IsRunning = false;
            Environment.Exit(0);
        }
    }
}