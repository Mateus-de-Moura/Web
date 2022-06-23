using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTeste.entites;
using WebTeste.Models;


namespace WebTeste.Controllers
{
    public class LoginController : Controller
    {
        private readonly conexao _conexao;

        public LoginController() 
        {
            _conexao = new conexao();
        }
                
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Logar(UsuarioModel UsuarioModel) 
        {
           var retorno =  _conexao.ConsultarUsuario(UsuarioModel.usuario, UsuarioModel.senha);

            try
            {
                if (retorno == true )
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Aviso", "Usuario nao  permitido");
                    return RedirectToAction("Index");
                }              

            }
            catch (Exception ex)
            {
                TempData["MenssagemErro"] = $"Erro ao logar {ex.Message}";
                return RedirectToAction("Index");
            } 

        }
    }
}
