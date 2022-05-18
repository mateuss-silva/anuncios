using Anuncios.Dados;
using Anuncios.Modelos;

namespace Anuncios.Repositorios
{
    public class AnuncioRepositorio : IAnuncioRepositorio
    {
        private readonly ApiContexto _contexto;

        public AnuncioRepositorio(ApiContexto contexto)
        {
            _contexto = contexto;
        }

        public void AtualizarAnuncio(Anuncio anuncio)
        {
            _contexto.Anuncios.Update(anuncio);

            _contexto.SaveChanges();
        }

        public bool RemoverAnuncio(int id)
        {
            var anuncio = _contexto.Anuncios.Find(id);

            bool anuncioNaoExiste = anuncio == null;

            if (anuncioNaoExiste) return false;

            _contexto.Anuncios.Remove(anuncio!);

            _contexto.SaveChanges();

            return true;
        }

        public void InserirAnuncio(Anuncio anuncio)
        {
            anuncio.Id = UltimoId() + 1;

            _contexto.Anuncios.Add(anuncio);

            _contexto.SaveChanges();
        }

        public Anuncio? ObterAnuncio(int id)
        {
            return _contexto.Anuncios.Find(id);
        }

        public List<Anuncio> ObterAnuncios()
        {
            return _contexto.Anuncios.ToList();
        }

        private int UltimoId()
        {
            return _contexto.Anuncios.Select(x => x.Id).Max();
        }
    }
}
