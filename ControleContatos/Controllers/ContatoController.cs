using ControleContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }


        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.BuscarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {

            ContatoModel contato = _contatoRepositorio.BuscarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MenagemSucesso"] = "Contato apagado com sucesso ";
                }
                else
                {
                    TempData["MenagemErro"] = "Ops, não conseguimos apagar seu contato ";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MenagemErro"] = "Ops, não conseguimos apagar";
                return RedirectToAction("Index");
            }

        }


        [HttpPost]
        public IActionResult Criar(ContatoModel contato) //sera criado as actions das paginas dos botoes
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MenagemSucesso"] = "Contato cadastrado com sucesso ";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MenagemErro"] = "Ops, não conseguimos cadastrar";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MenagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MenagemErro"] = "Ops, não conseguimos atualizar seu contato";
                return RedirectToAction("Index");
            }
        }
    }
}
