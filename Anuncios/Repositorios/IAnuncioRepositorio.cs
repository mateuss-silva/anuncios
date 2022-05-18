using Anuncios.Modelos;

namespace Anuncios.Repositorios
{
    public interface IAnuncioRepositorio
    {
        List<Anuncio> ObterAnuncios();

        void InserirAnuncio(Anuncio anuncio);
        void AtualizarAnuncio(Anuncio anuncio);

        Anuncio? ObterAnuncio(int id);

        bool RemoverAnuncio(int id);
    }
}
