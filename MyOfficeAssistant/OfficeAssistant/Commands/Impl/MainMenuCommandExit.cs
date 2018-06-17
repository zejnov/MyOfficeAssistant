using System;
using InteractiveGraphicMenu.Interfaces;
using OfficeAssistant.Domain;

namespace OfficeAssistant.Commands.Impl
{
    internal class MainMenuCommandExit : IMainMenuCommand
    {
        public string DisplayName => "Exit";
        public int Ordinal => 999;
        public string Command => DisplayName;
        public string HelpInfo => "Exit application";
        public bool IsSelected{get; set; }

        public void Execute()
        {
            ApplicationState.IsRunning = false;
            Environment.Exit(0);
        }
    }
}