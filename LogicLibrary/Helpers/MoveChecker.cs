using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLibrary.Helpers
{

    public class MoveChecker
    {

        private int[,] _playerSideBinaryGrid { get; set; }
        private int[,] _pcSideBinaryGrid { get; set; }
        private char?[,] _gameState { get; set; }
        public int[] PerspectiveCoordinates { get; set; }
        public MoveChecker(char?[,] gameState)
        {
            _gameState = gameState;
            _playerSideBinaryGrid = gameState.GridTransform('X', 'O');
            _pcSideBinaryGrid = gameState.GridTransform('O', 'X');
        }
        public int[] PerspectiveMovePosition()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_gameState[i, j] == null)
                    {
                        _gameState[i, j] = 'O';
                        if (IsChanceToWin(_gameState, 'O', 'X'))
                        {
                            _gameState[i, j] = null;
                            PerspectiveCoordinates = new int[] { i, j };
                            return PerspectiveCoordinates;
                        }
                        _gameState[i, j] = null;
                    }

                }
            }
            return null;
        }
        public bool IsDefendNeeded()
        {

            return IsMainCrossLineDangerous(_playerSideBinaryGrid) || IsSecondaryCrossLineDangerous(_playerSideBinaryGrid) ||
                IsFirstColumnDangerous(_playerSideBinaryGrid) || IsSecondColumnDangerous(_playerSideBinaryGrid) ||
                IsThirdColumnDangerous(_playerSideBinaryGrid) || IsFirstRowDangerous(_playerSideBinaryGrid) ||
                IsSecondRowDangerous(_playerSideBinaryGrid) || IsThirdRowDangerous(_playerSideBinaryGrid);
        }
        public bool IsChanceToWin(char?[,] gameState, char symbol, char negativeSymbol)
        {

            var BinaryGrid = gameState.GridTransform(symbol, negativeSymbol);

            return IsMainCrossLineDangerous(BinaryGrid) || IsSecondaryCrossLineDangerous(BinaryGrid) ||
            IsFirstColumnDangerous(BinaryGrid) || IsSecondColumnDangerous(BinaryGrid) ||
            IsThirdColumnDangerous(BinaryGrid) || IsFirstRowDangerous(BinaryGrid) ||
            IsSecondRowDangerous(BinaryGrid) || IsThirdRowDangerous(BinaryGrid);

        }
        public int[] FinalMovePosition()
        {

            if (IsMainCrossLineDangerous(_pcSideBinaryGrid))
            {
                if (!_gameState[0, 0].HasValue)
                {
                    return new int[] { 0, 0 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int[] { 1, 1 };
                }
                else if (!_gameState[2, 2].HasValue)
                {
                    return new int[] { 2, 2 };
                }
            }
            else if (IsSecondaryCrossLineDangerous(_pcSideBinaryGrid))
            {
                if (!_gameState[2, 0].HasValue)
                {
                    return new int[] { 2, 0 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int[] { 1, 1 };
                }
                else if (!_gameState[0, 2].HasValue)
                {
                    return new int[] { 0, 2 };
                }
            }
            else if (IsFirstColumnDangerous(_pcSideBinaryGrid))
            {
                if (!_gameState[0, 0].HasValue)
                {
                    return new int[] { 0, 0 };
                }
                else if (!_gameState[1, 0].HasValue)
                {
                    return new int[] { 1, 0 };
                }
                else if (!_gameState[2, 0].HasValue)
                {
                    return new int[] { 2, 0 };
                }
            }
            else if (IsSecondColumnDangerous(_pcSideBinaryGrid))
            {
                if (!_gameState[0, 1].HasValue)
                {
                    return new int[] { 0, 1 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int[] { 1, 1 };
                }
                else if (!_gameState[2, 1].HasValue)
                {
                    return new int[] { 2, 1 };
                }
            }
            else if (IsThirdColumnDangerous(_pcSideBinaryGrid))
            {
                if (!_gameState[0, 2].HasValue)
                {
                    return new int[] { 0, 2 };
                }
                else if (!_gameState[1, 2].HasValue)
                {
                    return new int[] { 1, 2 };
                }
                else if (!_gameState[2, 2].HasValue)
                {
                    return new int[] { 2, 2 };
                }
            }
            else if (IsFirstRowDangerous(_pcSideBinaryGrid))
            {
                if (!_gameState[0, 0].HasValue)
                {
                    return new int[] { 0, 0 };
                }
                else if (!_gameState[0, 1].HasValue)
                {
                    return new int[] { 0, 1 };
                }
                else if (!_gameState[0, 2].HasValue)
                {
                    return new int[] { 0, 2 };
                }
            }
            else if (IsSecondRowDangerous(_pcSideBinaryGrid))
            {
                if (!_gameState[1, 0].HasValue)
                {
                    return new int[] { 1, 0 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int[] { 1, 1 };
                }
                else if (!_gameState[1, 2].HasValue)
                {
                    return new int[] { 1, 2 };
                }
            }
            else if (IsThirdRowDangerous(_pcSideBinaryGrid))
            {
                if (!_gameState[2, 0].HasValue)
                {
                    return new int[] { 2, 0 };
                }
                else if (!_gameState[2, 1].HasValue)
                {
                    return new int[] { 2, 1 };
                }
                else if (!_gameState[2, 2].HasValue)
                {
                    return new int[] { 2, 2 };
                }
            }
            return null;
        }
        public int[] DangerPosition()
        {

            if (IsMainCrossLineDangerous(_playerSideBinaryGrid))
            {
                if (!_gameState[0, 0].HasValue)
                {
                    return new int[] { 0, 0 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int[] { 1, 1 };
                }
                else if (!_gameState[2, 2].HasValue)
                {
                    return new int[] { 2, 2 };
                }
            }
            else if (IsSecondaryCrossLineDangerous(_playerSideBinaryGrid))
            {
                if (!_gameState[2, 0].HasValue)
                {
                    return new int[] { 2, 0 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int[] { 1, 1 };
                }
                else if (!_gameState[0, 2].HasValue)
                {
                    return new int[] { 0, 2 };
                }
            }
            else if (IsFirstColumnDangerous(_playerSideBinaryGrid))
            {
                if (!_gameState[0, 0].HasValue)
                {
                    return new int[] { 0, 0 };
                }
                else if (!_gameState[1, 0].HasValue)
                {
                    return new int[] { 1, 0 };
                }
                else if (!_gameState[2, 0].HasValue)
                {
                    return new int[] { 2, 0 };
                }
            }
            else if (IsSecondColumnDangerous(_playerSideBinaryGrid))
            {
                if (!_gameState[0, 1].HasValue)
                {
                    return new int[] { 0, 1 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int[] { 1, 1 };
                }
                else if (!_gameState[2, 1].HasValue)
                {
                    return new int[] { 2, 1 };
                }
            }
            else if (IsThirdColumnDangerous(_playerSideBinaryGrid))
            {
                if (!_gameState[0, 2].HasValue)
                {
                    return new int[] { 0, 2 };
                }
                else if (!_gameState[1, 2].HasValue)
                {
                    return new int[] { 1, 2 };
                }
                else if (!_gameState[2, 2].HasValue)
                {
                    return new int[] { 2, 2 };
                }
            }
            else if (IsFirstRowDangerous(_playerSideBinaryGrid))
            {
                if (!_gameState[0, 0].HasValue)
                {
                    return new int[] { 0, 0 };
                }
                else if (!_gameState[0, 1].HasValue)
                {
                    return new int[] { 0, 1 };
                }
                else if (!_gameState[0, 2].HasValue)
                {
                    return new int[] { 0, 2 };
                }
            }
            else if (IsSecondRowDangerous(_playerSideBinaryGrid))
            {
                if (!_gameState[1, 0].HasValue)
                {
                    return new int[] { 1, 0 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int[] { 1, 1 };
                }
                else if (!_gameState[1, 2].HasValue)
                {
                    return new int[] { 1, 2 };
                }
            }
            else if (IsThirdRowDangerous(_playerSideBinaryGrid))
            {
                if (!_gameState[2, 0].HasValue)
                {
                    return new int[] { 2, 0 };
                }
                else if (!_gameState[2, 1].HasValue)
                {
                    return new int[] { 2, 1 };
                }
                else if (!_gameState[2, 2].HasValue)
                {
                    return new int[] { 2, 2 };
                }
            }
            return null;
        }
        public static bool IsMainCrossLineDangerous(int[,] binaryGrid) => binaryGrid[0, 0] + binaryGrid[1, 1] + binaryGrid[2, 2] == 2;
        public static bool IsSecondaryCrossLineDangerous(int[,] binaryGrid) => binaryGrid[2, 0] + binaryGrid[1, 1] + binaryGrid[0, 2] == 2;
        public static bool IsFirstRowDangerous(int[,] binaryGrid) => binaryGrid[0, 0] + binaryGrid[0, 1] + binaryGrid[0, 2] == 2;
        public static bool IsSecondRowDangerous(int[,] binaryGrid) => binaryGrid[1, 0] + binaryGrid[1, 1] + binaryGrid[1, 2] == 2;
        public static bool IsThirdRowDangerous(int[,] binaryGrid) => binaryGrid[2, 0] + binaryGrid[2, 1] + binaryGrid[2, 2] == 2;
        public static bool IsFirstColumnDangerous(int[,] binaryGrid) => binaryGrid[0, 0] + binaryGrid[1, 0] + binaryGrid[2, 0] == 2;
        public static bool IsSecondColumnDangerous(int[,] binaryGrid) => binaryGrid[0, 1] + binaryGrid[1, 1] + binaryGrid[2, 1] == 2;
        public static bool IsThirdColumnDangerous(int[,] binaryGrid) => binaryGrid[0, 2] + binaryGrid[1, 2] + binaryGrid[2, 2] == 2;
    }
}
