using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndMulticastDelegates
{
    public class Player
    {
        public string Name { get; set; }
        public Player(string name)
        {
            Name = name;
            // subscribe events (these two lines should be added after EventManager is created)
            GameEventManager.OnGameStart += StartGame;
            GameEventManager.OnGameStop += StopGame;
        }
        private void StartGame()
        {
            Console.WriteLine("Player {0} is created in the game...", Name);
        }
        private void StopGame()
        {
            Console.WriteLine("Player {0} is removed from the game...", Name);
        }
    }
}
