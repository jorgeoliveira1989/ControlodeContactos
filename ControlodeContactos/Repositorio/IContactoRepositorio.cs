using ControlodeContactos.Models;

namespace ControlodeContactos.Repositorio
{
    public interface IContactoRepositorio
    {
        List<ContactoModel> BuscarTodos();
        ContactoModel Adicionar(ContactoModel contacto);
    }
}
