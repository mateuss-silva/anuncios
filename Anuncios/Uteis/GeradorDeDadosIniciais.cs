using Anuncios.Dados;
using Anuncios.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Anuncios.Uteis
{
    public class GeradorDeDadosIniciais
    {
        public static void Gerar(IServiceProvider serviceProvider)
        {
            using var context = new ApiContexto(serviceProvider.GetRequiredService<DbContextOptions<ApiContexto>>());

            if (context.Anuncios.Any())
            {
                return;   // banco ja foi inicializado
            }
            context.Anuncios.AddRange(
                new Anuncio
                {
                    Id = 1,
                    Ano = 2018,
                    Marca = "Honda",
                    Modelo = "City",
                    Versao = "2.0 EXL 4X4 16V GASOLINA 4P AUTOMÁTICO",
                    Quilometragem = 0,
                    Observacao = "",
                },
                new Anuncio
                {
                    Id = 2,
                    Ano = 2018,
                    Marca = "Mitsubishi",
                    Modelo = "Lancer",
                    Versao = "2.0 EVO 4P AUTOMÁTICO",
                    Quilometragem = 47500,
                    Observacao = "",
                },
                new Anuncio
                {
                    Id = 3,
                    Ano = 2018,
                    Marca = "Honda",
                    Modelo = "Fit",
                    Versao = "1.4 LXL 16V FLEX 4P AUTOMÁTICO",
                    Quilometragem = 0,
                    Observacao = "",
                },
                new Anuncio
                {
                    Id = 4,
                    Ano = 2016,
                    Marca = "Mitsubishi",
                    Modelo = "Lancer",
                    Versao = "2.0 EVO 4P AUTOMÁTICO",
                    Quilometragem = 12900,
                    Observacao = "",
                },
                new Anuncio
                {
                    Id = 5,
                    Ano = 2014,
                    Marca = "Chevrolet",
                    Modelo = "Agile",
                    Versao = "1.4 MPFI EFFECT 8V FLEX 4P AUTOMATIZADO",
                    Quilometragem = 12000,
                    Observacao = "",
                },
                new Anuncio
                {
                    Id = 6,
                    Ano = 2018,
                    Marca = "Chevrolet",
                    Modelo = "Agile",
                    Versao = "1.4 MPFI EFFECT 8V FLEX 4P AUTOMATIZADO",
                    Quilometragem = 0,
                    Observacao = "",
                }
                );

            context.SaveChanges();
        }
    }
}
