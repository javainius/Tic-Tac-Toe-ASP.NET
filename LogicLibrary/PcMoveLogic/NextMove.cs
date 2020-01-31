using LogicLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLibrary.PcMoveLogic
{
    public class NextMove
    {
        public char?[,] _gameState { get; set; }
        public void HardModeMove()
        {
            if (IsDefendNeeded() && !IsChanceToWin())
            {
                int[] dangerPosition = DangerPosition();
                _gameState[dangerPosition[0], dangerPosition[1]] = 'O';
            }
            else if (IsChanceToWin())
            {
                int[] finalMovePosition = FinalMovePosition();
                _gameState[finalMovePosition[0], finalMovePosition[1]] = 'O';
            }
            else
            {
                var perspectivePostion = PerspectiveMovePosition();
                if (perspectivePostion.Length != 0)
                {
                    _gameState[perspectivePostion[0], perspectivePostion[1]] = 'O';
                }
            }
            else //random move
            {
                PcMove("easy");
            }

        }
    }
    public class MoveHelper
    {
        public MoveHelper(char?[,] gameState)
        {
            _playerSideBinaryGrid = gameState.GridTransform('X', 'O');
            _pcSideBinaryGrid = gameState.GridTransform('X', 'O');
        }
        private int[,] _playerSideBinaryGrid { get; set; }
        private int[,] _pcSideBinaryGrid { get; set; }
        public int [] PerspectiveMovePosition(char?[,] gameState)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameState[i, j] == null)
                    {
                        gameState[i, j] = 'O';
                        if (IsChanceToWin())
                        {
                            gameState[i, j] = null;
                            return new int[] { i, j };
                        }
                        gameState[i, j] = null;
                    }

                }
            }
            return null;
        }
        public bool IsDefendNeeded()
        {
            var playerSideBinaryGrid = _gameState.GridTransform('X', 'O');
            if (IsMainCrossLineDangerous(playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsSecondaryCrossLineDangerous(playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsFirstColumnDangerous(playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsSecondColumnDangerous(playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsThirdColumnDangerous(playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsFirstRowDangerous(playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsSecondRowDangerous(playerSideBinaryGrid))
            {
                return true;
            }
            else if (IsThirdRowDangerous(playerSideBinaryGrid))
            {
                return true;
            }
            else return false;
        }
        public bool IsChanceToWin(char?[,] gameState)
        {
            var pcSideBinaryGrid = gameState.GridTransform('O', 'X');
            if (IsMainCrossLineDangerous(pcSideBinaryGrid))
            {
                return true;
            }
            else if (IsSecondaryCrossLineDangerous(pcSideBinaryGrid))
            {
                return true;
            }
            else if (IsFirstColumnDangerous(pcSideBinaryGrid))
            {
                return true;
            }
            else if (IsSecondColumnDangerous(pcSideBinaryGrid))
            {
                return true;
            }
            else if (IsThirdColumnDangerous(pcSideBinaryGrid))
            {
                return true;
            }
            else if (IsFirstRowDangerous(pcSideBinaryGrid))
            {
                return true;
            }
            else if (IsSecondRowDangerous(pcSideBinaryGrid))
            {
                return true;
            }
            else if (IsThirdRowDangerous(pcSideBinaryGrid))
            {
                return true;
            }
            else return false;
        }
        public int?[] FinalMovePosition()
        {
            var pcSideBinaryGrid = _gameState.GridTransform('O', 'X');
            if (IsMainCrossLineDangerous(pcSideBinaryGrid))
            {
                if (!_gameState[0, 0].HasValue)
                {
                    return new int?[] { 0, 0 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int?[] { 1, 1 };
                }
                else if (!_gameState[2, 2].HasValue)
                {
                    return new int?[] { 2, 2 };
                }
            }
            else if (IsSecondaryCrossLineDangerous(pcSideBinaryGrid))
            {
                if (!_gameState[2, 0].HasValue)
                {
                    return new int?[] { 2, 0 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int?[] { 1, 1 };
                }
                else if (!_gameState[0, 2].HasValue)
                {
                    return new int?[] { 0, 2 };
                }
            }
            else if (IsFirstColumnDangerous(pcSideBinaryGrid))
            {
                if (!_gameState[0, 0].HasValue)
                {
                    return new int?[] { 0, 0 };
                }
                else if (!_gameState[1, 0].HasValue)
                {
                    return new int?[] { 1, 0 };
                }
                else if (!_gameState[2, 0].HasValue)
                {
                    return new int?[] { 2, 0 };
                }
            }
            else if (IsSecondColumnDangerous(pcSideBinaryGrid))
            {
                if (!_gameState[0, 1].HasValue)
                {
                    return new int?[] { 0, 1 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int?[] { 1, 1 };
                }
                else if (!_gameState[2, 1].HasValue)
                {
                    return new int?[] { 2, 1 };
                }
            }
            else if (IsThirdColumnDangerous(pcSideBinaryGrid))
            {
                if (!_gameState[0, 2].HasValue)
                {
                    return new int?[] { 0, 2 };
                }
                else if (!_gameState[1, 2].HasValue)
                {
                    return new int?[] { 1, 2 };
                }
                else if (!_gameState[2, 2].HasValue)
                {
                    return new int?[] { 2, 2 };
                }
            }
            else if (IsFirstRowDangerous(pcSideBinaryGrid))
            {
                if (!_gameState[0, 0].HasValue)
                {
                    return new int?[] { 0, 0 };
                }
                else if (!_gameState[0, 1].HasValue)
                {
                    return new int?[] { 0, 1 };
                }
                else if (!_gameState[0, 2].HasValue)
                {
                    return new int?[] { 0, 2 };
                }
            }
            else if (IsSecondRowDangerous(pcSideBinaryGrid))
            {
                if (!_gameState[1, 0].HasValue)
                {
                    return new int?[] { 1, 0 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int?[] { 1, 1 };
                }
                else if (!_gameState[1, 2].HasValue)
                {
                    return new int?[] { 1, 2 };
                }
            }
            else if (IsThirdRowDangerous(pcSideBinaryGrid))
            {
                if (!_gameState[2, 0].HasValue)
                {
                    return new int?[] { 2, 0 };
                }
                else if (!_gameState[2, 1].HasValue)
                {
                    return new int?[] { 2, 1 };
                }
                else if (!_gameState[2, 2].HasValue)
                {
                    return new int?[] { 2, 2 };
                }
            }
            return null;
        }
        public int?[] DangerPosition()
        {
            var playerSideBinaryGrid = _gameState.GridTransform('X', 'O');
            if (IsMainCrossLineDangerous(playerSideBinaryGrid))
            {
                if (!_gameState[0, 0].HasValue)
                {
                    return new int?[] { 0, 0 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int?[] { 1, 1 };
                }
                else if (!_gameState[2, 2].HasValue)
                {
                    return new int?[] { 2, 2 };
                }
            }
            else if (IsSecondaryCrossLineDangerous(playerSideBinaryGrid))
            {
                if (!_gameState[2, 0].HasValue)
                {
                    return new int?[] { 2, 0 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int?[] { 1, 1 };
                }
                else if (!_gameState[0, 2].HasValue)
                {
                    return new int?[] { 0, 2 };
                }
            }
            else if (IsFirstColumnDangerous(playerSideBinaryGrid))
            {
                if (!_gameState[0, 0].HasValue)
                {
                    return new int?[] { 0, 0 };
                }
                else if (!_gameState[1, 0].HasValue)
                {
                    return new int?[] { 1, 0 };
                }
                else if (!_gameState[2, 0].HasValue)
                {
                    return new int?[] { 2, 0 };
                }
            }
            else if (IsSecondColumnDangerous(playerSideBinaryGrid))
            {
                if (!_gameState[0, 1].HasValue)
                {
                    return new int?[] { 0, 1 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int?[] { 1, 1 };
                }
                else if (!_gameState[2, 1].HasValue)
                {
                    return new int?[] { 2, 1 };
                }
            }
            else if (IsThirdColumnDangerous(playerSideBinaryGrid))
            {
                if (!_gameState[0, 2].HasValue)
                {
                    return new int?[] { 0, 2 };
                }
                else if (!_gameState[1, 2].HasValue)
                {
                    return new int?[] { 1, 2 };
                }
                else if (!_gameState[2, 2].HasValue)
                {
                    return new int?[] { 2, 2 };
                }
            }
            else if (IsFirstRowDangerous(playerSideBinaryGrid))
            {
                if (!_gameState[0, 0].HasValue)
                {
                    return new int?[] { 0, 0 };
                }
                else if (!_gameState[0, 1].HasValue)
                {
                    return new int?[] { 0, 1 };
                }
                else if (!_gameState[0, 2].HasValue)
                {
                    return new int?[] { 0, 2 };
                }
            }
            else if (IsSecondRowDangerous(playerSideBinaryGrid))
            {
                if (!_gameState[1, 0].HasValue)
                {
                    return new int?[] { 1, 0 };
                }
                else if (!_gameState[1, 1].HasValue)
                {
                    return new int?[] { 1, 1 };
                }
                else if (!_gameState[1, 2].HasValue)
                {
                    return new int?[] { 1, 2 };
                }
            }
            else if (IsThirdRowDangerous(playerSideBinaryGrid))
            {
                if (!_gameState[2, 0].HasValue)
                {
                    return new int?[] { 2, 0 };
                }
                else if (!_gameState[2, 1].HasValue)
                {
                    return new int?[] { 2, 1 };
                }
                else if (!_gameState[2, 2].HasValue)
                {
                    return new int?[] { 2, 2 };
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
