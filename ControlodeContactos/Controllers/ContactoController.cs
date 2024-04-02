using ControlodeContactos.Models;
using ControlodeContactos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControlodeContactos.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IContactoRepositorio _contactoRepositorio;
        public ContactoController(IContactoRepositorio contactoRepositorio)
        {
            _contactoRepositorio = contactoRepositorio;
        }

        public IActionResult Index()
        {
         var contactos = _contactoRepositorio.BuscarTodos();

            return View(contactos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           ContactoModel contacto = _contactoRepositorio.ListarporID(id);
            return View(contacto);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContactoModel contacto = _contactoRepositorio.ListarporID(id);
            return View(contacto);
        }

        public IActionResult Apagar(int id)
        {
            _contactoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Criar(ContactoModel contacto)
        {
            _contactoRepositorio.Adicionar(contacto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult alterar(ContactoModel contacto)
        {
            _contactoRepositorio.Atualizar(contacto);
            return RedirectToAction("Index");
        }
    }
}
