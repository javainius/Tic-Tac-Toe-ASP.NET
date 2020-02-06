using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TicTacDB.Models;
using TicTacDB.Repositories;
using CheckGrid;
using LogicLibrary.Helpers;
using LogicLibrary.PcMoveLogic;
using LogicLibrary.Models;

namespace LogicLibrary
{
    public class GameEngine
    {
        private char?[,] _gameState;
        public int row { get; set; }
        public int column { get; set; }
        public GameEngine()
        {
            _gameState = LoadGameStateFromDb();
        }
        public string GetGameState()
        {
            if (GameChecker.CheckForWin('X', _gameState))
            {
                

                return "Victory";
            }

            if (GameChecker.CheckForWin('O', _gameState))
            {
                

                return "Defeat";
            }

            if (GameChecker.IsGameStillGoing(_gameState))
            {
                return "Still playing...";
            }

            

            return "Draw";
        }
        public void UpdateState(UserMoveModel userMove)
        {
            GameStateRepository.UpdateGameMode(new GameModeModel() { GameMode = userMove.GameMode });

            row = userMove.MovePositions[0];
            column = userMove.MovePositions[1];
            _gameState[row, column] = 'X';
            if (GetGameState() == "Still playing...")
            {
                PcMove(GameStateRepository.GetGameMode());
            }
            UpdateDbState();
        }
        public void UpdateDbState() => GameStateRepository.UpdateState(GridChangeHelper.ToGridList(_gameState));

        public char?[,] LoadGameStateFromDb()
        {
            var gameStateList = GameStateRepository.GetCurrentState();
            if (gameStateList.Count() == 0)
            {
                return new char?[3, 3];
            }

            return GridChangeHelper.ToCharArray(gameStateList);
        }

        public void PcMove(string mode)
        {
            if (mode == "easy")
            {
                _gameState = Move.EasyModeMove(_gameState);
            }
            else
            {
                if (GameChecker.IsItFirstMove(_gameState))
                {
                    _gameState = Move.FirstMove(_gameState);
                }
                else
                {
                    _gameState = Move.HardModeMove(_gameState);
                }
            }
        }
    }
}
