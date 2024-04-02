using ControlodeContactos.Models;

namespace ControlodeContactos.Repositorio
{
    public interface IContactoRepositorio
    {

        ContactoModel ListarporID(int id);
        List<ContactoModel> BuscarTodos();
        ContactoModel Adicionar(ContactoModel contacto);
        ContactoModel Atualizar(ContactoModel contacto);
       bool Apagar(int id);
    }
}
