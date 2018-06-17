using System;

namespace Game.TTTProvider.Models
{
    public interface IPlayer
    {
        String Name { get; set; }
        Char Symbol { get; set; }
    }
}
