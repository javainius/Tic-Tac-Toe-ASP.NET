using GameStateDB.Contexts;
using System.Collections.Generic;
using System.Linq;
using TicTacDB.Models;

namespace TicTacDB.Repositories
{
    public class GameRepository
    {
        private MainContext _context;
        public GameRepository()
        {
            _context = new MainContext();
        }

        public List<GridModel> GetCurrentState()
        {
            List<GridModel> gridList;
            gridList = _context.Grid.ToList();
            return gridList;
        }

        public string GetGameMode() => _context.GameMode.ToList().Count() == 0 ? null : _context.GameMode.ToList()[0].GameMode;

        public void UpdateState(List<GridModel> grid)
        {
            CleanDbGrid();
            _context.Grid.AddRange(grid);
            _context.SaveChanges();
        }

        public void UpdateGameMode(GameModeModel gameMode)
        {
            if (IsGameMode())
            {
                _context.GameMode.Add(gameMode);
            }
            _context.SaveChanges();
        }

        public void DeleteGameMode()
        {
            _context.GameMode.RemoveRange(_context.GameMode);
            _context.SaveChanges();
        }

        public bool IsGameMode() => _context.GameMode.ToList().Count() == 0;

        public void CleanDbGrid()
        {
            _context.Grid.RemoveRange(_context.Grid);
            _context.SaveChanges();
        }

        public void SetGameModeToNull()
        {
            _context.GameMode.RemoveRange(_context.GameMode);
            
            _context.SaveChanges();
        }

        public void SetGridToNewGame()
        {
            CleanDbGrid();
            SetGameModeToNull();

            for (int i = 0; i < 3; i++)
            {
                _context.Grid.Add(new GridModel()
                {
                    FirstColumn = " ",
                    SecondColumn = " ",
                    ThirdColumn = " "
                });
            }
            _context.SaveChanges();
        }
    }
}
