using Microsoft.AspNetCore.Mvc;
using Prueba.interfaces;
using Prueba.models;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : Controller

    {
        private readonly IMuestra _muestra;

        public SampleController(IMuestra muestra)
        {
            _muestra = muestra;
        }

        // Traer todas las muestras
        [HttpGet]
        public async Task<IActionResult> GetListSamples()
        {
            try
            {
                Response Muestras = await _muestra.ListarTodasLasMuestras();

                return Ok(Muestras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// Traer una muestra
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSamples(int id)
        {
            try
            {
                Response Muestras = await _muestra.TraerMuestraPorId(id);

                return Ok(Muestras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/CrearEditar")]
        // Crar o editar muestra 
        public async Task<IActionResult> CreateEditSamples([FromBody] MuestrasModel muestra)
        {
            try
            {
                Response Muestras = await _muestra.CrearOEditarUnaMuestra(muestra);

                return Ok(Muestras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Cambiar estado 
        [HttpPut]
        [Route("/EstadoMuestra")]
        public async Task<IActionResult> EstadoSamples([FromBody] Status status)
        {
            try
            {
                Response Muestras = await _muestra.CambiarEstadoDeMuestra(status);

                return Ok(Muestras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Eliminar mestra
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSamples(int id)
        {
            try
            {
                Response Muestras = await _muestra.EliminarMuestra(id);

                return Ok(Muestras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Traer listado de tipos de muestra 
        [HttpGet]
        [Route("/ListarTipos")]
        public async Task<IActionResult> ListaTiposMuestra()
        {
            try
            {
                Response Muestras = await _muestra.ListaTiposDeMuestra();

                return Ok(Muestras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
