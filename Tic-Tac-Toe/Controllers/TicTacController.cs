﻿using LogicLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public JsonResult UpdateState([FromBody] string fieldId)
        {
            _gameValidator.UpdateState(fieldId);
            return Json("Json");
        }
    }
}