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

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(ContactoModel contacto)
        {
            _contactoRepositorio.Adicionar(contacto);
            return RedirectToAction("Index");
        }
    }
}
