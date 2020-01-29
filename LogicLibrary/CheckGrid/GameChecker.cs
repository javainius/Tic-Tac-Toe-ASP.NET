using LogicLibrary;
using LogicLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckGrid
{
    public static class GameChecker // Checking functions
    {
        public static bool CheckForWin(char symbol, char [,] gameState)
        {
            var binaryGrid = gameState.GridTransform(symbol);

            if (CheckCrossLines(binaryGrid))
            {
                return true;
            }

            if (CheckVerticalLines(binaryGrid))
            {
                return true;
            }

            if (CheckColumns(binaryGrid))
            {
                return true;
            }

            return false;
        }
        public static bool CheckCrossLines(int[,] binaryGrid)
        {
            int tiltLine = binaryGrid[0, 0] + binaryGrid[1, 1] + binaryGrid[2, 2];

            if (tiltLine == 3)
            {
                return true;
            }

            tiltLine = binaryGrid[0, 2] + binaryGrid[1, 1] + binaryGrid[2, 0];

            if (tiltLine == 3)
            {
                return true;
            }

            return false;
        }
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
        public static bool IsGameStillGoing(char[,] gameState)
        {
            foreach (var square in gameState)
            {
                var smth = square.ToString();
                if (square.ToString() == "\0")
                {
                    return true;
                }
            }
            return false;

        }
    }
}
