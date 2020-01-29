using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TicTacDB.Models
{
    [Table("Grid")]
    public class GridModel
    {
        public int Id { get; set; }
        public string FirstColumn { get; set; }
        public string SecondColumn { get; set; }
        public string ThirdColumn { get; set; }
        public GridModel() { }
        public GridModel(char[] currentRow)
        {
            FirstColumn = currentRow[0].ToString();
            SecondColumn = currentRow[1].ToString();
            ThirdColumn = currentRow[2].ToString();
        }
    }
}
