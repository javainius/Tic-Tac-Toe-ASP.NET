using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Tic_Tac_Toe.Controllers
{
    public class TicTacController : Controller
    {
        [HttpPost]
        public JsonResult UsersTurn([FromBody] List<string> field)
        {
            return Json("Success"); ;
        }
    }
}