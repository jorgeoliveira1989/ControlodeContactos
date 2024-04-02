using ControlodeContactos.Data;
using ControlodeContactos.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

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

        public ContactoModel ListarporID(int id)
        {
            return _bdContext.Contactos.FirstOrDefault(x => x.Id== id);
        }

        public ContactoModel Atualizar(ContactoModel contacto)
        {
            //atualizar na base de dados
            ContactoModel contactoDB = ListarporID(contacto.Id);

            if (contactoDB == null) throw new Exception("Houve erro na atualização");
            {

                contactoDB.Nome = contacto.Nome;
                contactoDB.Email = contacto.Email;
                contactoDB.Telefone = contacto.Telefone;

                _bdContext.Contactos.Update(contactoDB);
                _bdContext.SaveChanges();
                return contactoDB;
            }
        }

        public bool Apagar(int id)
        {
            //Apagar na base de dados
            ContactoModel contactoDB = ListarporID(id);

            if (contactoDB == null) throw new Exception("Houve erro ao apagar");
            {
                contactoDB.Id = id;
                _bdContext.Contactos.Remove(contactoDB);
                _bdContext.SaveChanges();

                return true;
                
            }
        }
    }
}
