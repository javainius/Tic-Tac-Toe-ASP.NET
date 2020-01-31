using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TicTacDB.Models;
using TicTacDB.Repositories;
using CheckGrid;
using LogicLibrary.Helpers;

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
        public void UpdateState(string squareId)
        {
            row = int.Parse(squareId[0].ToString());
            column = int.Parse(squareId[1].ToString());
            _gameState[row, column] = 'X';
            if(GetGameState() == "Still playing...")
            {
                PcMove("easy");
                UpdateDbState();
            }
            
            
        }
        public string GetGameState()
        {
            if(GameChecker.CheckForWin('X', _gameState))
            {
                GameStateRepository.SetGridToNewGame();

                return "Victory";
            }

            if(GameChecker.CheckForWin('O', _gameState))
            {
                GameStateRepository.SetGridToNewGame();

                return "Defeat";
            }

            if(GameChecker.IsGameStillGoing(_gameState))
            {
                return "Still playing...";
            }

            GameStateRepository.SetGridToNewGame();

            return "Draw";
        }

        public void UpdateDbState() => GameStateRepository.UpdateState(GridChangeHelper.ToGridList(_gameState));

        public char?[,] LoadGameStateFromDb()
        {
            var gameStateList = GameStateRepository.GetCurrentState();
            if(gameStateList.Count() == 0)
            {
                return new char?[3, 3];
            }

            return GridChangeHelper.ToCharArray(gameStateList);
        }

        public void PcMove(string mode)
        {
            if(mode == "easy")
            {
                Random rnd = new Random();
                bool availableMove = false;

                while(!availableMove)
                {
                    int i = rnd.Next(0, 3);
                    int j = rnd.Next(0, 3);
                    if(!_gameState[i,j].HasValue)
                    {
                        _gameState[i, j] = 'O';
                        availableMove = true;
                    }
                }            
            }
            else
            {
                int userMoves = 0;
                foreach(var square in _gameState)
                {
                    if(square == 'X')
                    {
                        userMoves++;
                    }
                }
                if(userMoves == 1)
                {
                    if(_gameState[1, 1] == 'X')
                    {
                        Random rnd = new Random();
                        bool availableMove = false;

                        while(!availableMove)
                        {
                            int i = rnd.Next(0, 3);
                            int j = rnd.Next(0, 3);
                            if ( i != 1 && j != 1)
                            {
                                _gameState[i, j] = 'O';
                                availableMove = true;
                            }
                        }
                    }
                    else
                    {
                        _gameState[1, 1] = 'X';
                    }
                }
                else
                {
                    var playerSideBinaryGrid = _gameState.GridTransform('X');
                    if(IsMainCrossLineDangerous(playerSideBinaryGrid))
                    {
                        if(!_gameState[0, 0].HasValue)
                        {
                            _gameState[0, 0] = 'O';
                        }
                        else if(!_gameState[1, 1].HasValue)
                        {
                            _gameState[1, 1] = 'O';
                        }
                        else if(!_gameState[2, 2].HasValue)
                        {
                            _gameState[2, 2] = 'O';
                        }
                        else // means that there was danger, but the line was defended
                        {

                        }
                    }
                    else if(IsSecondaryCrossLineDangerous(playerSideBinaryGrid))
                    {
                        if(!_gameState[2, 0].HasValue)
                        {
                            _gameState[2, 0] = 'O';
                        }
                        else if(!_gameState[1, 1].HasValue)
                        {
                            _gameState[1, 1] = 'O';
                        }
                        else if(!_gameState[0, 2].HasValue)
                        {
                            _gameState[0, 2] = 'O';
                        }
                        else // means that there was danger, but the line was defended
                        {

                        }
                    }
                    else if(IsFirstColumnDangerous(playerSideBinaryGrid))
                    {

                    }
                    else if(IsSecondColumnDangerous(playerSideBinaryGrid))
                    {

                    }
                    else if(IsThirdColumnDangerous(playerSideBinaryGrid))
                    {

                    }
                    else if(IsFirstRowDangerous(playerSideBinaryGrid))
                    {

                    }
                    else if(IsSecondRowDangerous(playerSideBinaryGrid))
                    {

                    }
                    else if(IsThirdRowDangerous(playerSideBinaryGrid))
                    {

                    }
                    else // there is no danger from player side
                    {
                        var pcSideBinaryGrid = _gameState.GridTransform('O');
                        if(IsMainCrossLineDangerous(pcSideBinaryGrid))
                        {
                            if(!_gameState[0, 0].HasValue)
                            {
                                _gameState[0, 0] = 'O';
                            }
                            else if(!_gameState[1, 1].HasValue)
                            {
                                _gameState[1, 1] = 'O';
                            }
                            else if(!_gameState[2, 2].HasValue)
                            {
                                _gameState[2, 2] = 'O';
                            }
                            else // means that there was a danger, but the line was defended
                            {

                            }
                        }
                        else if(IsSecondaryCrossLineDangerous(pcSideBinaryGrid))
                        {
                            if(!_gameState[2, 0].HasValue)
                            {
                                _gameState[2, 0] = 'O';
                            }
                            else if(!_gameState[1, 1].HasValue)
                            {
                                _gameState[1, 1] = 'O';
                            }
                            else if(!_gameState[0, 2].HasValue)
                            {
                                _gameState[0, 2] = 'O';
                            }
                            else // means that there was danger, but the line was defended
                            {

                            }
                        }
                        else if(IsFirstColumnDangerous(pcSideBinaryGrid))
                        {

                        }
                        else if(IsSecondColumnDangerous(pcSideBinaryGrid))
                        {

                        }
                        else if(IsThirdColumnDangerous(pcSideBinaryGrid))
                        {

                        }
                        else if(IsFirstRowDangerous(pcSideBinaryGrid))
                        {

                        }
                        else if(IsSecondRowDangerous(pcSideBinaryGrid))
                        {

                        }
                        else if(IsThirdRowDangerous(pcSideBinaryGrid))
                        {

                        }
                    }
                }
            }
        }
        public bool IsMainCrossLineDangerous(int[,] binaryGrid)
        {
            int tiltLine = binaryGrid[0, 0] + binaryGrid[1, 1] + binaryGrid[2, 2];
            if(tiltLine == 2)
            {
                return true;
            }
            return false;
        }
        public bool IsSecondaryCrossLineDangerous(int[,] binaryGrid)
        {
            int tiltLine = binaryGrid[2, 0] + binaryGrid[1, 1] + binaryGrid[0, 2];
            if (tiltLine == 2)
            {
                return true;
            }
            return false;
        }
        public bool IsFirstColumnDangerous(int[,] binaryGrid)
        {

        }
        public bool IsSecondColumnDangerous(int[,] binaryGrid)
        {

        }
        public bool IsThirdColumnDangerous(int[,] binaryGrid)
        {

        }
        public bool IsFirstRowDangerous(int[,] binaryGrid)
        {

        }
        public bool IsSecondRowDangerous(int[,] binaryGrid)
        {

        }
        public bool IsThirdRowDangerous(int[,] binaryGrid)
        {

        }
    }
}
