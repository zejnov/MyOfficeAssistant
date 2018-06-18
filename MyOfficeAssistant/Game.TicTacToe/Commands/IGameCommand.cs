using Component.Service.CommandsManager.Interfaces;
using InteractiveGraphicMenu.Interfaces;

namespace Game.TicTacToe.Commands
{
    public interface IGameCommand : IBaseCommand, ISelected
    {
        string DisplayName { get; }
    }
}
