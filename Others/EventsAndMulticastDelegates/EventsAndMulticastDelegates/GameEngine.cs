using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndMulticastDelegates
{
    public class GameEngine
    {
        public GameEngine()
        {
            // subscribe events (these two lines should be added after EventManager is created)
            GameEventManager.OnGameStart += StartGame;
            GameEventManager.OnGameStop += StopGame;
        }
        private void StartGame()
        {
            Console.WriteLine("Game engine starts...");
        }
        private void StopGame()
        {
            Console.WriteLine("Game engine stops...");
        }
    }
}
