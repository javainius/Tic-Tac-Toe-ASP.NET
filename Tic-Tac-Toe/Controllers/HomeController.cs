using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tic_Tac_Toe.Models;
using TicTacDB.Repositories;

namespace Tic_Tac_Toe.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new TicTacViewModel(GameStateRepository.GetCurrentState());
            return View(model);
        }
    }
}
