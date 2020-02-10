using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLibrary.GameModes
{
    public static class EasyModeLogic
    {
        public static char?[,] EasyModeMove(char?[,] gameState)
        {
            Random rnd = new Random();
            bool availableMove = false;

            while (!availableMove)
            {
                int i = rnd.Next(0, 3);
                int j = rnd.Next(0, 3);
                if (gameState[i, j] == ' ')
                {
                    gameState[i, j] = 'O';
                    availableMove = true;
                }
            }
            return gameState;
        }
    }
}
