using LogicLibrary.Checkers;
using LogicLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLibrary.GameModes
{
    public class HardModeLogic
    {
        public char?[,] GameState { get; set; }
        public HardModeLogic(char?[,] gameState)
        {
            GameState = gameState;
        }
        public char?[,] FirstHardMove()
        {
            if (GameState[1, 1] == 'X')
            {
                var angleCoordinates = new List<int[]>() { new int[] {0, 0 }, new int[] { 0, 2 },
                                                           new int[] { 2, 0 }, new int[] { 2, 2 } };
                var random = new Random();
                var randomCoordinates = angleCoordinates[random.Next(angleCoordinates.Count)];

                GameState[randomCoordinates[0], randomCoordinates[1]] = 'O';
            }
            else
            {
                GameState[1, 1] = 'O';
            }
            return GameState;
        }

        public char?[,] OtherHardMoves()
        {
            var moveGenerator = new MoveChecker(GameState);

            if (moveGenerator.IsChanceToWin(GameState, 'O', 'X'))
            {
                int[] finalMovePosition = moveGenerator.FinalMovePosition();
                GameState[finalMovePosition[0], finalMovePosition[1]] = 'O';
            }
            else if (moveGenerator.IsDefendNeeded() && moveGenerator.IsChanceToWin(GameState, 'X', 'O'))
            {
                int[] dangerPosition = moveGenerator.DangerPosition();
                GameState[dangerPosition[0], dangerPosition[1]] = 'O';
            }
            else if (moveGenerator.PerspectiveMovePosition() != null)
            {
                GameState[moveGenerator.PerspectiveCoordinates[0], moveGenerator.PerspectiveCoordinates[1]] = 'O';
            }
            else //random move
            {
                return EasyModeLogic.EasyModeMove(GameState);
            }
            return GameState;
        }
    }
}
