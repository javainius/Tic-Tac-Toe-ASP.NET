using System;
using System.Collections.Generic;
using System.Text;
using TicTacDB.Models;
using System.Linq;
namespace LogicLibrary.Helpers
{
    public static class GridChanger
    {
        public static int[,] GridTransform(this char?[,] currentGrid, char symbol)
        {
            int[,] binaryGrid = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    binaryGrid[i, j] = currentGrid[i, j] == symbol ? 1 : 0;
                }
            }
            return binaryGrid;
        }
        public static int[,] GridTransform(this char?[,] currentGrid, char symbol, char negativeSymbol)
        {
            int[,] binaryGrid = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    binaryGrid[i, j] = currentGrid[i, j] == symbol ? 1 : currentGrid[i, j] == negativeSymbol ? -1 : 0;
                }
            }
            return binaryGrid;
        }
        public static char?[,] ToCharArray(List<GridModel> gridList)
        {
            var currentGrid = new char?[3, 3];
            
            for (int i = 0; i < 3; i++)
            {
                if (gridList[i].FirstColumn != "" && gridList[i].FirstColumn != null)
                {
                    currentGrid[i, 0] = char.Parse(gridList[i].FirstColumn);
                }

                if (gridList[i].SecondColumn != "" && gridList[i].SecondColumn != null)
                {
                    currentGrid[i, 1] = char.Parse(gridList[i].SecondColumn);
                }

                if (gridList[i].ThirdColumn != "" && gridList[i].ThirdColumn != null)
                {
                    currentGrid[i, 2] = char.Parse(gridList[i].ThirdColumn);
                }
            }

            return currentGrid;
        }
        public static List<GridModel> ToGridList(char?[,] gridArray)
        {
            var rows = new char?[][] {
                                    new char?[] { gridArray[0, 0], gridArray[0, 1], gridArray[0, 2] },
                                    new char?[] { gridArray[1, 0], gridArray[1, 1], gridArray[1, 2] },
                                    new char?[] { gridArray[2, 0], gridArray[2, 1], gridArray[2, 2] }
            };
            
            return new List<GridModel> (rows.Select(row => new GridModel(row)));
        }
    }
}
