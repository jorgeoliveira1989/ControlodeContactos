using ControlodeContactos.Data;
using ControlodeContactos.Models;

namespace ControlodeContactos.Repositorio
{
    public class ContactoRepositorio : IContactoRepositorio
    {

        private readonly BDContext _bdContext;
        public ContactoRepositorio(BDContext bDContext, BDContext bdContext)
        {

            _bdContext = bdContext;

        }

        public List<ContactoModel> BuscarTodos()
        {
            return _bdContext.Contactos.ToList();
        }

        public ContactoModel Adicionar(ContactoModel contacto)
        {
            //gravar na base de dados
            _bdContext.Contactos.Add(contacto);
            _bdContext.SaveChanges();
            return contacto;
        }

    }
}
