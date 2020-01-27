using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLibrary
{
    public class CheckingLogic
    {
        private char[,] GameField = new char[3, 3];
        public void PassField(List<string> field)
        {

            int fieldId = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    GameField[i, j] = field[fieldId][0];
                    fieldId++;
                }
            }
        }
        public string gameState(List<string> field)
        {
            if (CheckForWin('X'))
            {
                return "Victory";
            }

            if(CheckForWin('O'))
            {
                return "Defeat";
            }
            
            foreach(var square in field)
            {
                if (square == null)
                {
                    return "Still playing...";
                }
            }
            return "Draw";
        }
        public bool CheckForWin(char symbol)
        {
            int[,] BinaryField = FieldTransform(GameField, symbol);

            int tiltLine = 0;
            tiltLine += BinaryField[0, 0] + BinaryField[1, 1] + BinaryField[2, 2];
            if(tiltLine == 3)
            {
                return true;
            }

            tiltLine = 0;
            tiltLine += BinaryField[0, 2] + BinaryField[1, 1] + BinaryField[2, 0];
            if (tiltLine == 3)
            {
                return true;
            }

            for (int i = 0; i < 3; i++)
            {
                int horizontalSum = 0;
                for (int j = 0; j < 3; j++)
                {
                    horizontalSum += BinaryField[i, j];
                }
                if (horizontalSum == 3)
                {
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                int verticalSum = 0;
                for (int j = 0; j < 3; j++)
                {
                    verticalSum += BinaryField[j, i];
                }
                if (verticalSum == 3)
                {
                    return true;
                }
            }

            return false;
        }
        public int[,] FieldTransform(char[,] GameField, char symbol)
        {
            int[,] BinaryField = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (GameField[i, j] == symbol)
                    {
                        BinaryField[i, j] = 1;
                    }
                    else
                    {
                        BinaryField[i, j] = 0;
                    }
                }
            }
            return BinaryField;
        }
    }
}
