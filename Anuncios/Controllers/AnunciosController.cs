using Anuncios.Comandos;
using Anuncios.Dados;
using Anuncios.Modelos;
using Anuncios.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Anuncios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnunciosController : Controller
    {
        private readonly IAnuncioRepositorio _anuncioRepositorio;

        public AnunciosController(IAnuncioRepositorio anuncioRepositorio)
        {
            _anuncioRepositorio = anuncioRepositorio;
        }

        [HttpGet]
        public IActionResult ObterAnuncios()
        {
            try
            {
                var anuncios = _anuncioRepositorio.ObterAnuncios();

                return Ok(anuncios);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterAnuncio(int id)
        {
            try
            {
                var anuncio = _anuncioRepositorio.ObterAnuncio(id);

                if (anuncio == null) return NotFound();

                return Ok(anuncio);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult InserirAnuncio(InserirAnuncioComando comando)
        {
            try
            {
                if (!comando.Valido()) return BadRequest();

                var anuncio = new Anuncio(comando);

                _anuncioRepositorio.InserirAnuncio(anuncio);

                return Created(nameof(ObterAnuncio), anuncio);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPut]
        public IActionResult AtualizarAnuncio(AtualizarAnuncioComando comando)
        {
            try
            {
                if (!comando.Valido()) return BadRequest();

                var anuncio = new Anuncio(comando);

                _anuncioRepositorio.AtualizarAnuncio(anuncio);

                return Ok(anuncio);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult RemoverAnuncio(int id)
        {
            try
            {

                bool sucesso = _anuncioRepositorio.RemoverAnuncio(id);

                if (!sucesso) return NotFound();

                return NoContent();

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}
