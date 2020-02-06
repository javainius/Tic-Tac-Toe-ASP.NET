using LogicLibrary;
using LogicLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tic_Tac_Toe.Models;
using TicTacDB.Repositories;

namespace Tic_Tac_Toe.Controllers
{
    public class TicTacController : Controller
    {
        private readonly GameEngine _gameValidator;

        public TicTacController()
        {
            _gameValidator = new GameEngine();
        }

        [HttpPost]
        public JsonResult UpdateState([FromBody] UserMoveModel userMove)
        {
            _gameValidator.UpdateState(userMove);

            var model = new TicTacViewModel(_gameValidator.GetGameState(), GameStateRepository.GetCurrentState());
            
            if(_gameValidator.GetGameState() != "Still playing...")
            {
                GameStateRepository.SetGridToNewGame();
            }
            return Json(model);
        }
    }
}