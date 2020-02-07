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
        private readonly GameRepository _gameRepository;
        private MoveGenerator moveGenerator;
        private GameChecker _gameChecker;
        public int row { get; set; }
        public int column { get; set; }
        public GameEngine()
        {
            _gameRepository = new GameRepository();
            _gameState = LoadGameStateFromDb();
            moveGenerator = new MoveGenerator(_gameState);
            _gameChecker = new GameChecker(_gameState);
        }
        public string GetGameStatus()
        {
            return _gameChecker.CheckForWin('X', _gameState) ? "Victory" :
                   _gameChecker.CheckForWin('O', _gameState) ? "Defeat" :
                   GameChecker.IsGameStillGoing(_gameState) ? "Still playing..." : "Draw";
        }
        public void UpdateState(UserMoveModel userMove)
        {
            _gameRepository.UpdateGameMode(new GameModeModel() { GameMode = userMove.GameMode });

            row = userMove.MovePositions[0];
            column = userMove.MovePositions[1];
            _gameState[row, column] = 'X';
            if (GetGameStatus() == "Still playing...")
            {
                PcMove(_gameRepository.GetGameMode());
            }
            UpdateDbState();
        }
        public void UpdateDbState() => _gameRepository.UpdateState(GridChanger.ToGridList(_gameState));

        public char?[,] LoadGameStateFromDb()
        {
            var gameStateList = _gameRepository.GetCurrentState();

            return gameStateList.Count() == 0 ? new char?[3, 3] : GridChanger.ToCharArray(gameStateList);

        }

        public void PcMove(string mode)
        {
            if (mode == "easy")
            {
                _gameState = moveGenerator.EasyModeMove();
            }
            else
            {
                _gameState = moveGenerator.HardModeMove();
            }

        }
    }
}
