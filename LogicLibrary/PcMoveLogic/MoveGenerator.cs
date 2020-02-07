using CheckGrid;
using LogicLibrary.GameModes;
using LogicLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLibrary.PcMoveLogic
{
    public class MoveGenerator
    {
        public char?[,] GameState { get; set; }
        public MoveGenerator(char?[,] gameState)
        {
            GameState = gameState;
        }
        public char?[,] HardModeMove()
        {
            var hardMode = new HardModeLogic(GameState);
            return GameChecker.IsItFirstMove(GameState) ? hardMode.FirstHardMove() : hardMode.OtherHardMoves();
        }
        public char?[,] EasyModeMove() => EasyModeLogic.EasyModeMove(GameState);
    }
}