using Anuncios.Comandos;

namespace Anuncios.Modelos
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Versao { get; set; }

        public int Ano { get; set; }

        public int Quilometragem { get; set; }

        public string Observacao { get; set; }

        public Anuncio() { }

        public Anuncio(string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
        {
            Marca = marca;
            Modelo = modelo;
            Versao = versao;
            Ano = ano;
            Quilometragem = quilometragem;
            Observacao = observacao;
        }

        public Anuncio(InserirAnuncioComando comando)
        {
            Marca = comando.Marca!;
            Modelo = comando.Modelo!;
            Versao = comando.Versao!;
            Ano = comando.Ano!.Value;
            Quilometragem = comando.Quilometragem!.Value;
            Observacao = comando.Observacao!;
        }
        public Anuncio(AtualizarAnuncioComando comando)
        {
            Id = comando.Id!.Value;
            Marca = comando.Marca!;
            Modelo = comando.Modelo!;
            Versao = comando.Versao!;
            Ano = comando.Ano!.Value;
            Quilometragem = comando.Quilometragem!.Value;
            Observacao = comando.Observacao!;
        }
    }
}
