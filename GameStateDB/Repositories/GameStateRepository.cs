using GameStateDB.Contexts;
using System.Collections.Generic;
using System.Linq;
using TicTacDB.Helpers;
using TicTacDB.Models;

namespace TicTacDB.Repositories
{
    public static class GameStateRepository
    {
        public static List<GridModel> GetCurrentState()
        {
            List<GridModel> gridList;

            using (var context = new MainContext())
            {
                gridList = context.Grid.ToList();
            }
            
            return gridList;
        }

        public static void UpdateState(List<GridModel> grid)
        {
            DbOperationHelper.CleanDbGrid();

            using (var context = new MainContext())
            {
                foreach(var row in grid)
                {
                    context.Grid.Add(row);
                }
                
                context.SaveChanges();
            }
        }
    }
}
