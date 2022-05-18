namespace Anuncios.Comandos
{
    public class AtualizarAnuncioComando : IComando
    {
        public int? Id { get; init; }
        public string? Marca { get; init; }
        public string? Modelo { get; init; }
        public string? Versao { get; init; }
        public int? Ano { get; init; }
        public int? Quilometragem { get; init; }
        public string? Observacao { get; init; }
        public bool Valido()
        {
            return (
                !string.IsNullOrEmpty(Marca) &&
                !string.IsNullOrEmpty(Modelo) &&
                !string.IsNullOrEmpty(Versao) &&
                !string.IsNullOrEmpty(Observacao) &&
                Id != null &&
                Ano != null &&
                Quilometragem != null
                );

        }
    }
}
