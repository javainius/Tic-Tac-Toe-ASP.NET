using Microsoft.AspNetCore.Mvc;
using Tic_Tac_Toe.Models;
using TicTacDB.Repositories;
using LogicAndDbConnection;
using LogicLibrary;
using LogicLibrary.Models;

namespace Tic_Tac_Toe.Controllers
{
    public class HomeController : Controller
    {
        private GameApplication _gameApplication;
        public IActionResult Index()
        {
            var gameRepository = new GameRepository();
            var model = new TicTacViewModel(gameRepository.GetCurrentState(), null, gameRepository.GetGameMode());
            return View(model);
        }
        
        [HttpPost]
        public JsonResult UpdateState([FromBody] UserMoveModel userMove)
        {
            _gameApplication = new GameApplication();

            _gameApplication.UpdateState(userMove);

            var modelComponents = _gameApplication.GetViewComponents();

            var model = new TicTacViewModel(modelComponents.CurrentState, modelComponents.GameStatus, null);

            return Json(model);
        }
    }
}
