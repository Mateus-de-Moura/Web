using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebTeste.entites;
using WebTeste.Models;


namespace WebTeste.Controllers
{
    public class HomeController : Controller
    {
 
        private readonly conexao _conn;


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _conn = new conexao();
            _logger = logger;
        }

        public IActionResult Index()
        {
            var contas = _conn.GetContas();
            return View(contas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //[HttpGet("{Id}")]
        //public IActionResult GetPorId() 
        //{
        //    var contas = _conn.GetContas();
        //    return Ok(contas);   
        //}

        [HttpPost]
        public IActionResult Adicionar() 
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult AtualizarConta() 
        {
            return Ok();
            
        }
        [HttpDelete]
        public IActionResult DeletarConta()
        {
            return Ok();

        }

    }
}
