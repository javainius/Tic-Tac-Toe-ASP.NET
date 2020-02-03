using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLibrary.Helpers
{

    public class MoveHelper
    {

        private int[,] _playerSideBinaryGrid { get; set; }
        private int[,] _pcSideBinaryGrid { get; set; }
        private char?[,] _gameState { get; set; }
        public MoveHelper(char?[,] gameState)
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
                            return new int[] { i, j };
                        }
                        _gameState[i, j] = null;
                    }

                }
            }
            return null;
        }
        public bool IsDefendNeeded()
        {

            if (IsMainCrossLineDangerous(_playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsSecondaryCrossLineDangerous(_playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsFirstColumnDangerous(_playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsSecondColumnDangerous(_playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsThirdColumnDangerous(_playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsFirstRowDangerous(_playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsSecondRowDangerous(_playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsThirdRowDangerous(_playerSideBinaryGrid))
            {
                return true;
            }
            else return false;
        }
        public bool IsChanceToWin(char?[,] gameState, char symbol, char negativeSymbol)
        {

            var BinaryGrid = gameState.GridTransform(symbol, negativeSymbol);
            if (IsMainCrossLineDangerous(BinaryGrid))
            {
                return true;
            }
            else if (IsSecondaryCrossLineDangerous(BinaryGrid))
            {
                return true;
            }
            else if (IsFirstColumnDangerous(BinaryGrid))
            {
                return true;
            }
            else if (IsSecondColumnDangerous(BinaryGrid))
            {
                return true;
            }
            else if (IsThirdColumnDangerous(BinaryGrid))
            {
                return true;
            }
            else if (IsFirstRowDangerous(BinaryGrid))
            {
                return true;
            }
            else if (IsSecondRowDangerous(BinaryGrid))
            {
                return true;
            }
            else if (IsThirdRowDangerous(BinaryGrid))
            {
                return true;
            }
            else return false;
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
        public bool IsMainCrossLineDangerous(int[,] binaryGrid)
        {
            int tiltLine = binaryGrid[0, 0] + binaryGrid[1, 1] + binaryGrid[2, 2];
            if (tiltLine == 2)
            {
                return true;
            }
            return false;
        }
        public bool IsSecondaryCrossLineDangerous(int[,] binaryGrid)
        {
            int tiltLine = binaryGrid[2, 0] + binaryGrid[1, 1] + binaryGrid[0, 2];
            if (tiltLine == 2)
            {
                return true;
            }
            return false;
        }
        public bool IsFirstRowDangerous(int[,] binaryGrid)
        {
            int row = binaryGrid[0, 0] + binaryGrid[0, 1] + binaryGrid[0, 2];
            if (row == 2)
            {
                return true;
            }
            return false;
        }
        public bool IsSecondRowDangerous(int[,] binaryGrid)
        {
            int row = binaryGrid[1, 0] + binaryGrid[1, 1] + binaryGrid[1, 2];
            if (row == 2)
            {
                return true;
            }
            return false;
        }
        public bool IsThirdRowDangerous(int[,] binaryGrid)
        {
            int row = binaryGrid[2, 0] + binaryGrid[2, 1] + binaryGrid[2, 2];
            if (row == 2)
            {
                return true;
            }
            return false;
        }
        public bool IsFirstColumnDangerous(int[,] binaryGrid)
        {
            int column = binaryGrid[0, 0] + binaryGrid[1, 0] + binaryGrid[2, 0];
            if (column == 2)
            {
                return true;
            }
            return false;
        }
        public bool IsSecondColumnDangerous(int[,] binaryGrid)
        {
            int column = binaryGrid[0, 1] + binaryGrid[1, 1] + binaryGrid[2, 1];
            if (column == 2)
            {
                return true;
            }
            return false;
        }
        public bool IsThirdColumnDangerous(int[,] binaryGrid)
        {
            int column = binaryGrid[0, 2] + binaryGrid[1, 2] + binaryGrid[2, 2];
            if (column == 2)
            {
                return true;
            }
            return false;
        }
    }
}
