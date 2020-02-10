using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacDB.Models;

namespace Tic_Tac_Toe.Models
{
    public class TicTacViewModel
    {       
        public List<Row> Rows { get; set; } = new List<Row>();
        public string GameMode { get; set; } 
        public string Status { get; set; }
        public TicTacViewModel(List<GridModel> rows, string status, string gameMode)
        {
            Status = status;
            GameMode = gameMode;

            Rows.AddRange(rows.Select(row => new Row(row.FirstColumn, row.SecondColumn, row.ThirdColumn)));
        }
    }
}

