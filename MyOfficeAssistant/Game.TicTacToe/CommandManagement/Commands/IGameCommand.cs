using Component.Service.CommandsManager.Interfaces;

namespace Game.TicTacToe.CommandManagement.Commands
{
    public interface IGameCommand : IBaseCommand
    {
        string DisplayName { get; }
    }
}
