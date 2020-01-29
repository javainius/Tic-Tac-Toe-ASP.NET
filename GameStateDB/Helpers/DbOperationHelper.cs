using GameStateDB.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacDB.Helpers
{
    public static class DbOperationHelper
    {
        public static void CleanDbGrid()
        {
            using (var context = new MainContext())
            {

                context.Grid.RemoveRange(context.Grid);
                context.SaveChanges();
            }
        }
    }
}
