using Microsoft.EntityFrameworkCore;
using WebMotorsProject.Repository.Entity;

namespace WebMotorsProject.Repository.Context
{
    public class ContextDB : DbContext
    {
        #region Contructors
        public ContextDB() { }

        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }
        #endregion

        public DbSet<Anuncio> Anuncios { get; set; }
    }
}
