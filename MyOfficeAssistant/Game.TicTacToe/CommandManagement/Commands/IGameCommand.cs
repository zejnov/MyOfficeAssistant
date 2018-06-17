using Component.Service.CommandsManager.Interfaces;

namespace Game.TicTacToe.CommandManagement.Commands
{
    public interface IGameCommand : IBaseCommand
    {
        string Name { get; }
        string HelpInfo { get; }
    }
}
