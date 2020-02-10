using LogicLibrary;
using LogicLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CheckGrid
{
    public class GameChecker // Checking functions
    {
        public char?[,] GameState { get; set; }
        public GameChecker(char?[,] gameState)
        {
            GameState = gameState;
        }
        public bool CheckForWin(char symbol, char? [,] gameState)
        {
            var binaryGrid = gameState.GridTransform(symbol);

            return CheckCrossLines(binaryGrid) || CheckVerticalLines(binaryGrid) || CheckColumns(binaryGrid);
        }
        public bool CheckCrossLines(int[,] binaryGrid) => binaryGrid[0, 0] + binaryGrid[1, 1] + binaryGrid[2, 2] == 3 ||
                                                                 binaryGrid[0, 2] + binaryGrid[1, 1] + binaryGrid[2, 0] == 3;

        public bool CheckVerticalLines(int[,] binaryGrid)
        {
            for (int i = 0; i < 3; i++)
            {
                if (binaryGrid[i, 0] + binaryGrid[i, 1] + binaryGrid[i, 2] == 3)
                {
                    return true;
                }
            }
            return false;
        }
        public bool CheckColumns(int[,] binaryGrid)
        {
            for (int i = 0; i < 3; i++)
            {
                if (binaryGrid[0, i] + binaryGrid[1, i] + binaryGrid[2, i] == 3)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsGameStillGoing(char?[,] gameState) => gameState.Cast<char?>().ToList().Any( square => square.Equals(' '));
        public static bool IsItFirstMove(char?[,] gameState)
        {
            var gameStateInList = gameState.Cast<char?>().ToList();
            return gameStateInList.Where(array => array.Value.Equals('X')).Count() == 1;
        }
    }
}
