using LogicAndDbConnection;
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
        private readonly GameEngine gameEngine;
        private readonly GameApplication _gameApplication;
        public TicTacController()
        {
            _gameApplication = new GameApplication();
        }

        [HttpPost]
        public JsonResult UpdateState([FromBody] UserMoveModel userMove)
        {
            _gameApplication.UpdateState(userMove);

            var modelComponents = _gameApplication.GetViewComponents();

            var model = new TicTacViewModel(modelComponents.CurrentState, modelComponents.GameStatus, null);

            return Json(model);
        }
    }
}