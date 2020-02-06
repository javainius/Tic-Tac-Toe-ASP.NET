using GameStateDB.Contexts;
using System.Collections.Generic;
using System.Linq;
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

        public static string GetGameMode()
        {
            string gameMode;

            using (var context = new MainContext())
            {
                gameMode = context.GameMode.ToList()[0].GameMode;
            }

            return gameMode;
        }

        public static void UpdateState(List<GridModel> grid)
        {
            CleanDbGrid();

            using (var context = new MainContext())
            {
                foreach (var row in grid)
                {
                    context.Grid.Add(row);

                }
                context.SaveChanges();
            }
        }
        public static void UpdateGameMode(GameModeModel gameMode)
        {
            using (var context = new MainContext())
            {
                if (IsGameModeNull())
                {
                    DeleteGameMode();
                    context.GameMode.Add(gameMode);
                }
                context.SaveChanges();
            }

        }
        public static void DeleteGameMode()
        {
            using (var context = new MainContext())
            {

                context.GameMode.RemoveRange(context.GameMode);
                context.SaveChanges();
            }
        }
        public static bool IsGameModeNull()
        {
            using (var context = new MainContext())
            {
                return context.GameMode.ToList()[0].GameMode == null;
            }
        }

        public static void CleanDbGrid()
        {
            using (var context = new MainContext())
            {

                context.Grid.RemoveRange(context.Grid);
                context.SaveChanges();
            }
        }
        public static void SetGameModeToNull()
        {
            using (var context = new MainContext())
            {

                context.GameMode.RemoveRange(context.GameMode);
                context.GameMode.Add(new GameModeModel { GameMode = null });
                context.SaveChanges();
            }
        }
        public static void SetGridToNewGame()
        {
            CleanDbGrid();
            SetGameModeToNull();

            using (var context = new MainContext())
            {
                for (int i = 0; i < 3; i++)
                {
                    context.Grid.Add(new GridModel()
                    {
                        FirstColumn = null,
                        SecondColumn = null,
                        ThirdColumn = null
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
