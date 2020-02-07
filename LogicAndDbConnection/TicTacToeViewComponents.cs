using System;
using System.Collections.Generic;
using System.Text;
using TicTacDB.Models;

namespace LogicAndDbConnection
{
    public class TicTacToeViewComponents
    {
        public List<GridModel> CurrentState { get; set; }
        public string GameStatus { get; set; }
        public TicTacToeViewComponents(List<GridModel> currentState, string gameStatus)
        {
            CurrentState = currentState;
            GameStatus = gameStatus;
        }
    }
}
