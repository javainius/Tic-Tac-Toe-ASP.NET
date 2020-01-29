using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using TicTacDB.Models;

namespace GameStateDB.Contexts
{
    public class MainContext : DbContext
    {
        public DbSet<GridModel> Grid { get; set; }
        public MainContext()
            : base("data source = (localdb)\\MSSQLLocalDB; Initial Catalog = TicTacDB; integrated security = SSPI")
        {

        }
    }
}
