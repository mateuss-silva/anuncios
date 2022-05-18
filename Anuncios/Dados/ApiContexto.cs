using Anuncios.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Anuncios.Dados
{
    public class ApiContexto
        : DbContext
    {

        public ApiContexto(DbContextOptions<ApiContexto> options) : base(options) { }
        public DbSet<Anuncio> Anuncios { get; set; }
    }
}
