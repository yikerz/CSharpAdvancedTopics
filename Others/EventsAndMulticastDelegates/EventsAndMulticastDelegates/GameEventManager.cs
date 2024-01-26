using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndMulticastDelegates
{
    // manage to start game and stop game
    public class GameEventManager
    {
        public delegate void GameEvent();
        // instantiate two events and let the methods from other classes to subscribe
        public static GameEvent OnGameStart, OnGameStop;

        public static void TriggerGameStart() { OnGameStart(); }
        public static void TriggerGameStop() {  OnGameStop(); }
    }
}
