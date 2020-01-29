using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TicTacDB.Models;
using TicTacDB.Repositories;
using CheckGrid;
using LogicLibrary.Helpers;
using TicTacDB.Helpers;

namespace LogicLibrary
{
    public class GameEngine
    {
        private char[,] _gameState;
        public int row { get; set; }
        public int column { get; set; }
        public GameEngine()
        {
            _gameState = LoadGameStateFromDb();
        }
        public string UpdateState(string fieldId)
        {
            row = int.Parse(fieldId[0].ToString());
            column = int.Parse(fieldId[1].ToString());
            _gameState[row, column] = 'X';

            UpdateDbState();

            return GetGameState();
        }
        public string GetGameState()
        {
            if (GameChecker.CheckForWin('X', _gameState))
            {
                DbOperationHelper.CleanDbGrid();

                return "Victory";
            }

            if (GameChecker.CheckForWin('O', _gameState))
            {
                DbOperationHelper.CleanDbGrid();

                return "Defeat";
            }

            if (GameChecker.IsGameStillGoing(_gameState))
            {
                return "Still playing...";
            }

            DbOperationHelper.CleanDbGrid();

            return "Draw";
        }

        public void UpdateDbState() => GameStateRepository.UpdateState(GridChangeHelper.ToGridList(_gameState));
               
        public char[,] LoadGameStateFromDb()
        {
            var gameStateList = GameStateRepository.GetCurrentState();
            if (gameStateList.Count() == 0)
            {
                return new char[3, 3];
            }
                
            return GridChangeHelper.ToCharArray(gameStateList);
        }
    }
}
