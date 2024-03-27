using ControlodeContactos.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ControlodeContactos.Data
{
    public class BDContext : DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options)
        {
        }
        public DbSet<ContactoModel> Contactos { get; set; }
    }
}
