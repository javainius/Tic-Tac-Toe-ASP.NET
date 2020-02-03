using LogicLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLibrary.PcMoveLogic
{
    public class NextMove
    {
        public char?[,] _gameState { get; set; }
        public NextMove(char?[,] gameState)
        {
            _gameState = gameState;
        }
        public void HardModeMove()
        {
            var moveGenerator = new MoveHelper(_gameState);
            if (moveGenerator.IsDefendNeeded() && moveGenerator.IsChanceToWin(_gameState, 'X', 'O'))
            {
                int[] dangerPosition = moveGenerator.DangerPosition();
                _gameState[dangerPosition[0], dangerPosition[1]] = 'O';
            }
            else if (moveGenerator.IsChanceToWin(_gameState, 'O', 'X'))
            {
                int[] finalMovePosition = moveGenerator.FinalMovePosition();
                _gameState[finalMovePosition[0], finalMovePosition[1]] = 'O';
            }
            else
            {
                var perspectivePostion = moveGenerator.PerspectiveMovePosition();
                if (perspectivePostion.Length != 0)
                {
                    _gameState[perspectivePostion[0], perspectivePostion[1]] = 'O';
                }
            }
            else //random move
            {
                PcMove("easy");
            }

        }
    }
}