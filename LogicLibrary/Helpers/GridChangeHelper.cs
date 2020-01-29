using System;
using System.Collections.Generic;
using System.Text;
using TicTacDB.Models;

namespace LogicLibrary.Helpers
{
    public static class GridChangeHelper
    {
        public static int[,] GridTransform(this char[,] currentGrid, char symbol)
        {
            int[,] binaryGrid = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (currentGrid[i, j] == symbol)
                    {
                        binaryGrid[i, j] = 1;
                    }
                    else
                    {
                        binaryGrid[i, j] = 0;
                    }
                }
            }
            return binaryGrid;
        }
        public static char[,] ToCharArray(List<GridModel> gridList)
        {
            var currentGrid = new char[3, 3];
            int listIterator = 0;
            for (int i = 0; i < 3; i++)
            {
                currentGrid[i, 0] = char.Parse(gridList[listIterator].FirstColumn);
                currentGrid[i, 1] = char.Parse(gridList[listIterator].SecondColumn);
                currentGrid[i, 2] = char.Parse(gridList[listIterator].ThirdColumn);
                listIterator++;
            }

            return currentGrid;
        }
        public static List<GridModel> ToGridList(char[,] gridArray)
        {
            var rows = new char[][] {
                                    new char[] { gridArray[0, 0], gridArray[0, 1], gridArray[0, 2] },
                                    new char[] { gridArray[1, 0], gridArray[1, 1], gridArray[1, 2] },
                                    new char[] { gridArray[2, 0], gridArray[2, 1], gridArray[2, 2] }
            };

            var gridList = new List<GridModel>();

            foreach (var row in rows)
            {
                gridList.Add(new GridModel(row));
            }
            return gridList;
        }
    }
}
