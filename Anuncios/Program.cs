using Anuncios.Dados;
using Anuncios.Repositorios;
using Anuncios.Uteis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

ConfigureMvc(builder);

ConfigureServices(builder.Services);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

InitializeContext(app);

app.UseCors(option =>
{
    option.AllowAnyOrigin();
    option.AllowAnyMethod();
    option.AllowAnyHeader();

});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IAnuncioRepositorio, AnuncioRepositorio>();

    services.AddDbContext<ApiContexto>(options => options.UseInMemoryDatabase("AnuncioWebmotors"));
}

void ConfigureMvc(WebApplicationBuilder builder)
{

    builder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.InvalidModelStateResponseFactory = actionContext =>
        new BadRequestObjectResult(
            new
            {
                error = string.Join(
                    Environment.NewLine,
                    actionContext.ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage)).ToList()
                )
            }
        );

        options.SuppressModelStateInvalidFilter = true;
    });
}

void InitializeContext(WebApplication app)
{
    using var scope = app.Services.CreateScope();

    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApiContexto>();

    GeradorDeDadosIniciais.Gerar(services);
}
