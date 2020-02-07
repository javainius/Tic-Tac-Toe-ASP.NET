using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacDB.Models;

namespace Tic_Tac_Toe.Models
{
    public class TicTacViewModel
    {       
        public List<Row> Rows { get; set; }
        public string GameMode { get; set; }
        public string Status { get; set; }
        public TicTacViewModel(List<GridModel> rows, string status, string gameMode)
        {
            Status = status != null ? status : null;
            GameMode = gameMode != null ? gameMode : null;

            Rows = new List<Row>();

            Rows.AddRange(rows.Select(row => new Row(row.FirstColumn, row.SecondColumn, row.ThirdColumn)));
        }
    }
}

