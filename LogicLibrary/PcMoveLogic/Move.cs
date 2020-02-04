using LogicLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLibrary.PcMoveLogic
{
    public class Move
    {
      
        public static char?[,] HardModeMove(char?[,] gameState)
        {
            var moveGenerator = new MoveChecker(gameState);
            
            if (moveGenerator.IsChanceToWin(gameState, 'O', 'X'))
            {
                int[] finalMovePosition = moveGenerator.FinalMovePosition();
                gameState[finalMovePosition[0], finalMovePosition[1]] = 'O';
            }
            else if (moveGenerator.IsDefendNeeded() && moveGenerator.IsChanceToWin(gameState, 'X', 'O'))
            {
                int[] dangerPosition = moveGenerator.DangerPosition();
                gameState[dangerPosition[0], dangerPosition[1]] = 'O';
            }
            else if (moveGenerator.PerspectiveMovePosition().Length != 0)
            {
                    gameState[moveGenerator.PerspectiveCoordinates[0], moveGenerator.PerspectiveCoordinates[1]] = 'O';
            }
            else //random move
            {
                return EasyModeMove(gameState);
            }
            return gameState;
        }
        public static char?[,] EasyModeMove(char?[,] gameState)
        {
            Random rnd = new Random();
            bool availableMove = false;

            while (!availableMove)
            {
                int i = rnd.Next(0, 3);
                int j = rnd.Next(0, 3);
                if (!gameState[i, j].HasValue)
                {
                    gameState[i, j] = 'O';
                    availableMove = true;
                }
            }
            return gameState;

        }
        public static char?[,] FirstMove(char?[,] gameState)
        {
            if (gameState[1, 1] == 'X')
            {
                Random rnd = new Random();
                bool availableMove = false;

                while (!availableMove)
                {
                    int i = rnd.Next(0, 3);
                    int j = rnd.Next(0, 3);
                    if (i != 1 && j != 1)
                    {
                        gameState[i, j] = 'O';
                        availableMove = true;
                    }
                }
            }
            else
            {
                gameState[1, 1] = 'O';
            }
            return gameState;
        }
    }
}