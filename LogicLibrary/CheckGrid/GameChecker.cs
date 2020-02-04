using LogicLibrary;
using LogicLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CheckGrid
{
    public static class GameChecker // Checking functions
    {
        public static bool CheckForWin(char symbol, char? [,] gameState)
        {
            var binaryGrid = gameState.GridTransform(symbol);

            return CheckCrossLines(binaryGrid) || CheckVerticalLines(binaryGrid) || CheckColumns(binaryGrid);
        }
        public static bool CheckCrossLines(int[,] binaryGrid) => binaryGrid[0, 0] + binaryGrid[1, 1] + binaryGrid[2, 2] == 3 ||
                                                                 binaryGrid[0, 2] + binaryGrid[1, 1] + binaryGrid[2, 0] == 3;

        public static bool CheckVerticalLines(int[,] binaryGrid)
        {
            for (int i = 0; i < 3; i++)
            {
                int lineSum = 0;
                for (int j = 0; j < 3; j++)
                {
                    lineSum += binaryGrid[i, j];
                }
                if (lineSum == 3)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckColumns(int[,] binaryGrid)
        {
            for (int i = 0; i < 3; i++)
            {
                int columnSum = 0;
                for (int j = 0; j < 3; j++)
                {
                    columnSum += binaryGrid[j, i];
                }
                if (columnSum == 3)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsGameStillGoing(char?[,] gameState) => gameState.Cast<char?>().ToList().Any( square => square.Equals(null));
        public static bool IsItFirstMove(char?[,] gameState) //=> gameState.Cast<char?>().ToList().Where(array => array.Value.Equals('X')).Count() == 1;
        {
            int userMoves = 0;
            foreach (var square in gameState)
            {
                if (square == 'X')
                {
                    userMoves++;
                }
            }
            return userMoves == 1;
        }
    }
}
