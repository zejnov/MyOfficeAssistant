using System;
using Component.Service.CommandsManager;
using Game.TicTacToe.CommandManagement.Commands;
using Game.TicTacToe.IoHelpers;

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
                    ProviderLoop();
                }
                catch (Exception)
                {
                    Console.WriteLine("Some wild error occured!");
                    Console.ReadKey();
                }
            } while (true);
        }

        private void ProviderLoop()
        {
            WriteHelper.PrintAvaibleCommands();
            var choosenCommand = ReadHelper.GetCommandFromUser();
            CommandManager<IGameCommand>.GetInstance(System.Reflection.Assembly.GetExecutingAssembly()).Execute(choosenCommand);
        }
    }
}
