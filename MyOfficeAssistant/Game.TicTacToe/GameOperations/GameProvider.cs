using System;
using Component.Service.CommandsManager;
using Game.TicTacToe.Commands;
using Game.TicTacToe.IoHelpers;
using InteractiveGraphicMenu;
using OfficeAssistant.Core.Exception;

namespace Game.TicTacToe.GameOperations
{
    class GameProvider
    {
        public void Execute()
        {
            do
            {
                try
                {
                    ProviderLoopExtra();
                }
                catch (ExitException)
                {
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Some wild error occured!");
                    Console.ReadKey();
                }
            } while (true);
        }

        private void SampleMenu()  //if sth crash
        {
            WriteHelper.PrintAvaibleCommands();
            var choosenCommand = ReadHelper.GetCommandFromUser();
            CommandManager<IGameCommand>.GetInstance(System.Reflection.Assembly.GetExecutingAssembly()).Execute(choosenCommand);
        }

        private void ProviderLoopExtra()
        {
            var commands = CommandManager<IGameCommand>.GetInstance(System.Reflection.Assembly.GetExecutingAssembly()).GetAvaibleCommands();
            new Menu<IGameCommand>().Invoke(commands);
        }
    }
}
