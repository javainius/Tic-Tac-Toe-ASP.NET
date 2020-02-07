using LogicLibrary;
using LogicLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TicTacDB.Models;
using TicTacDB.Repositories;

namespace LogicAndDbConnection
{
    public class GameApplication
    {
        private readonly GameEngine _gameEngine;
        private readonly GameRepository _gameRepository; 
        public GameApplication()
        {
            _gameEngine = new GameEngine();
            _gameRepository = new GameRepository();
        }

        public void UpdateState (UserMoveModel userMove) => _gameEngine.UpdateState(userMove);

        public TicTacToeViewComponents GetViewComponents()
        {
            var components = new TicTacToeViewComponents(_gameRepository.GetCurrentState(), _gameEngine.GetGameStatus());

            CheckGameState();

            return components;
        }
        public void CheckGameState()
        {
            if (_gameEngine.GetGameStatus() != "Still playing...")
            {
                _gameRepository.SetGridToNewGame();
            }
        }
    }
}
