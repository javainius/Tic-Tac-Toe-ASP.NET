using Microsoft.AspNetCore.Mvc;

namespace Tic_Tac_Toe.Controllers
{
    public class TicTacController : Controller
    {
        [HttpPost]
        public JsonResult UsersTurn([FromBody] string fieldId)
        {
            return Json("Success"); ;
        }
    }
}